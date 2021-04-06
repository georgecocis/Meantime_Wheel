using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SEProject
{
    public partial class SongsForm : Form
    {
        int count;
        int x = 0;
        Timer t = new Timer();
        Timer t2 = new Timer();
        Timer t3 = new Timer();
        SoundPlayer sp = new SoundPlayer();
        int score = 0, val = 0, sum = 0;

        public SongsForm(string a)
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
            sp.Stop();
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

        private void soundPlayer(int x)
        {
            switch (x)
            {
                case 1:
                    sp = new SoundPlayer(Properties.Resources.queen);
                    sp.Play();
                    break;
                case 2:
                    sp = new SoundPlayer(Properties.Resources.tgheorghe);
                    sp.Play();
                    break;
                case 3:
                    sp = new SoundPlayer(Properties.Resources.hendrix);
                    sp.Play();
                    break;
                case 4:
                    sp = new SoundPlayer(Properties.Resources.rhcp);
                    sp.Play();
                    break;
                case 5:
                    sp = new SoundPlayer(Properties.Resources.sia);
                    sp.Play();
                    break;
                case 6:
                    sp = new SoundPlayer(Properties.Resources.katy);
                    sp.Play();
                    break;
                case 7:
                    sp = new SoundPlayer(Properties.Resources.bap);
                    sp.Play();
                    break;
                case 8:
                    sp = new SoundPlayer(Properties.Resources.prodigy);
                    sp.Play();
                    break;
                case 9:
                    sp = new SoundPlayer(Properties.Resources.pjam);
                    sp.Play();
                    break;
                case 10:
                    sp = new SoundPlayer(Properties.Resources.sub);
                    sp.Play();
                    break;
                default:
                    break;
            }
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
                button1.Text = "Next song";
                x++;
                unlockButtons();
                startRoundTimer();
                displayTimer();
                soundPlayer(x);
                scoreLabel.Text = score.ToString();
            }
            switch (x)
            {
                case 1:
                    button2.Text = "Queen - Don't Stop Me Now";
                    button3.Text = "The Rolling Stones - Gimme Shelter";
                    button4.Text = "The Beatles - Strawberry Fields";
                    button5.Text = "Guns 'n Roses - Civil War";
                    break;
                case 2:
                    button2.Text = "Subcarpati - Folclor Nemuritor";
                    button3.Text = "Holograf - Primara Incepe Cu Tine";
                    button4.Text = "Tudor Gheorghe - Au Innebunit Salcamii";
                    button5.Text = "Spike - Salcamii";
                    break;
                case 3:
                    button2.Text = "Led Zeppelin - Whole Lotta Love";
                    button3.Text = "Jimi Hendrix - Hey Joe";
                    button4.Text = "Eric Clapton - Cocaine";
                    button5.Text = "Carlos Santana - Black Magic Woman";
                    break;
                case 4:
                    button2.Text = "Arctic Monkeys - Flourescent Adolescent";
                    button3.Text = "Nothing But Thieves - Amsterdam";
                    button4.Text = "Cage The Elephant - Ain't No Rest For The Wicked";
                    button5.Text = "Red Hot Chili Peppers - Dani California";
                    break;
                case 5:
                    button2.Text = "Sia - Unstoppable";
                    button3.Text = "Billie Eilish ft. Khalid - Lovely";
                    button4.Text = "Nelly Furtado - Say It Right";
                    button5.Text = "Rihanna - Love On The Brain";
                    break;
                case 6:
                    button2.Text = "Lana Del Rey - Young And Beautiful";
                    button3.Text = "Miley Cyrus - We Can't Stop";
                    button4.Text = "Katy Perry - Firework";
                    button5.Text = "Taylor Swift - Blank Space";
                    break;
                case 7:
                    button2.Text = "Panic! At The Disco - Emperor's New Clothes";
                    button3.Text = "The Black Eyed Peas - Boom Boom Pow";
                    button4.Text = "Bring Me The Horizon - Teardrops";
                    button5.Text = "Mark Ranson ft. Bruno Mars - Uptown Funk";
                    break;
                case 8:
                    button2.Text = "The Prodigy - Omen";
                    button3.Text = "Noisia - Alpha Centauri";
                    button4.Text = "Modestep - Another Day ft. Popeska";
                    button5.Text = "Sub Focus - Rock It";
                    break;
                case 9:
                    button2.Text = "Alice In Chains - Rooster";
                    button3.Text = "Nirvana - In Bloom";
                    button4.Text = "Soundgarden - Black Hole Sun";
                    button5.Text = "Pearl Jam - Garden";
                    break;
                case 10:
                    button2.Text = "Suie Paparude - A Fost Odata";
                    button3.Text = "Dragonu' x Kaxi Ploae x Bean - Miles";
                    button4.Text = "Subcarpati cu Motanu' si Calin Han - Da-i Foale";
                    button5.Text = "Faust cu Motanu' - Acelasi Feeling";
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

        private void SongsForm_FormClosing(object sender, FormClosingEventArgs e)
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
