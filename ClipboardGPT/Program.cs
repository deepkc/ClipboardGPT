using System;
using System.Windows.Forms;

namespace ClipboardGPT
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());  // This should point to your Form1
        }
    }
}
