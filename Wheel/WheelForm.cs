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
    public partial class WheelForm : Form
    {

        private readonly Random _random = new Random();
        public int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }

        public void lockButtons()
        {
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;

            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            button9.Visible = false;

            label_bot.Visible = false;
            label_top.Visible = false;

        }

        public WheelForm(string a)
        {
            InitializeComponent();
            lockButtons();
            this.MyVal = a;

            /* this.BackgroundImage = Properties.Resources.pink_floyd;
             this.BackgroundImageLayout = ImageLayout.Stretch;
             pictureBox1.BackgroundImage = Properties.Resources.PinClipart_com_spinning_wheel_clipart_999821;
             pictureBox1.BackgroundImageLayout = ImageLayout.Stretch; */
        }
        public string MyVal { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {
            lockButtons();
            int x = RandomNumber(1,9);
            switch (x)
            {
                case 1:
                    label_top.Text = "Oh my god, you rolled one, you're crazy!";
                    button3.Visible = true;
                    button3.Enabled = true;
                    break;
                case 2:
                    label_top.Text = "Two? You're on a rampage!";
                    button4.Visible = true;
                    button4.Enabled = true;
                    break;
                case 3:
                    label_top.Text = "I can't believe you just rolled three!";
                    button8.Visible = true;
                    button8.Enabled = true;
                    break;
                case 4:
                    label_top.Text = "Woohoo! four!";
                    button9.Visible = true;
                    button9.Enabled = true;
                    break;
                case 5:
                    label_top.Text = "Jesus Christ, the holy five!";
                    button7.Visible = true;
                    button7.Enabled = true;
                    break;
                case 6:
                    label_top.Text = "I can't think of a better number to roll. 6 all the way!";
                    button6.Visible = true;
                    button6.Enabled = true;
                    break;
                case 7:
                    label_top.Text = "Seven. Seven. Seven. Good job!";
                    button5.Visible = true;
                    button5.Enabled = true;
                    break;
                case 8:
                    label_top.Text = "Rolling 8... I hope you know what you're getting yourself into!";
                    button2.Visible = true;
                    button2.Enabled = true;
                    break;
                default:
                    MessageBox.Show("There was an error with the spinning wheel. Please try again!");
                    break;
            }
            label_bot.Visible = true;
            label_top.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            ActOne a1 = new ActOne(MyVal);
            a1.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            ActTwo a2 = new ActTwo(MyVal);
            a2.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            ActThree a3 = new ActThree(MyVal);
            a3.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            ActFour a4 = new ActFour(MyVal);
            a4.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            ActFive a5 = new ActFive(MyVal);
            a5.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();

            Form5 a6 = new Form5(MyVal);
            a6.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            ActSeven a7 = new ActSeven(MyVal);
            a7.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ActEightcs a8 = new ActEightcs(MyVal);
            a8.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2(MyVal);
            f2.ShowDialog();
        }

        private void WheelForm_FormClosing(object sender, FormClosingEventArgs e)
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
