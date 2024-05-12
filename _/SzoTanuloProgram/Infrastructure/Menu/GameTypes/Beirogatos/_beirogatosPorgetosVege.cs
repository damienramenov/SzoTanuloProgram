using System;
using System.IO;
using System.Windows.Forms;

namespace SzoTanuloProgram
{
    public partial class BeirogatosPorgetosVege : Form
    {
        public BeirogatosPorgetosVege()
        {
            InitializeComponent();

            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;

            if (PorgetosEsBeirogatos_Almenu.IsSajatSzojegyzek == false)
            {
                string[] anyagresz = PorgetosEsBeirogatos_Almenu.ValasztottSzojegyzekFilePath.Split('\\', '.');
                int _teljesMeret = TeljesMeret(anyagresz[1], anyagresz[0]);
                _panelAlapAlso.Visible = true;
                _panelAlsoNoveled.Visible = true;

                var meret = Meret();

                richTextBox1.Text = $"Gratulálok! Megtanultad a(z) '{anyagresz[1]}' szójegyzéket, amely {meret} db szót tartalmazott :)."; //Ez 1 szójegyzék a 18-ből!\nAz egész Elementary anyagban pedig {_teljesMeret} szó található.
                _panelAlsoNoveled.Width = (int)((meret / _teljesMeret) * _panelAlapAlso.Width);
            }
            else
            {
                _panelAlsoNoveled.Visible = false;
                _panelAlapAlso.Visible = false;
                label1.Visible = false;
                richTextBox1.Text = $"Gratulálok! Megtanultad az általad betöltött szójegyzéket, amely {Meret()} szót tartalmazott :).";
            }
        }

        static double Meret()
        {
            double num = 0;
            StreamReader sr = new StreamReader(PorgetosEsBeirogatos_Almenu.ValasztottSzojegyzekFilePath);
            while (!sr.EndOfStream)
            {
                sr.ReadLine();
                num++;
            }
            return num;
        }

        static int TeljesMeret(string melyikSZojegyzek, string melyikMappa)
        {
            int teljesMeretet = 0;
            string path = Directory.GetCurrentDirectory().ToString() + "\\" + melyikMappa + "\\" + melyikSZojegyzek;
            string[] filePaths = Directory.GetFiles(path, "*.txt");

            for (int i = 0; i < filePaths.Length; i++)
            {
                StreamReader sr = new StreamReader(filePaths[i]);
                while (!sr.EndOfStream)
                {
                    sr.ReadLine();
                    teljesMeretet++;
                }
                sr.Close();
            }
            return teljesMeretet;
        }


        private void button1_Click(object sender, EventArgs e) => Close();
    }
}
