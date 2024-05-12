using DarrenLee.SpeechSynthesis;
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
using System.Speech.Synthesis;

namespace SzoTanuloProgram
{
    public partial class Szavak_Magyar_Angol_Porgetos : Form
    {
        static Random rnd = new Random();
        static int randNum;
        string eztolvasodBe = ProgetosEsBeirogatos.valasztott;
        static int ennyivelNovelemCsokkentem = 8;
        List<Szojegyzek> _szojegyzek = new List<Szojegyzek>();


        double teljesMeret;

        class Szojegyzek
        {
            public string magyarSzo;
            public string angolSzo;
            public int szamozas;
        }

        public Szavak_Magyar_Angol_Porgetos()
        {
            InitializeComponent();
            _magyarSzovegDoboz.SelectionAlignment = HorizontalAlignment.Center;
            _angolSzovegDoboz.SelectionAlignment = HorizontalAlignment.Center;

            pictureBox2.Hide();

            teljesMeret = 0;

            StreamReader sr = new StreamReader(eztolvasodBe);
            while (!sr.EndOfStream)
            {
                string[] sor = sr.ReadLine().Split('|');
                Szojegyzek actual = new Szojegyzek();
                actual.magyarSzo = sor[1];
                actual.angolSzo = sor[0];
                actual.szamozas = -1;
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
            _magyarSzovegDoboz.Text = _szojegyzek[randNum].magyarSzo;


        }

        private void Szavak_Magyar_Angol_Porgetos_Load(object sender, EventArgs e)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);
            
        }

        private void Mutasd_Gomb_Click(object sender, EventArgs e)
        {
            Mutasd_Gomb.Hide();
            Tudtam_Gomb.Show();
            NemTudtam_Gomb.Show();
            pictureBox2.Show();
            

            _angolSzovegDoboz.Text =  _szojegyzek[randNum].angolSzo;
                
            SpeechHelper.Rate = 0;
            string beszel = SpeechHelper.Speak("en-US", "Microsoft Zira Desktop", _angolSzovegDoboz.Text);
            if (beszel != null)
            {
                MessageBox.Show(beszel);
            }
                
        }



        private void Tudtam_Gomb_Click(object sender, EventArgs e)
        {
            Tudtam_Gomb.Hide();
            NemTudtam_Gomb.Hide();
            pictureBox2.Hide();
            Mutasd_Gomb.Show();

            //ha -1 , akkor elsőre tudta igy kivehető!
            if (_szojegyzek[randNum].szamozas == -1)
            {
                _szojegyzek.RemoveAt(randNum);

                int szazlekhoz = (int)teljesMeret - _szojegyzek.Count;

                double szazalekAlso = Math.Round(((szazlekhoz / teljesMeret)*100),2);
                double szazalekFelso = Math.Round((100-szazalekAlso),2);
                _labelHatravanSzazalek.Text = szazalekFelso.ToString() + "%";
                _labelEnnyiKellSzazalek.Text = szazalekAlso.ToString() + "%";

                _eztNovelemPanel.Width += ennyivelNovelemCsokkentem;
                _csokkentemPanel.Width -= ennyivelNovelemCsokkentem;


            }
            //ha 0 vagy 1
            else if (_szojegyzek[randNum].szamozas == 0)
            {
                _szojegyzek[randNum].szamozas++;
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
                _beirogatosPorgetosVege VEGE = new _beirogatosPorgetosVege();
                VEGE.ShowDialog();
                FoMenu _fmenu = new FoMenu();
                _fmenu.Show();
                this.Close();
            }
            else
            {
                System.Threading.Thread.Sleep(100);
                randNum = rnd.Next(0, _szojegyzek.Count);
                _magyarSzovegDoboz.Text = _szojegyzek[randNum].magyarSzo;
                _angolSzovegDoboz.Text = "";
            }
        }

        private void NemTudtam_Gomb_Click(object sender, EventArgs e)
        {
            Tudtam_Gomb.Hide();
            NemTudtam_Gomb.Hide();
            pictureBox2.Hide();
            Mutasd_Gomb.Show();

            _szojegyzek[randNum].szamozas = 0;

            System.Threading.Thread.Sleep(100);
            randNum = rnd.Next(0, _szojegyzek.Count);
            _magyarSzovegDoboz.Text = _szojegyzek[randNum].magyarSzo;
            _angolSzovegDoboz.Text = "";
        }

        //ANGÓL
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SpeechHelper.Rate = 0;
            string beszel = SpeechHelper.Speak("en-US", "Microsoft Zira Desktop", _angolSzovegDoboz.Text);
            if (beszel != null)
            {
                MessageBox.Show(beszel);
            }
        }

        private void _buttonMenu_Click(object sender, EventArgs e)
        {
            FoMenu _fMenu = new FoMenu();
            this.Close();
            _fMenu.Show();
        }

        private void _buttonKilepes_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
                        sw.WriteLine(_szojegyzek[i].angolSzo + "|" + _szojegyzek[i].magyarSzo);
                    }
                }


            }
        }
    }
}
