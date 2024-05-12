using System;
using System.Drawing;
using System.Windows.Forms;
using SzoTanuloProgram.Infrastructure.Menu;
using SzoTanuloProgram.Infrastructure.Utilities.Enums;

namespace SzoTanuloProgram
{
    public partial class FoMenu : Form
    {
        public static GameType SelectedGameType = GameType.None;

        public FoMenu()
        {
            InitializeComponent();

            SelectedGameType = GameType.None;
        }

        private void FoMenu_Load(object sender, EventArgs e)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);
        }

        //Pörgetős Magyar - Angól
        private void button0_Click(object sender, EventArgs e)
        {
            SelectedGameType = GameType.Porgetos_Magyar_Angol;

            new PorgetosEsBeirogatos_Almenu().Show();
            Hide();
        }

        private void button0_MouseEnter(object sender, EventArgs e)
        {
            pictureBox0_0.ImageLocation = FileService.GetImageFile(ImageType.Flag, "hun_flag.jpg");
            pictureBox0_1.ImageLocation = FileService.GetImageFile(ImageType.Flag, "english_flag.jpg");

            richTextBox0.BackColor = Color.FromArgb(227, 218, 201);
            richTextBox0.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox0.Text = "Ebben a játékmódban magyar szavak jelennek meg és a \"Mutasd\" gomb megnyomásával tudjuk felfedni az angol megfelelőjét." +
                "\nItt te magad döntöd el becsület játékban, hogy tudtad vagy nem tudtad a szót." +
                "\nAmennyiben nem tudtad, úgy a program majd még visszatér az adott szóra!";
        }

        private void button0_MouseLeave(object sender, EventArgs e)
        {
            pictureBox0_0.ImageLocation = null;
            pictureBox0_1.ImageLocation = null;
            richTextBox0.BackColor = Color.FromArgb(46, 51, 73);
            richTextBox0.Text = "";
        }


        //Pörgetős Angól - Magyar
        private void button1_Click(object sender, EventArgs e)
        {
            SelectedGameType = GameType.Porgetos_Angol_Magyar;

            new PorgetosEsBeirogatos_Almenu().Show();
            Hide();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1_1.ImageLocation = FileService.GetImageFile(ImageType.Flag, "english_flag.jpg");
            pictureBox1_1.ImageLocation = FileService.GetImageFile(ImageType.Flag, "hun_flag.jpg");

            richTextBox1.BackColor = Color.FromArgb(227, 218, 201);
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox1.Text = "Ebben a módban Angól szavak jelennek meg és a Mutasd gomb megnyomásával felfedjük a Magyar megfelelőjét.\nItt te magad döntöd el becsület játékban, hogy tudtad vagy nem tudtad a szót.\nAmennyiben nem tudtad, úgy a program majd még visszatér az adott szóra!";
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1_0.ImageLocation = null;
            pictureBox1_1.ImageLocation = null;

            richTextBox1.BackColor = Color.FromArgb(46, 51, 73);
            richTextBox1.Text = "";
        }

        //KILÉPÉS
        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //beirogatos
        private void button5_Click(object sender, EventArgs e)
        {
            SelectedGameType = GameType.Beirogatos;

            new PorgetosEsBeirogatos_Almenu().Show();
            Hide();
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            pictureBox5_0.ImageLocation = FileService.GetImageFile(ImageType.Flag, "hun_flag.jpg");
            pictureBox5_1.ImageLocation = FileService.GetImageFile(ImageType.Flag, "english_flag.jpg");

            richTextBox5.BackColor = Color.FromArgb(227, 218, 201);
            richTextBox5.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox5.Text = "Magyar szavak jelennek meg és a szótár szerinti angól párját kell beírni karakterhelyesen!";
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5_0.ImageLocation = null;
            pictureBox5_1.ImageLocation = null;
            richTextBox5.BackColor = Color.FromArgb(46, 51, 73);
            richTextBox5.Text = "";
        }

        //pörgetés egyéb magyar -angól
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2_0.ImageLocation = FileService.GetImageFile(ImageType.Flag, "hun_flag.jpg");
            pictureBox2_1.ImageLocation = FileService.GetImageFile(ImageType.Flag, "english_flag.jpg");
            richTextBox2.BackColor = Color.FromArgb(227, 218, 201);
            richTextBox2.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox2.Text = "";
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2_0.ImageLocation = null;
            pictureBox2_1.ImageLocation = null;
            richTextBox2.BackColor = Color.FromArgb(46, 51, 73);
            richTextBox2.Text = "";
        }
        //pörgetős egyéb angól-magyar
        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3_0.ImageLocation = FileService.GetImageFile(ImageType.Flag, "english_flag.jpg");
            pictureBox3_1.ImageLocation = FileService.GetImageFile(ImageType.Flag, "hun_flag.jpg");

            richTextBox3.BackColor = Color.FromArgb(227, 218, 201);
            richTextBox3.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox3.Text = "";
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3_0.ImageLocation = null;
            pictureBox3_1.ImageLocation = null;
            richTextBox3.BackColor = Color.FromArgb(46, 51, 73);
            richTextBox3.Text = "";
        }

        //feleletválasztós
        private void button4_Click(object sender, EventArgs e)
        {

            FeleletValasztos_Almenu fvm = new FeleletValasztos_Almenu();
            fvm.Show();
            Hide();
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            var questionMarkFilePath = FileService.GetImageFile(ImageType.Misc, "questionmark.jpg");
            pictureBox4_0.ImageLocation = questionMarkFilePath;
            pictureBox4_1.ImageLocation = questionMarkFilePath;

            richTextBox4.BackColor = Color.FromArgb(227, 218, 201);
            richTextBox4.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox4.Text = "#Quiz\nMagyarázatot nem igényel, remélem jól teljesítesz :)..";
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4_0.ImageLocation = null;
            pictureBox4_1.ImageLocation = null;
            richTextBox4.BackColor = Color.FromArgb(46, 51, 73);
            richTextBox4.Text = "";
        }

        //Mini Játék
        private void button6_Click(object sender, EventArgs e)
        {
            SelectedGameType = GameType.Memoriajatek;
            PorgetosEsBeirogatos_Almenu tp1magyarangolszavak = new PorgetosEsBeirogatos_Almenu();
            tp1magyarangolszavak.Show();
            this.Hide();

        }

        private void button6_MouseEnter(object sender, EventArgs e)
        {
            var minijatekFilePath = FileService.GetImageFile(ImageType.Misc, "minijatek.jpg");
            pictureBox6_0.ImageLocation = minijatekFilePath;
            pictureBox6_1.ImageLocation = minijatekFilePath;

            richTextBox6.BackColor = Color.FromArgb(227, 218, 201);
            richTextBox6.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox6.Text = "Szó pár kereső játék, ehhez a módhoz legalább 10 szavas szójegyzék kell!";
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6_0.ImageLocation = null;
            pictureBox6_1.ImageLocation = null;
            richTextBox6.BackColor = Color.FromArgb(46, 51, 73);
            richTextBox6.Text = "";
        }
    }
}
