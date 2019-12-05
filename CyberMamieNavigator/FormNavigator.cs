using System;
using System.Windows.Forms;

using System.Speech.Recognition.SrgsGrammar;
using System.Speech.Recognition;

namespace CyberMamieNavigator
{
    public partial class FormNavigator : Form
    {
        public FormNavigator()
        {
            InitializeComponent();

            browser.Navigate("http://www.google.fr");
        }
    }
}
