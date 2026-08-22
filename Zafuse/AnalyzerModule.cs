using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Zafuse{
    internal class AnalyzerModule{
        public struct ContentCounts{
            public int Placeholders; // Count of placeholder tokens like {0}, %s
            public int Punctuation;  // Count of punctuation characters
            public int Quotes;       // Count of single or double quotes
            public int Numbers;      // Count of numeric sequences
            public string PlaceholderSignature;
            public string NumberSignature;
            // Override Equals to compare ContentCounts by value
            public override bool Equals(object obj) => obj is ContentCounts other &&
                Placeholders == other.Placeholders && Punctuation == other.Punctuation && Quotes == other.Quotes && Numbers == other.Numbers &&
                string.Equals(PlaceholderSignature, other.PlaceholderSignature, StringComparison.Ordinal) &&
                string.Equals(NumberSignature, other.NumberSignature, StringComparison.Ordinal);
            // Override GetHashCode to match Equals
            public override int GetHashCode(){
                unchecked{
                    int hash = 17;
                    hash = hash * 23 + Placeholders.GetHashCode();
                    hash = hash * 23 + Punctuation.GetHashCode();
                    hash = hash * 23 + Quotes.GetHashCode();
                    hash = hash * 23 + Numbers.GetHashCode();
                    hash = hash * 23 + (PlaceholderSignature ?? string.Empty).GetHashCode();
                    hash = hash * 23 + (NumberSignature ?? string.Empty).GetHashCode();
                    return hash;
                }
            }
        }
        public class IniEntry{
            public string Section { get; set; }
            public string Key { get; set; }
            public string Value { get; set; }
            public int Line { get; set; }
            public string FullKey => $"{Section}.{Key}";
        }
        public class TS_FileParser{
            public string Files { get; private set; } // File name without extension
            public Dictionary<string, string> KeySectionMap { get; private set; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            public Dictionary<string, string> KeyValueMap { get; private set; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            public Dictionary<string, int> KeyLineMap { get; private set; } = new Dictionary<string, int>();
            public Dictionary<int, string> Comments { get; private set; } = new Dictionary<int, string>();
            public HashSet<string> DuplicateKeys { get; private set; } = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            public List<IniEntry> Entries { get; private set; } = new List<IniEntry>();
            public int TotalLineCount { get; private set; }
            public TS_FileParser(string filePath){
                Files = Path.GetFileNameWithoutExtension(filePath);
                ParseFile(filePath);
            }
            private void ParseFile(string filePath){
                if (!File.Exists(filePath)) return;
                 string[] allLines = File.ReadAllLines(filePath, Encoding.UTF8);
                 TotalLineCount = allLines.Length;
                 string currentSection = "Main";
                 HashSet<string> fullKeysInFile = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                for (int i = 0; i < allLines.Length; i++){
                    string line = allLines[i].Trim();
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    // Track comment lines
                    if (line.StartsWith(";")){
                        Comments[i + 1] = line;
                        continue;
                    }
                    // Track section headers [Section]
                     if (line.StartsWith("[") && line.EndsWith("]")){
                         string section = line.Substring(1, line.Length - 2).Trim();
                         if (section.Length > 0) currentSection = section;
                         continue;
                    }
                    // Track key=value lines
                     if (line.Contains("=")){
                         int equalIdx = line.IndexOf('=');
                         string key = line.Substring(0, equalIdx).Trim();
                         string value = line.Substring(equalIdx + 1).Trim();
                         if (key.Length == 0) continue;
                         string fullKey = $"{currentSection}.{key}";
                         if (fullKeysInFile.Contains(fullKey)){
                             DuplicateKeys.Add(fullKey);
                         }else{
                             fullKeysInFile.Add(fullKey);
                             Entries.Add(new IniEntry{ Section = currentSection, Key = key, Value = value, Line = i + 1 });
                             KeySectionMap[fullKey] = currentSection;
                            KeyValueMap[fullKey] = value;
                            KeyLineMap[fullKey] = i + 1;
                        }
                    }
                }
            }
        }
        public class TS_Comparer{
            public List<TS_FileParser> Parsers { get; private set; } // List of loaded file parsers
            public Dictionary<string, HashSet<string>> KeyPresenceMap { get; private set; } // Key - Files that contain it
            public Dictionary<string, Dictionary<string, string>> SectionMismatchMap { get; private set; } // Key - File - Section
            public TS_Comparer(){
                Parsers = new List<TS_FileParser>();
                KeyPresenceMap = new Dictionary<string, HashSet<string>>(StringComparer.OrdinalIgnoreCase);
                SectionMismatchMap = new Dictionary<string, Dictionary<string, string>>(StringComparer.OrdinalIgnoreCase);
            }
            // Load all .ini files from folder and build comparison maps
            public void LoadFolder(string folderPath){
                Parsers.Clear(); KeyPresenceMap.Clear(); SectionMismatchMap.Clear();
                if (!Directory.Exists(folderPath)) return;
                foreach (string file in Directory.GetFiles(folderPath, "*.ini")){
                    TS_FileParser parser = new TS_FileParser(file);
                    Parsers.Add(parser);
                    foreach (var group in parser.Entries.GroupBy(e => e.Key, StringComparer.OrdinalIgnoreCase)){
                        string key = group.Key;
                        if (!KeyPresenceMap.ContainsKey(key)) KeyPresenceMap[key] = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                        KeyPresenceMap[key].Add(parser.Files);
                        if (!SectionMismatchMap.ContainsKey(key)) SectionMismatchMap[key] = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                        string sections = string.Join(" | ", group.Select(e => e.Section).Distinct(StringComparer.OrdinalIgnoreCase));
                        SectionMismatchMap[key][parser.Files] = sections;
                    }
                }
            }
            // Compare placeholders, punctuation, quotes, and numbers across all files
            // Returns only keys with mismatches
            public Dictionary<string, Dictionary<string, ContentCounts>> GetPlaceholderMismatches(bool chkPlc, bool chkPnc, bool chkQt, bool chkNum){
                if (!chkPlc && !chkPnc && !chkQt && !chkNum)
                    return new Dictionary<string, Dictionary<string, ContentCounts>>();
                var result = new Dictionary<string, Dictionary<string, ContentCounts>>();
                var allKeys = Parsers.SelectMany(p => p.Entries.Select(e => e.Key)).Distinct(StringComparer.OrdinalIgnoreCase);
                foreach (string key in allKeys){
                    var counts = new Dictionary<string, ContentCounts>();
                    foreach (var parser in Parsers){
                         IniEntry entry = parser.Entries.FirstOrDefault(e => string.Equals(e.Key, key, StringComparison.OrdinalIgnoreCase));
                         if (entry != null){
                             counts[parser.Files] = GetContentCounts(entry.Value, chkPlc, chkPnc, chkQt, chkNum);
                        }
                    }
                    if (counts.Values.Distinct().Count() > 1){
                        result[key] = counts;
                    }
                }
                return result;
            }
            // Regex for detecting placeholders {0}, {name}, etc.
            private static readonly Regex PlaceholderCurly = new Regex(@"\{[^{}]+\}", RegexOptions.Compiled);
            // Regex for detecting printf-style placeholders %s, %d, %1$d, etc.
            private static readonly Regex PlaceholderPercent = new Regex(@"%(\d+\$)?[-+0#]*\d*(\.\d+)?(?:hh|h|ll|l|L|z|j|t)?[diouxXeEfFgGaAcspn]|%%", RegexOptions.Compiled);
            // Regex for detecting escaped quotes
            
            // Count placeholders, punctuation, quotes, and numbers in a string
            // Placeholders are removed before counting numbers and punctuation
            private ContentCounts GetContentCounts(string value, bool chkPlc, bool chkPnc, bool chkQt, bool chkNum){
                ContentCounts c = new ContentCounts();
                string temp = value;
                var cM = PlaceholderCurly.Matches(value);   // curly placeholders
                var pM = PlaceholderPercent.Matches(value); // percent placeholders
                if (chkPlc){
                     c.Placeholders = cM.Count + pM.Count;
                    // Translators may reorder arguments (for example {1} before {0}); compare the token set, not display order.
                    c.PlaceholderSignature = string.Join("|", cM.Cast<Match>().Concat(pM.Cast<Match>()).Select(m => m.Value).OrderBy(x => x, StringComparer.Ordinal));
                }
                // Remove placeholders to avoid double-counting numbers inside them
                foreach (Match m in cM) temp = temp.Replace(m.Value, " ");
                foreach (Match m in pM) temp = temp.Replace(m.Value, " ");
                if (chkPnc){
                    c.Punctuation = GetProtectedPunctuation(value, cM.Cast<Match>().Concat(pM.Cast<Match>())).Length;
                }
                if (chkQt){
                    // Use the raw value so an apostrophe directly before a placeholder (French "d'{2}") keeps its context
                    c.Quotes = CountUnbalancedQuotes(value);
                }
                if (chkNum){
                    MatchCollection numberMatches = Regex.Matches(temp, @"\b\d+(?:\.\d+)?\b");
                    c.NumberSignature = string.Join("|", numberMatches.Cast<Match>().Select(m => m.Value));
                    c.Numbers = numberMatches.Count;
                }
                return c;
            }
            private static int CountUnbalancedQuotes(string value){
                int quoteCount = 0;
                for (int i = 0; i < value.Length; i++){
                    char current = value[i];
                    if (current == '\'' || current == '\u2018' || current == '\u2019'){
                        // Latin contractions and elisions: l'emplacement, n'ont, d'{2}, user's
                        char prevChar = i > 0 ? value[i - 1] : '\0';
                        char nextChar = i + 1 < value.Length ? value[i + 1] : '\0';
                        bool apostrophe = IsLatinLetter(prevChar) && (IsLatinLetter(nextChar) || nextChar == '{' || nextChar == '%');
                        if (apostrophe) continue;
                    }
                    if (IsQuoteCharacter(current)) quoteCount++;
                }
                return quoteCount % 2;
            }
            private static bool IsLatinLetter(char value){
                return (value >= 'A' && value <= 'Z') ||
                    (value >= 'a' && value <= 'z') ||
                    (value >= '\u00C0' && value <= '\u024F');
            }
            private static bool IsQuoteCharacter(char current){
                return "\"\'\u00AB\u00BB\u2018\u2019\u201C\u201D\u201E\u201F\u3008\u3009\u300A\u300B\u300C\u300D\u300E\u300F\u301D\u301E\u301F".Contains(current);
            }
            private static string GetProtectedPunctuation(string value, IEnumerable<Match> placeholderMatches){
                HashSet<int> punctuationIndexes = new HashSet<int>();
                foreach (Match match in placeholderMatches){
                    int before = match.Index - 1;
                    while (before >= 0 && char.IsWhiteSpace(value[before])) before--;
                    if (before >= 0 && IsStructuralPunctuation(value[before])) punctuationIndexes.Add(before);
                    int after = match.Index + match.Length;
                    while (after < value.Length && char.IsWhiteSpace(value[after])) after++;
                    if (after < value.Length && IsStructuralPunctuation(value[after])) punctuationIndexes.Add(after);
                }
                return new string(punctuationIndexes.OrderBy(i => i).Select(i => value[i]).ToArray());
            }
            private static bool IsStructuralPunctuation(char value){
                if ("{}()\u002D\u2010\u2011\u2012\u2013\u2014\u2212".Contains(value)) return false;
                if ("'\"\u00AB\u00BB\u2018\u2019\u201C\u201D\u201E\u201F\u3008\u3009\u300A\u300B\u300C\u300D\u300E\u300F\u3010\u3011".Contains(value)) return false;
                if (".,!?:;\u060C\u00A1\u00BF\u3001\u3002\uFF01\uFF0C\uFF1F\uFF1A\u0964\u0965\u061F\u061B".Contains(value)) return false;
                UnicodeCategory category = CharUnicodeInfo.GetUnicodeCategory(value);
                return category == UnicodeCategory.ConnectorPunctuation ||
                    category == UnicodeCategory.DashPunctuation ||
                    category == UnicodeCategory.OpenPunctuation ||
                    category == UnicodeCategory.ClosePunctuation ||
                    category == UnicodeCategory.InitialQuotePunctuation ||
                    category == UnicodeCategory.FinalQuotePunctuation ||
                    category == UnicodeCategory.OtherPunctuation;
            }
            // Compare total line counts across files
            public Dictionary<string, int> GetLineCountDifferences(){
                if (Parsers.Count == 0) return new Dictionary<string, int>();
                int referenceCount = Parsers.First().TotalLineCount;
                return Parsers.Where(p => p.TotalLineCount != referenceCount).ToDictionary(p => p.Files, p => p.TotalLineCount);
            }
            // Compare comments across files for differences
            // Numbers in comments are ignored during comparison
            public Dictionary<int, Dictionary<string, string>> GetCommentDifferences(){
                var result = new Dictionary<int, Dictionary<string, string>>();
                var allLines = Parsers.SelectMany(p => p.Comments.Keys).Distinct().OrderBy(x => x);
                foreach (var line in allLines){
                    var lineComments = new Dictionary<string, string>();
                    foreach (var parser in Parsers){
                        if (parser.Comments.TryGetValue(line, out var comment)){
                            lineComments[parser.Files] = comment;
                        }
                    }
                    if (lineComments.Count != Parsers.Count)
                    {
                        result[line] = lineComments;
                        continue;
                    }
                    if (lineComments.Count >= 2)
                    {
                        var normalizedComments = lineComments.ToDictionary(kvp => kvp.Key, kvp => NormalizeComment(kvp.Value));
                        if (normalizedComments.Values.Distinct().Count() > 1){
                            result[line] = lineComments;
                        }
                    }
                }
                return result;
            }
            private static string NormalizeComment(string comment){
                string normalized = Regex.Replace(Regex.Replace(comment, @"\d+", ""), @"\s+", " ").Trim().TrimStart(';').Trim();
                if (normalized.IndexOf("Lang File", StringComparison.OrdinalIgnoreCase) >= 0)
                    return "Lang File";
                return normalized;
            }
            // Return line numbers of all keys in each file
            public Dictionary<string, Dictionary<string, int>> GetKeyLineNumbers(){
                var result = new Dictionary<string, Dictionary<string, int>>(StringComparer.OrdinalIgnoreCase);
                foreach (var parser in Parsers){
                    foreach (var entry in parser.Entries){
                        if (!result.ContainsKey(entry.Key)) result[entry.Key] = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
                        if (!result[entry.Key].ContainsKey(parser.Files)) result[entry.Key][parser.Files] = entry.Line;
                    }
                }
                return result;
            }
            // Get keys missing in one or more files
            public Dictionary<string, List<string>> GetMissingKeys(){
                var result = new Dictionary<string, List<string>>();
                var allLangs = Parsers.Select(p => p.Files).ToList();
                foreach (var kvp in KeyPresenceMap){
                    var missing = allLangs.Except(kvp.Value).ToList();
                    if (missing.Count > 0) result[kvp.Key] = missing;
                }
                return result;
            }
            // Get duplicate keys per file
            public Dictionary<string, List<string>> GetDuplicateKeys(){
                return Parsers.Where(p => p.DuplicateKeys.Count > 0).ToDictionary(p => p.Files, p => p.DuplicateKeys.ToList());
            }
            // Get section mismatches for keys across files
            public Dictionary<string, Dictionary<string, string>> GetSectionMismatches(){
                var result = new Dictionary<string, Dictionary<string, string>>();
                foreach (var kvp in SectionMismatchMap){
                    if (kvp.Value.Values.Any(v => v.Contains("|")) ||
                        (kvp.Value.Count > 1 && kvp.Value.Values.Distinct(StringComparer.OrdinalIgnoreCase).Count() > 1))
                        result[kvp.Key] = kvp.Value;
                }
                return result;
            }
        }
    }
}