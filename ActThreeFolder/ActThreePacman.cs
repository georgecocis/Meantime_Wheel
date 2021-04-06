using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SEProject.ActThreeFolder
{
    public partial class ActThreePacman : Form
    {
        bool goup, godown, goleft, goright, gameOver;

        int score, playerSpeed, pinkGhostSpeed, orangeGhostSpeed, redGhostX, redGhostY;

        private void ActThreePacman_FormClosing(object sender, FormClosingEventArgs e)
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

        int val = 0, sum = 0;

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
            MessageBox.Show("Game over \n Your score is " + score.ToString());
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
            ActThree act3 = new ActThree(MyVal);
            this.Hide();
            act3.ShowDialog();

        }

        
      

        public ActThreePacman(string a)
        {
            InitializeComponent();
            this.MyVal = a;
            resetGame();
        }
        public string MyVal { get; set; }
        private void keyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goleft = true;
               
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = true;
               
            }
            if (e.KeyCode == Keys.Up)
            {
                goup = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                godown = true;
            }

        }

        private void keyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goleft = false;
                
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                goup = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                godown = false;
            }

            if(e.KeyCode == Keys.Space && gameOver == true)
            {
                resetGame();
            }

        }

        private void mainGameTimer(object sender, EventArgs e)
        {

            txtScore.Text = "Score: " + score;

            if(goleft)
            {
                pacman.Left -= playerSpeed;
                pacman.Image = Properties.Resources.pacman_left;
            }

            if (goright)
            {
                pacman.Left += playerSpeed;
                pacman.Image = Properties.Resources.pacman_right;
            }

            if(goup)
            {
                pacman.Top -= playerSpeed;
                pacman.Image = Properties.Resources.pacman_up;
            }

            if(godown)
            {
                pacman.Top += playerSpeed;
                pacman.Image = Properties.Resources.pacman_down;
            }

            if (pacman.Left < 0)
            {
                pacman.Left = 600;
            }

            if (pacman.Left > 600)
            {
                pacman.Left = -5;
            }

            if (pacman.Top < -5)
            {
                pacman.Top = 450;
            }

            if(pacman.Top > 450)
            {
                pacman.Top = 0;
            }

           foreach(Control x in this.Controls)
           {
                if (x is PictureBox)
                {
                    if ((string)x.Tag == "food" && x.Visible == true)
                    {
                        if (pacman.Bounds.IntersectsWith(x.Bounds))
                        {
                            score += 1;
                            x.Visible = false;
                        }
                    }

                    if ((string)x.Tag == "wall")
                    {
                        if (pacman.Bounds.IntersectsWith(x.Bounds))
                        {
                            gameOverr("You lost");
                            button1.Enabled = true;
                            button1.Visible = true;
                        }

                        if (redGhost.Bounds.IntersectsWith(x.Bounds))
                        {
                            redGhostX = -redGhostX;
                        }
                    }

                    if((string)x.Tag == "ghost")
                    {
                        if (pacman.Bounds.IntersectsWith(x.Bounds))
                        {
                            gameOverr("You lost");
                            button1.Enabled = true;
                            button1.Visible = true;
                        }
                    }
                }
           }

            //ghosts

            orangeGhost.Left += orangeGhostSpeed;
            if (orangeGhost.Bounds.IntersectsWith(pictureBox1.Bounds) || orangeGhost.Bounds.IntersectsWith(pictureBox2.Bounds))
            {
                orangeGhostSpeed = -orangeGhostSpeed;
            }

            pinkGhost.Left -= pinkGhostSpeed;
            if (pinkGhost.Bounds.IntersectsWith(pictureBox3.Bounds) || pinkGhost.Bounds.IntersectsWith(pictureBox4.Bounds))
            {
                pinkGhostSpeed = -pinkGhostSpeed;
            }

            redGhost.Left -= redGhostX;
            redGhost.Top -= redGhostY;

            if(redGhost.Top < 0 || redGhost.Top > 400)
            {
                redGhostY = -redGhostY;
            }

            if(redGhost.Left < 0 || redGhost.Left > 550)
            {
                redGhostX = -redGhostX;
            }

            if (score == 65)
            {
                gameOverr("You won!");
                button1.Enabled = true;
                button1.Visible = true;
            }

        }

        private void resetGame()
        {
            txtScore.Text = "Score: 0";
            score = 0;

            playerSpeed = 18;
            pinkGhostSpeed = 9;
            orangeGhostSpeed = 9;
            redGhostY = 9;
            redGhostX = 9;

            gameOver = false;

            pacman.Left = 10;
            pacman.Top = 50;

            orangeGhost.Left = 310;
            orangeGhost.Top = 45;

            redGhost.Left = 500;
            redGhost.Top = 163;

            pinkGhost.Left = 215;
            pinkGhost.Top = 350;

            gameTimer.Start();

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    x.Visible = true;
                }
            }
        }

        private void gameOverr(string message)
        {
            gameOver = true;
            gameTimer.Stop();
            txtScore.Text = "Score: " + score + Environment.NewLine + message;
            
        }
    }
}
