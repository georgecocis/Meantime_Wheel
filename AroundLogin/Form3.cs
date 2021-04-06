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
    public partial class Form3 : Form
    {
        MySqlConnection sqlcon = new MySqlConnection(@"server=localhost;user id=root;database=seproject;password=rootpassword");
        public Form3()
        {
            InitializeComponent();
        }

        private void firstNameText_Enter(object sender, EventArgs e)
        {
            String firstName = firstNameText.Text;
            if(firstName.ToLower().Trim().Equals("first name"))
            {
                firstNameText.Text = "";
                firstNameText.ForeColor = Color.Black;
            }
        }

        private void firstNameText_Leave(object sender, EventArgs e)
        {
            String firstName = firstNameText.Text;
            if(firstName.ToLower().Trim().Equals("first name") || firstName.Trim().Equals(""))
            {
                firstNameText.Text = "first name";
                firstNameText.ForeColor = Color.DimGray;
            }
        }

        private void lastNameText_Enter(object sender, EventArgs e)
        {
            String lastName = lastNameText.Text;
            if (lastName.ToLower().Trim().Equals("last name"))
            {
                lastNameText.Text = "";
                lastNameText.ForeColor = Color.Black;
            }
        }

        private void lastNameText_Leave(object sender, EventArgs e)
        {
            String lastName = lastNameText.Text;
            if (lastName.ToLower().Trim().Equals("last name") || lastName.Trim().Equals(""))
            {
                lastNameText.Text = "last name";
                lastNameText.ForeColor = Color.DimGray;
            }
        }

        private void countryText_Enter(object sender, EventArgs e)
        {
            String country = countryText.Text;
            if (country.ToLower().Trim().Equals("country"))
            {
                countryText.Text = "";
                countryText.ForeColor = Color.Black;
            }
        }

        private void countryText_Leave(object sender, EventArgs e)
        {
            String country = countryText.Text;
            if (country.ToLower().Trim().Equals("country") || country.Trim().Equals(""))
            {
                countryText.Text = "country";
                countryText.ForeColor = Color.DimGray;
            }
        }

        private void emailText_Enter(object sender, EventArgs e)
        {
            String email = emailText.Text;
            if (email.ToLower().Trim().Equals("e-mail"))
            {
                emailText.Text = "";
                emailText.ForeColor = Color.Black;
            }
        }

        private void emailText_Leave(object sender, EventArgs e)
        {
            String email = emailText.Text;
            if (email.ToLower().Trim().Equals("e-mail") || email.Trim().Equals(""))
            {
                emailText.Text = "e-mail";
                emailText.ForeColor = Color.DimGray;
            }
        }

        private void phoneText_Enter(object sender, EventArgs e)
        {
            String phone = phoneText.Text;
            if (phone.ToLower().Trim().Equals("phone"))
            {
                phoneText.Text = "";
                phoneText.ForeColor = Color.Black;
            }
        }

        private void phoneText_Leave(object sender, EventArgs e)
        {
            String phone = phoneText.Text;
            if (phone.ToLower().Trim().Equals("phone") || phone.Trim().Equals(""))
            {
                phoneText.Text = "phone";
                phoneText.ForeColor = Color.DimGray;
            }
        }

        private void usernameText_Enter(object sender, EventArgs e)
        {
            String username = usernameText.Text;
            if (username.ToLower().Trim().Equals("username"))
            {
                usernameText.Text = "";
                usernameText.ForeColor = Color.Black;
            }
        }

        private void usernameText_Leave(object sender, EventArgs e)
        {
            String username = usernameText.Text;
            if (username.ToLower().Trim().Equals("username") || username.Trim().Equals(""))
            {
                usernameText.Text = "username";
                usernameText.ForeColor = Color.DimGray;
            }
        }

        private void passwordText_Enter(object sender, EventArgs e)
        {
            String password = passwordText.Text;
            if (password.ToLower().Trim().Equals("password"))
            {
                passwordText.Text = "";
                passwordText.UseSystemPasswordChar = true;
                passwordText.ForeColor = Color.Black;
            }
        }

        private void passwordText_Leave(object sender, EventArgs e)
        {
            String password = passwordText.Text;
            if (password.ToLower().Trim().Equals("password") || password.Trim().Equals(""))
            {
                passwordText.Text = "password";
                passwordText.UseSystemPasswordChar = false;
                passwordText.ForeColor = Color.DimGray;
            }
        }

        private void confirmText_Enter(object sender, EventArgs e)
        {
            String cpassword = confirmText.Text;
            if (cpassword.ToLower().Trim().Equals("confirm password"))
            {
                confirmText.Text = "";
                confirmText.UseSystemPasswordChar = true;
                confirmText.ForeColor = Color.Black;
            }
        }

        private void confirmText_Leave(object sender, EventArgs e)
        {
            String cpassword = confirmText.Text;
            if (cpassword.ToLower().Trim().Equals("confirm password") || cpassword.ToLower().Trim().Equals("password") || cpassword.Trim().Equals(""))
            {
                confirmText.Text = "confirm password";
                confirmText.UseSystemPasswordChar = false;
                confirmText.ForeColor = Color.DimGray;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            try
            {
                sqlcon.Open();
                string username = "Select username from seproject.user where username='" + usernameText.Text + "';";
                MySqlDataAdapter da = new MySqlDataAdapter(username, sqlcon);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Username already used");
                }
                else
                {
                    if (passwordText.Text == confirmText.Text )
                    {
                        string Query = "insert into seproject.user(first_name, last_name, country, `e-mail`, phone, username, password, inGameCurrency, realCurrency) values('" + this.firstNameText.Text + "','" + this.lastNameText.Text + "','" + this.countryText.Text + "','" + this.emailText.Text + "','" + this.phoneText.Text + "','" + this.usernameText.Text + "','" + this.passwordText.Text + "','" + 0 + "','" + 0 + "');";
                        MySqlCommand cmdInsert = new MySqlCommand(Query, sqlcon);
                        MySqlDataReader reader = cmdInsert.ExecuteReader();
                        MessageBox.Show("Saved");
                        Form1 f1 = new Form1();
                        this.Hide();
                        f1.ShowDialog();
                        
                        while (reader.Read())
                        { }
                        
                        firstNameText.Text = "first name";
                        firstNameText.ForeColor = Color.DimGray;
                        lastNameText.Text = "last name";
                        lastNameText.ForeColor = Color.DimGray;
                        countryText.Text = "country";
                        countryText.ForeColor = Color.DimGray;
                        emailText.Text = "e-mail";
                        emailText.ForeColor = Color.DimGray;
                        phoneText.Text = "phone";
                        phoneText.ForeColor = Color.DimGray;
                        usernameText.Text = "username";
                        usernameText.ForeColor = Color.DimGray;
                        passwordText.Text = "password";
                        passwordText.UseSystemPasswordChar = false;
                        passwordText.ForeColor = Color.DimGray;
                        confirmText.Text = "confirm password";
                        confirmText.UseSystemPasswordChar = false;
                        confirmText.ForeColor = Color.DimGray;

                    }
                    else
                    {
                        MessageBox.Show("Incorrect password");
                    }
                }
                sqlcon.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Insertion failed");
            }
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
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
