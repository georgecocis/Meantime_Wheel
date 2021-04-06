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

namespace SEProject
{
    public partial class MovieForm : Form
    {
        int count;
        int x = 0;
        Timer t = new Timer();
        Timer t2 = new Timer();
        Timer t3 = new Timer();
        int score = 0, val = 0, sum = 0;

        public MovieForm(string a)
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

        private void button1_Click_1(object sender, EventArgs e)
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
                    label2.Text = "In 'The Matrix', what's the color of the pull that Neo takes?";
                    button2.Text = "Red";
                    button3.Text = "Greeb";
                    button4.Text = "Blue";
                    button5.Text = "Cyan";
                    break;
                case 2:
                    label2.Text = "The head of what kind of animal is front-and-center in an infamous scene from The Godfather?";
                    button2.Text = "A buck";
                    button3.Text = "An ostrich";
                    button4.Text = "A horse";
                    button5.Text = "A wolf";
                    break;
                case 3:
                    label2.Text = "Who is the only actor to receive an Oscar nomination for acting in a Lord of the Rings movie?";
                    button2.Text = "Orlando Bloom";
                    button3.Text = "Ian McKellen";
                    button4.Text = "Vigo Mortensen";
                    button5.Text = "Elijah Wood";
                    break;
                case 4:
                    label2.Text = "Which Alfred Hitchcock movie is notorious for its shocking “shower scene”?";
                    button2.Text = "Strangers on a train";
                    button3.Text = "The Birds";
                    button4.Text = "Vertigo";
                    button5.Text = "Psycho";
                    break;
                case 5:
                    label2.Text = "What was Quentin Tarantino‘s first feature as writer/director?";
                    button2.Text = "Reservoir Dogs";
                    button3.Text = "Pulp Fiction";
                    button4.Text = "Planet Terror";
                    button5.Text = "Jackie Brown";
                    break;
                case 6:
                    label2.Text = "Which Friends star appeared in the movie Scream?";
                    button2.Text = "Phobe";
                    button3.Text = "Chandler";
                    button4.Text = "Monica";
                    button5.Text = "Joey";
                    break;
                case 7:
                    label2.Text = "Who is Harry Potter’s godfather?";
                    button2.Text = "Remus Lupin";
                    button3.Text = "Sirius Black";
                    button4.Text = "Severus Snape";
                    button5.Text = "Alastor Moody";
                    break;
                case 8:
                    label2.Text = "What is the name of Andy’s neighbor in Toy Story?";
                    button2.Text = "Sid";
                    button3.Text = "Diego";
                    button4.Text = "Zeke";
                    button5.Text = "Manfred";
                    break;
                case 9:
                    label2.Text = "Approximately how many languages can C-3PO speak in Star Wars?";
                    button2.Text = "600 thousand";
                    button3.Text = "100";
                    button4.Text = "3 thousand";
                    button5.Text = "6 million";
                    break;
                case 10:
                    label2.Text = "What is the symbolism of the crow crowing three times in the Godfather movies?";
                    button2.Text = "Famine";
                    button3.Text = "Pestilence";
                    button4.Text = "Death";
                    button5.Text = "War";
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

        private void button2_Click_1(object sender, EventArgs e)
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

        private void button3_Click_1(object sender, EventArgs e)
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

        private void button4_Click_1(object sender, EventArgs e)
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

        private void button5_Click_1(object sender, EventArgs e)
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

        private void MovieForm_FormClosing(object sender, FormClosingEventArgs e)
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
