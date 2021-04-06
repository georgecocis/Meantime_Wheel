using MySql.Data.MySqlClient;
using SEProject.ActFourFolder;
using SEProject.ActThreeFolder;
using SEProject.AroundLogin;
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
    public partial class Form1 : Form
    {
        private string data;
        public Form1()
        {
            InitializeComponent();
            groupBox1.BackColor = Color.FromArgb(70, Color.LightBlue);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "User")
            {
                data = usernameTextBox.Text.ToString();
                ActThreePacman pac = new ActThreePacman(data);
                ActThree act3 = new ActThree(data);
                Form2 f2 = new Form2(data);
                WheelForm wh = new WheelForm(data);
                Form5 f5 = new Form5(data);
                ActFourMatchTheCards mat = new ActFourMatchTheCards(data);

                MySqlConnection sqlcon = new MySqlConnection(@"server=localhost;user id=root;database=seproject;password=rootpassword");

                try
                {
                    sqlcon.Open();
                    String username = usernameTextBox.Text;
                    String password = passwordTextBox.Text;

                    DataTable table = new DataTable();

                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM seproject.user WHERE username = '" + username + "' and password = '" + password + "'", sqlcon);

                    adapter.Fill(table);

                    //check if the username exists or not
                    if (table.Rows.Count > 0)
                    {
                        if (checkBox1.Checked == true)
                        {
                            MessageBox.Show("Successfully logged in!");
                            this.Hide();
                            Form2 f22 = new Form2(data);
                            f22.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Incorrect captcha!");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Incorrect username/password");
                        usernameTextBox.Text = "";
                        passwordTextBox.Text = "";
                    }
                    sqlcon.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Connection error");
                }
            }
            else if(comboBox1.Text == "Moderator")
            {
                MySqlConnection sqlcon = new MySqlConnection(@"server=localhost;user id=root;database=seproject;password=rootpassword");

                try
                {
                    sqlcon.Open();
                    String username = usernameTextBox.Text;
                    String password = passwordTextBox.Text;

                    DataTable table = new DataTable();

                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM seproject.moderator WHERE username = '" + username + "' and password = '" + password + "'", sqlcon);

                    adapter.Fill(table);

                    //check if the username exists or not
                    if (table.Rows.Count > 0)
                    {
                        if (checkBox1.Checked == true)
                        {
                            MessageBox.Show("Admin successfully logged in!");
                            this.Hide();
                            Moderator md = new Moderator();
                            md.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Incorrect captcha!");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Incorrect username/password");
                        usernameTextBox.Text = "";
                        passwordTextBox.Text = "";
                    }
                    sqlcon.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Connection error");
                }
            }
           
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form3 f3 = new Form3();
            f3.ShowDialog();
        }



        private void button2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
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
