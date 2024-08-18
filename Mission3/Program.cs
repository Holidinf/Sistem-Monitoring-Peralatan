using Mission3.View;
using System;
using System.Windows.Forms;

namespace Mission3
{
    static class Program
    {
        /// <summary>
        /// Ini adalah titik masuk utama untuk aplikasi.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
