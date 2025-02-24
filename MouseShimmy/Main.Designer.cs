namespace MouseShimmy
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            TitleLabel = new Label();
            VersionLabel = new Label();
            CopyLabel = new Label();
            ActivateButton = new Button();
            HideButton = new Button();
            TrayIcon = new NotifyIcon(components);
            StatusLabel = new Label();
            HotKeyLabel = new Label();
            ProgramTimer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // TitleLabel
            // 
            TitleLabel.AutoSize = true;
            TitleLabel.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TitleLabel.Location = new Point(12, 8);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new Size(108, 19);
            TitleLabel.TabIndex = 0;
            TitleLabel.Text = "MouseShimmy";
            // 
            // VersionLabel
            // 
            VersionLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            VersionLabel.AutoSize = true;
            VersionLabel.Font = new Font("Consolas", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            VersionLabel.Location = new Point(261, 13);
            VersionLabel.Name = "VersionLabel";
            VersionLabel.Size = new Size(31, 13);
            VersionLabel.TabIndex = 1;
            VersionLabel.Text = "v1.0";
            // 
            // CopyLabel
            // 
            CopyLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            CopyLabel.Location = new Point(12, 32);
            CopyLabel.Name = "CopyLabel";
            CopyLabel.Size = new Size(280, 62);
            CopyLabel.TabIndex = 2;
            CopyLabel.Text = "MouseShimmy is an app to move the mouse around the screen to random positions at random intervals to continually keep the computer in an active state.";
            // 
            // ActivateButton
            // 
            ActivateButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ActivateButton.FlatStyle = FlatStyle.Flat;
            ActivateButton.Location = new Point(192, 126);
            ActivateButton.Name = "ActivateButton";
            ActivateButton.Size = new Size(100, 23);
            ActivateButton.TabIndex = 3;
            ActivateButton.Text = "Activate";
            ActivateButton.UseVisualStyleBackColor = true;
            ActivateButton.Click += ActivateButton_Click;
            // 
            // HideButton
            // 
            HideButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            HideButton.FlatStyle = FlatStyle.Flat;
            HideButton.Location = new Point(12, 126);
            HideButton.Name = "HideButton";
            HideButton.Size = new Size(100, 23);
            HideButton.TabIndex = 4;
            HideButton.Text = "Hide";
            HideButton.UseVisualStyleBackColor = true;
            HideButton.Click += HideButton_Click;
            // 
            // TrayIcon
            // 
            TrayIcon.Text = "MouseShimmy";
            TrayIcon.Visible = true;
            TrayIcon.Click += TrayIcon_Click;
            // 
            // StatusLabel
            // 
            StatusLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            StatusLabel.Font = new Font("Consolas", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            StatusLabel.ForeColor = Color.Orange;
            StatusLabel.Location = new Point(12, 92);
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Size = new Size(280, 25);
            StatusLabel.TabIndex = 5;
            StatusLabel.Text = "Inactive";
            StatusLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // HotKeyLabel
            // 
            HotKeyLabel.AutoSize = true;
            HotKeyLabel.Font = new Font("Consolas", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            HotKeyLabel.Location = new Point(116, 124);
            HotKeyLabel.Name = "HotKeyLabel";
            HotKeyLabel.Size = new Size(73, 26);
            HotKeyLabel.TabIndex = 6;
            HotKeyLabel.Text = "F8 - Toggle\r\nF10 - Hide";
            // 
            // ProgramTimer
            // 
            ProgramTimer.Interval = 1000;
            ProgramTimer.Tick += ProgramTimer_Tick;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(304, 161);
            Controls.Add(HotKeyLabel);
            Controls.Add(StatusLabel);
            Controls.Add(HideButton);
            Controls.Add(ActivateButton);
            Controls.Add(CopyLabel);
            Controls.Add(VersionLabel);
            Controls.Add(TitleLabel);
            Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(320, 200);
            MinimizeBox = false;
            MinimumSize = new Size(320, 200);
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MouseShimmy";
            FormClosing += Main_FormClosing;
            VisibleChanged += Main_VisibleChanged;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label TitleLabel;
        private Label VersionLabel;
        private Label CopyLabel;
        private Button ActivateButton;
        private Button HideButton;
        private NotifyIcon TrayIcon;
        private Label StatusLabel;
        private Label HotKeyLabel;
        private System.Windows.Forms.Timer ProgramTimer;
    }
}
