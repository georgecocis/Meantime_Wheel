using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEProject.ActEightFolder
{
    public partial class ActEightPuzzle : Form
    {
        int nullIndex, moves = 0, score = 0, sum = 0, val = 0;
        List<Bitmap> originalPicturesList = new List<Bitmap>();
        System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
        public ActEightPuzzle(string a)
        {
            InitializeComponent();
            originalPicturesList.AddRange(new Bitmap[] { Properties.Resources.cat1, Properties.Resources.cat2, Properties.Resources.cat3, Properties.Resources.cat4, Properties.Resources.cat5, Properties.Resources.cat6, Properties.Resources.cat7, Properties.Resources.cat8, Properties.Resources.cat9, Properties.Resources._null });
            TimeLabel.Text = "00:00:00";
            MovesLabel.Text += moves;
            this.MyVal = a;
        }
        public string MyVal { get; set; }
        void Shuffle()
        {
            do
            {
                int j;
                List<int> Indexes = new List<int>(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 9 }); //8 not present because it is the last slice
                Random rand = new Random();
                for (int i = 0; i < 9; i++)
                {
                    Indexes.Remove((j = Indexes[rand.Next(0, Indexes.Count)]));
                    ((PictureBox)groupBoxPuzzleBox.Controls[i]).Image = originalPicturesList[j];
                    if (j == 9) nullIndex = i; //store empty picture box index
                }
            } while (CheckWin());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult YesOrNo = new DialogResult();
            if (TimeLabel.Text != "00:00:00")
            {
                YesOrNo = MessageBox.Show("Do you want to restart?", "Puzzle", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            if (YesOrNo == DialogResult.Yes || TimeLabel.Text == "00:00:00")
            {
                Shuffle();
                timer.Reset();
                TimeLabel.Text = "00:00:00";
                moves = 0;
                MovesLabel.Text = "Moves made: 0";
            }
        }

        bool CheckWin()
        {
            int i;
            for (i = 0; i < 8; i++)
            {
                if ((groupBoxPuzzleBox.Controls[i] as PictureBox).Image != originalPicturesList[i]) break;
            }
            if (i == 8) return true;
            else return false;
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ActEightcs act8 = new ActEightcs(MyVal);
            this.Hide();
            act8.ShowDialog();
        }

        private void ActEightPuzzle_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.ApplicationExitCall)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to quit?", "Quit", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void UpdateTime(object sender, EventArgs e)
        {
            if (timer.Elapsed.ToString() != "00:00:00")
                TimeLabel.Text = timer.Elapsed.ToString().Remove(8);
            if (timer.Elapsed.ToString() == "00:00:00")
                pauseButton.Enabled = false;
            else
                pauseButton.Enabled = true;
            if (timer.Elapsed.Minutes.ToString() == "1")
            {
                timer.Reset();
                MovesLabel.Text = "Moves Made : 0";
                TimeLabel.Text = "00:00:00";
                moves = 0;
                pauseButton.Enabled = false;
                MessageBox.Show("Time Is Up\nTry Again", "Rabbit Puzzle");
                Shuffle();
            }

        }

        private void ActEightPuzzle_Load(object sender, EventArgs e)
        {
            Shuffle();
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {

            if (pauseButton.Text == "Pause")
            {
                timer.Stop();
                groupBoxPuzzleBox.Visible = false;
                pauseButton.Text = "Resume";
            }
            else
            {
                timer.Start();
                groupBoxPuzzleBox.Visible = true;
                pauseButton.Text = "Pause";
            }
        }

        private void SwitchPictureBox(object sender, EventArgs e)
        {
            if (TimeLabel.Text == "00:00:00")
                timer.Start();
            int inPictureBoxIndex = groupBoxPuzzleBox.Controls.IndexOf(sender as Control);
            if (nullIndex != inPictureBoxIndex)
            {
                List<int> FourBrothers = new List<int>(new int[] { (inPictureBoxIndex % 3 == 0) ? -1 : inPictureBoxIndex - 1, inPictureBoxIndex - 3, inPictureBoxIndex - 3, (inPictureBoxIndex % 3 == 2) ? -1 : inPictureBoxIndex + 1, inPictureBoxIndex + 3 });
                if (FourBrothers.Contains(nullIndex))
                {
                    ((PictureBox)groupBoxPuzzleBox.Controls[nullIndex]).Image = ((PictureBox)groupBoxPuzzleBox.Controls[inPictureBoxIndex]).Image;
                    ((PictureBox)groupBoxPuzzleBox.Controls[inPictureBoxIndex]).Image = originalPicturesList[9];
                    nullIndex = inPictureBoxIndex;
                    MovesLabel.Text = "Moves Made : " + (++moves);
                    if (CheckWin())
                    {
                        timer.Stop();
                        (groupBoxPuzzleBox.Controls[8] as PictureBox).Image = originalPicturesList[8];
                        MessageBox.Show("Congratulations...\nTime Elapsed : " + timer.Elapsed.ToString().Remove(8) + "\nTotal Moves Made : " + moves, " Puzzle");
                        moves = 0;
                        MovesLabel.Text = "Moves Made : 0";
                        TimeLabel.Text = "00:00:00";
                        timer.Reset();
                        Shuffle();
                    }
                }
            }
        }
    }
}
