using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CyberMamieNavigator
{
    public partial class FormNavigator : Form
    {
        public FormNavigator()
        {
            InitializeComponent();

            this.geckoWebBrowser1.Navigate("http://www.google.fr");
        }
    }
}
