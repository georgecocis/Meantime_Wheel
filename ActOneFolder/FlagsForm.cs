using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEProject.ActOneFolder
{
    public partial class FlagsForm : Form
    {
        int count;
        int x = 0;
        Timer t = new Timer();
        Timer t2 = new Timer();
        Timer t3 = new Timer();
        int score = 0, val = 0, sum = 0;

        public FlagsForm(string a)
        {
            InitializeComponent();
            pictureBox1.Image = SEProject.Properties.Resources.trivia_raceflag;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            refreshInterface();
            timerActions();
            this.MyVal = a;
        }
        public string MyVal { get; set; }
        private void refreshInterface()
        {
            count = 15;
            t.Stop();
            t2.Stop();
            t3.Stop();
            t3.Dispose();
            t2.Dispose();
            t.Dispose();
            label_cw.Text = "";
            counterLabel.Text = "";
            counterLabel.ForeColor = System.Drawing.Color.White;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button1.Enabled = true;
        }

        private void unlockButtons()
        {
            label_cw.Text = "";
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
        }

        private void timerAction(object source, EventArgs e)
        {
            t.Stop();
            t.Dispose();
            guessTimer();
        }

        private void secondTimerAction(object source, EventArgs e)
        {
            t2.Stop();
            t2.Dispose();
            refreshInterface();
            label_cw.Text = "Too late!";
        }

        private void thirdTimerAction(object source, EventArgs e)
        {
            t3.Stop();
            t3.Dispose();
            count--;
            counterLabel.Text = count.ToString();
            displayTimer();
        }

        private void startRoundTimer()
        {
            count = 15;
            t.Interval = 10000;
            t.Start();
        }

        private void guessTimer()
        {
            t2.Interval = 5000;
            t2.Start();
        }

        private void displayTimer()
        {
            if (count == 5) counterLabel.ForeColor = System.Drawing.Color.Red;
            if (count >= 0)
            {
                t3.Interval = 1000;
                t3.Enabled = true;
                if (count == 15)
                    counterLabel.Text = count.ToString();
            }
        }

        private void timerActions()
        {
            t.Tick += new System.EventHandler(timerAction);
            t2.Tick += new System.EventHandler(secondTimerAction);
            t3.Tick += new System.EventHandler(thirdTimerAction);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection sqlcon = new MySqlConnection(@"server=localhost;user id=root;database=seproject;password=rootpassword");
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;

            try
            {
                string sql = "SELECT inGameCurrency FROM seproject.user WHERE username = '" + MyVal + "';";

                //sqlcon = new MySqlConnection(Properties.Settings.Default.ConnectionString);
                cmd = new MySqlCommand(sql, sqlcon);

                sqlcon.Open();

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    val = reader.GetInt32("inGameCurrency");
                    //lblContinent.Text = reader.GetInt32("continent");
                    //lblRegion.Text = reader.GetString("region");
                    //lblSurfaceArea.Text = string.Format("{0:0.00}", reader.GetFloat("surfacearea"));
                }
                Console.WriteLine(val);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("An error occurred {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (reader != null) reader.Close();
                if (sqlcon != null) sqlcon.Close();
            }
            label2.Text = "Whose country is the following flag?";
            if (x <= 10)
            {
                button1.Enabled = false;
                button1.Text = "Next question";
                x++;
                unlockButtons();
                startRoundTimer();
                displayTimer();
                scoreLabel.Text = score.ToString();
            }
            switch (x)
            {
                case 1:
                    pictureBox1.Image = SEProject.Properties.Resources.trivia_jamaica;
                    button2.Text = "Jamaica";
                    button3.Text = "Morocco";
                    button4.Text = "Iran";
                    button5.Text = "Turkey";
                    break;
                case 2:
                    pictureBox1.Image = SEProject.Properties.Resources.trivia_greece;
                    button2.Text = "Estonia";
                    button3.Text = "Sweden";
                    button4.Text = "Greece";
                    button5.Text = "Latvia";
                    break;
                case 3:
                    pictureBox1.Image = SEProject.Properties.Resources.trivia_colombia;
                    button2.Text = "Bahamas";
                    button3.Text = "Colombia";
                    button4.Text = "Mongolia";
                    button5.Text = "Nepal";
                    break;
                case 4:
                    pictureBox1.Image = SEProject.Properties.Resources.trivia_cuba;
                    button2.Text = "Armenia";
                    button3.Text = "Thailans";
                    button4.Text = "Myanmar";
                    button5.Text = "Cuba";
                    break;
                case 5:
                    pictureBox1.Image = SEProject.Properties.Resources.trivia_brazil;
                    button2.Text = "Brazil";
                    button3.Text = "Uganda";
                    button4.Text = "Azerbaijan";
                    button5.Text = "Indonesia";
                    break;
                case 6:
                    pictureBox1.Image = SEProject.Properties.Resources.trivia_israel;
                    button2.Text = "Laos";
                    button3.Text = "Yemen";
                    button4.Text = "Israel";
                    button5.Text = "Qatar";
                    break;
                case 7:
                    pictureBox1.Image = SEProject.Properties.Resources.trivia_lebanon;
                    button2.Text = "Bangladesh";
                    button3.Text = "Lebanon";
                    button4.Text = "Bahrain";
                    button5.Text = "Jordan";
                    break;
                case 8:
                    pictureBox1.Image = SEProject.Properties.Resources.trivia_norway;
                    button2.Text = "Norway";
                    button3.Text = "Croatia";
                    button4.Text = "Slovenia";
                    button5.Text = "Slovakia";
                    break;
                case 9:
                    pictureBox1.Image = SEProject.Properties.Resources.trivia_egypt;
                    button2.Text = "Paraguay";
                    button3.Text = "Algeria";
                    button4.Text = "Tunisia";
                    button5.Text = "Egypt";
                    break;
                case 10:
                    pictureBox1.Image = SEProject.Properties.Resources.trivia_portugal;
                    button2.Text = "Argentina";
                    button3.Text = "Spain";
                    button4.Text = "Portugal";
                    button5.Text = "Italy";
                    break;
                default:
                    MessageBox.Show("All done! Your score is " + score.ToString());
                    sum = val + score;
                    try
                    {
                        sqlcon.Open();

                        string Query = "update seproject.user set inGameCurrency = " + "'" + sum + "' where (username = '" + MyVal + "');";
                        MySqlCommand cmdInsert = new MySqlCommand(Query, sqlcon);
                        MySqlDataReader reader1 = cmdInsert.ExecuteReader();
                        MessageBox.Show("Saved");
                        while (reader1.Read())
                        { }
                        sqlcon.Close();


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Insertion failed");
                    }
                    this.Hide();
                    ActOne a1 = new ActOne(MyVal);
                    a1.ShowDialog();
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            refreshInterface();
            switch (x)
            {
                case 1:
                    label_cw.Text = "Correct!";
                    score++;
                    break;
                case 2:
                    label_cw.Text = "Incorrect!";
                    break;
                case 3:
                    label_cw.Text = "Incorrect!";
                    break;
                case 4:
                    label_cw.Text = "Incorrect!";
                    break;
                case 5:
                    label_cw.Text = "Correct!";
                    score++;
                    break;
                case 6:
                    label_cw.Text = "Incorrect!";
                    break;
                case 7:
                    label_cw.Text = "Incorrect!";
                    break;
                case 8:
                    label_cw.Text = "Correct!";
                    score++;
                    break;
                case 9:
                    label_cw.Text = "Incorrect!";
                    break;
                case 10:
                    label_cw.Text = "Incorrect!";
                    button1.Text = "Exit";
                    break;
                default:
                    label_cw.Text = "";
                    break;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            refreshInterface();
            switch (x)
            {
                case 1:
                    label_cw.Text = "Incorrect!";
                    break;
                case 2:
                    label_cw.Text = "Incorrect!";
                    break;
                case 3:
                    label_cw.Text = "Correct!";
                    score++;
                    break;
                case 4:
                    label_cw.Text = "Incorrect!";
                    break;
                case 5:
                    label_cw.Text = "Incorrect!";
                    break;
                case 6:
                    label_cw.Text = "Incorrect!";
                    break;
                case 7:
                    label_cw.Text = "Correct!";
                    score++;
                    break;
                case 8:
                    label_cw.Text = "Incorrect!";
                    break;
                case 9:
                    label_cw.Text = "Incorrect!";
                    break;
                case 10:
                    label_cw.Text = "Incorrect!";
                    button1.Text = "Exit";
                    break;
                default:
                    label_cw.Text = "";
                    break;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            refreshInterface();
            switch (x)
            {
                case 1:
                    label_cw.Text = "Incorrect!";
                    break;
                case 2:
                    label_cw.Text = "Correct!";
                    score++;
                    break;
                case 3:
                    label_cw.Text = "Incorrect!";
                    break;
                case 4:
                    label_cw.Text = "Incorrect!";
                    break;
                case 5:
                    label_cw.Text = "Incorrect!";
                    break;
                case 6:
                    label_cw.Text = "Correct!";
                    score++;
                    break;
                case 7:
                    label_cw.Text = "Incorrect!";
                    break;
                case 8:
                    label_cw.Text = "Incorrect!";
                    break;
                case 9:
                    label_cw.Text = "Incorrect!";
                    break;
                case 10:
                    label_cw.Text = "Correct!";
                    score++;
                    button1.Text = "Exit";
                    break;
                default:
                    label_cw.Text = "";
                    break;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            refreshInterface();
            switch (x)
            {
                case 1:
                    label_cw.Text = "Incorrect!";
                    break;
                case 2:
                    label_cw.Text = "Incorrect!";
                    break;
                case 3:
                    label_cw.Text = "Incorrect!";
                    break;
                case 4:
                    label_cw.Text = "Correct!";
                    score++;
                    break;
                case 6:
                    label_cw.Text = "Incorrect!";
                    break;
                case 7:
                    label_cw.Text = "Incorrect!";
                    break;
                case 8:
                    label_cw.Text = "Incorrect!";
                    break;
                case 9:
                    label_cw.Text = "Correct!";
                    score++;
                    break;
                case 10:
                    label_cw.Text = "Incorrect!";
                    button1.Text = "Exit";
                    break;
                default:
                    label_cw.Text = "";
                    break;
            }
        }

        private void FlagsForm_FormClosing(object sender, FormClosingEventArgs e)
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
