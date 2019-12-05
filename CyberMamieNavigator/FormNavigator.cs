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
            VoiceRecognizer recognizer = new VoiceRecognizer(analyser);

            browser.DocumentCompleted += ((sender, _) =>
            {
                analyser.Analyse(browser.Document);

                recognizer.Recognize();
            });
        }
    }
}
