namespace AutoPatcherGUI
{
    partial class AM2RPatcherForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AM2RPatcherForm));
            this.AM2RHeaderPicturebox = new System.Windows.Forms.PictureBox();
            this.ToolStripStatus = new System.Windows.Forms.StatusStrip();
            this.FalseProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.LaunchButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.HQMusicCheckbox = new System.Windows.Forms.CheckBox();
            this.VersionLabel = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.ProgressBarStatus = new System.Windows.Forms.ProgressBar();
            this.CreateAPKButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.discordPictureBox = new System.Windows.Forms.PictureBox();
            this.redditPictureBox = new System.Windows.Forms.PictureBox();
            this.youtubePictureBox = new System.Windows.Forms.PictureBox();
            this.InfoTabControl = new System.Windows.Forms.TabControl();
            this.Tab_pNotes = new System.Windows.Forms.TabPage();
            this.patchNotesBrowserButton = new System.Windows.Forms.Button();
            this.PatchNotesWebBrowser = new System.Windows.Forms.WebBrowser();
            ((System.ComponentModel.ISupportInitialize)(this.AM2RHeaderPicturebox)).BeginInit();
            this.ToolStripStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.discordPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.redditPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.youtubePictureBox)).BeginInit();
            this.InfoTabControl.SuspendLayout();
            this.Tab_pNotes.SuspendLayout();
            this.SuspendLayout();
            // 
            // AM2RHeaderPicturebox
            // 
            this.AM2RHeaderPicturebox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AM2RHeaderPicturebox.BackColor = System.Drawing.Color.Transparent;
            this.AM2RHeaderPicturebox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AM2RHeaderPicturebox.BackgroundImage")));
            this.AM2RHeaderPicturebox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.AM2RHeaderPicturebox.Cursor = System.Windows.Forms.Cursors.Default;
            this.AM2RHeaderPicturebox.Location = new System.Drawing.Point(629, 12);
            this.AM2RHeaderPicturebox.Name = "AM2RHeaderPicturebox";
            this.AM2RHeaderPicturebox.Size = new System.Drawing.Size(204, 58);
            this.AM2RHeaderPicturebox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.AM2RHeaderPicturebox.TabIndex = 10;
            this.AM2RHeaderPicturebox.TabStop = false;
            this.AM2RHeaderPicturebox.Click += new System.EventHandler(this.AM2RHeaderPicturebox_Click);
            // 
            // ToolStripStatus
            // 
            this.ToolStripStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FalseProgressBar,
            this.StatusLabel});
            this.ToolStripStatus.Location = new System.Drawing.Point(0, 547);
            this.ToolStripStatus.Name = "ToolStripStatus";
            this.ToolStripStatus.Size = new System.Drawing.Size(1008, 22);
            this.ToolStripStatus.SizingGrip = false;
            this.ToolStripStatus.TabIndex = 13;
            this.ToolStripStatus.Text = "statusStrip1";
            // 
            // FalseProgressBar
            // 
            this.FalseProgressBar.Name = "FalseProgressBar";
            this.FalseProgressBar.Size = new System.Drawing.Size(100, 16);
            this.FalseProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(891, 17);
            this.StatusLabel.Spring = true;
            this.StatusLabel.Text = "Status Bar (show patch status)";
            this.StatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LaunchButton
            // 
            this.LaunchButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.LaunchButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LaunchButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LaunchButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(34)))), ((int)(((byte)(17)))));
            this.LaunchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LaunchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.5F);
            this.LaunchButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(188)))), ((int)(((byte)(35)))));
            this.LaunchButton.Location = new System.Drawing.Point(633, 212);
            this.LaunchButton.Name = "LaunchButton";
            this.LaunchButton.Size = new System.Drawing.Size(200, 34);
            this.LaunchButton.TabIndex = 14;
            this.LaunchButton.Text = "Update";
            this.LaunchButton.UseVisualStyleBackColor = false;
            this.LaunchButton.Click += new System.EventHandler(this.Button1_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.CloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.CloseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(34)))), ((int)(((byte)(17)))));
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.5F);
            this.CloseButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(188)))), ((int)(((byte)(35)))));
            this.CloseButton.Location = new System.Drawing.Point(633, 310);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(200, 34);
            this.CloseButton.TabIndex = 15;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // HQMusicCheckbox
            // 
            this.HQMusicCheckbox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.HQMusicCheckbox.AutoSize = true;
            this.HQMusicCheckbox.BackColor = System.Drawing.Color.Transparent;
            this.HQMusicCheckbox.Checked = true;
            this.HQMusicCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.HQMusicCheckbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HQMusicCheckbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(188)))), ((int)(((byte)(35)))));
            this.HQMusicCheckbox.Location = new System.Drawing.Point(635, 350);
            this.HQMusicCheckbox.Name = "HQMusicCheckbox";
            this.HQMusicCheckbox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.HQMusicCheckbox.Size = new System.Drawing.Size(201, 17);
            this.HQMusicCheckbox.TabIndex = 16;
            this.HQMusicCheckbox.Text = "Use high quality music when updating";
            this.HQMusicCheckbox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.HQMusicCheckbox, "Check this box to install the high quality music when installing or updating.");
            this.HQMusicCheckbox.UseVisualStyleBackColor = false;
            this.HQMusicCheckbox.CheckedChanged += new System.EventHandler(this.HQMusicCheckbox_CheckedChanged);
            // 
            // VersionLabel
            // 
            this.VersionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.VersionLabel.AutoSize = true;
            this.VersionLabel.BackColor = System.Drawing.Color.Transparent;
            this.VersionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(188)))), ((int)(((byte)(35)))));
            this.VersionLabel.Location = new System.Drawing.Point(900, 3);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(108, 13);
            this.VersionLabel.TabIndex = 19;
            this.VersionLabel.Text = "Launcher Version 1.1";
            this.VersionLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.VersionLabel.Click += new System.EventHandler(this.VersionLabel_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "AM2RLauncher minimized!";
            // 
            // ProgressBarStatus
            // 
            this.ProgressBarStatus.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ProgressBarStatus.Location = new System.Drawing.Point(0, 547);
            this.ProgressBarStatus.Name = "ProgressBarStatus";
            this.ProgressBarStatus.Size = new System.Drawing.Size(103, 22);
            this.ProgressBarStatus.TabIndex = 20;
            this.ProgressBarStatus.Click += new System.EventHandler(this.ProgressBarStatus_Click);
            // 
            // CreateAPKButton
            // 
            this.CreateAPKButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.CreateAPKButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.CreateAPKButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CreateAPKButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(34)))), ((int)(((byte)(17)))));
            this.CreateAPKButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateAPKButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.5F);
            this.CreateAPKButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(188)))), ((int)(((byte)(35)))));
            this.CreateAPKButton.Location = new System.Drawing.Point(633, 261);
            this.CreateAPKButton.Name = "CreateAPKButton";
            this.CreateAPKButton.Size = new System.Drawing.Size(200, 34);
            this.CreateAPKButton.TabIndex = 21;
            this.CreateAPKButton.Text = "Create .APK";
            this.toolTip1.SetToolTip(this.CreateAPKButton, "Creates an .APK that can be installed on an Android device.");
            this.CreateAPKButton.UseVisualStyleBackColor = false;
            this.CreateAPKButton.Click += new System.EventHandler(this.CreateAPKButton_Click);
            // 
            // discordPictureBox
            // 
            this.discordPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.discordPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.discordPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("discordPictureBox.Image")));
            this.discordPictureBox.Location = new System.Drawing.Point(771, 376);
            this.discordPictureBox.Name = "discordPictureBox";
            this.discordPictureBox.Size = new System.Drawing.Size(48, 48);
            this.discordPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.discordPictureBox.TabIndex = 22;
            this.discordPictureBox.TabStop = false;
            this.toolTip1.SetToolTip(this.discordPictureBox, "http://discord.gg/M9jAYwWXda");
            this.discordPictureBox.Click += new System.EventHandler(this.PictureBox1_Click);
            // 
            // redditPictureBox
            // 
            this.redditPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.redditPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.redditPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("redditPictureBox.Image")));
            this.redditPictureBox.Location = new System.Drawing.Point(653, 380);
            this.redditPictureBox.Name = "redditPictureBox";
            this.redditPictureBox.Size = new System.Drawing.Size(40, 36);
            this.redditPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.redditPictureBox.TabIndex = 23;
            this.redditPictureBox.TabStop = false;
            this.toolTip1.SetToolTip(this.redditPictureBox, "www.reddit.com/r/AM2R");
            this.redditPictureBox.Click += new System.EventHandler(this.RedditPictureBox_Click);
            // 
            // youtubePictureBox
            // 
            this.youtubePictureBox.BackColor = System.Drawing.Color.Transparent;
            this.youtubePictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.youtubePictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.youtubePictureBox.Image = ((System.Drawing.Image)(resources.GetObject("youtubePictureBox.Image")));
            this.youtubePictureBox.Location = new System.Drawing.Point(710, 380);
            this.youtubePictureBox.Name = "youtubePictureBox";
            this.youtubePictureBox.Size = new System.Drawing.Size(50, 36);
            this.youtubePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.youtubePictureBox.TabIndex = 24;
            this.youtubePictureBox.TabStop = false;
            this.toolTip1.SetToolTip(this.youtubePictureBox, "https://www.youtube.com/channel/UCptc9QWOMS_BUsr02hsSQQg");
            this.youtubePictureBox.Click += new System.EventHandler(this.PictureBox1_Click_1);
            // 
            // InfoTabControl
            // 
            this.InfoTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InfoTabControl.Controls.Add(this.Tab_pNotes);
            this.InfoTabControl.HotTrack = true;
            this.InfoTabControl.Location = new System.Drawing.Point(12, 12);
            this.InfoTabControl.Name = "InfoTabControl";
            this.InfoTabControl.SelectedIndex = 0;
            this.InfoTabControl.Size = new System.Drawing.Size(405, 529);
            this.InfoTabControl.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.InfoTabControl.TabIndex = 0;
            // 
            // Tab_pNotes
            // 
            this.Tab_pNotes.Controls.Add(this.patchNotesBrowserButton);
            this.Tab_pNotes.Controls.Add(this.PatchNotesWebBrowser);
            this.Tab_pNotes.Location = new System.Drawing.Point(4, 22);
            this.Tab_pNotes.Name = "Tab_pNotes";
            this.Tab_pNotes.Padding = new System.Windows.Forms.Padding(3);
            this.Tab_pNotes.Size = new System.Drawing.Size(397, 503);
            this.Tab_pNotes.TabIndex = 1;
            this.Tab_pNotes.Text = "Patch Notes";
            this.Tab_pNotes.UseVisualStyleBackColor = true;
            // 
            // patchNotesBrowserButton
            // 
            this.patchNotesBrowserButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.patchNotesBrowserButton.Location = new System.Drawing.Point(3, 477);
            this.patchNotesBrowserButton.Name = "patchNotesBrowserButton";
            this.patchNotesBrowserButton.Size = new System.Drawing.Size(391, 23);
            this.patchNotesBrowserButton.TabIndex = 1;
            this.patchNotesBrowserButton.Text = "Open Full Changelog in Web Browser";
            this.patchNotesBrowserButton.UseVisualStyleBackColor = true;
            this.patchNotesBrowserButton.Click += new System.EventHandler(this.patchNotesBrowserButton_Click);
            // 
            // PatchNotesWebBrowser
            // 
            this.PatchNotesWebBrowser.Location = new System.Drawing.Point(0, 3);
            this.PatchNotesWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.PatchNotesWebBrowser.Name = "PatchNotesWebBrowser";
            this.PatchNotesWebBrowser.Size = new System.Drawing.Size(394, 470);
            this.PatchNotesWebBrowser.TabIndex = 22;
            // 
            // AM2RPatcherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1008, 569);
            this.Controls.Add(this.youtubePictureBox);
            this.Controls.Add(this.redditPictureBox);
            this.Controls.Add(this.discordPictureBox);
            this.Controls.Add(this.ProgressBarStatus);
            this.Controls.Add(this.CreateAPKButton);
            this.Controls.Add(this.VersionLabel);
            this.Controls.Add(this.HQMusicCheckbox);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.LaunchButton);
            this.Controls.Add(this.ToolStripStatus);
            this.Controls.Add(this.InfoTabControl);
            this.Controls.Add(this.AM2RHeaderPicturebox);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AM2RPatcherForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "AM2R Launcher";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AM2RHeaderPicturebox)).EndInit();
            this.ToolStripStatus.ResumeLayout(false);
            this.ToolStripStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.discordPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.redditPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.youtubePictureBox)).EndInit();
            this.InfoTabControl.ResumeLayout(false);
            this.Tab_pNotes.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox AM2RHeaderPicturebox;

        private System.Windows.Forms.StatusStrip ToolStripStatus;

        private System.Windows.Forms.ToolStripProgressBar FalseProgressBar;

        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;

        private System.Windows.Forms.Button LaunchButton;

        private System.Windows.Forms.Button CloseButton;

        private System.Windows.Forms.CheckBox HQMusicCheckbox;

        private System.Windows.Forms.Label VersionLabel;

        private System.Windows.Forms.NotifyIcon notifyIcon1;

        private System.Windows.Forms.ProgressBar ProgressBarStatus;

        private System.Windows.Forms.Button CreateAPKButton;

        private System.Windows.Forms.ToolTip toolTip1;

        private System.Windows.Forms.TabPage Tab_Announce;

        private System.Windows.Forms.TabControl InfoTabControl;

        private System.Windows.Forms.TabPage Tab_pNotes;

        private System.Windows.Forms.WebBrowser PatchNotesWebBrowser;

        private System.Windows.Forms.Button patchNotesBrowserButton;

        private System.Windows.Forms.PictureBox discordPictureBox;

        private System.Windows.Forms.PictureBox redditPictureBox;

        private System.Windows.Forms.PictureBox youtubePictureBox;
    }
}

