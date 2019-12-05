using System;
using System.IO;
using System.Windows.Forms;

using Gecko;

namespace CyberMamieNavigator
{
    public partial class FormNavigator : Form
    {
        public FormNavigator()
        {
            InitializeComponent();

            browser.LoadHtml(File.ReadAllText("html/test.html"));

            DocumentAnalyser analyser = new DocumentAnalyser();
            VoiceRecognizer recognizer = new VoiceRecognizer();

            browser.DocumentCompleted += ((se, ea) =>
            {
                analyser.Analyse(browser.Document);

                /*this.Text = this.browser.Document.Title;
                GeckoElement sc = this.browser.Document.CreateElement("script");
                sc.SetAttribute("type", "text/javascript");
                sc.NodeValue = "function sayHello(){alert('hello')}";*/
            });
        }
    }
}
