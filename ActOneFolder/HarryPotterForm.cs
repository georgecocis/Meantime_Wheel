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
    public partial class HarryPotterForm : Form
    {
        int count;
        int x = 0;
        Timer t = new Timer();
        Timer t2 = new Timer();
        Timer t3 = new Timer();
        int score = 0, val = 0, sum = 0;

        public HarryPotterForm(string a)
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
                    label2.Text = "Which of the four Marauders turns evil?";
                    button2.Text = "Peter Pettigrew";
                    button3.Text = "Sirius Black";
                    button4.Text = "Remus Lupin";
                    button5.Text = "James Potter";
                    break;
                case 2:
                    label2.Text = "How does Harry catch his first snitch?";
                    button2.Text = "Before the oposing team scores";
                    button3.Text = "While falling off the broom";
                    button4.Text = "With his mouth";
                    button5.Text = "While being upside down";
                    break;
                case 3:
                    label2.Text = "What is the nickname of Alastor Moody?";
                    button2.Text = "Crazy Tongue Moody";
                    button3.Text = "Mad Eye Moody";
                    button4.Text = "Insane Auror Moody";
                    button5.Text = "Moody the Mad";
                    break;
                case 4:
                    label2.Text = "Who is the Half Blood Prince?";
                    button2.Text = "Frank Longbottom";
                    button3.Text = "Lucius Malfoy";
                    button4.Text = "Gellert Grindelwald";
                    button5.Text = "Severus Snape";
                    break;
                case 5:
                    label2.Text = "What does the Mirror of Erised do?";
                    button2.Text = "Show a person's deepest desires";
                    button3.Text = "Show a person's future";
                    button4.Text = "Show a person's place of death";
                    button5.Text = "Show a person's dark inner self";
                    break;
                case 6:
                    label2.Text = "What is Snape's patronus?";
                    button2.Text = "Stag";
                    button3.Text = "Gryphon";
                    button4.Text = "Deer";
                    button5.Text = "Horse";
                    break;
                case 7:
                    label2.Text = "Who is the seeker for the Bulgarian Quidditch team?";
                    button2.Text = "Cedric Diggory";
                    button3.Text = "Viktor Krum";
                    button4.Text = "Lev Zograf";
                    button5.Text = "Ivan Volkov";
                    break;
                case 8:
                    label2.Text = "Who tells Harry he's a Wizard?";
                    button2.Text = "Hagrid";
                    button3.Text = "Dumbledore";
                    button4.Text = "Vernon Dursley";
                    button5.Text = "Molly Weasley";
                    break;
                case 9:
                    label2.Text = "What was the name of Hagrid's Acronamntula?";
                    button2.Text = "Fawkes";
                    button3.Text = "Nagini";
                    button4.Text = "Aragorn";
                    button5.Text = "Aragog";
                    break;
                case 10:
                    label2.Text = "What does Prof. Lupin offer Harry to make him feel better when the Dementors try to attack him?";
                    button2.Text = "Pale ale";
                    button3.Text = "Tea";
                    button4.Text = "Chocolate";
                    button5.Text = "Acid Pops";
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

        private void HarryPotterForm_FormClosing(object sender, FormClosingEventArgs e)
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
