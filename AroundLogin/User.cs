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

namespace SEProject.AroundLogin
{
    public partial class User : Form
    {
        int oldTokens = 0, newTokens = 0, tDif = 0, tSum = 0;

        public User(string a)
        {
            InitializeComponent();

            this.MyVal = a;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(MyVal);
            this.Hide();
            f2.ShowDialog();
        }

        public string MyVal { get; set; }
        private void showButton_Click(object sender, EventArgs e)
        {
            MySqlConnection sqlcon = new MySqlConnection(@"server=localhost;user id=root;database=seproject;password=rootpassword");
            try
            {
                sqlcon.Open();
                DataTable Albums = new DataTable();
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM seproject.user WHERE username = '" + MyVal + "'", sqlcon))
                {
                    MySqlDataReader reader = cmd.ExecuteReader();
                    Albums.Load(reader);
                }
                dataGridView1.DataSource = Albums;
                sqlcon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection error");
            }
        }

        private void withdrawButton_Click(object sender, EventArgs e)
        {
            if (tokensText.Text != null)
            {
                //newTokens = oldTokens - Convert.ToInt32(tokensText.Text);
                tDif = 1;
                MySqlConnection sqlcon = new MySqlConnection(@"server=localhost;user id=root;database=seproject;password=rootpassword");
                MySqlCommand cmd = null;
                MySqlDataReader reader = null;

                try
                {
                    string sql = "SELECT realCurrency FROM seproject.user WHERE username = '" + MyVal + "';";

                    //sqlcon = new MySqlConnection(Properties.Settings.Default.ConnectionString);
                    cmd = new MySqlCommand(sql, sqlcon);

                    sqlcon.Open();

                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        oldTokens = reader.GetInt32("realCurrency");                        
                    }
                    Console.WriteLine(oldTokens);
                    MessageBox.Show("Tokens will be updated");
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
            }
        }

        private void User_FormClosing(object sender, FormClosingEventArgs e)
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

        private void verifyButton_Click(object sender, EventArgs e)
        {
            if (tokensText.Text != null)
            {
                if (tDif == 1)
                {
                    newTokens = oldTokens - Convert.ToInt32(tokensText.Text);
                }
                else if (tSum == 1)
                {
                    newTokens = oldTokens + Convert.ToInt32(tokensText.Text);
                }
                MySqlConnection sqlcon = new MySqlConnection(@"server=localhost;user id=root;database=seproject;password=rootpassword");
                try
                {
                    sqlcon.Open();

                    string Query = "update seproject.user set realCurrency = " + "'" + newTokens + "' where (username = '" + MyVal + "');";
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
                tokensText.Text = "";
                tDif = 0;
                tSum = 0;
            }
            
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            string pass = passwordText.Text;
            MySqlConnection sqlcon = new MySqlConnection(@"server=localhost;user id=root;database=seproject;password=rootpassword");
            try
            {
                sqlcon.Open();

                string Query = "update seproject.user set password = " + "'" + pass + "' where (username = '" + MyVal + "');";
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
            passwordText.Text = "";
        }

        private void depositButton_Click(object sender, EventArgs e)
        {
            if (tokensText.Text != null)
            {
                //newTokens = oldTokens + Convert.ToInt32(tokensText.Text);
                tSum = 1;
                MySqlConnection sqlcon = new MySqlConnection(@"server=localhost;user id=root;database=seproject;password=rootpassword");
                MySqlCommand cmd = null;
                MySqlDataReader reader = null;

                try
                {
                    string sql = "SELECT realCurrency FROM seproject.user WHERE username = '" + MyVal + "';";

                    //sqlcon = new MySqlConnection(Properties.Settings.Default.ConnectionString);
                    cmd = new MySqlCommand(sql, sqlcon);

                    sqlcon.Open();

                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        oldTokens = reader.GetInt32("realCurrency");                        
                    }
                    Console.WriteLine(oldTokens);
                    MessageBox.Show("Tokens will be updated");
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
            }
            
        }
    }
}
