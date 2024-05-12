using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SzoTanuloProgram
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Random rnd = new Random();
            int rndNumber = rnd.Next(0, 8);
            pictureBox1.ImageLocation = "kepek\\" + rndNumber.ToString() + ".jpg";
        }

        private void Idozito_Tick(object sender, EventArgs e)
        {
            panel1.Width += 5;

            if (panel1.Width >= 950)
            {
                Idozito.Stop();
                FoMenu show_menu = new FoMenu();
                show_menu.Show();
                this.Hide();
            }
        }
    }
}
