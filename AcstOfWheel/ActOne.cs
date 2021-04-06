using SEProject.ActOneFolder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEProject
{
    public partial class ActOne : Form
    {
        public ActOne(string a)
        {
            InitializeComponent();
            this.MyVal = a;
        }
        public string MyVal { get; set; }
        private void button_1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MovieForm mf = new MovieForm(MyVal);
            mf.ShowDialog();
        }

        private void button_3_Click(object sender, EventArgs e)
        {
            this.Hide();
            SongsForm sf = new SongsForm(MyVal);
            sf.ShowDialog();
        }

        private void button_5_Click(object sender, EventArgs e)
        {
            this.Hide();
            PopCultureForm pf = new PopCultureForm(MyVal);
            pf.ShowDialog();
        }

        private void button_2_Click(object sender, EventArgs e)
        {
            this.Hide();
            HarryPotterForm hf = new HarryPotterForm(MyVal);
            hf.ShowDialog();
        }

        private void button_4_Click(object sender, EventArgs e)
        {
            this.Hide();
            VideoGamesForm vf = new VideoGamesForm(MyVal);
            vf.ShowDialog();
        }

        private void button_6_Click(object sender, EventArgs e)
        {
            this.Hide();
            FlagsForm ff = new FlagsForm(MyVal);
            ff.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WheelForm wf = new WheelForm(MyVal);
            this.Hide();
            wf.ShowDialog();
        }

        private void ActOne_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}
