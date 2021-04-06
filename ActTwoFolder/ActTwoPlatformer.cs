using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace SEProject
{
    public partial class ActTwoPlatformer : Form
    {

        bool playerLeft, playerRight, playerJump, isGameOver, chaos;
        int jumpSpeed, movSpeed = 5, force;
        double score = 0, val = 0, sum = 0; /* Player related */
        int verticalSpeed = 2; /* Moving platform */

        private void player_Click(object sender, EventArgs e)
        {

        }

        private void ActTwoPlatformer_FormClosing(object sender, FormClosingEventArgs e)
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
            MessageBox.Show("Your score is " + score.ToString());
            sum = val + score;
            Console.WriteLine(MyVal);
            //MySqlConnection sqlcon = new MySqlConnection(@"server=localhost;user id=root;database=seproject;password=rootpassword");
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
            ActTwo act2 = new ActTwo(MyVal);
            this.Hide();
            act2.ShowDialog();
            
        }

        int enemySpeed = 4; /* Enemy */

        public ActTwoPlatformer(string a)
        {
            InitializeComponent();
            this.MyVal = a;
        }
        public string MyVal { get; set; }

        private void mainGameTimerEvent(object sender, EventArgs e)
        {
            score_label.Text = "Score: " + score.ToString();
            player.Top += jumpSpeed; 
            if (playerLeft == true)
                player.Left -= movSpeed;
            if (playerRight == true)
                player.Left += movSpeed;
            if (playerJump == true && force < 0)
                playerJump = false;
            if (playerJump == true)
            {
                jumpSpeed = -4;
                force--;
            }
            else
                jumpSpeed = 7;

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    //x.BringToFront();
                    if ((string)x.Tag == "platform")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            force = 8;
                            player.Top = x.Top - player.Height;
                        }
                    }

                    if ((string)x.Tag == "silver")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            if (x.Visible)
                                score += 50;
                            x.Visible = false;
                        }
                    }

                    if (x.Name == "gold")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            if (x.Visible)
                                score += 250;
                            x.Visible = false;
                        }
                    }

                    if ((string)x.Tag == "enemy")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            gameTimer.Stop();
                            isGameOver = true;
                            score_label.Text = "Score: " + score.ToString() + Environment.NewLine + "You got killed!" + Environment.NewLine + "Press enter to respawn.";
                            MessageBox.Show("You lost");
                            button1.Enabled = true;
                            button1.Visible = true;
                            
                        }
                    }

                    if (x.Name == "fire")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            gameTimer.Stop();
                            isGameOver = true;
                            score_label.Text = "Score: " + score.ToString() + Environment.NewLine + "You died in flames!" + Environment.NewLine + "Press enter to respawn.";
                            MessageBox.Show("You lost");
                            button1.Enabled = true;
                            button1.Visible = true;
                            
                        }
                    }

                    if (x.Name == "castle")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            gameTimer.Stop();
                            isGameOver = true;
                            score_label.Text = "Score: " + score.ToString() + Environment.NewLine + "You won!";
                            player.Visible = false;
                            MessageBox.Show("You Won");
                            button1.Enabled = true;
                            button1.Visible = true;
                            
                        }
                    }

                }
            }

            verticalPlatform1.Top += verticalSpeed;
            if (verticalPlatform1.Top < 224 || verticalPlatform1.Top > 350)
                verticalSpeed = -verticalSpeed;

            enemy.Left -= enemySpeed;
            if (enemy.Left < 450 || enemy.Left > 670)
                enemySpeed = -enemySpeed;

            if (player.Top > 400)
            {
                gameTimer.Stop();
                isGameOver = true;
                score_label.Text = "Score: " + score.ToString() + Environment.NewLine + "You fell to death!" + Environment.NewLine + "Press enter to respawn.";
                player.Visible = false;
                MessageBox.Show("You lost");
                button1.Enabled = true;
                button1.Visible = true;
                
            }
      /*
            if (chaos)
            {
                foreach (Control x in this.Controls)
                {
                    if (x is PictureBox)
                    {
                        if ((string)x.Tag == "platform" && x.Name != "start" && x.Name != "finish" && x.Name != "middle" && x.Name != "player" && x.Name != "enemy")
                        {
                            int var = x.Top;
                            x.Top += verticalSpeed;
                            if (x.Top < var - 100 || x.Top > var + 100)
                                verticalSpeed = -verticalSpeed;
                        }
                    }
                }
            }
            */
        }

        private void keyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
                playerLeft = true;
            if (e.KeyCode == Keys.Right)
                playerRight = true;
            if (e.KeyCode == Keys.Space && playerJump == false)
                playerJump = true;
        }

        private void keyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
                playerLeft = false;
            if (e.KeyCode == Keys.Right)
                playerRight = false;
            if (playerJump == true)
                playerJump = false;
            if (e.KeyCode == Keys.Enter && isGameOver == true)
                gameReset();
        }

        private void gameReset()
        {
            playerRight = false;
            playerRight = false;
            playerJump = false;
            isGameOver = false;
            score = 0;

            foreach (Control x in this.Controls)
            {
                /* Reset each coin */
                if (x is PictureBox && x.Visible == false)
                    x.Visible = true;
            }
            gold.Visible = true;
            player.Visible = true;
            /* Respawn player */
            player.Left = 12;
            player.Top = 225;
            /* Respawn enemy */
            enemy.Left = 670;

            gameTimer.Start();
        }
    }
}
