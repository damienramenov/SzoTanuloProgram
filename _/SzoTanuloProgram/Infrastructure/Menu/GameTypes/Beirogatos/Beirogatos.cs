using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SzoTanuloProgram
{
    public partial class Beirogatos : Form
    {
        static int _number = 1;

        static Random rnd = new Random();
        static int randNum;
        string eztolvasodBe = PorgetosEsBeirogatos_Almenu.ValasztottSzojegyzekFilePath;
        static int ennyivelNovelemCsokkentem = 8;
        List<Szojegyzek> _szojegyzek = new List<Szojegyzek>();


        double teljesMeret;

        class Szojegyzek
        {
            public string magyarSzo;
            public string angolSzo;
            public int szamozas;
        }



        public Beirogatos()
        {
            InitializeComponent();

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

        private void Beirogatos_Load(object sender, EventArgs e)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);
        }

        private void _buttonNext_Click(object sender, EventArgs e)
        {
            if (_number == 1)  //MUTASD
            {
                _number--;
                _buttonNext.Text = "Következő";
                Hang.Visible = true;


                _angolSzovegDoboz.Text = _szojegyzek[randNum].angolSzo;

                string angolSzovegdobozText = _angolSzovegDoboz.Text;
                SpeechUtility.Speak(angolSzovegdobozText);

                if (angolSzovegdobozText != null)
                {
                    MessageBox.Show(angolSzovegdobozText);
                }

                //TUDTA
                if (_angolSzovegDobozIros.Text.Trim() == _angolSzovegDoboz.Text.Trim())
                {

                    csekkPanel.BackColor = Color.FromArgb(89, 179, 0);

                    if (_szojegyzek[randNum].szamozas == -1)
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
                        new BeirogatosPorgetosVege().ShowDialog();
                        new FoMenu().Show();
                        Close();
                    }
                }
                //NEM TUDTA
                else
                {
                    csekkPanel.BackColor = Color.FromArgb(204, 0, 0);
                    _szojegyzek[randNum].szamozas = 0;
                    System.Threading.Thread.Sleep(100);
                }





            }
            else   //KÖVETKEZŐ
            {
                _number++;
                _buttonNext.Text = "Ellenőrzés";
                Hang.Visible = false;
                csekkPanel.BackColor = Color.FromArgb(41, 44, 51);

                _angolSzovegDoboz.Text = "";

                _angolSzovegDobozIros.Text = "";

                randNum = rnd.Next(0, _szojegyzek.Count);
                _magyarSzovegDoboz.Text = _szojegyzek[randNum].magyarSzo;
            }
        }

        private void Hang_Click(object sender, EventArgs e)
        {
            string angolSzovegdobozText = _angolSzovegDoboz.Text;
            SpeechUtility.Speak(angolSzovegdobozText);

            if (angolSzovegdobozText != null)
            {
                MessageBox.Show(angolSzovegdobozText);
            }
        }

        private void _buttonMenu_Click(object sender, EventArgs e)
        {
            Close();
            new FoMenu().Show();
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

        private void _buttonKilepes_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
