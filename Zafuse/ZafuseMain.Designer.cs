namespace Zafuse
{
    partial class ZafuseMain
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.HeaderMenu = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.themeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lightThemeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.darkThemeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemThemeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arabicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chineseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dutchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.frenchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.germanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hindiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.italianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.japaneseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.koreanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.polishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.portugueseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.russianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spanishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.turkishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fullScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contentAnalysis = new System.Windows.Forms.ToolStripMenuItem();
            this.caPlaceholders = new System.Windows.Forms.ToolStripMenuItem();
            this.caPunctuationMarks = new System.Windows.Forms.ToolStripMenuItem();
            this.caNailSigns = new System.Windows.Forms.ToolStripMenuItem();
            this.caNumbers = new System.Windows.Forms.ToolStripMenuItem();
            this.caCommentLines = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.donateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.BackPanel = new System.Windows.Forms.Panel();
            this.BtnGenReport = new Zafuse.TSCustomButton();
            this.SelDGV = new System.Windows.Forms.DataGridView();
            this.BtnRemoveFolder = new Zafuse.TSCustomButton();
            this.MainDGV = new System.Windows.Forms.DataGridView();
            this.BtnAddFolder = new Zafuse.TSCustomButton();
            this.HeaderMenu.SuspendLayout();
            this.BackPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SelDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // HeaderMenu
            // 
            this.HeaderMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.donateToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.HeaderMenu.Location = new System.Drawing.Point(0, 0);
            this.HeaderMenu.Name = "HeaderMenu";
            this.HeaderMenu.Size = new System.Drawing.Size(1008, 24);
            this.HeaderMenu.TabIndex = 0;
            this.HeaderMenu.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.themeToolStripMenuItem,
            this.languageToolStripMenuItem,
            this.startupToolStripMenuItem,
            this.contentAnalysis,
            this.checkForUpdatesToolStripMenuItem});
            this.settingsToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // themeToolStripMenuItem
            // 
            this.themeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lightThemeToolStripMenuItem,
            this.darkThemeToolStripMenuItem,
            this.systemThemeToolStripMenuItem});
            this.themeToolStripMenuItem.Name = "themeToolStripMenuItem";
            this.themeToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.themeToolStripMenuItem.Text = "Theme";
            // 
            // lightThemeToolStripMenuItem
            // 
            this.lightThemeToolStripMenuItem.Name = "lightThemeToolStripMenuItem";
            this.lightThemeToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.lightThemeToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.lightThemeToolStripMenuItem.Text = "Ligth Theme";
            this.lightThemeToolStripMenuItem.Click += new System.EventHandler(this.LightThemeToolStripMenuItem_Click);
            // 
            // darkThemeToolStripMenuItem
            // 
            this.darkThemeToolStripMenuItem.Name = "darkThemeToolStripMenuItem";
            this.darkThemeToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.darkThemeToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.darkThemeToolStripMenuItem.Text = "Dark Theme";
            this.darkThemeToolStripMenuItem.Click += new System.EventHandler(this.DarkThemeToolStripMenuItem_Click);
            // 
            // systemThemeToolStripMenuItem
            // 
            this.systemThemeToolStripMenuItem.Name = "systemThemeToolStripMenuItem";
            this.systemThemeToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.systemThemeToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.systemThemeToolStripMenuItem.Text = "System Theme";
            this.systemThemeToolStripMenuItem.Click += new System.EventHandler(this.SystemThemeToolStripMenuItem_Click);
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arabicToolStripMenuItem,
            this.chineseToolStripMenuItem,
            this.englishToolStripMenuItem,
            this.dutchToolStripMenuItem,
            this.frenchToolStripMenuItem,
            this.germanToolStripMenuItem,
            this.hindiToolStripMenuItem,
            this.italianToolStripMenuItem,
            this.japaneseToolStripMenuItem,
            this.koreanToolStripMenuItem,
            this.polishToolStripMenuItem,
            this.portugueseToolStripMenuItem,
            this.russianToolStripMenuItem,
            this.spanishToolStripMenuItem,
            this.turkishToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            this.languageToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.languageToolStripMenuItem.Text = "Language";
            // 
            // arabicToolStripMenuItem
            // 
            this.arabicToolStripMenuItem.Name = "arabicToolStripMenuItem";
            this.arabicToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.arabicToolStripMenuItem.Text = "Arabic";
            // 
            // chineseToolStripMenuItem
            // 
            this.chineseToolStripMenuItem.Name = "chineseToolStripMenuItem";
            this.chineseToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.chineseToolStripMenuItem.Text = "Chinese";
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            this.englishToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.englishToolStripMenuItem.Text = "English";
            // 
            // dutchToolStripMenuItem
            // 
            this.dutchToolStripMenuItem.Name = "dutchToolStripMenuItem";
            this.dutchToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.dutchToolStripMenuItem.Text = "Dutch";
            // 
            // frenchToolStripMenuItem
            // 
            this.frenchToolStripMenuItem.Name = "frenchToolStripMenuItem";
            this.frenchToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.frenchToolStripMenuItem.Text = "French";
            // 
            // germanToolStripMenuItem
            // 
            this.germanToolStripMenuItem.Name = "germanToolStripMenuItem";
            this.germanToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.germanToolStripMenuItem.Text = "German";
            // 
            // hindiToolStripMenuItem
            // 
            this.hindiToolStripMenuItem.Name = "hindiToolStripMenuItem";
            this.hindiToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.hindiToolStripMenuItem.Text = "Hindi";
            // 
            // italianToolStripMenuItem
            // 
            this.italianToolStripMenuItem.Name = "italianToolStripMenuItem";
            this.italianToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.italianToolStripMenuItem.Text = "Italian";
            // 
            // japaneseToolStripMenuItem
            // 
            this.japaneseToolStripMenuItem.Name = "japaneseToolStripMenuItem";
            this.japaneseToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.japaneseToolStripMenuItem.Text = "Japanese";
            // 
            // koreanToolStripMenuItem
            // 
            this.koreanToolStripMenuItem.Name = "koreanToolStripMenuItem";
            this.koreanToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.koreanToolStripMenuItem.Text = "Korean";
            // 
            // polishToolStripMenuItem
            // 
            this.polishToolStripMenuItem.Name = "polishToolStripMenuItem";
            this.polishToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.polishToolStripMenuItem.Text = "Polish";
            // 
            // portugueseToolStripMenuItem
            // 
            this.portugueseToolStripMenuItem.Name = "portugueseToolStripMenuItem";
            this.portugueseToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.portugueseToolStripMenuItem.Text = "Portuguese";
            // 
            // russianToolStripMenuItem
            // 
            this.russianToolStripMenuItem.Name = "russianToolStripMenuItem";
            this.russianToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.russianToolStripMenuItem.Text = "Russian";
            // 
            // spanishToolStripMenuItem
            // 
            this.spanishToolStripMenuItem.Name = "spanishToolStripMenuItem";
            this.spanishToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.spanishToolStripMenuItem.Text = "Spanish";
            // 
            // turkishToolStripMenuItem
            // 
            this.turkishToolStripMenuItem.Name = "turkishToolStripMenuItem";
            this.turkishToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.turkishToolStripMenuItem.Text = "Turkish";
            // 
            // startupToolStripMenuItem
            // 
            this.startupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.windowedToolStripMenuItem,
            this.fullScreenToolStripMenuItem});
            this.startupToolStripMenuItem.Name = "startupToolStripMenuItem";
            this.startupToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.startupToolStripMenuItem.Text = "Startup";
            // 
            // windowedToolStripMenuItem
            // 
            this.windowedToolStripMenuItem.Name = "windowedToolStripMenuItem";
            this.windowedToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.windowedToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.windowedToolStripMenuItem.Text = "Windowed";
            this.windowedToolStripMenuItem.Click += new System.EventHandler(this.WindowedToolStripMenuItem_Click);
            // 
            // fullScreenToolStripMenuItem
            // 
            this.fullScreenToolStripMenuItem.Name = "fullScreenToolStripMenuItem";
            this.fullScreenToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.fullScreenToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.fullScreenToolStripMenuItem.Text = "Full Screen";
            this.fullScreenToolStripMenuItem.Click += new System.EventHandler(this.FullScreenToolStripMenuItem_Click);
            // 
            // contentAnalysis
            // 
            this.contentAnalysis.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.caPlaceholders,
            this.caPunctuationMarks,
            this.caNailSigns,
            this.caNumbers,
            this.caCommentLines});
            this.contentAnalysis.Name = "contentAnalysis";
            this.contentAnalysis.Size = new System.Drawing.Size(173, 22);
            this.contentAnalysis.Text = "İçerik Analizi";
            // 
            // caPlaceholders
            // 
            this.caPlaceholders.Name = "caPlaceholders";
            this.caPlaceholders.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.caPlaceholders.Size = new System.Drawing.Size(198, 22);
            this.caPlaceholders.Text = "Yer Sağlayıcılar";
            // 
            // caPunctuationMarks
            // 
            this.caPunctuationMarks.Name = "caPunctuationMarks";
            this.caPunctuationMarks.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.caPunctuationMarks.Size = new System.Drawing.Size(198, 22);
            this.caPunctuationMarks.Text = "Noktalama İşaretleri";
            // 
            // caNailSigns
            // 
            this.caNailSigns.Name = "caNailSigns";
            this.caNailSigns.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.caNailSigns.Size = new System.Drawing.Size(198, 22);
            this.caNailSigns.Text = "Tırnak İşaretleri";
            // 
            // caNumbers
            // 
            this.caNumbers.Name = "caNumbers";
            this.caNumbers.ShortcutKeys = System.Windows.Forms.Keys.F9;
            this.caNumbers.Size = new System.Drawing.Size(198, 22);
            this.caNumbers.Text = "Sayılar";
            // 
            // caCommentLines
            // 
            this.caCommentLines.Name = "caCommentLines";
            this.caCommentLines.ShortcutKeys = System.Windows.Forms.Keys.F10;
            this.caCommentLines.Size = new System.Drawing.Size(198, 22);
            this.caCommentLines.Text = "Yorum Satırları";
            // 
            // checkForUpdatesToolStripMenuItem
            // 
            this.checkForUpdatesToolStripMenuItem.Name = "checkForUpdatesToolStripMenuItem";
            this.checkForUpdatesToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F11;
            this.checkForUpdatesToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.checkForUpdatesToolStripMenuItem.Text = "Check Update";
            this.checkForUpdatesToolStripMenuItem.Click += new System.EventHandler(this.CheckForUpdatesToolStripMenuItem_Click);
            // 
            // donateToolStripMenuItem
            // 
            this.donateToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.donateToolStripMenuItem.Name = "donateToolStripMenuItem";
            this.donateToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt)
            | System.Windows.Forms.Keys.D)));
            this.donateToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.donateToolStripMenuItem.Text = "Donate";
            this.donateToolStripMenuItem.Click += new System.EventHandler(this.DonateToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F12;
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // MainToolTip
            // 
            this.MainToolTip.OwnerDraw = true;
            this.MainToolTip.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.MainToolTip_Draw);
            // 
            // BackPanel
            // 
            this.BackPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackPanel.Controls.Add(this.BtnGenReport);
            this.BackPanel.Controls.Add(this.SelDGV);
            this.BackPanel.Controls.Add(this.BtnRemoveFolder);
            this.BackPanel.Controls.Add(this.MainDGV);
            this.BackPanel.Controls.Add(this.BtnAddFolder);
            this.BackPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BackPanel.Location = new System.Drawing.Point(0, 24);
            this.BackPanel.Name = "BackPanel";
            this.BackPanel.Padding = new System.Windows.Forms.Padding(5, 5, 8, 5);
            this.BackPanel.Size = new System.Drawing.Size(1008, 577);
            this.BackPanel.TabIndex = 1;
            // 
            // BtnGenReport
            // 
            this.BtnGenReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnGenReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(32)))), ((int)(((byte)(81)))));
            this.BtnGenReport.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(32)))), ((int)(((byte)(81)))));
            this.BtnGenReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnGenReport.BorderColor = System.Drawing.Color.SlateBlue;
            this.BtnGenReport.BorderRadius = 10;
            this.BtnGenReport.BorderSize = 0;
            this.BtnGenReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnGenReport.FlatAppearance.BorderSize = 0;
            this.BtnGenReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGenReport.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.BtnGenReport.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnGenReport.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnGenReport.Location = new System.Drawing.Point(746, 113);
            this.BtnGenReport.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.BtnGenReport.Name = "BtnGenReport";
            this.BtnGenReport.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.BtnGenReport.Size = new System.Drawing.Size(250, 36);
            this.BtnGenReport.TabIndex = 3;
            this.BtnGenReport.Text = "Rapor Oluştur";
            this.BtnGenReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnGenReport.TextColor = System.Drawing.Color.WhiteSmoke;
            this.BtnGenReport.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.BtnGenReport.UseVisualStyleBackColor = false;
            this.BtnGenReport.Click += new System.EventHandler(this.BtnGenReport_Click);
            // 
            // SelDGV
            // 
            this.SelDGV.AllowUserToAddRows = false;
            this.SelDGV.AllowUserToDeleteRows = false;
            this.SelDGV.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
            this.SelDGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.SelDGV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SelDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.SelDGV.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.SelDGV.BackgroundColor = System.Drawing.Color.White;
            this.SelDGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SelDGV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(87)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(87)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.SelDGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.SelDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SelDGV.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(87)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SelDGV.DefaultCellStyle = dataGridViewCellStyle3;
            this.SelDGV.EnableHeadersVisualStyles = false;
            this.SelDGV.GridColor = System.Drawing.Color.Gray;
            this.SelDGV.Location = new System.Drawing.Point(12, 15);
            this.SelDGV.Margin = new System.Windows.Forms.Padding(3, 10, 10, 3);
            this.SelDGV.MultiSelect = false;
            this.SelDGV.Name = "SelDGV";
            this.SelDGV.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(87)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SelDGV.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.SelDGV.RowHeadersVisible = false;
            this.SelDGV.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.SelDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.SelDGV.Size = new System.Drawing.Size(721, 177);
            this.SelDGV.TabIndex = 0;
            this.SelDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SelDGV_CellClick);
            this.SelDGV.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelDGV_KeyDown);
            // 
            // BtnRemoveFolder
            // 
            this.BtnRemoveFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnRemoveFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(32)))), ((int)(((byte)(81)))));
            this.BtnRemoveFolder.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(32)))), ((int)(((byte)(81)))));
            this.BtnRemoveFolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnRemoveFolder.BorderColor = System.Drawing.Color.SlateBlue;
            this.BtnRemoveFolder.BorderRadius = 10;
            this.BtnRemoveFolder.BorderSize = 0;
            this.BtnRemoveFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnRemoveFolder.FlatAppearance.BorderSize = 0;
            this.BtnRemoveFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRemoveFolder.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.BtnRemoveFolder.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnRemoveFolder.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnRemoveFolder.Location = new System.Drawing.Point(746, 64);
            this.BtnRemoveFolder.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.BtnRemoveFolder.Name = "BtnRemoveFolder";
            this.BtnRemoveFolder.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.BtnRemoveFolder.Size = new System.Drawing.Size(250, 36);
            this.BtnRemoveFolder.TabIndex = 2;
            this.BtnRemoveFolder.Text = "Klasörü Kaldır";
            this.BtnRemoveFolder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnRemoveFolder.TextColor = System.Drawing.Color.WhiteSmoke;
            this.BtnRemoveFolder.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.BtnRemoveFolder.UseVisualStyleBackColor = false;
            this.BtnRemoveFolder.Click += new System.EventHandler(this.BtnRemoveFolder_Click);
            // 
            // MainDGV
            // 
            this.MainDGV.AllowUserToAddRows = false;
            this.MainDGV.AllowUserToDeleteRows = false;
            this.MainDGV.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
            this.MainDGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.MainDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MainDGV.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.MainDGV.BackgroundColor = System.Drawing.Color.White;
            this.MainDGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MainDGV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(87)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(87)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.MainDGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.MainDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MainDGV.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(87)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.MainDGV.DefaultCellStyle = dataGridViewCellStyle7;
            this.MainDGV.EnableHeadersVisualStyles = false;
            this.MainDGV.GridColor = System.Drawing.Color.Gray;
            this.MainDGV.Location = new System.Drawing.Point(12, 205);
            this.MainDGV.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.MainDGV.MultiSelect = false;
            this.MainDGV.Name = "MainDGV";
            this.MainDGV.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(87)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.MainDGV.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.MainDGV.RowHeadersVisible = false;
            this.MainDGV.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.MainDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.MainDGV.Size = new System.Drawing.Size(984, 360);
            this.MainDGV.TabIndex = 4;
            this.MainDGV.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.MainDGV_CellFormatting);
            // 
            // BtnAddFolder
            // 
            this.BtnAddFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnAddFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(32)))), ((int)(((byte)(81)))));
            this.BtnAddFolder.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(32)))), ((int)(((byte)(81)))));
            this.BtnAddFolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnAddFolder.BorderColor = System.Drawing.Color.SlateBlue;
            this.BtnAddFolder.BorderRadius = 10;
            this.BtnAddFolder.BorderSize = 0;
            this.BtnAddFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAddFolder.FlatAppearance.BorderSize = 0;
            this.BtnAddFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAddFolder.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.BtnAddFolder.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnAddFolder.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnAddFolder.Location = new System.Drawing.Point(746, 15);
            this.BtnAddFolder.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.BtnAddFolder.Name = "BtnAddFolder";
            this.BtnAddFolder.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.BtnAddFolder.Size = new System.Drawing.Size(250, 36);
            this.BtnAddFolder.TabIndex = 1;
            this.BtnAddFolder.Text = "Klasör Ekle";
            this.BtnAddFolder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnAddFolder.TextColor = System.Drawing.Color.WhiteSmoke;
            this.BtnAddFolder.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.BtnAddFolder.UseVisualStyleBackColor = false;
            this.BtnAddFolder.Click += new System.EventHandler(this.BtnAddFolder_Click);
            // 
            // ZafuseMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(30)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(1008, 601);
            this.Controls.Add(this.BackPanel);
            this.Controls.Add(this.HeaderMenu);
            this.DoubleBuffered = true;
            this.Icon = global::Zafuse.Properties.Resources.ZafuseLogo;
            this.KeyPreview = true;
            this.MainMenuStrip = this.HeaderMenu;
            this.MinimumSize = new System.Drawing.Size(1024, 640);
            this.Name = "ZafuseMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zafuse";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ZafuseMain_FormClosing);
            this.Load += new System.EventHandler(this.ZafuseMain_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.ZafuseMain_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.ZafuseMain_DragEnter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ZafuseMain_KeyDown);
            this.HeaderMenu.ResumeLayout(false);
            this.HeaderMenu.PerformLayout();
            this.BackPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SelDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip HeaderMenu;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem themeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lightThemeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem darkThemeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem systemThemeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem turkishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem donateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkForUpdatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fullScreenToolStripMenuItem;
        private System.Windows.Forms.ToolTip MainToolTip;
        private System.Windows.Forms.ToolStripMenuItem arabicToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chineseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem frenchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem germanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hindiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem italianToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem japaneseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem koreanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem polishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem portugueseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spanishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem russianToolStripMenuItem;
        private System.Windows.Forms.Panel BackPanel;
        private TSCustomButton BtnAddFolder;
        private System.Windows.Forms.ToolStripMenuItem dutchToolStripMenuItem;
        private System.Windows.Forms.DataGridView MainDGV;
        private TSCustomButton BtnRemoveFolder;
        private System.Windows.Forms.ToolStripMenuItem contentAnalysis;
        private System.Windows.Forms.ToolStripMenuItem caPlaceholders;
        private System.Windows.Forms.ToolStripMenuItem caPunctuationMarks;
        private System.Windows.Forms.ToolStripMenuItem caNailSigns;
        private System.Windows.Forms.DataGridView SelDGV;
        private System.Windows.Forms.ToolStripMenuItem caCommentLines;
        private TSCustomButton BtnGenReport;
        private System.Windows.Forms.ToolStripMenuItem caNumbers;
    }
}
