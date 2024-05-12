using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SzoTanuloProgram
{
    public partial class Szavak_Angol_Magyar_Porgetos : Form
    {
        static Random rnd = new Random();
        static int randNum;
        string eztolvasodBe = PorgetosEsBeirogatos_Almenu.ValasztottSzojegyzekFilePath;
        static int ennyivelNovelemCsokkentem = 8;
        List<Szojegyzek> _szojegyzek = new List<Szojegyzek>();


        double teljesMeret;

        class Szojegyzek
        {
            public string MagyarSzo;
            public string AngolSzo;
            public int Szamozas;
        }


        public Szavak_Angol_Magyar_Porgetos()
        {
            InitializeComponent();

            _magyarSzovegDoboz.SelectionAlignment = HorizontalAlignment.Center;
            _angolSzovegDoboz.SelectionAlignment = HorizontalAlignment.Center;


            teljesMeret = 0;

            StreamReader sr = new StreamReader(eztolvasodBe);
            while (!sr.EndOfStream)
            {
                string[] sor = sr.ReadLine().Split('|');
                Szojegyzek actual = new Szojegyzek();
                actual.MagyarSzo = sor[0];
                actual.AngolSzo = sor[1];
                actual.Szamozas = -1;
                _szojegyzek.Add(actual);

                teljesMeret++;
            }

            int w = (Screen.PrimaryScreen.Bounds.Width) - _labelEnnyiKellSzazalek.Width;
            ennyivelNovelemCsokkentem = (int)(w / teljesMeret);



            int _panelSzel = (int)teljesMeret * ennyivelNovelemCsokkentem;
            _alapFelso.Size = new Size(_panelSzel, 40);
            _csokkentemPanel.Size = new Size(_panelSzel, 40);
            _alapAlso.Size = new Size(_panelSzel, 40);
            _eztNovelemPanel.Size = new Size(0, 40);


            randNum = rnd.Next(0, _szojegyzek.Count);
            _magyarSzovegDoboz.Text = _szojegyzek[randNum].MagyarSzo;


            var magyarSzovegDobozText = _magyarSzovegDoboz.Text.Trim();
            SpeechUtility.Speak(magyarSzovegDobozText);

            if (magyarSzovegDobozText != null)
            {
                MessageBox.Show(magyarSzovegDobozText);
            }
        }

        private void Mutasd_Gomb_Click(object sender, EventArgs e)
        {
            Mutasd_Gomb.Hide();
            Tudtam_Gomb.Show();
            NemTudtam_Gomb.Show();


            _angolSzovegDoboz.Text = _szojegyzek[randNum].AngolSzo;
        }

        private void Tudtam_Gomb_Click(object sender, EventArgs e)
        {
            Tudtam_Gomb.Hide();
            NemTudtam_Gomb.Hide();
            Mutasd_Gomb.Show();

            //ha -1 , akkor elsőre tudta igy kivehető!
            if (_szojegyzek[randNum].Szamozas == -1)
            {
                _szojegyzek.RemoveAt(randNum);

                int szazlekhoz = (int)teljesMeret - _szojegyzek.Count;

                double szazalekAlso = Math.Round(((szazlekhoz / teljesMeret) * 100), 2);
                double szazalekFelso = Math.Round((100 - szazalekAlso), 2);
                _labelHatravanSzazalek.Text = szazalekFelso.ToString() + "%";
                _labelEnnyiKellSzazalek.Text = szazalekAlso.ToString() + "%";

                _eztNovelemPanel.Width += ennyivelNovelemCsokkentem;
                _csokkentemPanel.Width -= ennyivelNovelemCsokkentem;


            }
            //ha 0 vagy 1
            else if (_szojegyzek[randNum].Szamozas == 0)
            {
                _szojegyzek[randNum].Szamozas++;
            }
            else
            {
                _szojegyzek.RemoveAt(randNum);


                int szazlekhoz = (int)teljesMeret - _szojegyzek.Count;

                double szazalekAlso = Math.Round(((szazlekhoz / teljesMeret) * 100), 2);
                double szazalekFelso = Math.Round((100 - szazalekAlso), 2);
                _labelHatravanSzazalek.Text = szazalekFelso.ToString() + "%";
                _labelEnnyiKellSzazalek.Text = szazalekAlso.ToString() + "%";


                _eztNovelemPanel.Width += ennyivelNovelemCsokkentem;
                _csokkentemPanel.Width -= ennyivelNovelemCsokkentem;
            }

            if (_szojegyzek.Count == 0)
            {
                //nincs több szó, nyertél
                new BeirogatosPorgetosVege().ShowDialog();
                new FoMenu().Show();
                Hide();
            }
            else
            {
                System.Threading.Thread.Sleep(100);
                randNum = rnd.Next(0, _szojegyzek.Count);
                _magyarSzovegDoboz.Text = _szojegyzek[randNum].MagyarSzo;
                _angolSzovegDoboz.Text = "";

                var magyarSzovegDobozText = _magyarSzovegDoboz.Text.Trim();
                SpeechUtility.Speak(magyarSzovegDobozText);

                if (magyarSzovegDobozText != null)
                {
                    MessageBox.Show(magyarSzovegDobozText);
                }
            }
        }

        private void NemTudtam_Gomb_Click(object sender, EventArgs e)
        {
            Tudtam_Gomb.Hide();
            NemTudtam_Gomb.Hide();
            Mutasd_Gomb.Show();

            _szojegyzek[randNum].Szamozas = 0;

            System.Threading.Thread.Sleep(100);
            randNum = rnd.Next(0, _szojegyzek.Count);
            _magyarSzovegDoboz.Text = _szojegyzek[randNum].MagyarSzo;
            _angolSzovegDoboz.Text = "";

            pictureBox2_Click(sender, e);
        }

        private void _buttonMenu_Click(object sender, EventArgs e)
        {
            new FoMenu().Show();
            Hide();
        }

        private void _buttonMentes_Click(object sender, EventArgs e)
        {
            SaveFileDialog Mented = new SaveFileDialog();
            if (Mented.ShowDialog() == DialogResult.OK)
            {
                using (Stream s = File.Open(Mented.FileName, FileMode.CreateNew))
                using (StreamWriter sw = new StreamWriter(s))
                {
                    for (int i = 0; i < _szojegyzek.Count; i++)
                    {
                        sw.WriteLine(_szojegyzek[i].AngolSzo + "|" + _szojegyzek[i].MagyarSzo);
                    }
                }
            }
        }

        private void _buttonKilepes_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            var magyarSzovegDobozText = _magyarSzovegDoboz.Text.Trim();
            SpeechUtility.Speak(magyarSzovegDobozText);

            if (magyarSzovegDobozText != null)
            {
                MessageBox.Show(magyarSzovegDobozText);
            }
        }

        private void Szavak_Angol_Magyar_Porgetos_Load(object sender, EventArgs e)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);
        }
    }
}
