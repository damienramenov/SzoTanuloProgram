using System;
using System.Windows.Forms;

namespace SzoTanuloProgram
{
    static class MainProgram
    {
        static void Main()
        {
            if (!ExecutePrecheck())
            {
                return;
            }

            RunApplication();
        }

        /// <summary>
        /// Biztos, hogy lehet szebben is hibát kezelni. (+ amúgy van egy .net-es runtime exception handler)
        /// </summary>
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
                MessageBox.Show($"Váratlan hiba történt! {Environment.NewLine} " +
                                $"{ex.Message}");
            }
        }

        /// <returns>
        ///     true, ha minden rendben
        ///     false, ha nincs minden rendben
        /// </returns>
        private static bool ExecutePrecheck()
        {
            //TODO: Ellenőrizzük, hogy minden szükséges fájl megvan-e.
            //TODO: Létre kell hozni egy settings.file -t, amiben tárolunk különböző adatokat.
            //TODO: Ellenőrizzük, hogy a settings létezik-e, ha nem, akkor hozzuk létre,
            //állítsuk be az alap adatokat, hívjuk fel a figyelmet arra, hogy ezeket be lehet állítani. --> Beállítások menüpont? (Van neki hely a főmenüben.)

            return true;
        }
    }
}
