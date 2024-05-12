using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SzoTanuloProgram
{
    public partial class FeleletValasztos_Osszes : Form
    {
        private List<string> osszesSZO = new List<string>();
        private Random rnd = new Random();


        public FeleletValasztos_Osszes()
        {
            InitializeComponent();
            string beolvasando = Directory.GetCurrentDirectory().ToString() + "\\" + "Szojegyzek_FeleletValasztos" + "\\";

            List<string> osszesSzo = new List<string>();
            string[][] filePath = new string[4][];
            filePath[0] = Directory.GetFiles(beolvasando + "Elementary", "*.txt");
            filePath[1] = Directory.GetFiles(beolvasando + "INTERMEDIATE", "*.txt");
            filePath[2] = Directory.GetFiles(beolvasando + "PreIntermediate", "*.txt");
            filePath[3] = Directory.GetFiles(beolvasando + "Proficiency", "*.txt");

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < filePath[i].Length; j++)
                {
                    string[] osszes = File.ReadAllLines(filePath[i][j]);
                    for (int k = 0; k < osszes.Length; k++)
                    {
                        osszesSzo.Add(osszes[k]);
                    }
                }
            }

            mennyiKerdes.Maximum = osszesSzo.Count;

            osszesSZO = osszesSzo;

        }

        private void _ButtonBEtolto_Click(object sender, EventArgs e)
        {
            int max = Convert.ToInt32(Math.Round(mennyiKerdes.Maximum, 0));
            int count = Convert.ToInt32(Math.Round(mennyiKerdes.Value, 0));

            string[] szavak = new string[count];
            List<int> VeletlenSzamok = new List<int>();

            for (int i = 0; i < szavak.Length; i++)
            {
                int _randNum = rnd.Next(0, max);
                while (VeletlenSzamok.Contains(_randNum))
                {
                    _randNum = rnd.Next(0, max);
                }
                VeletlenSzamok.Add(_randNum);

                szavak[i] = osszesSZO[VeletlenSzamok[i]];
            }

            FeleletValasztosMenu.beolvasottSzojegyzek = szavak;
            this.Close();


        }
    }
}
