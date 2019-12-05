using System;
using System.Collections.Generic;
using System.Globalization;

using System.Speech.Recognition;

namespace CyberMamieNavigator
{
    public class VoiceRecognizer
    {
        private SpeechRecognitionEngine recognitionEngine;

        public VoiceRecognizer()
        {
            recognitionEngine = new SpeechRecognitionEngine(CultureInfo.CurrentCulture);

            StartEngine();
        }

        private void StartEngine()
        {
            recognitionEngine.SetInputToDefaultAudioDevice();

            recognitionEngine.LoadGrammar(BuildGrammar());
        }

        private Grammar BuildGrammar()
        {
            GrammarBuilder builder = new GrammarBuilder();

            builder.Append("bourbier");
            builder.Append("pain");
            builder.Append("suivant");
            builder.Append("salade");

            return new Grammar(builder);
        }

        private static void ASREngine_SpeechHypothesized(object sender, SpeechHypothesizedEventArgs e)
        {
            Console.Write("? ");
            UseResult(e.Result);
        }

        private static void ASREngine_SpeechRecognitionRejected(object sender, SpeechRecognitionRejectedEventArgs e)
        {
            Console.WriteLine("Erreur !");
        }

        private static void UseResult(RecognitionResult rr)
        {
            string text = ">";

            foreach (RecognizedWordUnit rwu in rr.Words)
            {
                text += " " + rwu.LexicalForm;
            }

            text = text.Replace('.', ' ').Trim();

            Console.WriteLine(text);
        }

        private static void ASREngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            UseResult(e.Result);
        }
    }
}
