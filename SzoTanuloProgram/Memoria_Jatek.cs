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

namespace SzoTanuloProgram
{
    public partial class Memoria_Jatek : Form
    {
        class szavak
        {
            public string angol;
            public string magyar;

        }


        bool MEHET = false;
        int gyoztel = 0;
        int szamlalo = 1;
        string eztolvasbe = ProgetosEsBeirogatos.valasztott;
        Random random = new Random();
        List<szavak> osszesSzo = new List<szavak>();

        static List<int> voltak = new List<int>();
        static List<string> icoooos = new List<string>();
        Label elsoKlikk, masodikKlikk;

        public Memoria_Jatek()
        {
            icoooos.Clear();
            InitializeComponent();

            voltak.Clear();

            osszesSzo.Clear();
            szamlalo = 1;

            StreamReader sr = new StreamReader(eztolvasbe);
            while (!sr.EndOfStream)
            {
                string[] sor = sr.ReadLine().Split('|');
                szavak aktualis = new szavak();
                aktualis.angol = sor[0];
                aktualis.magyar = sor[1];
                osszesSzo.Add(aktualis);


            }

            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
            label16.Visible = false;
            label17.Visible = false;
            label18.Visible = false;
            label19.Visible = false;
            label20.Visible = false;



        }

        private void Memoria_Jatek_Load(object sender, EventArgs e)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);
        }


        private void label_Click(object sender, EventArgs e)
        {
            if (MEHET == true)
            {
                if (elsoKlikk != null && masodikKlikk != null)
                    return;


                Label clickedLabel = sender as Label;

                if (clickedLabel == null)
                    return;
                if (clickedLabel.BackColor == Color.FromArgb(140, 140, 140))
                    return;

                if (elsoKlikk == null)
                {
                    elsoKlikk = clickedLabel;
                    elsoKlikk.BackColor = Color.FromArgb(140, 140, 140);
                    return;
                }

                masodikKlikk = clickedLabel;
                masodikKlikk.BackColor = Color.FromArgb(140, 140, 140);

                //ELLENŐRZI A KÉT KLIKKET
                string egyik = elsoKlikk.Text;
                int egyikIndex = -10;
                string masik = masodikKlikk.Text;
                int masikIndex = 0;
                string AngolSZO = "";

                for (int i = 0; i < osszesSzo.Count; i++)
                {
                    if (egyik == osszesSzo[i].angol)
                    {
                        egyikIndex = i;
                        AngolSZO = osszesSzo[i].angol;
                    }
                    if (egyik == osszesSzo[i].magyar)
                    {
                        egyikIndex = i;
                    }
                    if (masik == osszesSzo[i].angol)
                    {
                        masikIndex = i;
                        AngolSZO = osszesSzo[i].angol;
                    }
                    if (masik == osszesSzo[i].magyar)
                    {
                        masikIndex = i;
                    }


                }
                if (egyikIndex == masikIndex)
                {
                    gyoztel++;
                    if (gyoztel < 10)
                    {
                        string szovegAmitKimondd = AngolSZO;
                        SpeechHelper.Rate = 0;
                        string MonddKi = SpeechHelper.Speak("en-US", "Microsoft Zira Desktop", szovegAmitKimondd);
                        if (MonddKi != null)
                        {
                            MessageBox.Show(MonddKi);
                        }
                        System.Threading.Thread.Sleep(20);

                    }

                    elsoKlikk.BackColor = Color.FromArgb(0, 179, 179);
                    masodikKlikk.BackColor = Color.FromArgb(0, 179, 179);
                    

                    elsoKlikk.Visible = false;
                    masodikKlikk.Visible = false;

                    System.Threading.Thread.Sleep(40);

                    elsoKlikk = null;
                    masodikKlikk = null;

                   

                    


                }
                else
                {

                    elsoKlikk.BackColor = Color.FromArgb(153, 0, 0);
                    masodikKlikk.BackColor = Color.FromArgb(153, 0, 0);

                    System.Threading.Thread.Sleep(25);
                    timer1.Start();
                }
                /* ....................................... */

                //Gyöztes csekk
                if (gyoztel == 10)
                {
                    btnMehet.Visible = true;
                    btnMenu.Visible = true;

                    string szovegAmitKimondd = AngolSZO;
                    SpeechHelper.Rate = 0;
                    string MonddKi = SpeechHelper.Speak("en-US", "Microsoft Zira Desktop", szovegAmitKimondd);
                    if (MonddKi != null)
                    {
                        MessageBox.Show(MonddKi);
                    }
                    System.Threading.Thread.Sleep(20);
                }

                if (szamlalo > ((osszesSzo.Count - (osszesSzo.Count % 10)) / 10))
                {
                    MessageBox.Show($"Végeztél ezzel a leckével!\nIsmételt szavak száma: {osszesSzo.Count - (osszesSzo.Count % 10)}\nAz OK gombra kattintva visszakerülsz a menübe!");
                    FoMenu f2 = new FoMenu();
                    this.Close();
                    f2.Show();
                }
            }
        }

        private void btnMehet_Click(object sender, EventArgs e)
        {
            btnMehet.Visible = false;
            btnMenu.Visible = false;

            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
            label11.Visible = true;
            label12.Visible = true;
            label13.Visible = true;
            label14.Visible = true;
            label15.Visible = true;
            label16.Visible = true;
            label17.Visible = true;
            label18.Visible = true;
            label19.Visible = true;
            label20.Visible = true;

            Label labelL;
            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                if (tableLayoutPanel1.Controls[i] is Label)
                {
                    labelL = (Label)tableLayoutPanel1.Controls[i];
                    labelL.BackColor = Color.FromArgb(153, 92, 0);
                }
                else
                {
                    continue;
                }
            }
            MEHET = true;
            gyoztel = 0;
            icoooos.Clear();

            if (szamlalo <= ((osszesSzo.Count - (osszesSzo.Count % 10)) / 10))
            {
                for (int i = 0; i < 10; i++)
                {
                    int generalj = random.Next(0, osszesSzo.Count);
                    bool volte = icoooos.Contains(osszesSzo[generalj].angol);
                    bool volteIndex = voltak.Contains(generalj);
                    if (volte == false && volteIndex == false)
                    {
                        voltak.Add(generalj);
                        icoooos.Add(osszesSzo[generalj].angol);
                        icoooos.Add(osszesSzo[generalj].magyar);
                    }
                    else
                    {
                        i--;
                    }
                }
                AssignIconsToSquares();
                szamlalo++;
            }
        }

        private void AssignIconsToSquares()
        {
            Label label;
            int randomNumber;

            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                if (tableLayoutPanel1.Controls[i] is Label)
                {
                    label = (Label)tableLayoutPanel1.Controls[i];
                }
                else
                {
                    continue;
                }

                randomNumber = random.Next(0, icoooos.Count);
                label.Text = icoooos[randomNumber];

                icoooos.RemoveAt(randomNumber);

            }


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            elsoKlikk.BackColor = Color.FromArgb(153, 92 , 0);
            masodikKlikk.BackColor = Color.FromArgb(153, 92, 0);
            elsoKlikk = null;
            masodikKlikk = null;
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            FoMenu f2 = new FoMenu();
            this.Close();
            f2.Show();
        }
    }
}
