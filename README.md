# Zafuse - Advanced Multi-INI Content Analysis Software

[![GitHub downloads](https://img.shields.io/github/downloads/turkaysoft/zafuse/total?style=flat&color=1a893c&label=Downloads)](https://github.com/turkaysoft/zafuse/releases)
[![GitHub stars](https://img.shields.io/github/stars/turkaysoft/zafuse?style=flat&color=0062cc&label=Stars)](https://github.com/turkaysoft/zafuse/stargazers)
[![GitHub release](https://img.shields.io/github/v/release/turkaysoft/zafuse?style=flat&color=5a32a3&label=Latest%20Release)](https://github.com/turkaysoft/zafuse/releases/latest)
[![Platform](https://img.shields.io/badge/platform-Windows-b31d28?style=flat&label=Platform)](https://github.com/turkaysoft/zafuse)

**Zafuse** is a high-performance **INI analysis tool** developed by **Eray Türkay**. Engineered for speed and precision, it is specifically designed to detect inconsistencies in multi-language configuration files. Whether you are managing complex localization datasets or auditing large-scale software configs, Zafuse pinpointing missing or desynchronized data with absolute precision.

---

### Donate
You can support this project by making a donation to help ensure its sustainability and the development of new features.

[![Buy Me A Coffee](https://img.shields.io/badge/Buy%20Me%20A%20Coffee-Donate-0a6628?style=flat&logo=buy-me-a-coffee&logoColor=white)](https://buymeacoffee.com/turkaysoft)

---

## Key Features

* **Privacy First:** Your data stays on your machine; no information is transferred to external servers.
* **Pure Performance:** Developed exclusively in **C# and .NET Framework** with no external libraries or dependencies.
* **Deep INI Comparison:** Audits keys, sections, and values across languages to find desynchronized data down to the specific line number.
* **Specialized Audit Layers:** Leverages a custom engine to detect punctuation errors, quotation marks, and placeholder inconsistencies.
* **Dynamic Customization:** Toggle analysis layers on-the-fly via **F6, F7, F8, F9, and F10** shortcuts during runtime.
* **Ultra-Fast Scanning:** Capable of analyzing massive datasets (thousands of lines) in less than half a second.
* **Professional Reporting:** Export detected inconsistencies and duplicate keys as rapid developer-focused debugging reports.
* **Modern UI:** Clean, intuitive interface compatible with Windows 11 design language, featuring Light, Dark, and System themes.
* **Multilingual:** It supports 15 different languages, primarily English. You can access the supported languages here: [Supported Languages](https://github.com/turkaysoft/zafuse/discussions/1)
* **Built-in Update Mechanism:** It features a built-in smart update mechanism developed specifically by **Türkaysoft**.

---

## Interface Preview

<img width="1010" height="633" alt="Zafuse UI" src="https://github.com/user-attachments/assets/755ceab1-c3f3-41cd-b356-28567c970aa3" />

---

## Getting Started

1.  Navigate to the **[Releases](https://github.com/turkaysoft/zafuse/releases/latest)** page.
2.  Download the latest ZIP file.
3.  **Extract all files from the ZIP** (Important: Application requires all folder contents to run correctly).
4.  Launch the executable corresponding to your architecture:
    * `Zafuse_x64.exe`: For standard 64-bit Intel/AMD systems.
    * `Zafuse_arm64.exe`: For ARM-based devices like Surface Pro.

---

## Translation Support

* **Translation Support:** Community-driven localization via the official [Translation Guide](https://github.com/turkaysoft/zafuse/discussions/1).

---

## System Requirements

| Feature | Minimum Requirements | Recommended Requirements |
| :--- | :--- | :--- |
| **OS** | Windows 10 22H2 x64 | Windows 11 25H2 x64 |
| **CPU** | x64 or ARM64 | x64 or ARM64 |
| **RAM** | 50 MB Free RAM | 75 MB Free RAM |
| **.NET** | .NET Framework 4.8.1 | .NET Framework 4.8.1 |

---

## Shortcut Keys

| Shortcut | Action |
|--|--|
| `F1` | Light Theme |
| `F2` | Dark Theme |
| `F3` | System Theme |
| `F4` | Starting With: Windowed |
| `F5` | Starting With: Full Screen |
| `F6` | Analysis Mode: Placeholders |
| `F7` | Analysis Mode: Punctuation Marks |
| `F8` | Analysis Mode: Quotation Marks |
| `F9` | Analysis Mode: Numbers |
| `F10` | Analysis Mode: Comment Lines |
| `F11` | Check Updates |
| `F12` | About |
| `CTRL + Alt + D` | Donate Page |
| `ESC` | Clear Selection |

---

## Security

* **Zero Data Export Policy:** Your privacy is our priority; no data leaves your machine.
* **No Dependencies:** Developed entirely from scratch using its own source code, there are no risks from security vulnerabilities in third-party libraries.
* **Open Source:** All source code for the program is open and can be reviewed by anyone.

---

## License

This software is offered free of charge as part of the **Türkaysoft solutions package** and is protected under the [**MIT License**](https://github.com/turkaysoft/zafuse?tab=MIT-1-ov-file).
