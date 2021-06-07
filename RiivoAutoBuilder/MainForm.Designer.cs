﻿
namespace RiivoAutoBuilder
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seprToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.rightClickOnWhatYouWantToEditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.moreComingSoonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.advancedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.riivolutionDocumentationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dwwToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.releasesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gitHubIssuesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dasToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gameIDtextbox = new System.Windows.Forms.TextBox();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rsToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.moveUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sectionBox = new System.Windows.Forms.ListBox();
            this.optionBox = new System.Windows.Forms.ListBox();
            this.patchIDBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.patchesBox = new System.Windows.Forms.ListBox();
            this.temptextbox = new System.Windows.Forms.TextBox();
            this.traversebutton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.choiceBox = new System.Windows.Forms.ListBox();
            this.propertiesGroupBox = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.europe = new System.Windows.Forms.CheckBox();
            this.america = new System.Windows.Forms.CheckBox();
            this.japan = new System.Windows.Forms.CheckBox();
            this.korea = new System.Windows.Forms.CheckBox();
            this.gameidLabel = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.contextMenu.SuspendLayout();
            this.propertiesGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem1,
            this.toolsToolStripMenuItem,
            this.advancedToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(622, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.seprToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.NewButtonClicked);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.loadToolStripMenuItem.Text = "Open";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.OpenButtonClicked);
            // 
            // seprToolStripMenuItem
            // 
            this.seprToolStripMenuItem.Name = "seprToolStripMenuItem";
            this.seprToolStripMenuItem.Size = new System.Drawing.Size(183, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveButtonClicked);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Enabled = false;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsButtonClicked);
            // 
            // editToolStripMenuItem1
            // 
            this.editToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rightClickOnWhatYouWantToEditToolStripMenuItem});
            this.editToolStripMenuItem1.Name = "editToolStripMenuItem1";
            this.editToolStripMenuItem1.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem1.Text = "Edit";
            // 
            // rightClickOnWhatYouWantToEditToolStripMenuItem
            // 
            this.rightClickOnWhatYouWantToEditToolStripMenuItem.Enabled = false;
            this.rightClickOnWhatYouWantToEditToolStripMenuItem.Name = "rightClickOnWhatYouWantToEditToolStripMenuItem";
            this.rightClickOnWhatYouWantToEditToolStripMenuItem.Size = new System.Drawing.Size(264, 22);
            this.rightClickOnWhatYouWantToEditToolStripMenuItem.Text = "Right click on what you want to edit";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buildToolStripMenuItem1,
            this.toolStripSeparator1,
            this.moreComingSoonToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // buildToolStripMenuItem1
            // 
            this.buildToolStripMenuItem1.Name = "buildToolStripMenuItem1";
            this.buildToolStripMenuItem1.Size = new System.Drawing.Size(184, 22);
            this.buildToolStripMenuItem1.Text = "ISO Builder";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(181, 6);
            // 
            // moreComingSoonToolStripMenuItem
            // 
            this.moreComingSoonToolStripMenuItem.Enabled = false;
            this.moreComingSoonToolStripMenuItem.Name = "moreComingSoonToolStripMenuItem";
            this.moreComingSoonToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.moreComingSoonToolStripMenuItem.Text = "More coming soon...";
            // 
            // advancedToolStripMenuItem
            // 
            this.advancedToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.preferencesToolStripMenuItem});
            this.advancedToolStripMenuItem.Name = "advancedToolStripMenuItem";
            this.advancedToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.advancedToolStripMenuItem.Text = "Advanced";
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.preferencesToolStripMenuItem.Text = "Preferences";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.riivolutionDocumentationToolStripMenuItem,
            this.dwwToolStripMenuItem,
            this.releasesToolStripMenuItem,
            this.gitHubIssuesToolStripMenuItem,
            this.dasToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.aboutToolStripMenuItem.Text = "Help";
            // 
            // riivolutionDocumentationToolStripMenuItem
            // 
            this.riivolutionDocumentationToolStripMenuItem.Name = "riivolutionDocumentationToolStripMenuItem";
            this.riivolutionDocumentationToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.riivolutionDocumentationToolStripMenuItem.Text = "Documentation";
            // 
            // dwwToolStripMenuItem
            // 
            this.dwwToolStripMenuItem.Name = "dwwToolStripMenuItem";
            this.dwwToolStripMenuItem.Size = new System.Drawing.Size(156, 6);
            // 
            // releasesToolStripMenuItem
            // 
            this.releasesToolStripMenuItem.Name = "releasesToolStripMenuItem";
            this.releasesToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.releasesToolStripMenuItem.Text = "GitHub Releases";
            // 
            // gitHubIssuesToolStripMenuItem
            // 
            this.gitHubIssuesToolStripMenuItem.Name = "gitHubIssuesToolStripMenuItem";
            this.gitHubIssuesToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.gitHubIssuesToolStripMenuItem.Text = "GitHub Issues";
            // 
            // dasToolStripMenuItem
            // 
            this.dasToolStripMenuItem.Name = "dasToolStripMenuItem";
            this.dasToolStripMenuItem.Size = new System.Drawing.Size(156, 6);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.helpToolStripMenuItem.Text = "About";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.HelpButtonClicked);
            // 
            // gameIDtextbox
            // 
            this.gameIDtextbox.BackColor = System.Drawing.SystemColors.Window;
            this.gameIDtextbox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.gameIDtextbox.Enabled = false;
            this.gameIDtextbox.Location = new System.Drawing.Point(9, 15);
            this.gameIDtextbox.MaxLength = 3;
            this.gameIDtextbox.Name = "gameIDtextbox";
            this.gameIDtextbox.Size = new System.Drawing.Size(38, 20);
            this.gameIDtextbox.TabIndex = 7;
            this.gameIDtextbox.TextChanged += new System.EventHandler(this.gameIDtextbox_TextChanged);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewToolStripMenuItem,
            this.removeSelectedToolStripMenuItem,
            this.rsToolStripMenuItem,
            this.editToolStripMenuItem,
            this.hToolStripMenuItem,
            this.moveUpToolStripMenuItem,
            this.moveDownToolStripMenuItem});
            this.contextMenu.Name = "contextMenuStrip1";
            this.contextMenu.Size = new System.Drawing.Size(191, 126);
            this.contextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuOpened);
            // 
            // addNewToolStripMenuItem
            // 
            this.addNewToolStripMenuItem.Name = "addNewToolStripMenuItem";
            this.addNewToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.addNewToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.addNewToolStripMenuItem.Text = "Add Node";
            this.addNewToolStripMenuItem.Click += new System.EventHandler(this.ContextMenuAddPressed);
            // 
            // removeSelectedToolStripMenuItem
            // 
            this.removeSelectedToolStripMenuItem.Name = "removeSelectedToolStripMenuItem";
            this.removeSelectedToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.removeSelectedToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.removeSelectedToolStripMenuItem.Text = "Remove Node";
            this.removeSelectedToolStripMenuItem.Click += new System.EventHandler(this.ContextMenuRemovePressed);
            // 
            // rsToolStripMenuItem
            // 
            this.rsToolStripMenuItem.Name = "rsToolStripMenuItem";
            this.rsToolStripMenuItem.Size = new System.Drawing.Size(187, 6);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.editToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.editToolStripMenuItem.Text = "Edit Selected";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.ContextMenuEditPressed);
            // 
            // hToolStripMenuItem
            // 
            this.hToolStripMenuItem.Name = "hToolStripMenuItem";
            this.hToolStripMenuItem.Size = new System.Drawing.Size(187, 6);
            // 
            // moveUpToolStripMenuItem
            // 
            this.moveUpToolStripMenuItem.Name = "moveUpToolStripMenuItem";
            this.moveUpToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.moveUpToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.moveUpToolStripMenuItem.Text = "Move Up";
            this.moveUpToolStripMenuItem.Click += new System.EventHandler(this.ContextMenuMoveUpPressed);
            // 
            // moveDownToolStripMenuItem
            // 
            this.moveDownToolStripMenuItem.Name = "moveDownToolStripMenuItem";
            this.moveDownToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.K)));
            this.moveDownToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.moveDownToolStripMenuItem.Text = "Move Down";
            this.moveDownToolStripMenuItem.Click += new System.EventHandler(this.ContextMenuMoveDownPressed);
            // 
            // sectionBox
            // 
            this.sectionBox.ContextMenuStrip = this.contextMenu;
            this.sectionBox.Enabled = false;
            this.sectionBox.FormattingEnabled = true;
            this.sectionBox.Location = new System.Drawing.Point(12, 42);
            this.sectionBox.Name = "sectionBox";
            this.sectionBox.Size = new System.Drawing.Size(283, 82);
            this.sectionBox.TabIndex = 9;
            this.sectionBox.SelectedIndexChanged += new System.EventHandler(this.SectionBoxIndexChanged);
            // 
            // optionBox
            // 
            this.optionBox.ContextMenuStrip = this.contextMenu;
            this.optionBox.Enabled = false;
            this.optionBox.FormattingEnabled = true;
            this.optionBox.Location = new System.Drawing.Point(12, 146);
            this.optionBox.Name = "optionBox";
            this.optionBox.Size = new System.Drawing.Size(283, 82);
            this.optionBox.TabIndex = 10;
            this.optionBox.SelectedIndexChanged += new System.EventHandler(this.OptionBoxIndexChanged);
            // 
            // patchIDBox
            // 
            this.patchIDBox.ContextMenuStrip = this.contextMenu;
            this.patchIDBox.Enabled = false;
            this.patchIDBox.FormattingEnabled = true;
            this.patchIDBox.Location = new System.Drawing.Point(300, 42);
            this.patchIDBox.Name = "patchIDBox";
            this.patchIDBox.Size = new System.Drawing.Size(112, 186);
            this.patchIDBox.TabIndex = 11;
            this.patchIDBox.SelectedIndexChanged += new System.EventHandler(this.PatchIDBoxIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(301, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Patch ID List";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Options (for current section)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Sections";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 332);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(156, 13);
            this.label5.TabIndex = 41;
            this.label5.Text = "Patches enabled for this choice";
            // 
            // patchesBox
            // 
            this.patchesBox.ContextMenuStrip = this.contextMenu;
            this.patchesBox.Enabled = false;
            this.patchesBox.FormattingEnabled = true;
            this.patchesBox.Location = new System.Drawing.Point(12, 350);
            this.patchesBox.Name = "patchesBox";
            this.patchesBox.Size = new System.Drawing.Size(283, 82);
            this.patchesBox.TabIndex = 28;
            this.patchesBox.SelectedIndexChanged += new System.EventHandler(this.PatchesBoxIndexChanged);
            // 
            // temptextbox
            // 
            this.temptextbox.ContextMenuStrip = this.contextMenu;
            this.temptextbox.Location = new System.Drawing.Point(462, 496);
            this.temptextbox.Name = "temptextbox";
            this.temptextbox.Size = new System.Drawing.Size(148, 20);
            this.temptextbox.TabIndex = 53;
            // 
            // traversebutton
            // 
            this.traversebutton.Location = new System.Drawing.Point(12, 465);
            this.traversebutton.Name = "traversebutton";
            this.traversebutton.Size = new System.Drawing.Size(111, 23);
            this.traversebutton.TabIndex = 55;
            this.traversebutton.Text = "Traverse <options>";
            this.traversebutton.UseVisualStyleBackColor = true;
            this.traversebutton.Click += new System.EventHandler(this.traversebutton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 494);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 57;
            this.button1.Text = "Print xml ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.printtoconsole);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(9, 449);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(60, 13);
            this.label14.TabIndex = 58;
            this.label14.Text = "debugging:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 231);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Choices (for current option)";
            // 
            // choiceBox
            // 
            this.choiceBox.ContextMenuStrip = this.contextMenu;
            this.choiceBox.Enabled = false;
            this.choiceBox.FormattingEnabled = true;
            this.choiceBox.Location = new System.Drawing.Point(12, 247);
            this.choiceBox.Name = "choiceBox";
            this.choiceBox.Size = new System.Drawing.Size(283, 82);
            this.choiceBox.TabIndex = 17;
            this.choiceBox.SelectedIndexChanged += new System.EventHandler(this.ChoiceBoxIndexChanged);
            // 
            // propertiesGroupBox
            // 
            this.propertiesGroupBox.Controls.Add(this.button3);
            this.propertiesGroupBox.Controls.Add(this.textBox1);
            this.propertiesGroupBox.Controls.Add(this.label6);
            this.propertiesGroupBox.Controls.Add(this.europe);
            this.propertiesGroupBox.Controls.Add(this.america);
            this.propertiesGroupBox.Controls.Add(this.japan);
            this.propertiesGroupBox.Controls.Add(this.korea);
            this.propertiesGroupBox.Controls.Add(this.gameidLabel);
            this.propertiesGroupBox.Controls.Add(this.gameIDtextbox);
            this.propertiesGroupBox.Location = new System.Drawing.Point(418, 36);
            this.propertiesGroupBox.Name = "propertiesGroupBox";
            this.propertiesGroupBox.Size = new System.Drawing.Size(192, 396);
            this.propertiesGroupBox.TabIndex = 60;
            this.propertiesGroupBox.TabStop = false;
            this.propertiesGroupBox.Text = "Global Properties";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(9, 205);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(177, 20);
            this.button3.TabIndex = 18;
            this.button3.Text = "Set New Folder...";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(9, 183);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(177, 20);
            this.textBox1.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 166);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Wiidisc Root Folder";
            // 
            // europe
            // 
            this.europe.AutoSize = true;
            this.europe.Location = new System.Drawing.Point(9, 44);
            this.europe.Name = "europe";
            this.europe.Size = new System.Drawing.Size(89, 17);
            this.europe.TabIndex = 15;
            this.europe.Text = "PAL (Europe)";
            this.europe.UseVisualStyleBackColor = true;
            this.europe.CheckedChanged += new System.EventHandler(this.europe_CheckedChanged);
            // 
            // america
            // 
            this.america.AutoSize = true;
            this.america.Location = new System.Drawing.Point(9, 67);
            this.america.Name = "america";
            this.america.Size = new System.Drawing.Size(113, 17);
            this.america.TabIndex = 14;
            this.america.Text = "NTSC-U (America)";
            this.america.UseVisualStyleBackColor = true;
            // 
            // japan
            // 
            this.japan.AutoSize = true;
            this.japan.Location = new System.Drawing.Point(9, 90);
            this.japan.Name = "japan";
            this.japan.Size = new System.Drawing.Size(101, 17);
            this.japan.TabIndex = 13;
            this.japan.Text = "NTSC-J (Japan)";
            this.japan.UseVisualStyleBackColor = true;
            // 
            // korea
            // 
            this.korea.AutoSize = true;
            this.korea.Location = new System.Drawing.Point(9, 113);
            this.korea.Name = "korea";
            this.korea.Size = new System.Drawing.Size(102, 17);
            this.korea.TabIndex = 11;
            this.korea.Text = "NTSC-K (Korea)";
            this.korea.UseVisualStyleBackColor = true;
            // 
            // gameidLabel
            // 
            this.gameidLabel.AutoSize = true;
            this.gameidLabel.Location = new System.Drawing.Point(53, 18);
            this.gameidLabel.Name = "gameidLabel";
            this.gameidLabel.Size = new System.Drawing.Size(46, 13);
            this.gameidLabel.TabIndex = 8;
            this.gameidLabel.Text = "GameID";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(461, 465);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(25, 26);
            this.button4.TabIndex = 61;
            this.button4.Text = "s";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(488, 465);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(25, 26);
            this.button5.TabIndex = 62;
            this.button5.Text = "o";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(515, 465);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(25, 26);
            this.button6.TabIndex = 63;
            this.button6.Text = "c";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(542, 465);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(25, 26);
            this.button7.TabIndex = 64;
            this.button7.Text = "p";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(569, 465);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(41, 26);
            this.button8.TabIndex = 65;
            this.button8.Text = "pID";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 524);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.propertiesGroupBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.patchIDBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sectionBox);
            this.Controls.Add(this.optionBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.choiceBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.patchesBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.traversebutton);
            this.Controls.Add(this.temptextbox);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Riivolution Editor Thing";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenu.ResumeLayout(false);
            this.propertiesGroupBox.ResumeLayout(false);
            this.propertiesGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buildToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem1;
        private System.Windows.Forms.TextBox gameIDtextbox;
        private System.Windows.Forms.ListBox sectionBox;
        private System.Windows.Forms.ListBox optionBox;
        private System.Windows.Forms.ListBox patchIDBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem advancedToolStripMenuItem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox patchesBox;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem riivolutionDocumentationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem releasesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gitHubIssuesToolStripMenuItem;
        private System.Windows.Forms.TextBox temptextbox;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.Button traversebutton;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveDownToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeSelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator hToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator seprToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator dwwToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator dasToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator rsToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox choiceBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem moreComingSoonToolStripMenuItem;
        private System.Windows.Forms.GroupBox propertiesGroupBox;
        private System.Windows.Forms.Label gameidLabel;
        private System.Windows.Forms.CheckBox korea;
        private System.Windows.Forms.CheckBox japan;
        private System.Windows.Forms.CheckBox europe;
        private System.Windows.Forms.CheckBox america;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripMenuItem rightClickOnWhatYouWantToEditToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
    }
}

