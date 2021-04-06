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

namespace SEProject.ActFourFolder
{
    public partial class ActFourMatchTheCards : Form
    {
        bool allowClick = false;
        PictureBox firstGuess;
        Timer clickTimer = new Timer();
        int time = 0, score = 0, val = 0, sum = 0;
        Timer timer = new Timer();
   
        public ActFourMatchTheCards(string a)
        {
            InitializeComponent();
            this.MyVal = a;
        }

        public string MyVal { get; set; }
        private PictureBox[] pictureBoxes
        {
            get { return Controls.OfType<PictureBox>().ToArray(); }
        }

        private static IEnumerable<Image> images
        {
            get
            {
                return new Image[]
                {
                    Properties.Resources.hulk_MatchTheCards,
                    Properties.Resources.thor_MatchTheCards,
                    Properties.Resources.ironMan_MatchTheCards,
                    Properties.Resources.captainAmerica_MatchTheCards,
                    Properties.Resources.captainMarvel_MatchTheCards,
                    Properties.Resources.loki_MatchTheCards,
                    Properties.Resources.blackPanther_MatchTheCards,
                    Properties.Resources.spiderMan_MatchTheCards,
                    Properties.Resources.question

                };
            }
        }

        private void startGameTimer()
        {

            time = 0;
            timer.Interval = (1000);
            timer.Start();
            timer.Tick += updateTimer;
           
        }
       

        private void ResetImages()
        {
            foreach (var pic in pictureBoxes)
            {
                pic.Visible = true;
                pic.Enabled = true;
            }
            
            HideImages();
            //time = 60;
            timer.Stop();
            button1.Enabled = true;
            //score = 0;
            scoreLabel.Text = "Score: 0" ;
            
        }

        private void HideImages()
        {
            foreach(var pic in pictureBoxes)
            {
                if (pic.Enabled)
                {
                    pic.Image = Properties.Resources.question;
                }
            }
        }

       

        private void CLICKTIMER_TICK(object sender, EventArgs e)
        {
            HideImages();

            allowClick = true;
            clickTimer.Stop();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void clickIamge(object sender, EventArgs e)
        {
            if (!allowClick) return;          

            var pic = sender as PictureBox;

            if(firstGuess == null)
            {
                firstGuess = pic;
                pic.Image = (Image)pic.BackgroundImage;
                firstGuess.Tag = pic.Tag;

                return;
            }

            pic.Image = (Image)pic.BackgroundImage;
            if(pic.Tag == firstGuess.Tag && pic != firstGuess)
            {                
                pic.Enabled = false;
                firstGuess.Enabled = false;
                
               
                firstGuess = null;
            }
            else
            {
                 allowClick = false;
                 clickTimer.Start();                
            }

            firstGuess = null;
            if (pictureBoxes.Any(p => p.Enabled)) return;            
            score = 10;
            scoreLabel.Text = "Score: " + score.ToString();
            label2.Text = "00:00";
            button2.Enabled = true;
            
            MessageBox.Show("You Win");
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

            ResetImages();
            button1.Enabled = false;

            return;
        }

        private void ActFourMatchTheCards_FormClosing(object sender, FormClosingEventArgs e)
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

        private void updateTimer(object sender, EventArgs e)
        {
            time = time + 1;
            if (time > 60)
            {
                timer.Stop();
                MessageBox.Show("Out of time :(");
                //score = 0;
                scoreLabel.Text = "Score: 0" ;
                ResetImages();
            }
            if (pictureBoxes.All(p => p.Enabled == false))
            {
                timer.Stop();
                return;
            }

            if (time >= 0)
            {
                if (time >= 10)
                {
                    label2.Text = "00:" + time.ToString();
                }
                else
                {
                    label2.Text = "00:" + "0" + time.ToString();
                }
            }

        }

        private void startGame(object sender, EventArgs e)
        {
            allowClick = true;
            HideImages();
            startGameTimer();
            //ResetImages();
            clickTimer.Interval = 750;
            clickTimer.Tick += CLICKTIMER_TICK;
            button1.Enabled = false;
            score = 0;
            scoreLabel.Text = "Score: " + score.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sum = score + val;
            MySqlConnection sqlcon = new MySqlConnection(@"server=localhost;user id=root;database=seproject;password=rootpassword");
            try
            {
                sqlcon.Open();

                string Query = "update seproject.user set inGameCurrency = " + "'" + sum + "' where (username = '" + MyVal + "');";
                MySqlCommand cmdInsert = new MySqlCommand(Query, sqlcon);
                MySqlDataReader reader = cmdInsert.ExecuteReader();
                MessageBox.Show("Saved");
                while (reader.Read())
                { }
                sqlcon.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Insertion failed");
            }
            ActFour act4 = new ActFour(MyVal);
            this.Hide();
            act4.ShowDialog();
        }
    }
}
