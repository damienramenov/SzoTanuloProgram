using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using SzoTanuloProgram.Infrastructure.Menu;
using SzoTanuloProgram.Infrastructure.Utilities.Enums;

namespace SzoTanuloProgram
{
    public partial class PorgetosEsBeirogatos_Almenu : Form
    {
        OpenFileDialog openFile = new OpenFileDialog();
        public static string ValasztottSzojegyzekFilePath = "";
        public static bool IsSajatSzojegyzek;


        private bool isCollapsed_1 = true;
        private bool isCollapsed_2 = true;
        private bool isCollapsed_3 = true;
        private bool isCollapsed_4 = true;

        public PorgetosEsBeirogatos_Almenu()
        {
            InitializeComponent();
        }

        private void Tipus_1_Magyar_Angol_Szavak_Load(object sender, EventArgs e)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);

            IsSajatSzojegyzek = false;
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
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                var filePath = openFile.FileName;

                var hibauzenet = FileService.ValidateFilePathAsSzojegyzek(filePath);

                if (hibauzenet != string.Empty)
                {
                    MessageBox.Show(hibauzenet);

                    return;
                }

                ValasztottSzojegyzekFilePath = filePath;

                IsSajatSzojegyzek = true;

                switch (FoMenu.SelectedGameType)
                {
                    case GameType.Beirogatos:
                        new Beirogatos().Show();
                        break;
                    case GameType.Memoriajatek:
                        new Memoriajatek().Show();
                        break;
                    case GameType.Porgetos_Magyar_Angol:
                        new Szavak_Angol_Magyar_Porgetos().Show();
                        break;
                    case GameType.Porgetos_Angol_Magyar:
                        new Szavak_Angol_Magyar_Porgetos().Show();
                        break;
                    default:
                        return;
                }

                Hide();
            }
        }

        private void OsszesSzojegyzekGombKattintas(object sender, EventArgs e)
        {
            Button _btn = (Button)sender;

            ValasztottSzojegyzekFilePath = "SzoJegyzekek";

            string[] darabolt = _btn.Name.Split('_');
            int szojegyzekSzama = int.Parse(darabolt[1]);

            if (_btn.Name.Contains("btnElementary"))
            {
                ValasztottSzojegyzekFilePath = FileService.GetSzojegyzekFile(SzojegyzekType.Elementary, szojegyzekSzama);
            }
            else if (_btn.Name.Contains("btnIntermedate"))
            {
                ValasztottSzojegyzekFilePath = FileService.GetSzojegyzekFile(SzojegyzekType.Intermediate, szojegyzekSzama);
            }
            else if (_btn.Name.Contains("btnPreIntermediate"))
            {
                ValasztottSzojegyzekFilePath = FileService.GetSzojegyzekFile(SzojegyzekType.PreIntermediate, szojegyzekSzama);
            }
            else if (_btn.Name.Contains("btnProficiency"))
            {
                ValasztottSzojegyzekFilePath = FileService.GetSzojegyzekFile(SzojegyzekType.Proficiency, szojegyzekSzama);
            }

            switch (FoMenu.SelectedGameType)
            {
                case GameType.Beirogatos:
                    new Beirogatos().Show();
                    break;
                case GameType.Memoriajatek:
                    new Memoriajatek().Show();
                    break;
                case GameType.Porgetos_Magyar_Angol:
                    new Szavak_Magyar_Angol_Porgetos().Show();
                    break;
                case GameType.Porgetos_Angol_Magyar:
                    new Szavak_Angol_Magyar_Porgetos().Show();
                    break;
                default:
                    return;
            }

            Hide();
        }
    }
}
