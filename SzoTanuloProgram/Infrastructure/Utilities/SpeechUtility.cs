using System.Speech.Synthesis;

namespace SzoTanuloProgram
{
    public static class SpeechUtility
    {
        private static readonly SpeechSynthesizer SpeechTool;

        static SpeechUtility()
        {
            SpeechTool = new SpeechSynthesizer();
            SpeechTool.SelectVoice("Microsoft Server Speech Text to Speech Voice (en-US, Helen)");
            SpeechTool.Volume = 100;
            SpeechTool.SetOutputToDefaultAudioDevice();
        }

        public static void Speak(string textToSpeech) => SpeechTool.Speak(textToSpeech);
    }
}
