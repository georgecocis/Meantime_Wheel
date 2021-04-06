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
    public partial class ActSeven : Form
    {
        int coinsBalance = 50;
        int tokensBalance = 50;
        int val1 = 0, val2 = 0, sum1 = 0, sum2 = 0;

        private readonly Random _random = new Random();
        public int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }
        public ActSeven(string a)
        {
            InitializeComponent();
            panel1.BackColor = Color.FromArgb(100, Color.Red);
            label11.Text = tokensBalance.ToString();
            label12.Text = coinsBalance.ToString();
            this.MyVal = a;
        }
        public string MyVal { get; set; }
        private void updateBalance(int x, int y)
        {
            label11.Text = x.ToString();
            label12.Text = y.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String currency = comboBox1.Text;
            String bet = textBox1.Text;
            String nr = comboBox2.Text;
            if (currency != "" && bet != "" && nr != "")
            {
                if ((currency == "Coins" && Int32.Parse(bet) <= coinsBalance) || (currency == "Tokens" && Int32.Parse(bet) <= tokensBalance))
                {
                    label5.Text = "You rolled:";
                    int roll = RandomNumber(0, 100);
                    rolledLabel.Text = roll.ToString();
                    switch (nr)
                    {
                        case "Exactly 0":
                            if (roll == 0)
                            {
                                label7.Text = "Woohoo! You won!";
                                if (currency == "Coins")
                                    coinsBalance += Int32.Parse(bet) * 2;
                                else if (currency == "Tokens")
                                    tokensBalance += Int32.Parse(bet) * 2;
                            }
                            else
                            {
                                label7.Text = "Too bad. Try again!";
                                if (currency == "Coins")
                                    coinsBalance -= Int32.Parse(bet);
                                else if (currency == "Tokens")
                                    tokensBalance -= Int32.Parse(bet);
                            }
                            break;
                        case "Exactly 100":
                            if (roll == 100)
                            {
                                label7.Text = "Woohoo! You won!";
                                if (currency == "Coins")
                                    coinsBalance += Int32.Parse(bet) * 2;
                                else if (currency == "Tokens")
                                    tokensBalance += Int32.Parse(bet) * 2;
                            }
                            else
                            {
                                label7.Text = "Too bad. Try again!";
                                if (currency == "Coins")
                                    coinsBalance -= Int32.Parse(bet);
                                else if (currency == "Tokens")
                                    tokensBalance -= Int32.Parse(bet);
                            }
                            break;
                        case "Exactly 50":
                            if (roll == 50)
                            {
                                label7.Text = "Woohoo! You won!";
                                if (currency == "Coins")
                                    coinsBalance += Int32.Parse(bet) * 2;
                                else if (currency == "Tokens")
                                    tokensBalance += Int32.Parse(bet) * 2;
                            }
                            else
                            {
                                label7.Text = "Too bad. Try again!";
                                if (currency == "Coins")
                                    coinsBalance -= Int32.Parse(bet);
                                else if (currency == "Tokens")
                                    tokensBalance -= Int32.Parse(bet);
                            }
                            break;
                        case "Greater than 90":
                            if (roll >= 90)
                            {
                                label7.Text = "Too bad. Try again!";
                                label7.Text = "Woohoo! You won!";
                                if (currency == "Coins")
                                    coinsBalance += Int32.Parse(bet);
                                else if (currency == "Tokens")
                                    tokensBalance += Int32.Parse(bet);
                            }
                            else
                            {
                                label7.Text = "Too bad. Try again!";
                                if (currency == "Coins")
                                    coinsBalance -= Int32.Parse(bet);
                                else if (currency == "Tokens")
                                    tokensBalance -= Int32.Parse(bet);
                            }
                            break;
                        case "Lower than 10":
                            if (roll < 10)
                            {
                                label7.Text = "Woohoo! You won!";
                                if (currency == "Coins")
                                    coinsBalance += Int32.Parse(bet);
                                else if (currency == "Tokens")
                                    tokensBalance += Int32.Parse(bet);
                            }
                            else
                            {
                                label7.Text = "Too bad. Try again!";
                                if (currency == "Coins")
                                    coinsBalance -= Int32.Parse(bet);
                                else if (currency == "Tokens")
                                    tokensBalance -= Int32.Parse(bet);
                            }
                            break;
                        case "Between 20 and 40":
                            if (roll >= 20 && roll <= 40)
                            {
                                label7.Text = "Woohoo! You won!";
                                if (currency == "Coins")
                                    coinsBalance += Int32.Parse(bet) / 2;
                                else if (currency == "Tokens")
                                    tokensBalance += Int32.Parse(bet) / 2;
                            }
                            else
                            {
                                label7.Text = "Too bad. Try again!";
                                if (currency == "Coins")
                                    coinsBalance -= Int32.Parse(bet);
                                else if (currency == "Tokens")
                                    tokensBalance -= Int32.Parse(bet);
                            }
                            break;
                        case "Between 60 and 80":
                            if (roll >= 60 && roll <= 80)
                            {
                                label7.Text = "Woohoo! You won!";
                                if (currency == "Coins")
                                    coinsBalance += Int32.Parse(bet) / 2;
                                else if (currency == "Tokens")
                                    tokensBalance += Int32.Parse(bet) / 2;
                            }
                            else
                            {
                                label7.Text = "Too bad. Try again!";
                                if (currency == "Coins")
                                    coinsBalance -= Int32.Parse(bet);
                                else if (currency == "Tokens")
                                    tokensBalance -= Int32.Parse(bet);
                            }
                            break;
                        default:
                            MessageBox.Show("Error");
                            break;

                    }
                    updateBalance(tokensBalance, coinsBalance);
                }
                else MessageBox.Show("Balance error.");
            }
            else
                MessageBox.Show("Input error");
        }

        private void ActSeven_FormClosing(object sender, FormClosingEventArgs e)
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

                    val1 = reader.GetInt32("inGameCurrency");
                    //lblContinent.Text = reader.GetInt32("continent");
                    //lblRegion.Text = reader.GetString("region");
                    //lblSurfaceArea.Text = string.Format("{0:0.00}", reader.GetFloat("surfacearea"));
                }
                Console.WriteLine(val1);
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
            try
            {
                string sql = "SELECT realCurrency FROM seproject.user WHERE username = '" + MyVal + "';";

                //sqlcon = new MySqlConnection(Properties.Settings.Default.ConnectionString);
                cmd = new MySqlCommand(sql, sqlcon);

                sqlcon.Open();

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    val2 = reader.GetInt32("realCurrency");
                    //lblContinent.Text = reader.GetInt32("continent");
                    //lblRegion.Text = reader.GetString("region");
                    //lblSurfaceArea.Text = string.Format("{0:0.00}", reader.GetFloat("surfacearea"));
                }
                Console.WriteLine(val2);
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
            MessageBox.Show("Your coins: " + coinsBalance.ToString() );
            sum1 = val1 + coinsBalance;
            sum2 = val2 + tokensBalance;
            try
            {
                sqlcon.Open();

                string Query1 = "update seproject.user set inGameCurrency = " + "'" + sum1 + "' where (username = '" + MyVal + "');";
                MySqlCommand cmdInsert = new MySqlCommand(Query1, sqlcon);
                MySqlDataReader reader1 = cmdInsert.ExecuteReader();
                MessageBox.Show("Saved");
                while (reader1.Read())
                { }
                
                //sqlcon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Insertion failed");
            }
            finally
            {
                sqlcon.Close();
            }
            MessageBox.Show("Your tokens: " + tokensBalance.ToString());
            try
            {
                sqlcon.Open();

                string Query2 = "update seproject.user set realCurrency = " + "'" + sum2 + "' where (username = '" + MyVal + "');";
                MySqlCommand cmdInsert1 = new MySqlCommand(Query2, sqlcon);
                MySqlDataReader reader2 = cmdInsert1.ExecuteReader();
                MessageBox.Show("Saved");
                while (reader2.Read())
                { }
                sqlcon.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Insertion failed");
            }
            finally
            {
                sqlcon.Close();
            }
            this.Hide();
            WheelForm wf = new WheelForm(MyVal);
            wf.ShowDialog();
        }

    }
}
