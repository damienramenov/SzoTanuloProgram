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
    public partial class Feleletvalasztos_JatekGUI : Form
    {
        static Random rnd = new Random();

        class Szojegyzek
        {
            public string _kerdes;
            public string _valasz1;
            public string _valasz2;
            public string _valasz3;
            public string _valasz4;
            public string _joValasz;

            public Szojegyzek(string kerdes, string joValasz, string valasz1, string valasz2, string valasz3, string valasz4)
            {
                _kerdes = kerdes;
                _joValasz = joValasz;
                _valasz1 = valasz1;
                _valasz2 = valasz2;
                _valasz3 = valasz3;
                _valasz4 = valasz4;
            }
            public Szojegyzek()
            {
                
            }
        }

        static List<Szojegyzek> keverendoSzojegyzek = new List<Szojegyzek>();

        static List<Szojegyzek> _szojegyzek = new List<Szojegyzek>();

        static int Indexelo = 0;
        static int Teljes = 0;
        static int JoValaszok = 0;


        public Feleletvalasztos_JatekGUI()
        {
            InitializeComponent();

            Indexelo = 0;
            Teljes = 0;
            JoValaszok = 0;

            for (int i = 0; i < _szojegyzek.Count; i++)
            {
                _szojegyzek.RemoveAt(i);
                keverendoSzojegyzek.RemoveAt(i);
                i--;
            }


            //BEKEVERI A VALASZOK sorrendjét
            for (int i = 0; i < FeleletValasztos_Almenu.BeolvasottSzojegyzek.Length; i++)
            {
                List<int> eddigiszamok = new List<int>();
                int _randNum = rnd.Next(1, 5);
                eddigiszamok.Add(_randNum);
                _randNum = VeletlenSzamEgyNegyKozott(ref eddigiszamok);
                _randNum = VeletlenSzamEgyNegyKozott(ref eddigiszamok);
                _randNum = VeletlenSzamEgyNegyKozott(ref eddigiszamok);

                string[] sor = FeleletValasztos_Almenu.BeolvasottSzojegyzek[i].Split('|');
                Szojegyzek _peldany = new Szojegyzek(sor[0], sor[1], sor[eddigiszamok[0]], sor[eddigiszamok[1]] , sor[eddigiszamok[2]] , sor[eddigiszamok[3]]);

                keverendoSzojegyzek.Add(_peldany);

            }


            //BEKEVERI A SZÓJEGYZÉKET!
            List<int> eddigiszamok2 = new List<int>();
            for (int i = 0; i < keverendoSzojegyzek.Count; i++)
            {
                int _randNum = rnd.Next(0, keverendoSzojegyzek.Count);
                while (eddigiszamok2.Contains(_randNum))
                {
                    _randNum = rnd.Next(0, keverendoSzojegyzek.Count);
                }
                eddigiszamok2.Add(_randNum);

                _szojegyzek.Add(keverendoSzojegyzek[_randNum]);
            }

            Teljes = keverendoSzojegyzek.Count;

            _labelMennyiTalalt.Text = $"0/{keverendoSzojegyzek.Count}";
            _labelEnnyiMentLe.Text = $"0/{keverendoSzojegyzek.Count}";

            if (_szojegyzek.Count == 0)
            {
                MessageBox.Show("ÜRES SZÓJEGYZÉK!!!");
                FoMenu _fm = new FoMenu();
                _fm.Show();
                this.Close();
            }


        }

        static int VeletlenSzamEgyNegyKozott(ref List<int> eddigiszamak)
        {
            int _randNum = rnd.Next(1, 5);
            while (eddigiszamak.Contains(_randNum))
            {
                _randNum = rnd.Next(1, 5);
            }
            eddigiszamak.Add(_randNum);
            return _randNum;
        }

        private void _buttonStart_Click(object sender, EventArgs e)
        {
            Console.Beep(700, 70);
            _buttonStart.Hide();
            _buttonStart.Visible = false;
            _buttonValasz1.Show();
            _buttonValasz2.Show();
            _buttonValasz3.Show();
            _buttonValasz4.Show();

            _buttonValasz1.Text = _szojegyzek[Indexelo]._valasz1;
            _buttonValasz2.Text = _szojegyzek[Indexelo]._valasz2;
            _buttonValasz3.Text = _szojegyzek[Indexelo]._valasz3;
            _buttonValasz4.Text = _szojegyzek[Indexelo]._valasz4;
            _kerdesTextBox.Text = _szojegyzek[Indexelo]._kerdes;

            _labelEnnyiMentLe.Text = $"{Indexelo+1}/{keverendoSzojegyzek.Count}";


            _buttonValasz1.BackColor = Color.FromArgb(24, 31, 54);
            _buttonValasz2.BackColor = Color.FromArgb(24, 31, 54);
            _buttonValasz3.BackColor = Color.FromArgb(24, 31, 54);
            _buttonValasz4.BackColor = Color.FromArgb(24, 31, 54);




        }

        private void _buttonValasz1_Click(object sender, EventArgs e)
        {
            Console.Beep(700, 70);

            if (_buttonStart.Visible == false)
            {
                if (_buttonValasz1.Text == _szojegyzek[Indexelo]._joValasz)
                {
                    _buttonValasz1.BackColor = Color.DarkGreen;
                    JoValaszok++;
                    _labelMennyiTalalt.Text = $"{JoValaszok}/{keverendoSzojegyzek.Count}";
                }
                else
                {
                    _buttonValasz1.BackColor = Color.DarkRed;

                    if (_buttonValasz2.Text == _szojegyzek[Indexelo]._joValasz)
                    {
                        _buttonValasz2.BackColor = Color.Green;
                    }
                    else if (_buttonValasz3.Text == _szojegyzek[Indexelo]._joValasz)
                    {
                        _buttonValasz3.BackColor = Color.Green;
                    }
                    else if (_buttonValasz4.Text == _szojegyzek[Indexelo]._joValasz)
                    {
                        _buttonValasz4.BackColor = Color.Green;
                    }
                }

                Indexelo++;


                if (Indexelo == _szojegyzek.Count)
                {
                    MessageBox.Show($"{_szojegyzek.Count} kérdésből összesen {JoValaszok} jó választ adtál...");
                    FoMenu _fMenu = new FoMenu();
                    _fMenu.Show();
                    this.Close();
                }


                _buttonStart.Show();
                _buttonStart.Visible = true;
            }
            else
            {
                //SEMME
            }
        }

        private void _buttonValasz2_Click(object sender, EventArgs e)
        {
            Console.Beep(700, 70);
            if (_buttonStart.Visible == false)
            {
                if (_buttonValasz2.Text == _szojegyzek[Indexelo]._joValasz)
                {
                    _buttonValasz2.BackColor = Color.DarkGreen;
                    JoValaszok++;
                    _labelMennyiTalalt.Text = $"{JoValaszok}/{keverendoSzojegyzek.Count}";
                }
                else
                {
                    _buttonValasz2.BackColor = Color.DarkRed;

                    if (_buttonValasz1.Text == _szojegyzek[Indexelo]._joValasz)
                    {
                        _buttonValasz1.BackColor = Color.Green;
                    }
                    else if (_buttonValasz3.Text == _szojegyzek[Indexelo]._joValasz)
                    {
                        _buttonValasz3.BackColor = Color.Green;
                    }
                    else if (_buttonValasz4.Text == _szojegyzek[Indexelo]._joValasz)
                    {
                        _buttonValasz4.BackColor = Color.Green;
                    }
                }




                Indexelo++;


                if (Indexelo == _szojegyzek.Count)
                {
                    MessageBox.Show($"{_szojegyzek.Count} kérdésből összesen {JoValaszok} jó választ adtál...");
                    FoMenu _fMenu = new FoMenu();
                    _fMenu.Show();
                    this.Close();
                }


                _buttonStart.Show();
                _buttonStart.Visible = true;
            }
            else
            {
                //SEMMI
            }
      

        }

        private void _buttonValasz3_Click(object sender, EventArgs e)
        {
            Console.Beep(700, 70);
            if (_buttonStart.Visible == false)
            {
                if (_buttonValasz3.Text == _szojegyzek[Indexelo]._joValasz)
                {
                    _buttonValasz3.BackColor = Color.DarkGreen;
                    JoValaszok++;
                    _labelMennyiTalalt.Text = $"{JoValaszok}/{keverendoSzojegyzek.Count}";
                }
                else
                {
                    _buttonValasz3.BackColor = Color.DarkRed;

                    if (_buttonValasz1.Text == _szojegyzek[Indexelo]._joValasz)
                    {
                        _buttonValasz1.BackColor = Color.Green;
                    }
                    else if (_buttonValasz2.Text == _szojegyzek[Indexelo]._joValasz)
                    {
                        _buttonValasz2.BackColor = Color.Green;
                    }
                    else if (_buttonValasz4.Text == _szojegyzek[Indexelo]._joValasz)
                    {
                        _buttonValasz4.BackColor = Color.Green;
                    }

                }




                Indexelo++;


                if (Indexelo == _szojegyzek.Count)
                {
                    MessageBox.Show($"{_szojegyzek.Count} kérdésből összesen {JoValaszok} jó választ adtál...");
                    FoMenu _fMenu = new FoMenu();
                    _fMenu.Show();
                    this.Close();
                }


                _buttonStart.Show();
                _buttonStart.Visible = true;
            }
            else
            {
                //SEMMI
            }
          

        }

        private void _buttonValasz4_Click(object sender, EventArgs e)
        {
            Console.Beep(700, 70);
            if (_buttonStart.Visible == false)
            {
                if (_buttonValasz4.Text == _szojegyzek[Indexelo]._joValasz)
                {
                    _buttonValasz4.BackColor = Color.DarkGreen;
                    JoValaszok++;
                    _labelMennyiTalalt.Text = $"{JoValaszok}/{keverendoSzojegyzek.Count}";
                }
                else
                {
                    _buttonValasz4.BackColor = Color.DarkRed;
                    if (_buttonValasz1.Text == _szojegyzek[Indexelo]._joValasz)
                    {
                        _buttonValasz1.BackColor = Color.Green;
                    }
                    else if (_buttonValasz2.Text == _szojegyzek[Indexelo]._joValasz)
                    {
                        _buttonValasz2.BackColor = Color.Green;
                    }
                    else if (_buttonValasz4.Text == _szojegyzek[Indexelo]._joValasz)
                    {
                        _buttonValasz4.BackColor = Color.Green;
                    }
                }



                Indexelo++;

                if (Indexelo == _szojegyzek.Count)
                {
                    MessageBox.Show($"{_szojegyzek.Count} kérdésből összesen {JoValaszok} jó választ adtál...");
                    FoMenu _fMenu = new FoMenu();
                    _fMenu.Show();
                    this.Close();
                }



                _buttonStart.Show();
                _buttonStart.Visible = true;
            }
            else
            {
                //SEMMI
            }

        }

        private void Quiz_Load(object sender, EventArgs e)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);

            tableLayoutPanel1.Height = (h / 10) * 5;
            tableLayoutPanel2.Height = (h / 10) * 5;

        }
    }
}
