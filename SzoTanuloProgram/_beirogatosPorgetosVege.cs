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
    public partial class _beirogatosPorgetosVege : Form
    {
        public _beirogatosPorgetosVege()
        {

            InitializeComponent();
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;

            if (ProgetosEsBeirogatos.sajat == false)
            {
                string[] anyagresz = ProgetosEsBeirogatos.valasztott.Split('\\', '.');
                int _teljesMeret = TeljesMeret(anyagresz[1], anyagresz[0]);
                _panelAlapAlso.Visible = true;
                _panelAlsoNoveled.Visible = true;
                if (anyagresz[1] == "Proficiency")
                {
                    richTextBox1.Text = $"Gratulálok Megtanultad {anyagresz[1]} szójegyzéket, amely {Meret()} szót tartalmazott :). Ez 1 szójegyzék a 18-ből!\nAz egész Elementary anyagban pedig {_teljesMeret} szó található.";
                    double MERET = Meret();
                    double _osztas = MERET / _teljesMeret;
                    int _panelMeret = (int)(_osztas * _panelAlapAlso.Width);
                    _panelAlsoNoveled.Width = _panelMeret;
                }
                else if (anyagresz[1] == "Elementary")
                {
                    richTextBox1.Text = $"Gratulálok Megtanultad {anyagresz[1]} szójegyzéket, amely {Meret()} szót tartalmazott :). Ez 1 szójegyzék a 10-ből!\nAz egész Elementary anyagban pedig {_teljesMeret} szó található.";
                    double MERET = Meret();
                    double _osztas = MERET / _teljesMeret;
                    int _panelMeret = (int)(_osztas * _panelAlapAlso.Width);
                    _panelAlsoNoveled.Width = _panelMeret;
                }
                else if (anyagresz[1] == "Intermediate")
                {
                    richTextBox1.Text = $"Gratulálok Megtanultad {anyagresz[1]} szójegyzéket, amely {Meret()} szót tartalmazott :). Ez 1 szójegyzék a 10-ből!\nAz egész Elementary anyagban pedig {_teljesMeret} szó található.";
                    double MERET = Meret();
                    double _osztas = MERET / _teljesMeret;
                    int _panelMeret = (int)(_osztas * _panelAlapAlso.Width);
                    _panelAlsoNoveled.Width = _panelMeret;
                }
                else if (anyagresz[1] == "PreIntermediate")
                {
                    richTextBox1.Text = $"Gratulálok Megtanultad {anyagresz[1]} szójegyzéket, amely {Meret()} szót tartalmazott :). Ez 1 szójegyzék a 10-ből!\nAz egész Elementary anyagban pedig {_teljesMeret} szó található.";
                    double MERET = Meret();
                    double _osztas = MERET / _teljesMeret;
                    int _panelMeret = (int)(_osztas * _panelAlapAlso.Width);
                    _panelAlsoNoveled.Width = _panelMeret;
                }
            }
            else
            {
                _panelAlsoNoveled.Visible = false;
                _panelAlapAlso.Visible = false;
                label1.Visible = false;
                richTextBox1.Text = $"Gratulálok Megtanultad az általad betöltött szójegyzéket, amely {Meret()} szót tartalmazott :).";

            }

        }

        static double Meret()
        {
            double num = 0;
            StreamReader sr = new StreamReader(ProgetosEsBeirogatos.valasztott);
            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                num++;
            }
            return num;
        }

        static int TeljesMeret(string melyikSZojegyzek, string melyikMappa)
        {
            int teljesMeretet = 0;
            string path = Directory.GetCurrentDirectory().ToString() + "\\" + melyikMappa + "\\" + melyikSZojegyzek;
            string[] filePaths = Directory.GetFiles(path, "*.txt");

            for (int i = 0; i < filePaths.Length; i++)
            {
                StreamReader sr = new StreamReader(filePaths[i]);
                while (!sr.EndOfStream)
                {
                    string _line = sr.ReadLine();
                    teljesMeretet++;
                }
                sr.Close();
            }
            return teljesMeretet;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

    }
}
