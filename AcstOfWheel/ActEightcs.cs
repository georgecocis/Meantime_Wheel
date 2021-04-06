using SEProject.ActEightFolder;
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
    public partial class ActEightcs : Form
    {
        public ActEightcs(string a)
        {
            InitializeComponent();
            panel1.BackColor = Color.FromArgb(200, Color.Azure);
            this.MyVal = a;
        }
        public string MyVal { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            ActEightPuzzle act8 = new ActEightPuzzle(MyVal);
            this.Hide();
            act8.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WheelForm wf = new WheelForm(MyVal);
            this.Hide();
            wf.ShowDialog();
        }

        private void ActEight_FormClosing(object sender, FormClosingEventArgs e)
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
