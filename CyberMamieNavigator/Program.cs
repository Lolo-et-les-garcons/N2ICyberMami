using System;
using System.Windows.Forms;

using Gecko;

namespace CyberMamieNavigator
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();

            Xpcom.Initialize(Application.StartupPath);

            Application.Run(new FormNavigator());
        }
    }
}
