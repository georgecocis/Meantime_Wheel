using SEProject.ActFourFolder;
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
    public partial class ActFour : Form
    {
        public ActFour(string a)
        {
            InitializeComponent();
            panel1.BackColor = Color.FromArgb(170, Color.Beige);
            this.MyVal = a;
        }
        public string MyVal { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {
            ActFourMatchTheCards act4 = new ActFourMatchTheCards(MyVal);
            this.Hide();
            act4.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            WheelForm wf = new WheelForm(MyVal);
            this.Hide();
            wf.ShowDialog();
        }

        private void ActFour_FormClosing(object sender, FormClosingEventArgs e)
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
