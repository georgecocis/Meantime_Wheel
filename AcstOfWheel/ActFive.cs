using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEProject
{
    public partial class ActFive : Form
    {
        SoundPlayer sp = new SoundPlayer();
        public ActFive(string a)
        {
            InitializeComponent();
            this.BackgroundImage = SEProject.Properties.Resources.jukebox_background;
            pictureBox1.Image = SEProject.Properties.Resources.jukebox_cassette;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.MyVal = a;
        }
        public string MyVal { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = SEProject.Properties.Resources.jukepic_cow;
            sp = new SoundPlayer(Properties.Resources.juke_cow);
            sp.Play();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = SEProject.Properties.Resources.jukepic_creeper;
            sp = new SoundPlayer(Properties.Resources.juke_Creeper);
            sp.Play();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = SEProject.Properties.Resources.jukepic_homer;
            sp = new SoundPlayer(Properties.Resources.juke_homer);
            sp.Play();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = SEProject.Properties.Resources.jukepic_lol;
            sp = new SoundPlayer(Properties.Resources.juke_lol);
            sp.Play();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = SEProject.Properties.Resources.jukepic_omg;
            sp = new SoundPlayer(Properties.Resources.juke_omg);
            sp.Play();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = SEProject.Properties.Resources.jukepic_scratch;
            sp = new SoundPlayer(Properties.Resources.juke_scratch);
            sp.Play();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = SEProject.Properties.Resources.jukepic_static;
            sp = new SoundPlayer(Properties.Resources.juke_static);
            sp.Play();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = SEProject.Properties.Resources.jukepic_trance;
            sp = new SoundPlayer(Properties.Resources.juke_trance);
            sp.Play();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = SEProject.Properties.Resources.jukepic_bossLaugh;
            sp = new SoundPlayer(Properties.Resources.juke_vgameLaugh);
            sp.Play();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = SEProject.Properties.Resources.jukepic_3menCheering;
            sp = new SoundPlayer(Properties.Resources.juke_3menCheering);
            sp.Play();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = SEProject.Properties.Resources.jukepic_trump;
            sp = new SoundPlayer(Properties.Resources.juke_trump);
            sp.Play();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = SEProject.Properties.Resources.jukepic_hitchcock;
            sp = new SoundPlayer(Properties.Resources.juke_hitchcock);
            sp.Play();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = SEProject.Properties.Resources.jukepic_pbjtime;
            sp = new SoundPlayer(Properties.Resources.juke_pbjtime);
            sp.Play();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = SEProject.Properties.Resources.jukepic_spacecats;
            sp = new SoundPlayer(Properties.Resources.juke_SpaceCats);
            sp.Play();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = SEProject.Properties.Resources.jukepic_helicopter;
            sp = new SoundPlayer(Properties.Resources.juke_helicopter);
            sp.Play();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = SEProject.Properties.Resources.jukepic_zedsDead;
            sp = new SoundPlayer(Properties.Resources.juke_zedsDead);
            sp.Play();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = SEProject.Properties.Resources.jukepic_jimmyBarnes;
            sp = new SoundPlayer(Properties.Resources.juke_jimmyBarnes);
            sp.Play();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = SEProject.Properties.Resources.jukepic_samuraiJack;
            sp = new SoundPlayer(Properties.Resources.juke_samuraiJack);
            sp.Play();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = SEProject.Properties.Resources.jukepic_getSchwifty;
            sp = new SoundPlayer(Properties.Resources.juke_getSchwifty);
            sp.Play();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = SEProject.Properties.Resources.jukepic_uvu;
            sp = new SoundPlayer(Properties.Resources.juke_uvu);
            sp.Play();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = SEProject.Properties.Resources.jukebox_cassette;
            sp.Stop();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            WheelForm wf = new WheelForm(MyVal);
            this.Hide();
            wf.ShowDialog();
        }

        private void ActFive_FormClosing(object sender, FormClosingEventArgs e)
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
