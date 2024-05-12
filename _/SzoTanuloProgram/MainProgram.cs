using System;
using System.Windows.Forms;

namespace SzoTanuloProgram
{
    static class MainProgram
    {
        static void Main()
        {
            /*
            if (!CheckForFiles())
            {
                return;
            }*/

            RunApplication();
        }

        private static void RunApplication()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new LoaderGUI());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Váratlan hiba történt! {Environment.NewLine} {ex.Message}");
            }

        }

        /// <returns>
        ///     true, ha minden rendben
        ///     false, ha nincs minden rendben
        /// </returns>
        private static bool CheckForFiles()
        {
            //resources
            //settings

            return true;
        }
    }
}
