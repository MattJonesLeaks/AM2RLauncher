using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AutoPatcherGUI
{
    public static class ProgressBarColor
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr w, IntPtr l);

        private const int ProgressBarMsg = 1040;

        /// <summary>
        /// Sets ProgressBar state
        /// </summary>
        /// <param name="pBar">WinForms ProgressBar class</param>
        /// <param name="state">State to set</param>
        public static void SetState(ProgressBar pBar, int state)
        {
            SendMessage(pBar.Handle, ProgressBarMsg, (IntPtr)state, IntPtr.Zero);
        }
    }
}
