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
    public partial class PopCultureForm : Form
    {
        int count;
        int x = 0;
        Timer t = new Timer();
        Timer t2 = new Timer();
        Timer t3 = new Timer();
        int score = 0, val = 0, sum = 0;

        public PopCultureForm(string a)
        {
            InitializeComponent();
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
                    label2.Text = "Which rapper performs on Usher's 'Yeah'?";
                    button2.Text = "Ludacris";
                    button3.Text = "B-Real";
                    button4.Text = "Pit Bull";
                    button5.Text = "50 Cent";
                    break;
                case 2:
                    label2.Text = "What is Jack Nicholson’s famous line from The Shining?";
                    button2.Text = "I'm not gonna hurt ya. I'm just gonna bash your brains in!";
                    button3.Text = "Wendy, I'm home!";
                    button4.Text = "Here's Johnny!";
                    button5.Text = "All work and no play makes Jack a dull boy.";
                    break;
                case 3:
                    label2.Text = "Get Out, and Us were created by what director?";
                    button2.Text = "John Carpenter";
                    button3.Text = "Jordan Peele";
                    button4.Text = "Tim Burton";
                    button5.Text = "Mike Flanagan";
                    break;
                case 4:
                    label2.Text = "Who did Forbes name the youngest “self-made billionaire ever” in 2019?";
                    button2.Text = "Jeff Bezos";
                    button3.Text = "Kendall Jenner";
                    button4.Text = "Elon Musk";
                    button5.Text = "Kylie Jenner";
                    break;
                case 5:
                    label2.Text = "What is Chandler Bing’s middle name?";
                    button2.Text = "Muriel";
                    button3.Text = "McCarthy";
                    button4.Text = "Joffrey";
                    button5.Text = "Dusty";
                    break;
                case 6:
                    label2.Text = "What is the name of Michelle Obama’s 2018 memoir?";
                    button2.Text = "Awareness";
                    button3.Text = "Aspiration";
                    button4.Text = "Becoming";
                    button5.Text = "Ascension";
                    break;
                case 7:
                    label2.Text = "What day is Star Wars Day?";
                    button2.Text = "February 25";
                    button3.Text = "May 4";
                    button4.Text = "August 17";
                    button5.Text = "October 18";
                    break;
                case 8:
                    label2.Text = "Which tech entrepreneur named his son X Æ A-12?";
                    button2.Text = "Elon Musk";
                    button3.Text = "Markus Villig";
                    button4.Text = "Leah Busque";
                    button5.Text = "Bill Gates";
                    break;
                case 9:
                    label2.Text = "What is the name of the alternate dimension in Netflix’s Stranger Things?";
                    button2.Text = "The Nether";
                    button3.Text = "The Void";
                    button4.Text = "The Necropolis";
                    button5.Text = "The Upside Down";
                    break;
                case 10:
                    label2.Text = "What was the name of 'The book of evil' in Evil Dead?";
                    button2.Text = "The Book of Ur";
                    button3.Text = "Morellonomicon";
                    button4.Text = "Necronomicon";
                    button5.Text = "The Forbidden Scripture";
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

        private void PopCultureForm_FormClosing(object sender, FormClosingEventArgs e)
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
