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
    public partial class FeleletValasztos_TeljesSzoJegyzek : Form
    {
        static Random rnd = new Random();
        private string[] osszesSzo;

        public FeleletValasztos_TeljesSzoJegyzek()
        {
            InitializeComponent();
        }

        private void _buttonIntermediateFoGomb_Click(object sender, EventArgs e)
        {

        }



        private void NegyFoTipus(object sender, EventArgs e)
        {
            _ButtonBEtolto.Visible = true;

            Button _btn = sender as Button;
            string beolvasando = Directory.GetCurrentDirectory().ToString() + "\\" + "Szojegyzek_FeleletValasztos" + "\\";

            if (_btn.Text == "ELEMENTARY")
            {
                beolvasando += "Elementary";
            }
            else if (_btn.Text == "INTERMEDIATE")
            {
                beolvasando += "Intermediate";
            }
            else if (_btn.Text == "PRE INTERMEDIATE")
            {
                beolvasando += "PreIntermediate";
            }
            else if (_btn.Text == "PROFICIENCY")
            {
                beolvasando += "Proficiency";
            }

            string[] filePaths = Directory.GetFiles(beolvasando, "*.txt");
            int teljesMeret = 0;
            for (int i = 0; i < filePaths.Length; i++)
            {
                string[] array = File.ReadAllLines(filePaths[i]);
                teljesMeret += array.Length;

            }

            osszesSzo = new string[teljesMeret];
            int idx = 0;
            for (int i = 0; i < filePaths.Length; i++)
            {
                string[] array = File.ReadAllLines(filePaths[i]);
                for (int k = 0; k < array.Length; k++)
                {
                    osszesSzo[idx] = array[k];
                    idx++;
                }
            }
            mennyiKerdes.Maximum = teljesMeret;
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

                szavak[i] = osszesSzo[VeletlenSzamok[i]];
            }

            FeleletValasztosMenu.beolvasottSzojegyzek = szavak;
            this.Close();
        }
    }
}
