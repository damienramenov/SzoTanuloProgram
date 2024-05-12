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
    public partial class ProgetosEsBeirogatos : Form
    {
        OpenFileDialog openFile = new OpenFileDialog();
        public static string valasztott = "";
        public static bool sajat = false;


        private bool isCollapsed_1 = true;
        private bool isCollapsed_2 = true;
        private bool isCollapsed_3 = true;
        private bool isCollapsed_4 = true;

        public ProgetosEsBeirogatos()
        {
            InitializeComponent();
        }

        private void Tipus_1_Magyar_Angol_Szavak_Load(object sender, EventArgs e)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);

            int _height = h / 5;
            sajat = false;

        }


        //ELEMENTARY
        private void ElementaryDropDownListTimer_Tick(object sender, EventArgs e)
        {
            if (isCollapsed_1)
            {
                ElementaryDropDownPanel.Width += 15;
                if (ElementaryDropDownPanel.Width >= 1265)
                {
                    ElementaryDropDownListTimer.Stop();
                    isCollapsed_1 = false;
                }
            }
            else
            {
                ElementaryDropDownPanel.Width -= 15;
                if (ElementaryDropDownPanel.Width <= ElementaryFoButton.Width)
                {
                    ElementaryDropDownListTimer.Stop();
                    isCollapsed_1 = true;
                }
            }

        }

        private void ElementaryFoButton_Click(object sender, EventArgs e)
        {
            ElementaryDropDownListTimer.Start();
        }

        //----------------------------------------------
        //Intermediate

        private void IntermediateDropDownListTimer_Tick(object sender, EventArgs e)
        {
            if (isCollapsed_2)
            {
                IntermediateDropDownListPanel.Width += 15;
                if (IntermediateDropDownListPanel.Width >= 1265)
                {
                    IntermediateDropDownListTimer.Stop();
                    isCollapsed_2 = false;
                }
            }
            else
            {
                IntermediateDropDownListPanel.Width -= 15;
                if (IntermediateDropDownListPanel.Width <= ElementaryFoButton.Width)
                {
                    IntermediateDropDownListTimer.Stop();
                    isCollapsed_2 = true;
                }
            }
        }

        private void IntermediateFoGomb_Click(object sender, EventArgs e)
        {
            IntermediateDropDownListTimer.Start();
        }

        //----------------------------------------------
        //PreIntermediate
        private void PreIntermediateTimer_Tick(object sender, EventArgs e)
        {
            if (isCollapsed_3)
            {
                PreintermedateDropDownListPanel.Width += 15;
                if (PreintermedateDropDownListPanel.Width >= 1265)
                {
                    PreIntermediateTimer.Stop();
                    isCollapsed_3 = false;
                }
            }
            else
            {
                PreintermedateDropDownListPanel.Width -= 15;
                if (PreintermedateDropDownListPanel.Width <= ElementaryFoButton.Width)
                {
                    PreIntermediateTimer.Stop();
                    isCollapsed_3 = true;
                }
            }

        }

        private void PreIntermediateFoGomb_Click(object sender, EventArgs e)
        {
            PreIntermediateTimer.Start();
        }

        //----------------------------------------------
        //Proficiency
        private void ProficiencyTimer_Tick(object sender, EventArgs e)
        {
            if (isCollapsed_4)
            {
                ProficiencyDropDownList.Width += 15;
                if (ProficiencyDropDownList.Width >= 1265)
                {
                    ProficiencyTimer.Stop();
                    isCollapsed_4 = false;
                }
            }
            else
            {
                ProficiencyDropDownList.Width -= 15;
                if (ProficiencyDropDownList.Width <= ElementaryFoButton.Width)
                {
                    ProficiencyTimer.Stop();
                    isCollapsed_4 = true;
                }
            }
        }

        private void ProficiencyFoGomb_Click(object sender, EventArgs e)
        {
            ProficiencyTimer.Start();
        }




        //----------------------------------------------------------------------------------------------------------------------
        //SAJÁT
        private void SajatSzojegyzek_Click(object sender, EventArgs e)
        {
            sajat = true;
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
                    if (sor.Contains("|"))
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
                    valasztott = openFile.FileName + ".txt";

                    if (FoMenu.tipus_1_magyar_angol == true)
                    {
                        Szavak_Magyar_Angol_Porgetos nyisd = new Szavak_Magyar_Angol_Porgetos();
                        this.Hide();
                        nyisd.Show();
                    }
                    else if (FoMenu.tipus_1_angol_magyar == true)
                    {
                        Szavak_Angol_Magyar_Porgetos nyisd = new Szavak_Angol_Magyar_Porgetos();
                        this.Hide();
                        nyisd.Show();
                    }
                    else if (FoMenu.beirogatos == true)
                    {
                        Beirogatos nyisd = new Beirogatos();
                        this.Hide();
                        nyisd.Show();
                    }
                    else if (FoMenu.minijatek == true)
                    {
                        Memoria_Jatek nyisd = new Memoria_Jatek();
                        nyisd.Show();
                        this.Close();
                    }
                }
                else if (jo != true && text == true)
                {
                    MessageBox.Show("Valami hiba van a txt fileodba, nézd át, hogy megfelelően van-e felbontva a szójegyzék: PLD: (  angolSZÓ|magyarMegfelelője  )");
                }



            }
        }

        private void OsszesSzojegyzekGombKattintas(object sender, EventArgs e)
        {
            Button _btn = (Button)sender;

            valasztott = "SzoJegyzekek";

            if (_btn.Name.Contains("btnElementary"))
            {
                string[] darabolt = _btn.Name.Split('_');
                int szojegyzekSzama = int.Parse(darabolt[1]);
                valasztott += "\\" + "Elementary" + "\\" + "Elementary_Unit" + darabolt[1] + ".txt";
            }
            else if (_btn.Name.Contains("btnIntermedate"))
            {
                string[] darabolt = _btn.Name.Split('_');
                int szojegyzekSzama = int.Parse(darabolt[1]);
                valasztott += "\\" + "Intermediate" + "\\" + "Intermediate_Unit" + darabolt[1] + ".txt";
            }
            else if (_btn.Name.Contains("btnPreIntermediate"))
            {
                string[] darabolt = _btn.Name.Split('_');
                int szojegyzekSzama = int.Parse(darabolt[1]);
                valasztott += "\\" + "PreIntermediate" + "\\" + "Pre_Intermediate_Unit" + darabolt[1] + ".txt";
            }
            else if (_btn.Name.Contains("btnProficiency"))
            {
                
                string[] darabolt = _btn.Name.Split('_');
                int szojegyzekSzama = int.Parse(darabolt[1]);
                valasztott += "\\" + "Proficiency" + "\\" + "Proficiency_Unit" + darabolt[1] + ".txt";
            }


            if (FoMenu.tipus_1_magyar_angol == true)
            {
                Szavak_Magyar_Angol_Porgetos nyisd = new Szavak_Magyar_Angol_Porgetos();
                nyisd.Show();
                this.Close();
            }
            else if (FoMenu.tipus_1_angol_magyar == true)
            {
                Szavak_Angol_Magyar_Porgetos nyisd = new Szavak_Angol_Magyar_Porgetos();
                nyisd.Show();
                this.Close();
            }
            else if (FoMenu.beirogatos == true)
            {
                Beirogatos nyisd = new Beirogatos();
                nyisd.Show();
                this.Close();
            }
            else if (FoMenu.minijatek == true)
            {
                Memoria_Jatek nyisd = new Memoria_Jatek();
                nyisd.Show();
                this.Close();
            }


        }


    }
}
