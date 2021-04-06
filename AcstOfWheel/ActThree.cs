using SEProject.ActThreeFolder;
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
    public partial class ActThree : Form
    {
        public ActThree(string a)
        {
            InitializeComponent();
            this.MyVal = a;
        }
        public string MyVal { get; set; }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ActThreePacman act3 = new ActThreePacman(MyVal);
            this.Hide();
            act3.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WheelForm wf = new WheelForm(MyVal);
            this.Hide();
            wf.ShowDialog();

        }

        private void ActThree_FormClosing(object sender, FormClosingEventArgs e)
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
