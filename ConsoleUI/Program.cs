

using System;
using System.Windows.Forms;

namespace ConsoleUI
{
    internal class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
            //ConsoleInterface ui = new ConsoleInterface();
            //ui.Start();


        }
    }
}
