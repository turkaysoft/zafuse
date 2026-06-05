// ======================================================================================================
// Zafuse - Multi INI File Content Analysis Software
// © Copyright 2025-2026, Eray Türkay.
// Publisher: Türkaysoft
// Project Type: Open Source
// License: MIT License
// Website: https://turkaysoft.com
// GitHub: https://github.com/turkaysoft/zafuse
// ======================================================================================================

using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
// TS Modules
using static Zafuse.AnalyzerModule;
using static Zafuse.TSModules;

namespace Zafuse{
    public partial class ZafuseMain : Form{
        public ZafuseMain(){
            InitializeComponent();
            //
            caPlaceholders.Click += async (s, e) => { caPlaceholders.Checked = !caPlaceholders.Checked; await RenderResults(); Analysis_mode_settings(); };
            caPunctuationMarks.Click += async (s, e) => { caPunctuationMarks.Checked = !caPunctuationMarks.Checked; await RenderResults(); Analysis_mode_settings(); };
            caNailSigns.Click += async (s, e) => { caNailSigns.Checked = !caNailSigns.Checked; await RenderResults(); Analysis_mode_settings(); };
            caNumbers.Click += async (s, e) => { caNumbers.Checked = !caNumbers.Checked; await RenderResults(); Analysis_mode_settings(); };
            caCommentLines.Click += async (s, e) => { caCommentLines.Checked = !caCommentLines.Checked; await RenderResults(); Analysis_mode_settings(); };
            // LANGUAGE SET TAGS
            // ==================
            arabicToolStripMenuItem.Tag = "ar";
            chineseToolStripMenuItem.Tag = "zh";
            englishToolStripMenuItem.Tag = "en";
            dutchToolStripMenuItem.Tag = "nl";
            frenchToolStripMenuItem.Tag = "fr";
            germanToolStripMenuItem.Tag = "de";
            hindiToolStripMenuItem.Tag = "hi";
            italianToolStripMenuItem.Tag = "it";
            japaneseToolStripMenuItem.Tag = "ja";
            koreanToolStripMenuItem.Tag = "ko";
            polishToolStripMenuItem.Tag = "pl";
            portugueseToolStripMenuItem.Tag = "pt";
            russianToolStripMenuItem.Tag = "ru";
            spanishToolStripMenuItem.Tag = "es";
            turkishToolStripMenuItem.Tag = "tr";
            // LANGUAGE SET EVENTS
            // ==================
            arabicToolStripMenuItem.Click += LanguageToolStripMenuItem_Click;
            chineseToolStripMenuItem.Click += LanguageToolStripMenuItem_Click;
            englishToolStripMenuItem.Click += LanguageToolStripMenuItem_Click;
            dutchToolStripMenuItem.Click += LanguageToolStripMenuItem_Click;
            frenchToolStripMenuItem.Click += LanguageToolStripMenuItem_Click;
            germanToolStripMenuItem.Click += LanguageToolStripMenuItem_Click;
            hindiToolStripMenuItem.Click += LanguageToolStripMenuItem_Click;
            italianToolStripMenuItem.Click += LanguageToolStripMenuItem_Click;
            japaneseToolStripMenuItem.Click += LanguageToolStripMenuItem_Click;
            koreanToolStripMenuItem.Click += LanguageToolStripMenuItem_Click;
            polishToolStripMenuItem.Click += LanguageToolStripMenuItem_Click;
            portugueseToolStripMenuItem.Click += LanguageToolStripMenuItem_Click;
            russianToolStripMenuItem.Click += LanguageToolStripMenuItem_Click;
            spanishToolStripMenuItem.Click += LanguageToolStripMenuItem_Click;
            turkishToolStripMenuItem.Click += LanguageToolStripMenuItem_Click;
            //
            SystemEvents.UserPreferenceChanged += (s, e) => TSUseSystemTheme();
        }
        // GLOBAL VARIABLES
        // ======================================================================================================
        public static string lang, lang_path;
        public static int theme, themeSystem;
        // VARIABLES
        // ======================================================================================================
        private int startup_status;
        // MAIN PROCCESS FIELDS
        // ======================================================================================================
        private readonly TS_Comparer TSComparer = new TS_Comparer();
        private readonly Dictionary<string, string> LangPaths = new Dictionary<string, string>();
        private readonly Dictionary<string, string> ManuelLangPaths = new Dictionary<string, string>();
        private readonly SemaphoreSlim _renderSemaphore = new SemaphoreSlim(1, 1);
        private bool _suppressSelectionChanged = false;
        private bool _isFirstKeyNavigation = true;
        private bool _isSelectionProcessing = false;
        private string selectedProccessPath = null;
        // ======================================================================================================
        // UI COLORS
        private static readonly List<Color> header_colors = new List<Color>() { Color.Transparent, Color.Transparent, Color.Transparent };
        // HEADER SETTINGS
        // ======================================================================================================
        private class HeaderMenuColors : ToolStripProfessionalRenderer{
            public HeaderMenuColors() : base(new HeaderColors()) { }
            protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e) { e.ArrowColor = header_colors[1]; base.OnRenderArrow(e); }
            protected override void OnRenderItemCheck(ToolStripItemImageRenderEventArgs e){
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                float dpiScale = g.DpiX / 96f;
                Rectangle rect = e.ImageRectangle;
                using (Pen anti_alias_pen = new Pen(header_colors[2], 2.2f * dpiScale)){
                    anti_alias_pen.StartCap = LineCap.Round;
                    anti_alias_pen.EndCap = LineCap.Round;
                    anti_alias_pen.LineJoin = LineJoin.Round;
                    PointF p1 = new PointF(rect.Left + rect.Width * 0.18f, rect.Top + rect.Height * 0.52f);
                    PointF p2 = new PointF(rect.Left + rect.Width * 0.38f, rect.Top + rect.Height * 0.72f);
                    PointF p3 = new PointF(rect.Left + rect.Width * 0.78f, rect.Top + rect.Height * 0.28f);
                    g.DrawLines(anti_alias_pen, new[] { p1, p2, p3 });
                }
            }
        }
        private class HeaderColors : ProfessionalColorTable{
            public override Color MenuItemSelected => header_colors[0];
            public override Color ToolStripDropDownBackground => header_colors[0];
            public override Color ImageMarginGradientBegin => header_colors[0];
            public override Color ImageMarginGradientEnd => header_colors[0];
            public override Color ImageMarginGradientMiddle => header_colors[0];
            public override Color MenuItemSelectedGradientBegin => header_colors[0];
            public override Color MenuItemSelectedGradientEnd => header_colors[0];
            public override Color MenuItemPressedGradientBegin => header_colors[0];
            public override Color MenuItemPressedGradientMiddle => header_colors[0];
            public override Color MenuItemPressedGradientEnd => header_colors[0];
            public override Color MenuItemBorder => header_colors[0];
            public override Color CheckBackground => header_colors[0];
            public override Color ButtonSelectedBorder => header_colors[0];
            public override Color CheckSelectedBackground => header_colors[0];
            public override Color CheckPressedBackground => header_colors[0];
            public override Color MenuBorder => header_colors[0];
            public override Color SeparatorLight => header_colors[1];
            public override Color SeparatorDark => header_colors[1];
        }
        // LOAD SOFTWARE SETTINGS
        // ======================================================================================================
        private void RunSoftwareEngine(){
            HeaderMenu.Cursor = Cursors.Hand;
            //
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, SelDGV, new object[] { true });
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, MainDGV, new object[] { true });
            //
            // THEME - LANG - STARTUP - HIDIN MODE PRELOADER
            // ======================================================================================================
            TSSettingsModule software_read_settings = new TSSettingsModule(ts_sf);
            //
            int theme_mode = int.TryParse(software_read_settings.TSReadSettings(ts_settings_container, "ThemeStatus"), out int the_status) && (the_status == 0 || the_status == 1 || the_status == 2) ? the_status : 1;
            if (theme_mode == 2) { themeSystem = 2; Theme_engine(TSThemeModeHelper.GetSystemTheme(2)); } else Theme_engine(theme_mode);
            darkThemeToolStripMenuItem.Checked = theme_mode == 0;
            lightThemeToolStripMenuItem.Checked = theme_mode == 1;
            systemThemeToolStripMenuItem.Checked = theme_mode == 2;
            //
            string lang_mode = software_read_settings.TSReadSettings(ts_settings_container, "LanguageStatus");
            var languageFiles = new Dictionary<string, (object langResource, ToolStripMenuItem menuItem, bool fileExists)>{
                { "ar", (ts_lang_ar, arabicToolStripMenuItem, File.Exists(ts_lang_ar)) },
                { "zh", (ts_lang_zh, chineseToolStripMenuItem, File.Exists(ts_lang_zh)) },
                { "en", (ts_lang_en, englishToolStripMenuItem, File.Exists(ts_lang_en)) },
                { "nl", (ts_lang_nl, dutchToolStripMenuItem, File.Exists(ts_lang_nl)) },
                { "fr", (ts_lang_fr, frenchToolStripMenuItem, File.Exists(ts_lang_fr)) },
                { "de", (ts_lang_de, germanToolStripMenuItem, File.Exists(ts_lang_de)) },
                { "hi", (ts_lang_hi, hindiToolStripMenuItem, File.Exists(ts_lang_hi)) },
                { "it", (ts_lang_it, italianToolStripMenuItem, File.Exists(ts_lang_it)) },
                { "ja", (ts_lang_ja, japaneseToolStripMenuItem, File.Exists(ts_lang_ja)) },
                { "ko", (ts_lang_ko, koreanToolStripMenuItem, File.Exists(ts_lang_ko)) },
                { "pl", (ts_lang_pl, polishToolStripMenuItem, File.Exists(ts_lang_pl)) },
                { "pt", (ts_lang_pt, portugueseToolStripMenuItem, File.Exists(ts_lang_pt)) },
                { "ru", (ts_lang_ru, russianToolStripMenuItem, File.Exists(ts_lang_ru)) },
                { "es", (ts_lang_es, spanishToolStripMenuItem, File.Exists(ts_lang_es)) },
                { "tr", (ts_lang_tr, turkishToolStripMenuItem, File.Exists(ts_lang_tr)) },
            };
            foreach (var langLoader in languageFiles) { langLoader.Value.menuItem.Enabled = langLoader.Value.fileExists; }
            var (langResource, selectedMenuItem, _) = languageFiles.ContainsKey(lang_mode) ? languageFiles[lang_mode] : languageFiles["en"];
            Lang_engine(Convert.ToString(langResource), lang_mode);
            selectedMenuItem.Checked = true;
            //
            string startup_mode = software_read_settings.TSReadSettings(ts_settings_container, "StartupStatus");
            startup_status = int.TryParse(startup_mode, out int str_status) && (str_status == 0 || str_status == 1) ? str_status : 0;
            WindowState = startup_status == 1 ? FormWindowState.Maximized : FormWindowState.Normal;
            windowedToolStripMenuItem.Checked = startup_status == 0;
            fullScreenToolStripMenuItem.Checked = startup_status == 1;
            //
            string analysis_status = software_read_settings.TSReadSettings(ts_settings_container, "AnalysisStatus");
            var selectedItems = analysis_status?.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries) ?? new string[0];
            caPlaceholders.Checked = selectedItems.Contains("Placeholders");
            caPunctuationMarks.Checked = selectedItems.Contains("Punctuation");
            caNailSigns.Checked = selectedItems.Contains("NailSigns");
            caNumbers.Checked = selectedItems.Contains("Numbers");
            caCommentLines.Checked = selectedItems.Contains("CommentLines");
        }
        // TOOLTIP SETTINGS
        // ======================================================================================================
        private void MainToolTip_Draw(object sender, DrawToolTipEventArgs e){ e.DrawBackground(); e.DrawBorder(); e.DrawText(); }
        // LOAD
        // ====================================================================================================== 
        private async void ZafuseMain_Load(object sender, EventArgs e){ 
            Text = TS_VersionEngine.TS_SoftwareVersion(0);
            // LAUNCH PROCESS 
            // ====================================
            RunSoftwareEngine();
            // SETUP
            // ====================================
            SetupDGV();
            // LOAD DATA
            // ====================================
            await RenderResults();
            // SOFTWARE UPDATE CHECK
            // ====================================
            await Task.Run(() => Software_update_check(0));
        }
        // SETUP SEL DGV
        // ====================================================================================================== 
        private void SetupDGV(){
            TSGetLangs software_lang = new TSGetLangs(lang_path);
            //
            int ScaleDPI(int size){
                return (int)(size * this.DeviceDpi / 96f);
            }
            //
            SelDGV.Columns.Clear();
            SelDGV.Columns.Add("Name", software_lang.TSReadLangs("ZafuseMain", "zm_s_name"));
            SelDGV.Columns.Add("Path", software_lang.TSReadLangs("ZafuseMain", "zm_s_path"));
            SelDGV.Columns.Add("IniCount", software_lang.TSReadLangs("ZafuseMain", "zm_s_count"));
            SelDGV.Columns.Add("TotalSize", software_lang.TSReadLangs("ZafuseMain", "zm_s_size"));
            SelDGV.Columns[0].Width = ScaleDPI(85);
            SelDGV.Columns[2].Width = ScaleDPI(75);
            SelDGV.Columns[3].Width = ScaleDPI(120);
            foreach (DataGridViewColumn SelDGV_Column in SelDGV.Columns) SelDGV_Column.SortMode = DataGridViewColumnSortMode.NotSortable;
            PreloadLangFilePaths();
            //
            MainDGV.Columns.Clear();
            MainDGV.Columns.Add("Line", software_lang.TSReadLangs("ZafuseMain", "zm_h_row"));
            MainDGV.Columns.Add("Type", software_lang.TSReadLangs("ZafuseMain", "zm_h_error_type"));
            MainDGV.Columns.Add("Key", software_lang.TSReadLangs("ZafuseMain", "zm_h_key_section"));
            MainDGV.Columns.Add("Details", software_lang.TSReadLangs("ZafuseMain", "zm_h_detailed_analysis"));
            MainDGV.Columns[0].Width = ScaleDPI(65);
            MainDGV.Columns[1].Width = ScaleDPI(150);
            MainDGV.Columns[2].Width = ScaleDPI(200);
            MainDGV.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            foreach (DataGridViewColumn MainDGV_Column in MainDGV.Columns) MainDGV_Column.SortMode = DataGridViewColumnSortMode.NotSortable;
            //
            foreach (var tableMod in new[] { SelDGV, MainDGV }){
                foreach (DataGridViewColumn columnPadding in tableMod.Columns){
                    columnPadding.DefaultCellStyle.Padding = new Padding(ScaleDPI(3));
                }
            }
        }
        // HELPERS
        // ======================================================================================================
        public class LangFolderItem{
            public string Name { get; set; }
            public string Path { get; set; }
            public int IniCount { get; set; }
            public double TotalSizeBytes { get; set; }
        }
        private void GetIniStats(string folderPath, out int iniCount, out double totalBytes){
            var iniFiles = Directory.EnumerateFiles(folderPath, "*.ini", SearchOption.TopDirectoryOnly);
            double size = 0;
            int count = 0;
            foreach (var file in iniFiles){
                FileInfo fi = new FileInfo(file);
                size += fi.Length;
                count++;
            }
            iniCount = count;
            totalBytes = size;
        }
        // PRELOAD
        // ======================================================================================================
        private void PreloadLangFilePaths(){
            _suppressSelectionChanged = true;
            SelDGV.Rows.Clear();
            LangPaths.Clear();
            Dictionary<string, string> defaultPaths = new Dictionary<string, string>{
                { "Astel", @"E:\TSApps\Astel\bin\x64\Release\a_langs" },
                { "Encryphix", @"E:\TSApps\Encryphix\bin\x64\Release\e_langs" },
                { "Glow", @"E:\TSApps\Glow\bin\x64\Release\g_langs" },
                { "VCardix", @"E:\TSApps\VCardix\bin\x64\Release\vc_langs" },
                { "Vimera", @"E:\TSApps\Vimera\bin\x64\Release\v_langs" },
                { "Yamira", @"E:\TSApps\Yamira\bin\x64\Release\y_langs" },
                { "Zafuse", @"E:\TSApps\Zafuse\bin\x64\Release\z_langs" }
            };
            if (!Program.debug_mode){
                defaultPaths.Clear();
            }
            LoadManuelPaths();
            foreach (var m in ManuelLangPaths){
                if (!defaultPaths.ContainsKey(m.Key)){
                    defaultPaths.Add(m.Key, m.Value);
                }
            }
            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            foreach (var kvp in defaultPaths){
                if (!Directory.Exists(kvp.Value)) continue;
                GetIniStats(kvp.Value, out int iniCount, out double totalBytes);
                if (iniCount < 2) continue;
                LangPaths[kvp.Key] = kvp.Value;
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(SelDGV, kvp.Key, kvp.Value, iniCount, TS_FormatSize(totalBytes));
                rows.Add(row);
            }
            SelDGV.Rows.AddRange(rows.ToArray());
            SelDGV.ClearSelection();
            _suppressSelectionChanged = false;
        }
        // SELECT FOLDER & DRAG AND DROP
        // ======================================================================================================
        private async void BtnAddFolder_Click(object sender, EventArgs e){
            TSGetLangs lang = new TSGetLangs(lang_path);
            using (FolderBrowserDialog dialog = new FolderBrowserDialog{
                SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                ShowNewFolderButton = false,
                Description = lang.TSReadLangs("ZafuseMain", "zm_b_add_msg")
            }){
                if (dialog.ShowDialog() != DialogResult.OK){
                    return;
                }
                await TryAddLangFolder(dialog.SelectedPath);
            }
        }
        private void ZafuseMain_DragEnter(object sender, DragEventArgs e){
            if (!e.Data.GetDataPresent(DataFormats.FileDrop)){
                e.Effect = DragDropEffects.None;
                return;
            }
            string[] items = (string[])e.Data.GetData(DataFormats.FileDrop);
            //
            if (items.Length != 1 || !Directory.Exists(items[0])){
                e.Effect = DragDropEffects.None;
                return;
            }
            e.Effect = DragDropEffects.Copy;
        }
        private async void ZafuseMain_DragDrop(object sender, DragEventArgs e){
            TSGetLangs lang = new TSGetLangs(lang_path);
            if (!e.Data.GetDataPresent(DataFormats.FileDrop)){
                return;
            }
            string[] items = (string[])e.Data.GetData(DataFormats.FileDrop);
            //
            if (items.Length != 1){
                TS_MessageBoxEngine.TS_MessageBox(this, 2, lang.TSReadLangs("ZafuseMain", "zm_drag_only_one_folder"));
                return;
            }
            string path = items[0];
            if (!Directory.Exists(path)){
                TS_MessageBoxEngine.TS_MessageBox(this, 2, lang.TSReadLangs("ZafuseMain", "zm_drag_not_folder"));
                return;
            }
            await TryAddLangFolder(path);
        }
        private async Task<bool> TryAddLangFolder(string folderPath){
            TSGetLangs lang = new TSGetLangs(lang_path);
            //
            if (!Directory.Exists(folderPath)){
                TS_MessageBoxEngine.TS_MessageBox(this, 2, lang.TSReadLangs("ZafuseMain", "zm_drag_not_folder"));
                return false;
            }
            //
            if (LangPaths.Values.Any(v => string.Equals(v, folderPath, StringComparison.OrdinalIgnoreCase))){
                TS_MessageBoxEngine.TS_MessageBox(this, 2, lang.TSReadLangs("ZafuseMain", "zm_b_add_available_msg"));
                return false;
            }
            //
            GetIniStats(folderPath, out int iniCount, out double totalBytes);
            if (iniCount < 2){
                TS_MessageBoxEngine.TS_MessageBox(this, 2, lang.TSReadLangs("ZafuseMain", "zm_drag_ini_not_found"));
                return false;
            }
            //
            string baseName = Path.GetFileName(folderPath);
            string folderName = baseName;
            int suffix = 1;
            while (LangPaths.ContainsKey(folderName)){
                folderName = $"{baseName} ({suffix++})";
            }
            //
            LangFolderItem item = new LangFolderItem{
                Name = folderName,
                Path = folderPath,
                IniCount = iniCount,
                TotalSizeBytes = totalBytes
            };
            LangPaths.Add(folderName, folderPath);
            int rowIndex = SelDGV.Rows.Add(item.Name, item.Path, item.IniCount, TS_FormatSize(item.TotalSizeBytes));
            SelDGV.ClearSelection();
            SelDGV.Rows[rowIndex].Selected = true;
                        SaveManuelPath(folderName, folderPath);
            TSComparer.LoadFolder(folderPath);
            await RenderResults();
            return true;
        }
        // SEL DGV SELECTION
        // ======================================================================================================
        private async void SelDGV_CellClick(object sender, DataGridViewCellEventArgs e){
            if (_suppressSelectionChanged) return;
            if (SelDGV.SelectedRows.Count == 0) return;
            string selectedPath = SelDGV.SelectedRows[0].Cells["Path"].Value?.ToString();
            if (string.IsNullOrEmpty(selectedPath)) return;
            TSComparer.LoadFolder(selectedPath);
            await RenderResults();
        }
        // FORM-LEVEL KEY DOWN
        // ======================================================================================================
        private void ZafuseMain_KeyDown(object sender, KeyEventArgs e){
            if (_isSelectionProcessing){
                e.Handled = true;
                return;
            }
            if ((e.KeyCode == Keys.Up || e.KeyCode == Keys.Down) && !SelDGV.Focused){
                if (this.ActiveControl is TextBox){
                    return;
                }
                e.Handled = true;
                e.SuppressKeyPress = true;
                SelDGV.Focus();
                SelDGV_KeyDown(SelDGV, e);
            }
        }
        // SEL DGV KEYBOARD NAVIGATION
        // ======================================================================================================
        private async void SelDGV_KeyDown(object sender, KeyEventArgs e){
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down){
                e.Handled = true;
                if (_isSelectionProcessing) return;
                int rowCount = SelDGV.Rows.Count;
                if (rowCount == 0) return;
                try{
                    _isSelectionProcessing = true;
                    if (_isFirstKeyNavigation || SelDGV.CurrentCell == null){
                        _isFirstKeyNavigation = false;
                        SelDGV.ClearSelection();
                        SelDGV.Rows[0].Selected = true;
                        SelDGV.CurrentCell = SelDGV.Rows[0].Cells[0];
                        SelDGV.FirstDisplayedScrollingRowIndex = 0;
                        await PerformSelDGVSelection(0);
                        return;
                    }
                    int currentIndex = SelDGV.CurrentCell.RowIndex;
                    int newIndex;
                    if (e.KeyCode == Keys.Down){
                        newIndex = (currentIndex + 1) % rowCount;
                    }else{
                        newIndex = (currentIndex - 1 + rowCount) % rowCount;
                    }
                    SelDGV.ClearSelection();
                    SelDGV.Rows[newIndex].Selected = true;
                    SelDGV.CurrentCell = SelDGV.Rows[newIndex].Cells[0];
                    SelDGV.FirstDisplayedScrollingRowIndex = newIndex;
                    await PerformSelDGVSelection(newIndex);
                }finally{
                    _isSelectionProcessing = false;
                }
            }
        }
        // SEL DGV SELECTION HELPER
        // ======================================================================================================
        private async Task PerformSelDGVSelection(int rowIndex){
            if (rowIndex < 0 || rowIndex >= SelDGV.RowCount) return;
            string selectedPath = SelDGV.Rows[rowIndex].Cells["Path"].Value?.ToString();
            if (string.IsNullOrEmpty(selectedPath)) return;
            TSComparer.LoadFolder(selectedPath);
            await RenderResults();
        }
        // REMOVE FOLDER
        // ======================================================================================================
        private async void BtnRemoveFolder_Click(object sender, EventArgs e){
            TSGetLangs langObj = new TSGetLangs(lang_path);
            if (SelDGV.SelectedRows.Count == 0){
                TS_MessageBoxEngine.TS_MessageBox(this, 2, langObj.TSReadLangs("ZafuseMain", "zm_b_remove_select_msg"));
                return;
            }
            DataGridViewRow row = SelDGV.SelectedRows[0];
            string folderName = row.Cells["Name"].Value.ToString();
            string[] defaultApps = { "Astel", "Encryphix", "Glow", "VCardix", "Vimera", "Yamira", "Zafuse" };
            if (Program.debug_mode && defaultApps.Contains(folderName)){
                TS_MessageBoxEngine.TS_MessageBox(this, 2, langObj.TSReadLangs("ZafuseMain", "zm_b_remove_default_msg"));
                return;
            }
            DialogResult accept_warnings = TS_MessageBoxEngine.TS_MessageBox(this, 6, string.Format(langObj.TSReadLangs("ZafuseMain", "zm_b_remove_msg"), "\n\n"));
            if (accept_warnings != DialogResult.Yes) return;
            LangPaths.Remove(folderName);
            SelDGV.Rows.Remove(row);
            RemovePathFromSettings(folderName);
            TSComparer.Parsers.Clear();
            if (SelDGV.Rows.Count > 0){
                SelDGV.FirstDisplayedScrollingRowIndex = 0;
            }
            SelDGV.ClearSelection();
            selectedProccessPath = null;
            await RenderResults();
        }
        // MANUAL PATH SAVE AND LOADA
        // ======================================================================================================
        private void SaveManuelPath(string name, string path){
            try{
                TSSettingsModule save = new TSSettingsModule(ts_sf);
                string existing = save.TSReadSettings(ts_settings_container, "ManuelPaths");
                string newValue = existing + (string.IsNullOrEmpty(existing) ? "" : ";") + $"{name}|{path}";
                save.TSWriteSettings(ts_settings_container, "ManuelPaths", newValue);
            }catch { }
        }
        private void LoadManuelPaths(){
            ManuelLangPaths.Clear();
            try{
                TSSettingsModule read = new TSSettingsModule(ts_sf);
                string rawPaths = read.TSReadSettings(ts_settings_container, "ManuelPaths");
                if (string.IsNullOrEmpty(rawPaths)) return;
                foreach (var entry in rawPaths.Split(';')){
                    var parts = entry.Split('|');
                    if (parts.Length == 2 && Directory.Exists(parts[1])){
                        ManuelLangPaths[parts[0]] = parts[1];
                    }
                }
            }catch{ }
        }
        private void RemovePathFromSettings(string nameToRemove){
            try{
                TSSettingsModule settings = new TSSettingsModule(ts_sf);
                string rawPaths = settings.TSReadSettings(ts_settings_container, "ManuelPaths");
                if (string.IsNullOrEmpty(rawPaths)) return;
                var entries = rawPaths.Split(';').Select(e => e.Split('|')).Where(p => p.Length == 2 && p[0] != nameToRemove).Select(p => $"{p[0]}|{p[1]}").ToList();
                if (entries.Count > 0){
                    settings.TSWriteSettings(ts_settings_container, "ManuelPaths", string.Join(";", entries));
                }else{
                    settings.TSDeleteSetting(ts_settings_container, "ManuelPaths");
                }
            }catch { }
        }
        // RENDER ANALYSIS ERROR TYPE
        // ======================================================================================================
        public enum AnalysisErrorType{
            None,                    // No error or informational message
            MissingKey,              // Keys missing in one language but present in another
            DuplicateKey,            // Keys defined multiple times within the same file
            SectionMismatch,         // Same key exists under different section headers in different files
            PlaceholderSymbolError,  // Mismatch in number of placeholders ({0}, %s), punctuation (. , ! ?), or quotes (" ')
            CommentMismatch,         // Comments (;) differ between languages for the same line
            LineCountDifference      // Total physical line count differs between files
        }
        // RENDER RESULTS
        // ======================================================================================================
        private void MainDGVAddRowHelper(int line, AnalysisErrorType type, string key, string details, string typeText){
            int rowIndex = MainDGV.Rows.Add(line == -1 ? "-" : line.ToString(), typeText, key, details);
            MainDGV.Rows[rowIndex].Tag = type;
        }
        private async Task RenderResults(){
            if (!await _renderSemaphore.WaitAsync(0)){
                return;
            }
            TSGetLangs software_lang = new TSGetLangs(lang_path);
            string oldTitle = this.Text;
            this.Text = string.Format(software_lang.TSReadLangs("ZafuseMain", "zm_t_analysis"), oldTitle);
            //
            string missingKeyText = software_lang.TSReadLangs("ZafuseMain", "zm_e_missing_key");
            string duplicateKeyText = software_lang.TSReadLangs("ZafuseMain", "zm_e_repeat_key");
            string sectionMismatchText = software_lang.TSReadLangs("ZafuseMain", "zm_e_different_section");
            string placeholderErrorText = software_lang.TSReadLangs("ZafuseMain", "zm_e_placeholder");
            string numberErrorText = software_lang.TSReadLangs("ZafuseMain", "zm_e_number");
            string punctuationErrorText = software_lang.TSReadLangs("ZafuseMain", "zm_e_punctuation");
            string quoteErrorText = software_lang.TSReadLangs("ZafuseMain", "zm_e_quote");
            string commentMismatchText = software_lang.TSReadLangs("ZafuseMain", "zm_e_different_comment");
            string lineCountDiffText = software_lang.TSReadLangs("ZafuseMain", "zm_e_different_row_count");
            string pL = software_lang.TSReadLangs("ZafuseMain", "zm_ep_placeholder");
            string missingKeyDetailFormat = software_lang.TSReadLangs("ZafuseMain", "zm_e_target_file_null");
            string duplicateKeyDetailFormat = software_lang.TSReadLangs("ZafuseMain", "zm_e_file");
            string commentDetailFormat = software_lang.TSReadLangs("ZafuseMain", "zm_e_different_files");
            string lineCountDetailFormat = software_lang.TSReadLangs("ZafuseMain", "zm_e_row_total");
            //
            try{
                MainDGV.Rows.Clear();
                int checkPlaceholders = 0, checkPunctuation = 0, checkQuotes = 0;
                bool checkNums = false;
                bool checkComments = false;
                this.Invoke(new Action(() => {
                    if (SelDGV.SelectedRows.Count > 0){
                        selectedProccessPath = SelDGV.SelectedRows[0].Cells["Path"].Value?.ToString();
                    }
                    checkPlaceholders = caPlaceholders.Checked ? 1 : 0;
                    checkPunctuation = caPunctuationMarks.Checked ? 1 : 0;
                    checkQuotes = caNailSigns.Checked ? 1 : 0;
                    checkNums = caNumbers.Checked;
                    checkComments = caCommentLines.Checked;
                    MainDGV.SuspendLayout();
                }));
                if (string.IsNullOrEmpty(selectedProccessPath)){
                    this.Invoke(new Action(() => {
                        MainDGVAddRowHelper(-1, AnalysisErrorType.None, software_lang.TSReadLangs("ZafuseMain", "zm_e_info"), software_lang.TSReadLangs("ZafuseMain", "zm_e_select_pending_msg"), software_lang.TSReadLangs("ZafuseMain", "zm_e_select_pending"));
                        MainDGV.ClearSelection();
                    }));
                    return;
                }
                await Task.Run(() => TSComparer.LoadFolder(selectedProccessPath));
                try{
                    var lineMap = TSComparer.GetKeyLineNumbers();
                    // Get line number from first file that contains the key, or -1 if not found
                    int GetFirstFileLine(string key){
                        if (!lineMap.ContainsKey(key)) return -1;
                        var firstFile = lineMap[key].FirstOrDefault();
                        return firstFile.Value;
                    }
                    // Collect all rows first for batch update
                    var rowsToAdd = new List<Action>();
                    // Missing keys
                    foreach (var kvp in TSComparer.GetMissingKeys()){
                        int lineNum = GetFirstFileLine(kvp.Key);
                        string details = string.Format(missingKeyDetailFormat, string.Join(", ", kvp.Value));
                        rowsToAdd.Add(() => MainDGVAddRowHelper(lineNum, AnalysisErrorType.MissingKey, kvp.Key, details, missingKeyText));
                    }
                    // Duplicate keys
                    foreach (var kvp in TSComparer.GetDuplicateKeys()){
                        foreach (var keyInfo in kvp.Value){
                            if (keyInfo.Contains("[SectionMismatch:")){
                                int openBracket = keyInfo.IndexOf('[');
                                string pureKey = keyInfo.Substring(0, openBracket).Trim();
                                string sectionInfo = keyInfo.Substring(openBracket).Replace("[SectionMismatch:", "").Replace("]", "").Trim();
                                int lineNum = GetFirstFileLine(pureKey);
                                string details = $"{string.Format(duplicateKeyDetailFormat, kvp.Key)} ({sectionInfo})";
                                rowsToAdd.Add(() => MainDGVAddRowHelper(lineNum, AnalysisErrorType.SectionMismatch, pureKey, details, sectionMismatchText));
                            }else{
                                int lineNum = GetFirstFileLine(keyInfo);
                                string details = string.Format(duplicateKeyDetailFormat, kvp.Key);
                                rowsToAdd.Add(() => MainDGVAddRowHelper(lineNum, AnalysisErrorType.DuplicateKey, keyInfo, details, duplicateKeyText));
                            }
                        }
                    }
                    // Section mismatches
                    foreach (var kvp in TSComparer.GetSectionMismatches()){
                        int lineNum = GetFirstFileLine(kvp.Key);
                        string sectionsInfo = string.Join(" | ", kvp.Value.Select(v => $"{v.Key}: {v.Value}"));
                        rowsToAdd.Add(() => MainDGVAddRowHelper(lineNum, AnalysisErrorType.SectionMismatch, kvp.Key, sectionsInfo, sectionMismatchText));
                    }
                    // Dynamic Content Analysis - RESPECT CHECKBOX STATES
                    var placeholders = TSComparer.GetPlaceholderMismatches(checkPlaceholders > 0, checkPunctuation > 0, checkQuotes > 0, checkNums);
                    foreach (var kvp in placeholders){
                        int lineNum = GetFirstFileLine(kvp.Key);
                        var counts = kvp.Value.Values;
                        var first = counts.First();
                        // Only report mismatches for enabled checks
                        List<string> errorParts = new List<string>();
                        if (checkPlaceholders > 0 && counts.Any(c => c.Placeholders != first.Placeholders))
                            errorParts.Add(placeholderErrorText);
                        if (checkNums && counts.Any(c => c.Numbers != first.Numbers))
                            errorParts.Add(numberErrorText);
                        if (checkPunctuation > 0 && counts.Any(c => c.Punctuation != first.Punctuation))
                            errorParts.Add(punctuationErrorText);
                        if (checkQuotes > 0 && counts.Any(c => c.Quotes != first.Quotes))
                            errorParts.Add(quoteErrorText);
                        // Skip if no actual mismatches (should not happen, but safety check)
                        if (errorParts.Count == 0) continue;
                        string dynamicErrorTitle = string.Join(", ", errorParts);
                        // Only show metrics that are actually checked
                        var metricParts = new List<string>();
                        foreach (var v in kvp.Value){
                            var metrics = new List<string>();
                            if (checkPlaceholders > 0)
                                metrics.Add($"{pL}:{v.Value.Placeholders}");
                            if (checkNums)
                                metrics.Add($"{numberErrorText}:{v.Value.Numbers}");
                            if (checkPunctuation > 0)
                                metrics.Add($"{punctuationErrorText}:{v.Value.Punctuation}");
                            if (checkQuotes > 0)
                                metrics.Add($"{quoteErrorText}:{v.Value.Quotes}");
                            metricParts.Add($"{v.Key}: {string.Join(" ", metrics)}");
                        }
                        string detailText = string.Join(" | ", metricParts);
                        rowsToAdd.Add(() => MainDGVAddRowHelper(lineNum, AnalysisErrorType.PlaceholderSymbolError, kvp.Key, detailText, dynamicErrorTitle));
                    }
                    // Comment check
                    if (checkComments){
                        var commentDifferences = TSComparer.GetCommentDifferences();
                        if (commentDifferences.Count > 0){
                            foreach (var kvp in commentDifferences){
                                string details = string.Format(commentDetailFormat, string.Join(", ", kvp.Value.Keys));
                                rowsToAdd.Add(() => MainDGVAddRowHelper(kvp.Key, AnalysisErrorType.CommentMismatch, string.Format(software_lang.TSReadLangs("ZafuseMain", "zm_e_row"), kvp.Key), details, commentMismatchText));
                            }
                        }
                    }
                    // Line count difference
                    foreach (var kvp in TSComparer.GetLineCountDifferences()){
                        string details = string.Format(lineCountDetailFormat, kvp.Value);
                        rowsToAdd.Add(() => MainDGVAddRowHelper(-1, AnalysisErrorType.LineCountDifference, kvp.Key, details, lineCountDiffText));
                    }
                    // Batch update UI - single Invoke for all rows
                    if (rowsToAdd.Count > 0){
                        this.Invoke(new Action(() => {
                            foreach (var addRow in rowsToAdd){
                                addRow();
                            }
                        }));
                    }
                }catch (Exception ex){
                    this.Invoke(new Action(() => {
                        TS_MessageBoxEngine.TS_MessageBox(this, 3, string.Format(software_lang.TSReadLangs("ZafuseMain", "zm_e_error"), "\n\n", ex.Message));
                    }));
                }finally{
                    this.Invoke(new Action(() => {
                        MainDGV.ResumeLayout();
                        MainDGV.ClearSelection();
                    }));
                }
            }finally{
                this.Invoke(new Action(() => {
                    MainDGV.ResumeLayout();
                    if (MainDGV.Rows.Count == 0 && !string.IsNullOrEmpty(selectedProccessPath)){
                        MainDGVAddRowHelper(-1, AnalysisErrorType.None, software_lang.TSReadLangs("ZafuseMain", "zm_e_info"), software_lang.TSReadLangs("ZafuseMain", "zm_e_no_issue_detected"), software_lang.TSReadLangs("ZafuseMain", "zm_e_no_issue"));
                    }
                    MainDGV.ClearSelection();
                }));
                this.Text = oldTitle;
                _renderSemaphore.Release();
            }
        }
        // CELL FORMATTINGS
        // ======================================================================================================
        private void MainDGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e){
            if (e.RowIndex < 0 || MainDGV.Rows[e.RowIndex].Tag == null) return;
            if (MainDGV.Rows[e.RowIndex].Selected){
                e.CellStyle.SelectionForeColor = TS_ThemeEngine.ColorMode(theme, "DataGridHeaderFE");
                return;
            }
            if (MainDGV.Rows[e.RowIndex].Tag is AnalysisErrorType errorType){
                switch (errorType){
                    case AnalysisErrorType.MissingKey:
                        e.CellStyle.ForeColor = TS_ThemeEngine.ColorMode(theme, "AccentBlue");
                        break;
                    case AnalysisErrorType.DuplicateKey:
                        e.CellStyle.ForeColor = TS_ThemeEngine.ColorMode(theme, "AccentPurple");
                        break;
                    case AnalysisErrorType.PlaceholderSymbolError:
                        e.CellStyle.ForeColor = TS_ThemeEngine.ColorMode(theme, "AccentRed");
                        break;
                    case AnalysisErrorType.SectionMismatch:
                        e.CellStyle.ForeColor = TS_ThemeEngine.ColorMode(theme, "AccentGreen");
                        break;
                    case AnalysisErrorType.CommentMismatch:
                        e.CellStyle.ForeColor = TS_ThemeEngine.ColorMode(theme, "AccentOrange");
                        break;
                    case AnalysisErrorType.LineCountDifference:
                        e.CellStyle.ForeColor = TS_ThemeEngine.ColorMode(theme, "AccentColor");
                        break;
                    default:
                        e.CellStyle.ForeColor = TS_ThemeEngine.ColorMode(theme, "DataGridFEColor");
                        break;
                }
            }
        }
        // GENERATE REPORT (ASYNC VERSION)
        // ======================================================================================================
        readonly List<string> AnalysisGenRepList = new List<string>();
        private async void BtnGenReport_Click(object sender, EventArgs e){
            TSGetLangs software_lang = new TSGetLangs(lang_path);
            if (string.IsNullOrEmpty(selectedProccessPath)){
                TS_MessageBoxEngine.TS_MessageBox(this, 2, software_lang.TSReadLangs("ZafuseGenReport", "zgr_pending_select_msg"));
                return;
            }
            try{
                AnalysisGenRepList.Clear();
                // HEADER
                AnalysisGenRepList.Add(string.Format(software_lang.TSReadLangs("ZafuseGenReport", "zgr_report_title"), Application.ProductName));
                AnalysisGenRepList.Add(string.Format(software_lang.TSReadLangs("ZafuseGenReport", "zgr_analysis_path"), selectedProccessPath));
                AnalysisGenRepList.Add(Environment.NewLine + new string('-', 100));
                // MAIN - BACKGROUND TASK
                var reportLines = await Task.Run(() =>{
                    var current_lines = new List<string>();
                    for (int i = 0; i < MainDGV.Rows.Count; i++){
                        int lineLength = (i == MainDGV.Rows.Count - 1) ? 100 : 25;
                        current_lines.Add(Environment.NewLine +
                            MainDGV.Columns[0].HeaderText + ": " + MainDGV.Rows[i].Cells[0].Value.ToString() + Environment.NewLine +
                            MainDGV.Columns[1].HeaderText + ": " + MainDGV.Rows[i].Cells[1].Value.ToString() + Environment.NewLine +
                            MainDGV.Columns[2].HeaderText + ": " + MainDGV.Rows[i].Cells[2].Value.ToString() + Environment.NewLine +
                            MainDGV.Columns[3].HeaderText + ": " + MainDGV.Rows[i].Cells[3].Value.ToString() + Environment.NewLine + Environment.NewLine +
                            new string('-', lineLength)
                        );
                    }
                    return current_lines;
                });
                AnalysisGenRepList.AddRange(reportLines);
                // FOOTER
                AnalysisGenRepList.Add(Environment.NewLine + Application.ProductName + " " + software_lang.TSReadLangs("ZafuseGenReport", "zgr_version") + " " + TS_VersionEngine.TS_SoftwareVersion(1));
                AnalysisGenRepList.Add(TS_SoftwareCopyrightDate.ts_scd_preloader);
                AnalysisGenRepList.Add(software_lang.TSReadLangs("ZafuseGenReport", "zgr_process_time") + " " + DateTime.Now.ToString("dd.MM.yyyy - HH:mm:ss"));
                AnalysisGenRepList.Add(software_lang.TSReadLangs("ZafuseGenReport", "zgr_website") + " " + TS_LinkSystem.website_link);
                AnalysisGenRepList.Add(software_lang.TSReadLangs("ZafuseGenReport", "zgr_github") + " " + TS_LinkSystem.github_link);
                AnalysisGenRepList.Add(software_lang.TSReadLangs("ZafuseGenReport", "zgr_donate") + " " + TS_LinkSystem.ts_donate);
                // SAVE DIALOG
                using (SaveFileDialog saveDlg = new SaveFileDialog{
                    InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    Title = Application.ProductName + " - " + software_lang.TSReadLangs("ZafuseGenReport", "zgr_save_directory"),
                    DefaultExt = "txt",
                    FileName = string.Format(software_lang.TSReadLangs("ZafuseGenReport", "zgr_export_name"), Application.ProductName, DateTime.Now.ToString("dd.MM.yyyy - HH.mm.ss")),
                    Filter = software_lang.TSReadLangs("ZafuseGenReport", "zgr_save_txt") + " (*.txt)|*.txt"
                }){
                    if (saveDlg.ShowDialog() == DialogResult.OK){
                        using (var fs = new FileStream(saveDlg.FileName, FileMode.Create, FileAccess.Write, FileShare.None, 4096, useAsync: true))
                        using (var sw = new StreamWriter(fs, Encoding.UTF8)){
                            foreach (var line in AnalysisGenRepList){
                                await sw.WriteLineAsync(line);
                            }
                        }
                        var response_success = TS_MessageBoxEngine.TS_MessageBox(this, 5, string.Format(software_lang.TSReadLangs("ZafuseGenReport", "zgr_save_success") + Environment.NewLine + Environment.NewLine + software_lang.TSReadLangs("ZafuseGenReport", "zgr_save_info_open"), Application.ProductName, saveDlg.FileName));
                        if (response_success == DialogResult.Yes){
                            Process.Start(new ProcessStartInfo{
                                FileName = saveDlg.FileName,
                                UseShellExecute = true
                            });
                        }
                    }
                }
            }catch (Exception ex){
                TS_MessageBoxEngine.TS_MessageBox(this, 3, string.Format(software_lang.TSReadLangs("ZafuseMain", "zgr_save_failed"), "\n\n", ex.Message));
            }
        }
        // THEME SETTINGS
        // ======================================================================================================
        private ToolStripMenuItem selected_theme = null;
        private void Select_theme_active(object target_theme){
            if (target_theme == null)
                return;
            ToolStripMenuItem clicked_theme = (ToolStripMenuItem)target_theme;
            if (selected_theme == clicked_theme)
                return;
            Select_theme_deactive();
            selected_theme = clicked_theme;
            selected_theme.Checked = true;
        }
        private void Select_theme_deactive(){
            foreach (ToolStripMenuItem theme in themeToolStripMenuItem.DropDownItems){
                theme.Checked = false;
            }
        }
        // THEME SWAP
        // ======================================================================================================
        private void SystemThemeToolStripMenuItem_Click(object sender, EventArgs e){
            themeSystem = 2; Theme_engine(TSThemeModeHelper.GetSystemTheme(2)); SaveTheme(2); Select_theme_active(sender);
        }
        private void LightThemeToolStripMenuItem_Click(object sender, EventArgs e){
            themeSystem = 0; Theme_engine(1); SaveTheme(1); Select_theme_active(sender);
        }
        private void DarkThemeToolStripMenuItem_Click(object sender, EventArgs e){
            themeSystem = 0; Theme_engine(0); SaveTheme(0); Select_theme_active(sender);
        }
        private void TSUseSystemTheme(){ if (themeSystem == 2) Theme_engine(TSThemeModeHelper.GetSystemTheme(2)); }
        private void SaveTheme(int ts){
            // SAVE CURRENT THEME
            try{
                TSSettingsModule software_setting_save = new TSSettingsModule(ts_sf);
                software_setting_save.TSWriteSettings(ts_settings_container, "ThemeStatus", Convert.ToString(ts));
            }catch (Exception){ }
        }
        // THEME ENGINE
        // ======================================================================================================
        private void Theme_engine(int ts){
            try{
                theme = ts;
                //
                TSThemeModeHelper.SetThemeMode(ts == 0);
                TSThemeModeHelper.InitializeThemeForForm(this);
                //
                if (theme == 1){
                    // TOP MENU LOGO CHANGE
                    TSImageRenderer(settingsToolStripMenuItem, Properties.Resources.tm_settings_light, 0, ContentAlignment.MiddleRight);
                    TSImageRenderer(themeToolStripMenuItem, Properties.Resources.tm_theme_light, 0, ContentAlignment.MiddleRight);
                    TSImageRenderer(languageToolStripMenuItem, Properties.Resources.tm_language_light, 0, ContentAlignment.MiddleRight);
                    TSImageRenderer(startupToolStripMenuItem, Properties.Resources.tm_startup_light, 0, ContentAlignment.MiddleRight);
                    TSImageRenderer(contentAnalysis, Properties.Resources.tm_analysis_light, 0, ContentAlignment.MiddleRight);
                    TSImageRenderer(checkForUpdatesToolStripMenuItem, Properties.Resources.tm_update_light, 0, ContentAlignment.MiddleRight);
                    // DONATE
                    TSImageRenderer(donateToolStripMenuItem, Properties.Resources.tm_donate_light, 0, ContentAlignment.MiddleRight);
                    // ABOUT
                    TSImageRenderer(aboutToolStripMenuItem, Properties.Resources.tm_about_light, 0, ContentAlignment.MiddleRight);
                    // UI
                    TSImageRenderer(BtnAddFolder, Properties.Resources.ct_add_light, 17, ContentAlignment.MiddleRight);
                    TSImageRenderer(BtnRemoveFolder, Properties.Resources.ct_remove_light, 17, ContentAlignment.MiddleRight);
                    TSImageRenderer(BtnGenReport, Properties.Resources.ct_generate_light, 17, ContentAlignment.MiddleRight);
                }else if (theme == 0){
                    // TOP MENU LOGO CHANGE
                    TSImageRenderer(settingsToolStripMenuItem, Properties.Resources.tm_settings_dark, 0, ContentAlignment.MiddleRight);
                    TSImageRenderer(themeToolStripMenuItem, Properties.Resources.tm_theme_dark, 0, ContentAlignment.MiddleRight);
                    TSImageRenderer(languageToolStripMenuItem, Properties.Resources.tm_language_dark, 0, ContentAlignment.MiddleRight);
                    TSImageRenderer(startupToolStripMenuItem, Properties.Resources.tm_startup_dark, 0, ContentAlignment.MiddleRight);
                    TSImageRenderer(contentAnalysis, Properties.Resources.tm_analysis_dark, 0, ContentAlignment.MiddleRight);
                    TSImageRenderer(checkForUpdatesToolStripMenuItem, Properties.Resources.tm_update_dark, 0, ContentAlignment.MiddleRight);
                    // DONATE
                    TSImageRenderer(donateToolStripMenuItem, Properties.Resources.tm_donate_dark, 0, ContentAlignment.MiddleRight);
                    // ABOUT
                    TSImageRenderer(aboutToolStripMenuItem, Properties.Resources.tm_about_dark, 0, ContentAlignment.MiddleRight);
                    // UI
                    TSImageRenderer(BtnAddFolder, Properties.Resources.ct_add_dark, 17, ContentAlignment.MiddleRight);
                    TSImageRenderer(BtnRemoveFolder, Properties.Resources.ct_remove_dark, 17, ContentAlignment.MiddleRight);
                    TSImageRenderer(BtnGenReport, Properties.Resources.ct_generate_dark, 17, ContentAlignment.MiddleRight);
                }
                // OTHER PAGE DYNAMIC UI
                Zafuse_other_page_dynamic_ui();
                // HEADER
                header_colors[0] = TS_ThemeEngine.ColorMode(theme, "HeaderBGColorMain");
                header_colors[1] = TS_ThemeEngine.ColorMode(theme, "HeaderFEColorMain");
                header_colors[2] = TS_ThemeEngine.ColorMode(theme, "AccentColor");
                HeaderMenu.Renderer = new HeaderMenuColors();
                // TOOLTIP
                MainToolTip.ForeColor = TS_ThemeEngine.ColorMode(theme, "HeaderFEColor");
                MainToolTip.BackColor = TS_ThemeEngine.ColorMode(theme, "HeaderBGColor");
                // HEADER MENU
                var bg = TS_ThemeEngine.ColorMode(theme, "HeaderBGColor");
                var fg = TS_ThemeEngine.ColorMode(theme, "HeaderFEColor");
                HeaderMenu.ForeColor = fg;
                HeaderMenu.BackColor = bg;
                SetMenuStripColors(HeaderMenu, bg, fg);
                // UI
                BackColor = TS_ThemeEngine.ColorMode(theme, "BGColor");
                BackPanel.BackColor = TS_ThemeEngine.ColorMode(theme, "BGColor");
                //
                foreach (Control ui_buttons in BackPanel.Controls){
                    if (ui_buttons is Button ui_button){
                        ui_button.ForeColor = TS_ThemeEngine.ColorMode(theme, "FontColor2");
                        ui_button.BackColor = TS_ThemeEngine.ColorMode(theme, "AccentColor");
                        ui_button.FlatAppearance.BorderColor = TS_ThemeEngine.ColorMode(theme, "AccentColor");
                        ui_button.FlatAppearance.MouseDownBackColor = TS_ThemeEngine.ColorMode(theme, "AccentColor");
                        ui_button.FlatAppearance.MouseOverBackColor = TS_ThemeEngine.ColorMode(theme, "AccentColorHover");
                    }
                }
                //
                Color headerBG = TS_ThemeEngine.ColorMode(theme, "DataGridHeaderBG");
                Color headerFE = TS_ThemeEngine.ColorMode(theme, "DataGridHeaderFE");
                //
                SelDGV.BackgroundColor = TS_ThemeEngine.ColorMode(theme, "DataGridBGColor");
                SelDGV.GridColor = TS_ThemeEngine.ColorMode(theme, "DataGridColor");
                SelDGV.DefaultCellStyle.BackColor = TS_ThemeEngine.ColorMode(theme, "DataGridBGColor");
                SelDGV.DefaultCellStyle.ForeColor = TS_ThemeEngine.ColorMode(theme, "DataGridFEColor");
                SelDGV.AlternatingRowsDefaultCellStyle.BackColor = TS_ThemeEngine.ColorMode(theme, "DataGridAlternatingColor");
                SelDGV.DefaultCellStyle.SelectionBackColor = TS_ThemeEngine.ColorMode(theme, "DataGridSelectionColor");
                SelDGV.DefaultCellStyle.SelectionForeColor = TS_ThemeEngine.ColorMode(theme, "DataGridHeaderFE");
                SelDGV.ColumnHeadersDefaultCellStyle.BackColor = headerBG;
                SelDGV.ColumnHeadersDefaultCellStyle.ForeColor = headerFE;
                SelDGV.ColumnHeadersDefaultCellStyle.SelectionBackColor = headerBG;
                SelDGV.ColumnHeadersDefaultCellStyle.SelectionForeColor = headerFE;
                //
                MainDGV.BackgroundColor = TS_ThemeEngine.ColorMode(theme, "DataGridBGColor");
                MainDGV.GridColor = TS_ThemeEngine.ColorMode(theme, "DataGridColor");
                MainDGV.DefaultCellStyle.BackColor = TS_ThemeEngine.ColorMode(theme, "DataGridBGColor");
                MainDGV.DefaultCellStyle.ForeColor = TS_ThemeEngine.ColorMode(theme, "DataGridFEColor");
                MainDGV.AlternatingRowsDefaultCellStyle.BackColor = TS_ThemeEngine.ColorMode(theme, "DataGridAlternatingColor");
                MainDGV.DefaultCellStyle.SelectionBackColor = TS_ThemeEngine.ColorMode(theme, "DataGridSelectionColor");
                MainDGV.DefaultCellStyle.SelectionForeColor = TS_ThemeEngine.ColorMode(theme, "DataGridHeaderFE");
                MainDGV.ColumnHeadersDefaultCellStyle.BackColor = headerBG;
                MainDGV.ColumnHeadersDefaultCellStyle.ForeColor = headerFE;
                MainDGV.ColumnHeadersDefaultCellStyle.SelectionBackColor = headerBG;
                MainDGV.ColumnHeadersDefaultCellStyle.SelectionForeColor = headerFE;
                //
                MainDGV.Invalidate();
            }catch (Exception){ }
        }
        private void SetMenuStripColors(MenuStrip menuStrip, Color bgColor, Color fgColor){
            if (menuStrip == null) return;
            foreach (ToolStripItem item in menuStrip.Items){
                if (item is ToolStripMenuItem menuItem){
                    SetMenuItemColors(menuItem, bgColor, fgColor);
                }
            }
        }
        private void SetMenuItemColors(ToolStripMenuItem menuItem, Color bgColor, Color fgColor){
            if (menuItem == null) return;
            menuItem.BackColor = bgColor;
            menuItem.ForeColor = fgColor;
            foreach (ToolStripItem item in menuItem.DropDownItems){
                if (item is ToolStripMenuItem subMenuItem){
                    SetMenuItemColors(subMenuItem, bgColor, fgColor);
                }
            }
        }
        private void SetContextMenuColors(ContextMenuStrip contextMenu, Color bgColor, Color fgColor){
            if (contextMenu == null) return;
            foreach (ToolStripItem item in contextMenu.Items){
                if (item is ToolStripMenuItem menuItem){
                    SetMenuItemColors(menuItem, bgColor, fgColor);
                }
            }
        }
        // MODULES PAGE DYNAMIC UI
        // ======================================================================================================
        private void Zafuse_other_page_dynamic_ui(){
            try{
                var zafuse_other_pages = new (string name, Func<object> createTool, Action<object> applySettings)[]{
                    ("zafuse_about", () => new ZafuseAbout(), tool => ((ZafuseAbout)tool).About_preloader()),
                };
                foreach (var (toolName, createTool, applySettings) in zafuse_other_pages){
                    try{
                        var tool = createTool();
                        tool.GetType().GetProperty("Name")?.SetValue(tool, toolName);
                        if (Application.OpenForms[toolName] != null){
                            tool = Application.OpenForms[toolName];
                            applySettings(tool);
                        }
                    }catch (Exception){ }
                }
            }catch (Exception){ }
        }
        // LANGUAGES SETTINGS
        // ======================================================================================================
        private void Select_lang_active(object target_lang){
            ToolStripMenuItem selected_lang = null;
            Select_lang_deactive();
            if (target_lang != null){
                if (selected_lang != (ToolStripMenuItem)target_lang){
                    selected_lang = (ToolStripMenuItem)target_lang;
                    selected_lang.Checked = true;
                }
            }
        }
        private void Select_lang_deactive(){
            foreach (ToolStripMenuItem disabled_lang in languageToolStripMenuItem.DropDownItems){
                disabled_lang.Checked = false;
            }
        }
        // LANG SWAP
        // ======================================================================================================
        private void LanguageToolStripMenuItem_Click(object sender, EventArgs e){
            if (sender is ToolStripMenuItem menuItem && menuItem.Tag is string langCode){
                if (lang != langCode && AllLanguageFiles.ContainsKey(langCode)){
                    Lang_preload(AllLanguageFiles[langCode], langCode);
                    Select_lang_active(sender);
                }
            }
        }
        private void Lang_preload(string lang_type, string lang_code){
            Lang_engine(lang_type, lang_code);
            try{
                TSSettingsModule software_setting_save = new TSSettingsModule(ts_sf);
                software_setting_save.TSWriteSettings(ts_settings_container, "LanguageStatus", lang_code);
            }catch (Exception){ }
            // LANG CHANGE NOTIFICATION
            // TSGetLangs software_lang = new TSGetLangs(lang_path);
            // DialogResult lang_change_message = TS_MessageBoxEngine.TS_MessageBox(this, 5, string.Format(software_lang.TSReadLangs("LangChange", "lang_change_notification"), "\n\n", "\n\n"));
            // if (lang_change_message == DialogResult.Yes) { Application.Restart(); }
        }
        private async void Lang_engine(string lang_type, string lang_code){
            try{
                lang_path = lang_type;
                lang = lang_code;
                // GLOBAL ENGINE
                TSGetLangs software_lang = new TSGetLangs(lang_path);
                // SETTINGS
                settingsToolStripMenuItem.Text = software_lang.TSReadLangs("HeaderMenu", "header_menu_settings");
                // THEMES
                themeToolStripMenuItem.Text = software_lang.TSReadLangs("HeaderMenu", "header_menu_theme");
                lightThemeToolStripMenuItem.Text = software_lang.TSReadLangs("HeaderThemes", "theme_light");
                darkThemeToolStripMenuItem.Text = software_lang.TSReadLangs("HeaderThemes", "theme_dark");
                systemThemeToolStripMenuItem.Text = software_lang.TSReadLangs("HeaderThemes", "theme_system");
                // LANGS
                languageToolStripMenuItem.Text = software_lang.TSReadLangs("HeaderMenu", "header_menu_language");
                arabicToolStripMenuItem.Text = software_lang.TSReadLangs("HeaderLangs", "lang_ar");
                chineseToolStripMenuItem.Text = software_lang.TSReadLangs("HeaderLangs", "lang_zh");
                englishToolStripMenuItem.Text = software_lang.TSReadLangs("HeaderLangs", "lang_en");
                dutchToolStripMenuItem.Text = software_lang.TSReadLangs("HeaderLangs", "lang_nl");
                frenchToolStripMenuItem.Text = software_lang.TSReadLangs("HeaderLangs", "lang_fr");
                germanToolStripMenuItem.Text = software_lang.TSReadLangs("HeaderLangs", "lang_de");
                hindiToolStripMenuItem.Text = software_lang.TSReadLangs("HeaderLangs", "lang_hi");
                italianToolStripMenuItem.Text = software_lang.TSReadLangs("HeaderLangs", "lang_it");
                japaneseToolStripMenuItem.Text = software_lang.TSReadLangs("HeaderLangs", "lang_ja");
                koreanToolStripMenuItem.Text = software_lang.TSReadLangs("HeaderLangs", "lang_ko");
                polishToolStripMenuItem.Text = software_lang.TSReadLangs("HeaderLangs", "lang_pl");
                portugueseToolStripMenuItem.Text = software_lang.TSReadLangs("HeaderLangs", "lang_pt");
                russianToolStripMenuItem.Text = software_lang.TSReadLangs("HeaderLangs", "lang_ru");
                spanishToolStripMenuItem.Text = software_lang.TSReadLangs("HeaderLangs", "lang_es");
                turkishToolStripMenuItem.Text = software_lang.TSReadLangs("HeaderLangs", "lang_tr");
                // STARTUP VIEW
                startupToolStripMenuItem.Text = software_lang.TSReadLangs("HeaderMenu", "header_menu_start");
                windowedToolStripMenuItem.Text = software_lang.TSReadLangs("HeaderViewMode", "header_view_mode_windowed");
                fullScreenToolStripMenuItem.Text = software_lang.TSReadLangs("HeaderViewMode", "header_view_mode_full_screen");
                // ANALYSIS MODE
                contentAnalysis.Text = software_lang.TSReadLangs("HeaderMenu", "header_analysis_mode");
                caPlaceholders.Text = software_lang.TSReadLangs("HeaderAnalysisMode", "has_placeholders");
                caPunctuationMarks.Text = software_lang.TSReadLangs("HeaderAnalysisMode", "has_punctuation_marks");
                caNailSigns.Text = software_lang.TSReadLangs("HeaderAnalysisMode", "has_nail_signs");
                caNumbers.Text = software_lang.TSReadLangs("HeaderAnalysisMode", "has_numbers");
                caCommentLines.Text = software_lang.TSReadLangs("HeaderAnalysisMode", "has_comment_lines");
                // UPDATE CHECK
                checkForUpdatesToolStripMenuItem.Text = software_lang.TSReadLangs("HeaderMenu", "header_menu_update");
                // DONATE
                donateToolStripMenuItem.Text = software_lang.TSReadLangs("HeaderMenu", "header_menu_donate");
                // ABOUT
                aboutToolStripMenuItem.Text = software_lang.TSReadLangs("HeaderMenu", "header_menu_about");
                // CONTENT
                BtnAddFolder.Text = software_lang.TSReadLangs("ZafuseMain", "zm_b_add") + " ";
                BtnRemoveFolder.Text = software_lang.TSReadLangs("ZafuseMain", "zm_b_remove") + " ";
                BtnGenReport.Text = software_lang.TSReadLangs("ZafuseMain", "zm_b_generate") + " ";
                if (SelDGV.Columns.Count > 0){
                    SelDGV.Columns[0].HeaderText = software_lang.TSReadLangs("ZafuseMain", "zm_s_name");
                    SelDGV.Columns[1].HeaderText = software_lang.TSReadLangs("ZafuseMain", "zm_s_path");
                    SelDGV.Columns[2].HeaderText = software_lang.TSReadLangs("ZafuseMain", "zm_s_count");
                    SelDGV.Columns[3].HeaderText = software_lang.TSReadLangs("ZafuseMain", "zm_s_size");
                }
                if (MainDGV.Columns.Count > 0){
                    MainDGV.Columns[0].HeaderText = software_lang.TSReadLangs("ZafuseMain", "zm_h_row");
                    MainDGV.Columns[1].HeaderText = software_lang.TSReadLangs("ZafuseMain", "zm_h_error_type");
                    MainDGV.Columns[2].HeaderText = software_lang.TSReadLangs("ZafuseMain", "zm_h_key_section");
                    MainDGV.Columns[3].HeaderText = software_lang.TSReadLangs("ZafuseMain", "zm_h_detailed_analysis");
                }
                await RenderResults();
                // OTHER PAGE DYNAMIC UI
                Zafuse_other_page_dynamic_ui();
            }catch (Exception) { }
        }
        // STARTUP SETINGS
        // ======================================================================================================
        private void Select_startup_mode_active(object target_startup_mode){
            ToolStripMenuItem selected_startup_mode = null;
            Select_startup_mode_deactive();
            if (target_startup_mode != null){
                if (selected_startup_mode != (ToolStripMenuItem)target_startup_mode){
                    selected_startup_mode = (ToolStripMenuItem)target_startup_mode;
                    selected_startup_mode.Checked = true;
                }
            }
        }
        private void Select_startup_mode_deactive(){
            foreach (ToolStripMenuItem disabled_startup in startupToolStripMenuItem.DropDownItems){
                disabled_startup.Checked = false;
            }
        }
        private void WindowedToolStripMenuItem_Click(object sender, EventArgs e){
            if (startup_status != 0){ startup_status = 0; Startup_mode_settings("0"); Select_startup_mode_active(sender); }
        }
        private void FullScreenToolStripMenuItem_Click(object sender, EventArgs e){
            if (startup_status != 1){ startup_status = 1; Startup_mode_settings("1"); Select_startup_mode_active(sender); }
        }
        private void Startup_mode_settings(string get_startup_value){
            try{
                TSSettingsModule software_setting_save = new TSSettingsModule(ts_sf);
                software_setting_save.TSWriteSettings(ts_settings_container, "StartupStatus", get_startup_value);
            }catch (Exception){ }
        }
        // ANALYSIS MODE SETTINGS
        // ======================================================================================================
        private void Analysis_mode_settings(){
            bool isPlaceholdersChecked = caPlaceholders.Checked;
            bool isPunctuationChecked = caPunctuationMarks.Checked;
            bool isNailSignsChecked = caNailSigns.Checked;
            bool isNumbersChecked = caNumbers.Checked;
            bool isCommentLinesChecked = caCommentLines.Checked;
            //
            List<string> selectedItems = new List<string>();
            if (isPlaceholdersChecked) selectedItems.Add("Placeholders");
            if (isPunctuationChecked) selectedItems.Add("Punctuation");
            if (isNailSignsChecked) selectedItems.Add("NailSigns");
            if (isNumbersChecked) selectedItems.Add("Numbers");
            if (isCommentLinesChecked) selectedItems.Add("CommentLines");
            //
            string analysis_result = string.Join(",", selectedItems);
            try{
                TSSettingsModule software_setting_save = new TSSettingsModule(ts_sf);
                software_setting_save.TSWriteSettings(ts_settings_container, "AnalysisStatus", analysis_result);
            }catch (Exception){ }
        }
        // UPDATE CHECK ENGINE
        // ======================================================================================================
        private void CheckForUpdatesToolStripMenuItem_Click(object sender, EventArgs e){
            Task.Run(() => Software_update_check(1));
        }
        public async void Software_update_check(int _check_update_ui){
            try{
                TSGetLangs software_lang = new TSGetLangs(lang_path);
                SetUpdateMenuEnabled(false);
                if (!await IsNetworkAvailable()){
                    if (_check_update_ui == 1){
                        TS_MessageBoxEngine.TS_MessageBox(this, 2, string.Format(software_lang.TSReadLangs("SoftwareUpdate", "su_not_connection"), "\n\n"), string.Format(software_lang.TSReadLangs("SoftwareUpdate", "su_title"), Application.ProductName));
                    }
                    return;
                }
                using (HttpClientHandler handler = new HttpClientHandler()){
                    handler.UseProxy = false;
                    using (HttpClient httpClient = new HttpClient(handler)){
                        httpClient.Timeout = TimeSpan.FromSeconds(15);
                        httpClient.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue{ NoCache = true, NoStore = true, MustRevalidate = true };
                        httpClient.DefaultRequestHeaders.Pragma.ParseAdd("no-cache");
                        string versionUrl = TS_LinkSystem.github_link_lv;
                        versionUrl += (versionUrl.Contains("?") ? "&" : "?") + "_ts=" + DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                        string response = await httpClient.GetStringAsync(versionUrl);
                        string firstLine = response.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None)[0];
                        string client_version_raw = TS_VersionParser.ParseUINormalize(Application.ProductVersion);
                        string last_version_raw = TS_VersionParser.ParseUINormalize(firstLine.Split(new[] { '=' }, 2)[1].Trim());
                        Version client_ver = Version.Parse(client_version_raw);
                        Version last_ver = Version.Parse(last_version_raw);
                        if (client_ver < last_ver){
                            DialogResult info_update = TS_MessageBoxEngine.TS_MessageBox(this, 5, string.Format(software_lang.TSReadLangs("SoftwareUpdate", "su_available"), Application.ProductName, "\n\n", client_version_raw, "\n", last_version_raw, "\n\n"), string.Format(software_lang.TSReadLangs("SoftwareUpdate", "su_title"), Application.ProductName));
                            if (info_update == DialogResult.Yes){
                                try{
                                    string updaterPath = Path.Combine(Application.StartupPath, Program.updater_exe_name);
                                    if (File.Exists(updaterPath)){
                                        string procName = Path.GetFileNameWithoutExtension(updaterPath);
                                        bool isRunning = Process.GetProcessesByName(procName).Length > 0;
                                        if (!isRunning){
                                            Process.Start(new ProcessStartInfo(updaterPath) { UseShellExecute = true, Arguments = $"-app={Application.ProductName}" });
                                        }else{
                                            TS_MessageBoxEngine.TS_MessageBox(this, 1, software_lang.TSReadLangs("SoftwareUpdate", "su_ts_updater_c_running"), string.Format(software_lang.TSReadLangs("SoftwareUpdate", "su_title"), Application.ProductName));
                                        }
                                        Application.Exit();
                                        return;
                                    }else{
                                        TS_MessageBoxEngine.TS_MessageBox(this, 2, string.Format(software_lang.TSReadLangs("SoftwareUpdate", "su_ts_updater_not_available"), Program.updater_exe_name), string.Format(software_lang.TSReadLangs("SoftwareUpdate", "su_title"), Application.ProductName));
                                        Process.Start(new ProcessStartInfo(TS_LinkSystem.github_link_lr) { UseShellExecute = true });
                                        Application.Exit();
                                        return;
                                    }
                                }catch (Exception ex){
                                    Debug.WriteLine(ex, $"{Program.updater_exe_name} launch block.");
                                }
                            }
                        }else if (_check_update_ui == 1){
                            string update_msg = client_ver == last_ver ? string.Format(software_lang.TSReadLangs("SoftwareUpdate", "su_not_available"), Application.ProductName, "\n", client_version_raw) : string.Format(software_lang.TSReadLangs("SoftwareUpdate", "su_newer"), "\n\n", $"v{client_version_raw}");
                            TS_MessageBoxEngine.TS_MessageBox(this, 1, update_msg, string.Format(software_lang.TSReadLangs("SoftwareUpdate", "su_title"), Application.ProductName));
                        }
                    }
                }
            }catch (Exception ex){
                Debug.WriteLine(ex, "Software_update_check()");
                TSGetLangs software_lang = new TSGetLangs(lang_path);
                TS_MessageBoxEngine.TS_MessageBox(this, 3, string.Format(software_lang.TSReadLangs("SoftwareUpdate", "su_error"), "\n\n", ex.Message), string.Format(software_lang.TSReadLangs("SoftwareUpdate", "su_title"), Application.ProductName));
            }finally{
                SetUpdateMenuEnabled(true);
            }
        }
        private void SetUpdateMenuEnabled(bool enabled){
            if (InvokeRequired){
                BeginInvoke(new Action(() => checkForUpdatesToolStripMenuItem.Enabled = enabled));
            }else{
                checkForUpdatesToolStripMenuItem.Enabled = enabled;
            }
        }
        // DONATE LINK
        // ======================================================================================================
        private void DonateToolStripMenuItem_Click(object sender, EventArgs e){
            try{
                Process.Start(new ProcessStartInfo(TS_LinkSystem.ts_donate) { UseShellExecute = true });
            }catch (Exception){ }
        }
        // TS TOOL LAUNCHER MODULE
        // ======================================================================================================
        private void TSToolLauncher<T>(string formName, string langKey) where T : Form, new(){
            try{
                TSGetLangs software_lang = new TSGetLangs(lang_path);
                T tool = new T { Name = formName };
                if (Application.OpenForms[formName] == null){
                    tool.Show();
                }else{
                    if (Application.OpenForms[formName].WindowState == FormWindowState.Minimized){
                        Application.OpenForms[formName].WindowState = FormWindowState.Normal;
                    }
                    string public_message = string.Format(software_lang.TSReadLangs("HeaderHelp", "header_help_info_notification"), software_lang.TSReadLangs("HeaderMenu", langKey));
                    TS_MessageBoxEngine.TS_MessageBox(this, 1, public_message);
                    Application.OpenForms[formName].Activate();
                }
            }catch (Exception){ }
        }
        // ABOUT
        // ======================================================================================================
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e){
            TSToolLauncher<ZafuseAbout>("zafuse_about", "header_menu_about");
        }
        // EXIT
        // ======================================================================================================
        private void Software_exit() { Application.Exit(); }
        private void ZafuseMain_FormClosing(object sender, FormClosingEventArgs e){ Software_exit(); }
    }
}