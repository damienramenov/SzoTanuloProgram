using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace SzoTanuloProgram
{
    public partial class Memoriajatek : Form
    {
        private bool _hasGameBeenStarted;
        private int _foundPairsInCurrentSession = 0;
        private int _createdPairsInAllSession = 1;
        private Random random = new Random();
        private bool _hasAlertBeenSent;

        private struct Szopar
        {
            public string AngolKifejezes;
            public string MagyarKifejezes;
            public int UniqueId;

            public Szopar(string angol, string magyar, int uid)
            {
                AngolKifejezes = angol;
                MagyarKifejezes = magyar;
                UniqueId = uid;
            }
        }

        private List<Szopar> _osszesSzo = new List<Szopar>();

        private List<int> _createdSzoparIndexes = new List<int>();
        private List<string> _currentSessionSzoparElemek = new List<string>();
        private Label firstlyClickedLabel, secondlyClickedLabel;

        private static readonly Color _mainBackgroundColor = Color.FromArgb(46, 51, 73);
        private static readonly Color _greyBackgroundColor = Color.FromArgb(140, 140, 140);
        private static readonly Color _redBackgroundColor = Color.FromArgb(153, 0, 0);
        private static readonly Color _darkOrangeBackgroundColor = Color.FromArgb(153, 92, 0);

        public Memoriajatek()
        {
            InitializeComponent();

            LoadSzojegyzek();
            
            ModifyLabelVisibility(shouldBeVisible: false);
        }

        private void LoadSzojegyzek()
        {
            StreamReader sr = new StreamReader(PorgetosEsBeirogatos_Almenu.ValasztottSzojegyzekFilePath);

            var i = 0;
            while (!sr.EndOfStream)
            {
                var currentLineSplitted = sr.ReadLine().Split('|');

                _osszesSzo.Add(new Szopar(currentLineSplitted[1], currentLineSplitted[0], i));

                i++;
            }
        }

        private void Memoriajatek_Load(object sender, EventArgs e)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);
        }

        private void label_Click(object sender, EventArgs e)
        {
            if (!_hasGameBeenStarted == true || firstlyClickedLabel != null && secondlyClickedLabel != null)
            {
                return;
            }

            var clickedLabel = sender as Label;
            if (clickedLabel == null || IsSameColor(clickedLabel.BackColor, _mainBackgroundColor))
            {
                return;
            }

            if (IsSameColor(clickedLabel.BackColor, _greyBackgroundColor))
            {
                firstlyClickedLabel.BackColor = _darkOrangeBackgroundColor;
                firstlyClickedLabel = null;

                return;
            }

            if (firstlyClickedLabel == null)
            {
                firstlyClickedLabel = clickedLabel;
                firstlyClickedLabel.BackColor = _greyBackgroundColor;

                return;
            }

            secondlyClickedLabel = clickedLabel;
            secondlyClickedLabel.BackColor = _greyBackgroundColor;

            var szoparFromFirstlyClickedLabel = GetSzoparFromWord(firstlyClickedLabel.Text);
            var szoparFromSecondlyClickedLabel = GetSzoparFromWord(secondlyClickedLabel.Text);

            if (szoparFromFirstlyClickedLabel.UniqueId == 0 || szoparFromSecondlyClickedLabel.UniqueId == 0)
            {
                return;
            }

            if (szoparFromFirstlyClickedLabel.UniqueId == szoparFromSecondlyClickedLabel.UniqueId)
            {
                _foundPairsInCurrentSession++;

                var angolSzo = szoparFromFirstlyClickedLabel.AngolKifejezes;

                SpeechUtility.Speak(angolSzo);

                Thread.Sleep(angolSzo.Length * 5);

                firstlyClickedLabel.Text = string.Empty;
                firstlyClickedLabel.BackColor = _mainBackgroundColor;
                firstlyClickedLabel.IsAccessible = false;
                firstlyClickedLabel = null;

                secondlyClickedLabel.Text = string.Empty;
                secondlyClickedLabel.BackColor = _mainBackgroundColor;
                secondlyClickedLabel.IsAccessible = false;
                secondlyClickedLabel = null;

                Thread.Sleep(40);

            }
            else
            {
                firstlyClickedLabel.BackColor = _redBackgroundColor;
                secondlyClickedLabel.BackColor = _redBackgroundColor;

                Thread.Sleep(50);
                timer1.Start();
            }
            /* ....................................... */

            //Gyöztes csekk
            if (_foundPairsInCurrentSession == 10)
            {
                btnMehet.Text = "Kérem az újabb szópárokat!";
                btnMehet.Visible = true;

                Thread.Sleep(20);
            }

            if (_createdPairsInAllSession > ((_osszesSzo.Count - (_osszesSzo.Count % 10)) / 10))
            {
                MessageBox.Show("Végeztél ezzel a leckével!" +
                    $"\nIsmételt szavak száma: {_osszesSzo.Count - (_osszesSzo.Count % 10)}" +
                     "\nAz OK gombra kattintva visszakerülsz a menübe!");

                new FoMenu().Show();
                Hide();
            }
        }

        private void btnMehet_Click(object sender, EventArgs e)
        {
            btnMehet.Visible = false;

            ModifyLabelVisibility(shouldBeVisible: true);

            foreach (var control in tableLayoutPanel1.Controls)
            {
                var label = control as Label;

                if (label != null)
                {
                    label.BackColor = _darkOrangeBackgroundColor;
                }
            }

            _hasGameBeenStarted = true;
            _foundPairsInCurrentSession = 0;
            _currentSessionSzoparElemek.Clear();

            if (_createdPairsInAllSession <= ((_osszesSzo.Count - (_osszesSzo.Count % 10)) / 10))
            {
                for (int i = 0; i < 10; i++)
                {
                    int randomNumber = random.Next(0, _osszesSzo.Count);

                    bool volte = _currentSessionSzoparElemek.Contains(_osszesSzo[randomNumber].AngolKifejezes);
                    bool volteIndex = _createdSzoparIndexes.Contains(randomNumber);
                    if (!volte && !volteIndex)
                    {
                        _createdSzoparIndexes.Add(randomNumber);
                        _currentSessionSzoparElemek.Add(_osszesSzo[randomNumber].AngolKifejezes);
                        _currentSessionSzoparElemek.Add(_osszesSzo[randomNumber].MagyarKifejezes);
                    }
                    else
                    {
                        i--;
                    }
                }

                AssignIconsToSquares();

                _createdPairsInAllSession++;
            }
        }

        private void AssignIconsToSquares()
        {
            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                var currentControlAsLabel = tableLayoutPanel1.Controls[i] as Label;
                if (currentControlAsLabel == null)
                {
                    continue;
                }

                int randomNumber = random.Next(0, _currentSessionSzoparElemek.Count);
                currentControlAsLabel.Text = _currentSessionSzoparElemek[randomNumber];

                _currentSessionSzoparElemek.RemoveAt(randomNumber);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            firstlyClickedLabel.BackColor = _darkOrangeBackgroundColor;
            secondlyClickedLabel.BackColor = _darkOrangeBackgroundColor;
            firstlyClickedLabel = null;
            secondlyClickedLabel = null;
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            if ((_foundPairsInCurrentSession > 0 || _createdPairsInAllSession > 10) && !_hasAlertBeenSent)
            {
                MessageBox.Show($"Figyelem! {Environment.NewLine}" +
                                $"Még nem fejezted be a párosítást. " +
                                    $"Kérlek, nyomj újra a 'Menü' gombra, ha tényleg vissza szeretnél lépni a főmenübe!");

                _hasAlertBeenSent = true;

                return;
            }

            new FoMenu().Show();

            Hide();
        }

        private void ModifyLabelVisibility(bool shouldBeVisible)
        {
            label1.Visible = shouldBeVisible;
            label2.Visible = shouldBeVisible;
            label3.Visible = shouldBeVisible;
            label4.Visible = shouldBeVisible;
            label5.Visible = shouldBeVisible;
            label6.Visible = shouldBeVisible;
            label7.Visible = shouldBeVisible;
            label8.Visible = shouldBeVisible;
            label9.Visible = shouldBeVisible;
            label10.Visible = shouldBeVisible;
            label11.Visible = shouldBeVisible;
            label12.Visible = shouldBeVisible;
            label13.Visible = shouldBeVisible;
            label14.Visible = shouldBeVisible;
            label15.Visible = shouldBeVisible;
            label16.Visible = shouldBeVisible;
            label17.Visible = shouldBeVisible;
            label18.Visible = shouldBeVisible;
            label19.Visible = shouldBeVisible;
            label20.Visible = shouldBeVisible;
        }

        private bool IsSameColor(Color c1, Color c2) => c1.R == c2.R && c1.G == c2.G && c1.B == c2.B;

        private Szopar GetSzoparFromWord(string word)
        {
            var trimmedWord = word.Trim();

            var szoparIfItIsAnEnglishPhrase = _osszesSzo.FirstOrDefault(szp => szp.AngolKifejezes.Trim() == trimmedWord);

            //ha angol kifejezés és sikerült megtalálni az alapján a szópárat
            if (szoparIfItIsAnEnglishPhrase.UniqueId != 0)
            {
                return szoparIfItIsAnEnglishPhrase;
            }

            return _osszesSzo.FirstOrDefault(szp => szp.MagyarKifejezes.Trim() == trimmedWord);
        }
    }
}
