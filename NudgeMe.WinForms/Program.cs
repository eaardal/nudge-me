using System;
using System.Windows.Forms;

namespace NudgeMe.WinForms
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ApplicationContext context = new TaskbarApplicationContext();
            Application.Run(context);
        }
    }
}
