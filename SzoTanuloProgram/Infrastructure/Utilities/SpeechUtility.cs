using DarrenLee.SpeechSynthesis;

namespace SzoTanuloProgram
{
    public static class SpeechUtility
    {
        public static void Speak(string textToSpeech)
        {
            SpeechHelper.Rate = 0;

            SpeechHelper.Speak("en-US", "Microsoft Zira Desktop", textToSpeech);
        }
    }
}
