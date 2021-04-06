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
    public partial class ActTwo : Form
    {

        String nL = "\r\n";

        public ActTwo(string a)
        {
            InitializeComponent();
            panel1.BackColor = Color.FromArgb(25, Color.DarkCyan);
            panel2.BackColor = Color.FromArgb(25, Color.DarkCyan);
            label2.Text = "Go left: Arrow Left" + nL + "Go right: Arrow Right" + nL + "Jump: Space" + nL + nL + "Silver coin: 50" + nL + "Gold coin: 250";
            label3.Text = "Gather as many coins as you can" + nL + "Don't fall off the platform" + nL + "Avoid the enemy" + nL + "Avoid the fire" + nL + "Reach the castle" + nL + "Have fun!";
            this.MyVal = a;
        }
        public string MyVal { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {
            ActTwoPlatformer a2 = new ActTwoPlatformer(MyVal);
            this.Hide();
            a2.ShowDialog();
        }

        private void ActTwo_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            WheelForm wf = new WheelForm(MyVal);
            this.Hide();
            wf.ShowDialog();
        }

        private void ActTwo_FormClosing(object sender, FormClosingEventArgs e)
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
