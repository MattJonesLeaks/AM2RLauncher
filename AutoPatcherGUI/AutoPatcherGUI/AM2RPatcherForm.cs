using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoPatcherGUI.Properties;
using LibGit2Sharp;

// From MattJonesLeaks with <3
// PS: Who's even using String.Concat?

namespace AutoPatcherGUI
{
    public partial class AM2RPatcherForm : Form
    {
        // I'm pretty sure they're supposed to be here.
        private PrivateFontCollection fonts = new PrivateFontCollection();

        private Font myFont;

        private const string LAUNCHER_VERSION = "1_1_1"; // change this for newer versions.

        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);

        public AM2RPatcherForm()
        {
            InitializeComponent();

            // Add BankGothic font from the resource file.
            // But seriously, why use P/Invoke???????????????????????????????????????????????
            byte[] bankGothicRegular = Resources.BankGothicRegular;
            IntPtr intPtr = Marshal.AllocCoTaskMem(bankGothicRegular.Length);
            Marshal.Copy(bankGothicRegular, 0, intPtr, bankGothicRegular.Length);
            uint pcFonts = 0;
            fonts.AddMemoryFont(intPtr, Resources.BankGothicRegular.Length);
            AddFontMemResourceEx(intPtr, (uint)Resources.BankGothicRegular.Length, IntPtr.Zero, ref pcFonts);
            Marshal.FreeCoTaskMem(intPtr);
            myFont = new Font(fonts.Families[0], 16.5f);

            // Set the icon.
            base.Icon = Resources.icon64;
        }

        // Non-static methods:

        public void UpdateGame()
        {
            if (!OriginalFound())
            {
                UpdateLaunchButton("Install 1.1", true);
                ToggleCloseButton(true);
                UpdateStatus(@"1.1 not found! Press ""Install 1.1"" to load AM2R_11.zip.");
                return;
            }

            UpdateStatus("Initializing patch...");
            Directory.CreateDirectory(String.Concat(GetDir(), @"\AM2R_", GetVersion()));
            DirectoryInfo directoryInfo = new DirectoryInfo(String.Concat(GetDir(), @"\AM2R_", GetVersion()));
            DirectoryInfo dir = GetDir();
            if (Directory.Exists(String.Concat(dir, @"\PatchData\utilities\android\assets")))
            {
                Directory.Delete(String.Concat(dir, @"\PatchData\utilities\android\assets"), true);
            }

            if (File.Exists(String.Concat(dir, @"\PatchData\utilities\android\AM2RWrapper.apk")))
            {
                File.Delete(String.Concat(dir, @"\PatchData\utilities\android\AM2RWrapper.apk"));
            }

            UpdateStatus("Extracting AM2R 1.1...");
            Extract11(String.Concat(directoryInfo));
            UpdateProgressBar(33);
            File.Delete(String.Concat(directoryInfo, @"\AM2R.exe"));
            UpdateStatus("Applying patch...");

            // Run xdelta3 on our data.win
            Process xdeltaProc = new Process();
            xdeltaProc.StartInfo.FileName = String.Concat(dir, @"\PatchData\utilities\xdelta\xdelta3.exe");
            xdeltaProc.StartInfo.WorkingDirectory = String.Concat(dir);
            xdeltaProc.StartInfo.Arguments = @"-f -d -s AM2R_" + GetVersion() + @"\data.win PatchData\patch_data\AM2R.xdelta AM2R_" + GetVersion() + @"\AM2R.exe";
            xdeltaProc.StartInfo.UseShellExecute = false;
            xdeltaProc.StartInfo.CreateNoWindow = true;
            xdeltaProc.Start();
            xdeltaProc.WaitForExit();
            xdeltaProc.Dispose();
            UpdateProgressBar(66);
            File.Delete(String.Concat(directoryInfo, @"\data.win"));
            UpdateStatus("Installing new datafiles...");

            // Copy patchdata and dirs.
            Process cmdXcopyProc = new Process();
            cmdXcopyProc.StartInfo.CreateNoWindow = true;
            cmdXcopyProc.StartInfo.UseShellExecute = false;
            cmdXcopyProc.StartInfo.FileName = "cmd.exe";
            cmdXcopyProc.StartInfo.Arguments = String.Concat("/C xcopy /s /v /y /q \"", dir, "\\PatchData\\patch_data\\files_to_copy\" \"", directoryInfo, "\"");
            cmdXcopyProc.Start();
            cmdXcopyProc.WaitForExit();
            if (HQMusicCheckbox.Checked)
            {
                UpdateStatus("Installing HDR HQ soundtrack...");
                Console.WriteLine("Installing HQ OST!");
                cmdXcopyProc.StartInfo.CreateNoWindow = true;
                cmdXcopyProc.StartInfo.UseShellExecute = false;
                cmdXcopyProc.StartInfo.FileName = "cmd.exe";
                cmdXcopyProc.StartInfo.Arguments = String.Concat(@"/C xcopy /s /v /y /q """, dir, @"\PatchData\patch_data\HDR_HQ_in-game_music"" """, directoryInfo, @"""");
                cmdXcopyProc.Start();
                cmdXcopyProc.WaitForExit();
            }
            cmdXcopyProc.Dispose();

            // We're done!
            UpdateProgressBar(100);
            UpdateStatus("Patch finished!");
            Console.WriteLine("Patch finished!");
            ToggleButtons(true);
            UpdateLaunchButton("Play", true);
            ToggleCloseButton(true);
        }

        public void Extract11(string output)
        {
            ZipFile.ExtractToDirectory(String.Concat(GetDir(), "\\AM2R_11.zip"), output ?? "");
            if (!File.Exists(output + "\\data.win"))
            {
                if (Directory.Exists(output + "\\AM2R"))
                {
                    Process process = new Process();
                    process.StartInfo.CreateNoWindow = true;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.FileName = "cmd.exe";
                    process.StartInfo.Arguments = "/C xcopy /s /v /y /q \"" + output + "\\AM2R\" \"" + output + "\"";
                    process.Start();
                    process.WaitForExit();
                    process.Dispose();
                    Directory.Delete(output + "\\AM2R", true);
                }
                else if (Directory.Exists(output + "\\AnotherMetroid2Remake"))
                {
                    Process process = new Process();
                    process.StartInfo.CreateNoWindow = true;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.FileName = "cmd.exe";
                    process.StartInfo.Arguments = "/C xcopy /s /v /y /q \"" + output + "\\AnotherMetroid2Remake\" \"" + output + "\"";
                    process.Start();
                    process.WaitForExit();
                    process.Dispose();
                    Directory.Delete(output + @"\AnotherMetroid2Remake", true);
                }
                else
                {
                    ShowMessage("Error", "data.win not found! Are you sure AM2R_11.zip was packed correctly? Please delete and re-install AM2R_11.zip", MessageBoxButtons.OK);
                    Directory.Delete(output ?? "", true);
                    Close();
                    Application.ExitThread();
                    Environment.Exit(0);
                }
            }
        }

        public void CreateAPK()
        {
            if (!OriginalFound())
            {
                UpdateLaunchButton("Install 1.1", true);
                ToggleCloseButton(true);
                UpdateStatus("1.1 not found! Press \"Install 1.1\" to load AM2R_11.zip.");
                return;
            }
            DirectoryInfo directoryInfo = new DirectoryInfo(String.Concat(GetDir(), "\\AM2R_", GetVersion()));
            DirectoryInfo dir = GetDir();
            if (Directory.Exists(String.Concat(dir, "\\PatchData\\utilities\\android\\assets")))
            {
                Directory.Delete(String.Concat(dir, "\\PatchData\\utilities\\android\\assets"), true);
            }
            if (File.Exists(String.Concat(dir, "\\PatchData\\utilities\\android\\AM2RWrapper.apk")))
            {
                File.Delete(String.Concat(dir, "\\PatchData\\utilities\\android\\AM2RWrapper.apk"));
            }
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = "/C where java";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.Start();
            process.WaitForExit();
            if (process.ExitCode != 0)
            {
                UpdateStatus("Java not found! Please install Java to create an AndroidM2R APK.");
                UpdateProgressBar(100, 2);
                process.Dispose();
                return;
            }
            process.Dispose();
            string text = String.Concat("xcopy /s /v /y /q \"", dir, "\\PatchData\\patch_data\\android\\AM2RWrapper.apk\" \"", dir, "\\PatchData\\utilities\\android\"");
            string text2 = String.Concat("& xcopy /s /v /y /q \"", directoryInfo, "\" \"", dir, "\\PatchData\\utilities\\android\\assets\\\" /EXCLUDE:ignore.txt");
            string text3 = String.Concat("& xcopy /s /v /y /q \"", dir, "\\PatchData\\patch_data\\files_to_copy\\*.ogg\" \"", dir, "\\PatchData\\utilities\\android\\assets\\\"");
            string text4 = "";
            if (HQMusicCheckbox.Checked)
            {
                text4 = String.Concat("& xcopy /s /v /y /q \"", dir, "\\PatchData\\patch_data\\HDR_HQ_in-game_music\" \"", dir, "\\PatchData\\utilities\\android\\assets\\\"");
                ShowMessage("Warning!", "You are attempting to install HQ music on Android! This will increase the filesize by around 200MB.", MessageBoxButtons.OK);
            }
            UpdateProgressBar(25, 0);
            UpdateStatus("Copying game files...");
            Process cmdExeProc = new Process();
            cmdExeProc.StartInfo.CreateNoWindow = true;
            cmdExeProc.StartInfo.UseShellExecute = false;
            cmdExeProc.StartInfo.WorkingDirectory = String.Concat(dir, "\\PatchData\\utilities\\android");
            cmdExeProc.StartInfo.FileName = "cmd.exe";
            cmdExeProc.StartInfo.Arguments = "/C " + text + text2 + text3 + text4;
            cmdExeProc.Start();
            cmdExeProc.WaitForExit();
            cmdExeProc.Dispose();
            Extract11(String.Concat(dir, "\\working"));
            if (!HQMusicCheckbox.Checked)
            {
                FileInfo[] files = new DirectoryInfo(String.Concat(dir, "\\working")).GetFiles();
                foreach (FileInfo fileInfo in files)
                {
                    if (fileInfo.Name.EndsWith(".ogg"))
                    {
                        fileInfo.CopyTo(String.Concat(dir, "\\PatchData\\utilities\\android\\assets\\", fileInfo.Name), true);
                    }
                }
                Thread.Sleep(2000);
            }
            UpdateProgressBar(50);
            UpdateStatus("Extracting and patching 1.1 data.win...");
            File.Copy(String.Concat(dir, "\\working\\data.win"), String.Concat(dir, "\\PatchData\\utilities\\android\\assets\\data.win"));
            File.Copy(String.Concat(dir, "\\PatchData\\patch_data\\android\\AM2R.ini"), String.Concat(dir, "\\PatchData\\utilities\\android\\assets\\AM2R.ini"));

            // do xdelta3
            Process xdelta3Proc = new Process();
            xdelta3Proc.StartInfo.FileName = String.Concat(dir, "\\PatchData\\utilities\\xdelta\\xdelta3.exe");
            xdelta3Proc.StartInfo.WorkingDirectory = String.Concat(dir);
            xdelta3Proc.StartInfo.Arguments = "-f -d -s PatchData\\utilities\\android\\assets\\data.win PatchData\\patch_data\\droid.xdelta PatchData\\utilities\\android\\assets\\game.droid";
            xdelta3Proc.StartInfo.UseShellExecute = false;
            xdelta3Proc.StartInfo.CreateNoWindow = true;
            xdelta3Proc.Start();
            xdelta3Proc.WaitForExit();
            xdelta3Proc.Dispose();
            UpdateProgressBar(75);

            UpdateStatus("Packaging APK...");
            // package assets.
            Process assetsBatProc = new Process();
            assetsBatProc.StartInfo.FileName = String.Concat(dir, "\\PatchData\\utilities\\android\\apk_package_assets.bat");
            assetsBatProc.StartInfo.WorkingDirectory = String.Concat(dir, "\\PatchData\\utilities\\android");
            assetsBatProc.StartInfo.UseShellExecute = false;
            assetsBatProc.StartInfo.CreateNoWindow = true;
            assetsBatProc.Start();
            assetsBatProc.WaitForExit();
            assetsBatProc.Dispose();
            if (Directory.Exists(String.Concat(dir, "\\PatchData\\utilities\\android\\assets")))
            {
                Directory.Delete(String.Concat(dir, "\\PatchData\\utilities\\android\\assets"), true);
            }
            if (File.Exists(String.Concat(dir, "\\AndroidM2R_", GetVersion(), "-signed.apk")))
            {
                File.Delete(String.Concat(dir, "\\AndroidM2R_", GetVersion(), "-signed.apk"));
            }
            File.Move(String.Concat(dir, "\\PatchData\\utilities\\android\\AM2RWrapper-aligned-debugSigned.apk"), String.Concat(dir, "\\AndroidM2R_", GetVersion(), "-signed.apk"));
            Directory.Delete(String.Concat(dir, "\\working"), true);
            UpdateProgressBar(100);
            UpdateStatus(String.Concat("APK created! Located at ", dir, "\\AndroidM2R_", GetVersion(), "-signed.apk"));
            ToggleButtons(true);
            ToggleCloseButton(true);
        }

        /// <summary>
        /// Extracts a zip archive to a specified directory.
        /// This actually seems to be unused????????????
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="output"></param>
        /// <param name="filetype"></param>
        private void ExtractFiles(string dir, string output, string filetype)
        {
            using (ZipArchive zipArchive = ZipFile.OpenRead(dir))
            {
                foreach (ZipArchiveEntry entry in zipArchive.Entries)
                {
                    if (entry.FullName.EndsWith(filetype, StringComparison.OrdinalIgnoreCase))
                    {
                        entry.ExtractToFile(output + @"\" + entry.FullName, true);
                    }
                }
            }
        }

        public void UpdateLaunchButton(string buttonText, bool enabled)
        {
            if (LaunchButton.InvokeRequired)
            {
                Invoke((MethodInvoker)delegate
                {
                    LaunchButton.Text = buttonText;
                });
                Invoke((MethodInvoker)delegate
                {
                    LaunchButton.Enabled = enabled;
                });
            }
            else
            {
                LaunchButton.Text = buttonText;
                LaunchButton.Enabled = enabled;
            }
        }

        /// <summary>
        /// Returns the patchdata version as a string.
        /// </summary>
        /// <returns>Version string</returns>
        private string GetVersion()
        {
            if (!Directory.Exists(String.Concat(GetDir(), "/PatchData")))
            {
                DebugLog("No PatchData directory found! Creating it now...");
                Directory.CreateDirectory(String.Concat(GetDir(), "/PatchData"));
            }
            if (!File.Exists(String.Concat(GetDir(), "/PatchData/version.txt")))
            {
                DebugLog("No version.txt found! Creating one now...");
                CreateFile(String.Concat(GetDir(), "/PatchData/version.txt"));
            }
            return File.ReadAllText(String.Concat(GetDir(), "/PatchData/version.txt"));
        }

        /// <summary>
        /// Gets the current directory.
        /// Matt should've used smth like AppDomain.CurrentDomain.BaseDirectory
        /// But that's matt
        /// </summary>
        /// <returns>DirectoryInfo structure of the current directory</returns>
        private DirectoryInfo GetDir()
        {
            return new DirectoryInfo(Directory.GetCurrentDirectory());
        }

        public void UpdateStatus(string str)
        {
            Invoke((MethodInvoker)delegate
            {
                StatusLabel.Text = str;
            });
        }

        private bool OriginalFound()
        {
            if (File.Exists(String.Concat(GetDir(), "\\AM2R_11.zip")))
            {
                return true;
            }

            return false;
        }

        private bool LatestFound()
        {
            if (File.Exists(String.Concat(GetDir(), "\\AM2R_", GetVersion(), "\\AM2R.exe")))
            {
                return true;
            }
            return false;
        }

        private void ToggleButtons(bool status)
        {
            Invoke((MethodInvoker)delegate
            {
                LaunchButton.Enabled = status;
            });
            Invoke((MethodInvoker)delegate
            {
                CreateAPKButton.Enabled = status;
            });
        }

        private void ToggleCloseButton(bool status)
        {
            Invoke((MethodInvoker)delegate
            {
                CloseButton.Enabled = status;
            });
        }

        private void UpdateSelf()
        {
            string launcherVersion = LAUNCHER_VERSION;
            string b = LAUNCHER_VERSION;
            WebClient webClient = new WebClient();
            try
            {
                b = webClient.DownloadString("https://raw.githubusercontent.com/Lojemiru/AM2RLauncher/master/version.txt");
            }
            catch
            {
                ShowMessage("Error:", "Could not find current version! Is your internet connection down?", MessageBoxButtons.OK);
            }
            if (launcherVersion != b)
            {
                try
                {
                    webClient.DownloadFile("https://raw.githubusercontent.com/Lojemiru/AM2RLauncher/master/update.zip", String.Concat(GetDir(), "\\utility\\update.zip"));
                    Process process = new Process();
                    process.StartInfo.FileName = String.Concat(GetDir(), "\\utility\\update.bat");
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.Verb = "runas";
                    process.StartInfo.Arguments = String.Concat("\"", GetDir(), "\"");
                    process.Start();
                    Close();
                    Application.ExitThread();
                    Environment.Exit(0);
                }
                catch
                {
                    ShowMessage("Error:", "Update failed! Check your internet connection and verify that the utility folder has not been modified.", MessageBoxButtons.OK);
                    Close();
                    Application.ExitThread();
                    Environment.Exit(0);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateSelf();
            GetVersion();
            bool flag = false;
            DirectoryInfo dir = GetDir();
            LaunchButton.Enabled = false;
            LaunchButton.Font = myFont;
            CloseButton.Font = myFont;
            CreateAPKButton.Font = myFont;
            UpdateInfoTabControl();
            if (HasCloned(String.Concat(dir, @"\PatchData")))
            {
                GitPull(String.Concat(dir, @"\PatchData"));
            }
            else
            {
                Task.Factory.StartNew(delegate
                {
                    GitClone(String.Concat(dir, @"\PatchData"));
                });
                UpdateLaunchButton("Downloading...", false);
                ToggleButtons(false);
                ToggleCloseButton(false);
                UpdateStatus("Downloading initial patch files. This may take some time!");
                UpdateProgressBar(50);
                flag = true;
            }
            if (LatestFound() && !flag)
            {
                UpdateLaunchButton("Play", true);
                UpdateStatus("Latest version installed. Game ready to launch.");
            }
            else if (OriginalFound() && !flag)
            {
                ToggleButtons(false);
                UpdateLaunchButton("Update", true);
                UpdateStatus("New release found! Ready to install.");
            }
            else if (!flag)
            {
                ToggleButtons(false);
                UpdateLaunchButton("Install 1.1", true);
                UpdateStatus("1.1 not found! Press \"Install 1.1\" to load AM2R_11.zip.");
            }
            else
            {
                ToggleButtons(false);
                ToggleCloseButton(false);
                UpdateLaunchButton("Installing", false);
                UpdateStatus("Downloading base patch files... This may take some time!");
            }
        }

        /// <summary>
        /// Prints the message to the debug console.
        /// </summary>
        /// <param name="message">What to print</param>
        public void DebugLog(string message)
        {
            Debug.WriteLine(message);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            switch (button.Text)
            {
                case "Play":
                    button.Enabled = false;
                    LaunchGame();
                    DebugLog("AM2R launched!");
                    break;
                case "Update":
                    DebugLog("Updating game!");
                    ToggleButtons(false);
                    ToggleCloseButton(false);
                    Task.Factory.StartNew(UpdateGame);
                    button.Text = "Updating...";
                    break;
                case "Install 1.1":
                    {
                        if (LatestFound())
                        {
                            UpdateProgressBar(0);
                            UpdateStatus("Latest version installed. Game ready to launch.");
                            ToggleButtons(true);
                            UpdateLaunchButton("Play", true);
                            break;
                        }
                        if (OriginalFound())
                        {
                            UpdateProgressBar(0);
                            UpdateStatus("1.1 found! Ready to update.");
                            UpdateLaunchButton("Update", true);
                            break;
                        }
                        OpenFileDialog openFileDialog = new OpenFileDialog();
                        openFileDialog.InitialDirectory = String.Concat(GetDir());
                        openFileDialog.Title = "Please select AM2R_11.zip";
                        openFileDialog.DefaultExt = "zip";
                        openFileDialog.Filter = "zip files (*.zip)|*.zip";
                        openFileDialog.CheckFileExists = true;
                        openFileDialog.CheckPathExists = true;
                        openFileDialog.Multiselect = false;
                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            File.Copy(openFileDialog.FileName, String.Concat(GetDir(), "\\AM2R_11.zip"));
                            UpdateProgressBar(0);
                            UpdateStatus("1.1 found! Ready to update.");
                            UpdateLaunchButton("Update", true);
                        }
                        break;
                    }
                default:
                    DebugLog("Nothing run!");
                    break;
            }
        }

        /// <summary>
        /// Create an empty file.
        /// </summary>
        /// <param name="path">Path to the file that needs to be created.</param>
        private void CreateFile(string path)
        {
            using (FileStream fileStream = File.Create(path, 1024))
            {
                byte[] bytes = new UTF8Encoding(true).GetBytes("");
                fileStream.Write(bytes, 0, bytes.Length);
            }
        }

        /// <summary>
        /// Runs the game and disables various buttons etc.
        /// </summary>
        public void LaunchGame()
        {
            DirectoryInfo dir = GetDir();
            string version = GetVersion();
            try
            {
                using (Process process = Process.Start(String.Concat(dir, "\\AM2R_", version, "\\AM2R.exe")))
                {
                    Hide();
                    notifyIcon1.Visible = true;
                    process.WaitForExit();
                    Show();
                    base.WindowState = FormWindowState.Normal;
                    notifyIcon1.Visible = false;
                    UpdateLaunchButton("Play", true);
                }
            }
            catch
            {
                ShowMessage("Error", "AM2R.exe not found! If this error persists, please delete the AM2R_" + version + " folder and re-patch the game.", MessageBoxButtons.OK);
                UpdateLaunchButton("Play", true);
            }
        }

        public void UpdateProgressBar(int percent)
        {
            Invoke((MethodInvoker)delegate
            {
                ProgressBarStatus.Value = percent;
            });
        }

        public void UpdateProgressBar(int percent, int state)
        {
            Invoke((MethodInvoker)delegate
            {
                ProgressBarStatus.Value = percent;
            });
            Invoke((MethodInvoker)delegate
            {
                ProgressBarColor.SetState(ProgressBarStatus, state);
            });
        }

        private void UpdateInfoTabControl()
        {
            try
            {
                string documentText = new WebClient().DownloadString("https://raw.githubusercontent.com/Lojemiru/AM2R-Autopatcher/master/changelog.html");
                PatchNotesWebBrowser.DocumentText = documentText;
            }
            catch
            {
                ShowMessage("Error", "Unable to fetch changelog text; is your internet connection down?", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Shows a message box.
        /// </summary>
        /// <param name="title">Title of the MessageBox window</param>
        /// <param name="message">Message to be displayed inside the MessageBox</param>
        /// <param name="buttons">Button config</param>
        private void ShowMessage(string title, string message, MessageBoxButtons buttons)
        {
            MessageBox.Show(message, title, buttons);
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void patchNotesBrowserButton_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/Lojemiru/AM2R-Autopatcher/blob/master/patch_data/files_to_copy/readme.txt");
        }

        /// <summary>
        /// Clones the 'patchdata' repository.
        /// </summary>
        /// <param name="directory">Where to clone</param>
        public void GitClone(string directory)
        {
            ToggleButtons(false);
            ToggleCloseButton(false);
            string sourceUrl = "https://github.com/Lojemiru/AM2R-Autopatcher.git";
            try
            {
                ClearRepository(directory);
                Repository.Clone(sourceUrl, directory);
                UpdateProgressBar(100);
                if (LatestFound())
                {
                    ToggleButtons(true);
                    UpdateLaunchButton("Play", true);
                    UpdateStatus("Latest version installed. Game ready to launch.");
                }
                if (OriginalFound())
                {
                    ToggleButtons(false);
                    UpdateLaunchButton("Update", true);
                    UpdateStatus("Patch files downloaded. Ready to update.");
                }
                else
                {
                    ToggleButtons(false);
                    UpdateLaunchButton("Install 1.1", true);
                    UpdateStatus(@"1.1 not found! Press ""Install 1.1"" to load AM2R_11.zip.");
                }
                ToggleCloseButton(true);
            }
            catch (Exception ex)
            {
                ClearRepository(directory);
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Pulls latest changes from the repository.
        /// </summary>
        /// <param name="directory">Repository directory</param>
        public void GitPull(string directory)
        {
            Console.WriteLine("pulling...");
            try
            {
                using (Repository repository = new Repository(directory))
                {
                    PullOptions pullOptions = new PullOptions();
                    pullOptions.FetchOptions = new FetchOptions();

                    // how cute.
                    Signature merger = new Signature(new Identity("MERGE_USER_NAME", "MERGE_USER_EMAIL"), DateTimeOffset.Now);
                    Commit tip = repository.Head.Tip;
                    repository.Reset(ResetMode.Hard, tip);
                    Commands.Pull(repository, merger, pullOptions);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                GitClone(directory);
            }
        }

        private void AM2RHeaderPicturebox_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("AM2RHeaderPicturebox_Click()");
        }

        private void CreateAPKButton_Click(object sender, EventArgs e)
        {
            ToggleButtons(false);
            ToggleCloseButton(false);
            Task.Factory.StartNew(delegate
            {
                CreateAPK();
            });
        }

        private void ProgressBarStatus_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("ProgressBarStatus_Click()");
        }

        private void HQMusicCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            Debug.WriteLine("HQMusicCheckbox_CheckedChanged()");
        }

        private void VersionLabel_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("VersionLabel_Click()");
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            Process.Start("http://discord.gg/M9jAYwWXda");
        }

        private void RedditPictureBox_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.reddit.com/r/AM2R");
        }

        private void PictureBox1_Click_1(object sender, EventArgs e)
        {
            Process.Start("https://www.youtube.com/channel/UCptc9QWOMS_BUsr02hsSQQg");
        }

        // Static methods:

        /// <summary>
        /// Checks if the repository has been cloned or not.
        /// </summary>
        /// <param name="directory">Repository directory</param>
        /// <returns>true if the repo is cloned, false if otherwise.</returns>
        public static bool HasCloned(string directory)
        {
            return Directory.Exists(directory + @"\.git");
        }

        /// <summary>
        /// Deletes all files and directories in a repository
        /// But doesn't delete the folder itself(!)
        /// </summary>
        /// <param name="directory">Repository directory</param>
        public static void ClearRepository(string directory)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(directory);
            FileInfo[] files = directoryInfo.GetFiles();
            for (int i = 0; i < files.Length; i++)
            {
                files[i].Delete();
            }
            DirectoryInfo[] directories = directoryInfo.GetDirectories();
            for (int i = 0; i < directories.Length; i++)
            {
                directories[i].Delete(true);
            }
        }
    }
}