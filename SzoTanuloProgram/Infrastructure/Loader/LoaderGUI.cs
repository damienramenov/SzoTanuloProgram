using System;
using System.Windows.Forms;

namespace SzoTanuloProgram
{
    public partial class LoaderGUI : Form
    {
        public LoaderGUI()
        {
            InitializeComponent();

            pictureBox1.ImageLocation = FileService.GetRandomLoaderImageFilePath();
        }

        private void Idozito_Tick(object sender, EventArgs e)
        {
            panel1.Width += 50;

            if (panel1.Width >= 950)
            {
                Idozito.Stop();

                new FoMenu().Show();
                
                Hide();
            }
        }
    }
}
