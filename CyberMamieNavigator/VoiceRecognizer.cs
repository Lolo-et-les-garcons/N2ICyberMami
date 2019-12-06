using System;
using System.IO;
using System.Globalization;

using System.Speech.Recognition;

using NAudio;
using NAudio.Wave;

namespace CyberMamieNavigator
{
    public class VoiceRecognizer
    {
        private SpeechRecognitionEngine recognitionEngine;
        private DocumentAnalyser analyser;

        public VoiceRecognizer(DocumentAnalyser analyser)
        {
            this.analyser = analyser;
            recognitionEngine = new SpeechRecognitionEngine(CultureInfo.CurrentCulture);

            StartEngine();
        }

        private void StartEngine()
        {
            //InitalizeMicrophone();

            //recognitionEngine.SetInputToWaveFile("test2.wav");
            recognitionEngine.SetInputToDefaultAudioDevice();

            //recognitionEngine.MaxAlternates = 4;
            recognitionEngine.InitialSilenceTimeout = TimeSpan.Zero;

            recognitionEngine.SpeechRecognized += Engine_SpeechRecognized;
            recognitionEngine.SpeechRecognitionRejected += Engine_SpeechRecognitionRejected;
            recognitionEngine.SpeechHypothesized += Engine_SpeechHypothesized;
        }

        /*private void InitalizeMicrophone()
        {
            WaveIn waveIn = new WaveIn();
            waveIn.WaveFormat = new WaveFormat();

            waveIn.StartRecording();

            MemoryStream ms = new MemoryStream();

            waveIn.DataAvailable += (sender, e) =>
            {
                ms.Write(e.Buffer, 0, e.BytesRecorded);
            };

            recognitionEngine.SetInputToWaveStream(ms);
        }*/


        public void Recognize()
        {
            Stop();

            GrammarBuilder builder = new GrammarBuilder();

            Choices choices = new Choices(analyser.GetLabels());
            /*Choices choices = new Choices();
            choices.Add("test");
            choices.Add("bourbe");*/

            builder.Append(choices);

            recognitionEngine.LoadGrammar(new Grammar(builder));

            recognitionEngine.RequestRecognizerUpdate();

            recognitionEngine.RecognizeAsync(RecognizeMode.Multiple);
        }

        public void Stop()
        {
            recognitionEngine.RecognizeAsyncStop();
        }


        private void Engine_SpeechHypothesized(object sender, SpeechHypothesizedEventArgs e)
        {
            Console.Write("? ");
            UseResult(e.Result);
        }

        private void Engine_SpeechRecognitionRejected(object sender, SpeechRecognitionRejectedEventArgs e)
        {
            Console.WriteLine("Erreur !");
        }

        private void Engine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            UseResult(e.Result);
        }

        private void UseResult(RecognitionResult rr)
        {
            string text = "";

            foreach (RecognizedWordUnit rwu in rr.Words)
            {
                text += " " + rwu.LexicalForm;
            }

            text = text.Replace('.', ' ').Trim();

            Console.WriteLine(text);

            VoiceAction action = analyser.FindByName(text);

            if (action != null)
            {
                Console.WriteLine("Firing " + action.label);
                action.Fire();
            }
            else
            {
                Console.WriteLine("Not found");
            }
        }
    }
}
