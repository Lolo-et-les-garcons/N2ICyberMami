using System;
using System.IO;
using System.Windows.Forms;

using System.Speech.Recognition.SrgsGrammar;
using System.Speech.Recognition;

using Gecko;


namespace CyberMamieNavigator
{
    public partial class FormNavigator : Form
    {
        public FormNavigator()
        {
            InitializeComponent();

            browser.LoadHtml(File.ReadAllText("html/test.html"));
            //browser.Navigate("http://www.google.fr");

            browser.DocumentCompleted += ((se, ea) =>
            {
                /*this.Text = this.browser.Document.Title;
                GeckoElement sc = this.browser.Document.CreateElement("script");
                sc.SetAttribute("type", "text/javascript");
                sc.NodeValue = "function sayHello(){alert('hello')}";*/
            });
        }
    }
}
