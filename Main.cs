using System.Runtime.InteropServices;

namespace MouseShimmy
{
    public partial class Main : Form
    {
        // App Info
        public string AppName = "MouseShimmy";
        public string Version = "1.0";

        // App Vars Setup
        public Random random = new();
        public bool IsActive = false;
        public int ShimmyInterval;
        public int ActivityTimer = 0;

        // Constants for hotkeys
        private const int HOTKEY_ID_F8 = 1;
        private const int HOTKEY_ID_F10 = 2;
        private const int MOD_NONE = 0x0000;
        private const int WM_HOTKEY = 0x0312;

        // Disable warning about unnecessary warning suppression,
        // then disable warning about incorrect P/Invoke method
        // (since it is actually the correct method afaik)
#pragma warning disable IDE0079
#pragma warning disable SYSLIB1054
        // Import functions from user32.dll
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);
#pragma warning restore SYSLIB1054
#pragma warning restore IDE0079

        // Constructor
        public Main()
        {
            // Initialize the application
            InitializeComponent();
            VersionLabel.Text = "v" + Version;

            Text = AppName + " - Inactive";
            TrayIcon.Text = AppName + " - Inactive";
            TrayIcon.Icon = Icon;
            TrayIcon.Visible = false;

            ShimmyInterval = random.Next(1, 1005);
            // Register global hotkeys
            RegisterHotKey(this.Handle, HOTKEY_ID_F8, MOD_NONE, (int)Keys.F8);
            RegisterHotKey(this.Handle, HOTKEY_ID_F10, MOD_NONE, (int)Keys.F10);
        }

        // Async cursor movement
        private async Task MoveCursorAsync()
        {
            var screen = Screen.PrimaryScreen;
            if (screen != null)
            {
                while (IsActive)
                {
                    // Always start from the current cursor position
                    Point startPosition = Cursor.Position;

                    // Generate a random end position within the correct screen bounds
                    Point endPosition = new(
                        random.Next(screen.Bounds.Left, screen.Bounds.Right),
                        random.Next(screen.Bounds.Top, screen.Bounds.Bottom)
                    );

                    int duration = random.Next(863, 1083); // Duration in milliseconds
                    int steps = random.Next(94, 174); // Number of steps in the animation

                    for (int i = 0; i <= steps; i++)
                    {
                        if (!IsActive) break; // Stop if deactivated

                        double t = (double)i / steps;
                        int x = (int)(startPosition.X + t * (endPosition.X - startPosition.X));
                        int y = (int)(startPosition.Y + t * (endPosition.Y - startPosition.Y)
                                     - (int)(100 * Math.Sin(t * Math.PI))); // More natural curve

                        Cursor.Position = new Point(x, y);
                        await Task.Delay(duration / steps);
                    }

                    ShimmyInterval = random.Next(15, 1005);
                    await Task.Delay(ShimmyInterval);
                }
            }
            else
            {
                ActivateButton.PerformClick();
                MessageBox.Show("Primary Screen not found!", AppName + " - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Modify the ActivateButton_Click method to start the cursor movement asynchronously
        private async void ActivateButton_Click(object sender, EventArgs e)
        {
            // Toggle the Shimmy-er
            IsActive = !IsActive;
            switch (IsActive)
            {
                case true:
                    Text = AppName + " - Active";
                    TrayIcon.Text = AppName + " - Active";
                    ActivateButton.Text = "Deactivate";
                    StatusLabel.Text = "Active";
                    StatusLabel.ForeColor = Color.Lime;
                    ProgramTimer.Start();
                    await MoveCursorAsync(); // Start the cursor movement
                    break;
                case false:
                    Text = AppName + " - Inactive";
                    TrayIcon.Text = AppName + " - Inactive";
                    ActivateButton.Text = "Activate";
                    StatusLabel.Text = "Inactive";
                    StatusLabel.ForeColor = Color.Orange;
                    ActivityTimer = 0;
                    ProgramTimer.Stop();
                    break;
            }
        }

        private void ProgramTimer_Tick(object sender, EventArgs e)
        {
            if (IsActive)
            {
                ActivityTimer++;
                // Convert the ActivityTimer int in Seconds into
                // a timestamp string in the format "HH:MM:SS"
                string TimeStamp = TimeSpan.FromSeconds(ActivityTimer).ToString(@"hh\:mm\:ss");
                StatusLabel.Text = "Active (" + TimeStamp + ")";
                TrayIcon.Text = AppName + " - Active (" + TimeStamp + ")";
            }
        }

        // Handle the hotkey presses
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_HOTKEY)
            {
                switch (m.WParam.ToInt32())
                {
                    case HOTKEY_ID_F8:
                        ActivateButton.PerformClick();
                        break;
                    case HOTKEY_ID_F10:
                        if (Visible)
                        {
                            Hide();
                        }
                        else
                        {
                            Show();
                        }
                        break;
                }
            }
            base.WndProc(ref m);
        }

        // Close gracefully
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Disable the Shimmy-er
            IsActive = false;
            // Clear the tray icon
            TrayIcon.Visible = false;
            TrayIcon.Dispose();
            // Unregister global hotkeys
            UnregisterHotKey(this.Handle, HOTKEY_ID_F8);
            UnregisterHotKey(this.Handle, HOTKEY_ID_F10);
        }

        // Handle HideButton click
        private void HideButton_Click(object sender, EventArgs e)
        {
            Hide();
        }

        // Handle TrayIcon click
        private void TrayIcon_Click(object sender, EventArgs e)
        {
            Show();
        }

        // Handle Main form visibility change
        private void Main_VisibleChanged(object sender, EventArgs e)
        {
            // Toggle the tray icon when the form is hidden or shown
            switch (Visible)
            {
                case true:
                    TrayIcon.Visible = false;
                    break;
                case false:
                    TrayIcon.Visible = true;
                    break;
            }
        }
    }
}