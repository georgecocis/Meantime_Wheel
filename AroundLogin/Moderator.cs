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
    public partial class Moderator : Form
    {
        MySqlConnection sqlcon = new MySqlConnection(@"server=localhost;user id=root;database=seproject;password=rootpassword");
        public Moderator()
        {
            InitializeComponent();
            
        }

      
        private void showButton_Click(object sender, EventArgs e)
        {
            
            try
            {
                sqlcon.Open();
                DataTable users = new DataTable();
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM seproject.user", sqlcon))
                {
                    MySqlDataReader reader = cmd.ExecuteReader();
                    users.Load(reader);
                }
                dataGridView1.DataSource = users;
                sqlcon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection error");
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            string username = usernameText.Text;
            int nr = Convert.ToInt32(coinsText.Text);
            try
            {
                sqlcon.Open();

                string Query = "update seproject.user set inGameCurrency = " + "'" + nr + "' where (username = '" + username + "');";
                MySqlCommand cmdInsert = new MySqlCommand(Query, sqlcon);
                MySqlDataReader reader = cmdInsert.ExecuteReader();
                MessageBox.Show("Saved");
                while (reader.Read())
                { }
                sqlcon.Close();
                usernameText.Text = "";
                coinsText.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Insertion failed");
            }
           
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            string username = usernameText.Text;
            sqlcon.Open();
            string Query = "delete from seproject.user where (username ='" + username + "');";
            MySqlCommand cmdDelete = new MySqlCommand(Query, sqlcon);
            MySqlDataReader reader;
            try
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    //Application.Exit();
                    reader = cmdDelete.ExecuteReader();
                    MessageBox.Show("Deleted");
                    while (reader.Read())
                    {
                    }
                }
                else
                {
                    //e.Cancel = true;
                }
                
                sqlcon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Deletion failed");
            }
            usernameText.Text = "";
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.ShowDialog();
        }

        private void Moderator_FormClosing(object sender, FormClosingEventArgs e)
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
