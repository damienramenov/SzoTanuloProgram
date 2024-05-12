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
    public partial class FeleletValasztosMenu : Form
    {
        OpenFileDialog openFile = new OpenFileDialog();
        public static string[] beolvasottSzojegyzek;

        private bool isCollapsedElementary = true;
        private bool isCollapsedInter = true;
        private bool isCollapsedPreInter = true;
        private bool isCollapsedProf = true;

        public FeleletValasztosMenu()
        {
            InitializeComponent();
        }

        private void FeleletValasztosMenu_Load(object sender, EventArgs e)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);

            int _btnHeight = (((h / 10) * 9) / 16);
            tableLayoutPanel1.Height = _btnHeight * 16;
            tableLayoutPanel2.Height = h - tableLayoutPanel1.Height;

            //Elementary
            _panelElementary.Height = _btnHeight;
            _buttonElementaryFoGomb.Height = _btnHeight;
            btnElementary_1.Height = _btnHeight;
            btnElementary_2.Height = _btnHeight;
            btnElementary_3.Height = _btnHeight;
            btnElementary_4.Height = _btnHeight;
            btnElementary_5.Height = _btnHeight;
            btnElementary_6.Height = _btnHeight;
            btnElementary_7.Height = _btnHeight;
            btnElementary_8.Height = _btnHeight;
            btnElementary_9.Height = _btnHeight;
            btnElementary_10.Height = _btnHeight;
            btnElementary_11.Height = _btnHeight;
            btnElementary_12.Height = _btnHeight;
            btnElementary_13.Height = _btnHeight;
            btnElementary_14.Height = _btnHeight;
            btnElementary_15.Height = _btnHeight;

            //INter
            _panelIntermediate.Height = _btnHeight;
            _buttonIntermediateFoGomb.Height = _btnHeight;
            btnIntermedate_1.Height = _btnHeight;
            btnIntermedate_2.Height = _btnHeight;
            btnIntermedate_3.Height = _btnHeight;
            btnIntermedate_4.Height = _btnHeight;
            btnIntermedate_5.Height = _btnHeight;
            btnIntermedate_6.Height = _btnHeight;
            btnIntermedate_7.Height = _btnHeight;
            btnIntermedate_8.Height = _btnHeight;
            btnIntermedate_9.Height = _btnHeight;
            btnIntermedate_10.Height = _btnHeight;
            btnIntermedate_11.Height = _btnHeight;
            btnIntermedate_12.Height = _btnHeight;
            btnIntermedate_13.Height = _btnHeight;
            btnIntermedate_14.Height = _btnHeight;
            btnIntermedate_15.Height = _btnHeight;

            //Preinter
            _panel_PreIntermediate.Height = _btnHeight;
            _buttonPreIntermediateFoGomb.Height = _btnHeight;
            btnPreIntermediate_1.Height = _btnHeight;
            btnPreIntermediate_2.Height = _btnHeight;
            btnPreIntermediate_3.Height = _btnHeight;
            btnPreIntermediate_4.Height = _btnHeight;
            btnPreIntermediate_5.Height = _btnHeight;
            btnPreIntermediate_6.Height = _btnHeight;
            btnPreIntermediate_7.Height = _btnHeight;
            btnPreIntermediate_8.Height = _btnHeight;
            btnPreIntermediate_9.Height = _btnHeight;
            btnPreIntermediate_10.Height = _btnHeight;
            btnPreIntermediate_11.Height = _btnHeight;
            btnPreIntermediate_12.Height = _btnHeight;
            btnPreIntermediate_13.Height = _btnHeight;
            btnPreIntermediate_14.Height = _btnHeight;
            btnPreIntermediate_15.Height = _btnHeight;

            //Prof
            _panelProficiency.Height = _btnHeight;
            _buttonProficiencyFoGomb.Height = _btnHeight;
            btnProficiency_1.Height = _btnHeight;
            btnProficiency_2.Height = _btnHeight;
            btnProficiency_3.Height = _btnHeight;
            btnProficiency_4.Height = _btnHeight;
            btnProficiency_5.Height = _btnHeight;
            btnProficiency_6.Height = _btnHeight;
            btnProficiency_7.Height = _btnHeight;
            btnProficiency_8.Height = _btnHeight;
            btnProficiency_9.Height = _btnHeight;
            btnProficiency_10.Height = _btnHeight;
            btnProficiency_11.Height = _btnHeight;
            btnProficiency_12.Height = _btnHeight;
            btnProficiency_13.Height = _btnHeight;
            btnProficiency_14.Height = _btnHeight;
            btnProficiency_15.Height = _btnHeight;

        }

        #region DropDownList
        private void ElementaryDropDownListTimer_Tick(object sender, EventArgs e)
        {
            if (isCollapsedElementary)
            {
                int _height = 0;
                int before = _panelElementary.Height;
                _panelElementary.Height += 16;

                if (before == _panelElementary.Height)
                {
                    _height = tableLayoutPanel1.Height - _panelElementary.Height;
                    _panelElementary.Height += _height;
                }

                if (_panelElementary.Height >= (int)(tableLayoutPanel1.Height - _height))
                {
                    ElementaryDropDownListTimer.Stop();
                    isCollapsedElementary = false;
                }
            }
            else
            {
                _panelElementary.Height -= 16;
                if (_panelElementary.Height <= _buttonElementaryFoGomb.Height)
                {
                    ElementaryDropDownListTimer.Stop();
                    isCollapsedElementary = true;
                }
            }
        }

        private void _buttonElementaryFoGomb_Click(object sender, EventArgs e)
        {
            ElementaryDropDownListTimer.Start();
        }

        private void IntermediateDropDownListTimer_Tick(object sender, EventArgs e)
        {
            if (isCollapsedInter)
            {
                int _height = 0;
                int before = _panelIntermediate.Height;
                _panelIntermediate.Height += 16;

                if (before == _panelIntermediate.Height)
                {
                    _height = tableLayoutPanel1.Height - _panelIntermediate.Height;
                    _panelIntermediate.Height += _height;
                }

                if (_panelIntermediate.Height >= (int)(tableLayoutPanel1.Height - _height))
                {
                    IntermediateDropDownListTimer.Stop();
                    isCollapsedInter = false;
                }
            }
            else
            {
                _panelIntermediate.Height -= 16;
                if (_panelIntermediate.Height <= _buttonElementaryFoGomb.Height)
                {
                    IntermediateDropDownListTimer.Stop();
                    isCollapsedInter = true;
                }
            }
        }

        private void _buttonIntermediateFoGomb_Click(object sender, EventArgs e)
        {
            IntermediateDropDownListTimer.Start();
        }

        private void PreIntermediateTimer_Tick(object sender, EventArgs e)
        {
            if (isCollapsedPreInter)
            {
                int _height = 0;
                int before = _panel_PreIntermediate.Height;
                _panel_PreIntermediate.Height += 16;

                if (before == _panel_PreIntermediate.Height)
                {
                    _height = tableLayoutPanel1.Height - _panel_PreIntermediate.Height;
                    _panel_PreIntermediate.Height += _height;
                }
                if (_panel_PreIntermediate.Height >= (int)(tableLayoutPanel1.Height - _height))
                {
                    PreIntermediateTimer.Stop();
                    isCollapsedPreInter = false;
                }
            }
            else
            {
                _panel_PreIntermediate.Height -= 16;
                if (_panel_PreIntermediate.Height <= _buttonElementaryFoGomb.Height)
                {
                    PreIntermediateTimer.Stop();
                    isCollapsedPreInter = true;
                }
            }
        }

        private void _buttonPreIntermediateFoGomb_Click(object sender, EventArgs e)
        {
            PreIntermediateTimer.Start();
        }

        private void ProficiencyTimer_Tick(object sender, EventArgs e)
        {
            if (isCollapsedProf)
            {
                int _height = 0;
                int before = _panelProficiency.Height;
                _panelProficiency.Height += 16;

                if (before == _panelProficiency.Height)
                {
                    _height = tableLayoutPanel1.Height - _panelProficiency.Height;
                    _panelProficiency.Height += _height;
                }
                if (_panelProficiency.Height >= (int)(tableLayoutPanel1.Height - _height))
                {
                    ProficiencyTimer.Stop();
                    isCollapsedProf = false;
                }
            }
            else
            {
                _panelProficiency.Height -= 16;
                if (_panelProficiency.Height <= _buttonElementaryFoGomb.Height)
                {
                    ProficiencyTimer.Stop();
                    isCollapsedProf = true;
                }
            }

        }

        private void _buttonProficiencyFoGomb_Click(object sender, EventArgs e)
        {
            ProficiencyTimer.Start();
        }



        #endregion

        private void OsszesSzoJegyzekClick(object sender, EventArgs e)
        {
            Button _btn = (Button)sender;

            string beolvasando = "Szojegyzek_FeleletValasztos" + "\\";


            if (_btn.Name.Contains("btnElementary"))
            {
                string[] darabolt = _btn.Name.Split('_');
                int szojegyzekSzama = int.Parse(darabolt[1]);
                beolvasando += "\\" + "Elementary" + "\\" + "Elementary_" + darabolt[1] + ".txt";
            }
            else if (_btn.Name.Contains("btnIntermedate"))
            {
                string[] darabolt = _btn.Name.Split('_');
                int szojegyzekSzama = int.Parse(darabolt[1]);
                beolvasando += "\\" + "Intermediate" + "\\" + "Intermediate_" + darabolt[1] + ".txt";
            }
            else if (_btn.Name.Contains("btnPreIntermediate"))
            {
                string[] darabolt = _btn.Name.Split('_');
                int szojegyzekSzama = int.Parse(darabolt[1]);
                beolvasando += "\\" + "PreIntermediate" + "\\" + "PreIntermediate_" + darabolt[1] + ".txt";
            }
            else if (_btn.Name.Contains("btnProficiency"))
            {

                string[] darabolt = _btn.Name.Split('_');
                int szojegyzekSzama = int.Parse(darabolt[1]);
                beolvasando += "\\" + "Proficiency" + "\\" + "Proficiency_" + darabolt[1] + ".txt";
            }

            beolvasottSzojegyzek = File.ReadAllLines(beolvasando);

            if (beolvasottSzojegyzek.Length == 0)
            {
                MessageBox.Show("ÜRES SZÓJEGYZÉK!!!");
                FoMenu _fm = new FoMenu();
                _fm.Show();
                this.Close();
            }
            else
            {
                Quiz q = new Quiz();
                this.Hide();
                q.Show();
            }
        }

        private void OsszesGombEgerRavisz(object sender, EventArgs e)
        {
            Button _btn = (Button)sender;

            string beolvasando = "Szojegyzek_FeleletValasztos" + "\\";


            if (_btn.Name.Contains("btnElementary"))
            {
                string[] darabolt = _btn.Name.Split('_');
                int szojegyzekSzama = int.Parse(darabolt[1]);
                beolvasando += "\\" + "Elementary" + "\\" + "Elementary_" + darabolt[1] + ".txt";
            }
            else if (_btn.Name.Contains("btnIntermedate"))
            {
                string[] darabolt = _btn.Name.Split('_');
                int szojegyzekSzama = int.Parse(darabolt[1]);
                beolvasando += "\\" + "Intermediate" + "\\" + "Intermediate_" + darabolt[1] + ".txt";
            }
            else if (_btn.Name.Contains("btnPreIntermediate"))
            {
                string[] darabolt = _btn.Name.Split('_');
                int szojegyzekSzama = int.Parse(darabolt[1]);
                beolvasando += "\\" + "PreIntermediate" + "\\" + "PreIntermediate_" + darabolt[1] + ".txt";
            }
            else if (_btn.Name.Contains("btnProficiency"))
            {

                string[] darabolt = _btn.Name.Split('_');
                int szojegyzekSzama = int.Parse(darabolt[1]);
                beolvasando += "\\" + "Proficiency" + "\\" + "Proficiency_" + darabolt[1] + ".txt";
            }

            string[] osszes = File.ReadAllLines(beolvasando);
            _labelMennyiSzo.Text = osszes.Length.ToString() + " kérdés..";

        }

        private void _buttonProficiencyFoGomb_MouseHover(object sender, EventArgs e)
        {
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

            _labelMennyiSzo.Text = teljesMeret.ToString() + " kérdés..";
        }

        private void _buttonSajat_Click(object sender, EventArgs e)
        {
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                string nev = openFile.FileName;
                bool text = nev.Contains(".txt");


                StreamReader sr = new StreamReader(openFile.FileName);
                bool jo = true;
                while (!sr.EndOfStream)
                {
                    bool tartalmaz = false;
                    string sor = sr.ReadLine();

                    int db = 0;

                    for (int i = 0; i < sor.Length; i++)
                    {
                        if (sor[i].ToString() == "|")
                        {
                            db++;
                        }
                    }
                    if (db == 4)
                    {
                        tartalmaz = true;
                    }
                    if (tartalmaz == false)
                    {
                        jo = false;
                    }
                }


                if (text == false)
                {
                    MessageBox.Show("Csak txt file okat tölthetsz be!");
                }

                if (jo == true && text == true)
                {
                    openFile.FileName = openFile.FileName.Remove(openFile.FileName.Length - 4, 4);
                    beolvasottSzojegyzek = File.ReadAllLines(openFile.FileName + ".txt");
                    
                    Quiz _quiz = new Quiz();
                    _quiz.Show();
                    this.Hide();

                }
                else if (jo != true && text == true)
                {
                    MessageBox.Show("Valami hiba van a txt fileodba, nézd át, hogy megfelelően van-e felbontva a szójegyzék: PLD: (  kérdés | jóválasz | válasz2 | válasz3 | válasz 4)");
                }
            }
        }

        private void _buttonEgyTeljesSzojegyzek_Click(object sender, EventArgs e)
        {
            FeleletValasztos_TeljesSzoJegyzek fvt = new FeleletValasztos_TeljesSzoJegyzek();
            fvt.ShowDialog();

            if (beolvasottSzojegyzek.Length == 0)
            {
                MessageBox.Show("ÜRES SZÓJEGYZÉK!!!");
                FoMenu _fm = new FoMenu();
                _fm.Show();
                this.Close();
            }
            else
            {
                Quiz q = new Quiz();
                this.Hide();
                q.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FeleletValasztos_Osszes fvt = new FeleletValasztos_Osszes();
            fvt.ShowDialog();

            if (beolvasottSzojegyzek.Length == 0)
            {
                MessageBox.Show("ÜRES SZÓJEGYZÉK!!!");
                FoMenu _fm = new FoMenu();
                _fm.Show();
                this.Close();
            }
            else
            {
                Quiz q = new Quiz();
                this.Hide();
                q.Show();
            }
        }
    }
}
