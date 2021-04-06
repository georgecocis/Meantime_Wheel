using SEProject.AroundLogin;
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
    public partial class Form2 : Form
    {
        public Form2(string a)
        {
            InitializeComponent();
            panel1.BackColor = Color.FromArgb(40, Color.DarkCyan);
            panel2.BackColor = Color.FromArgb(40, Color.DarkCyan);
            this.MyVal = a;
        }
        public string MyVal { get; set; }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            WheelForm wf = new WheelForm(MyVal);
            wf.ShowDialog();        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            Form1 f1 = new Form1();
            f1.ShowDialog();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            User us = new User(MyVal);
            us.ShowDialog();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
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
