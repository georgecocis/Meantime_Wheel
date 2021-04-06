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
    public partial class Form6 : Form
    {
        int x = 0, score = 0, val = 0, sum = 0;
        public Form6(string a)
        {
            InitializeComponent();
            this.MyVal = a;
        }
        public string MyVal { get; set; }
        private void RefreshForm()
        {
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button1.Enabled = false;
            button5.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RefreshForm();
            switch (x)
            {
                case 1:
                    MessageBox.Show("Incorrect");
                    break;
                case 3:
                    MessageBox.Show("Incorrect");
                    break;
                case 5:
                    MessageBox.Show("Incorrect");
                    break;
                case 7:
                    MessageBox.Show("Incorrect");
                    break;
                case 9:
                    MessageBox.Show("Correct");
                    score++;
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RefreshForm();
            switch (x)
            {
                case 1:
                    MessageBox.Show("Incorrect");
                    break;
                case 3:
                    MessageBox.Show("Incorrect");
                    break;
                case 5:
                    MessageBox.Show("Incorrect");
                    break;
                case 7:
                    MessageBox.Show("Correct");
                    score++;
                    break;
                case 9:
                    MessageBox.Show("Incorrect");
                    break;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RefreshForm();
            switch (x)
            {
                case 1:
                    MessageBox.Show("Correct");
                    score++;
                    break;
                case 3:
                    MessageBox.Show("Incorrect");
                    break;
                case 5:
                    MessageBox.Show("Correct");
                    score++;
                    break;
                case 7:
                    MessageBox.Show("Incorrect");
                    break;
                case 9:
                    MessageBox.Show("Incorrect");
                    break;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RefreshForm();
            switch (x)
            {
                case 1:
                    MessageBox.Show("Incorrect");
                    break;
                case 3:
                    MessageBox.Show("Correct");
                    score++;
                    break;
                case 5:
                    MessageBox.Show("Incorrect");
                    break;
                case 7:
                    MessageBox.Show("Incorrect");
                    break;
                case 9:
                    MessageBox.Show("Incorrect");
                    break;
            }
        }

        private void ActSixLearning_FormClosing(object sender, FormClosingEventArgs e)
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

        private void answerBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button5.Enabled = true;
            switch (x)
            {
                case 2:  
                    if (answerBox.Text == "the home page" || answerBox.Text == "The home page" || answerBox.Text == "home page")
                    {
                       MessageBox.Show("Correct");
                       score++;
                       button6.Enabled = false;
                       button5.Enabled = true;
                       answerBox.Text = "";

                    }
                    else
                    {
                       MessageBox.Show("Incorrect");
                       button6.Enabled = false;
                       button5.Enabled = true;
                       answerBox.Text = "";
                    }                    
                    break;
                case 4:
                    if (answerBox.Text != "" && answerBox.Text == "Console.WriteLine('Hello world!')")
                    {
                        MessageBox.Show("Correct");
                        score++;
                        button6.Enabled = false;
                        button5.Enabled = true;
                        answerBox.Text = "";

                    }
                    else
                    {
                        MessageBox.Show("Incorrect");
                        button6.Enabled = false;
                        button5.Enabled = true;
                        answerBox.Text = "";
                    }
                    break;
                case 6:
                    if (answerBox.Text != "" && answerBox.Text == "the operating system" || answerBox.Text == "The operating system" || answerBox.Text == "operating system" || answerBox.Text == "OS")
                    {
                        MessageBox.Show("Correct");
                        score++;
                        button6.Enabled = false;
                        button5.Enabled = true;
                        answerBox.Text = "";

                    }
                    else
                    {
                        MessageBox.Show("Incorrect");
                        button6.Enabled = false;
                        button5.Enabled = true;
                        answerBox.Text = "";
                    }
                    break;
                case 8:
                    if (answerBox.Text != "" && answerBox.Text == "Browsers" || answerBox.Text == "browsers" )
                    {
                        MessageBox.Show("Correct");
                        score++;
                        button6.Enabled = false;
                        button5.Enabled = true;
                        answerBox.Text = "";

                    }
                    else
                    {
                        MessageBox.Show("Incorrect");
                        button6.Enabled = false;
                        button5.Enabled = true;
                        answerBox.Text = "";
                    }
                    break;
                case 10:
                    if (answerBox.Text == "alt+tab" || answerBox.Text == "alt + tab" || answerBox.Text == "alt+ tab" || answerBox.Text == "alt +tab" || answerBox.Text == "ALT+TAB" || answerBox.Text == "ALT + TAB" || answerBox.Text == "ALT+ TAB" || answerBox.Text == "ALT +TAB")
                    {
                        MessageBox.Show("Correct");
                        score++;
                        button6.Enabled = false;
                        button5.Enabled = true;
                        answerBox.Text = "";

                    }
                    else
                    {
                        MessageBox.Show("Incorrect");
                        button6.Enabled = false;
                        button5.Enabled = true;
                        answerBox.Text = "";
                    }
                    break;
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
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
                button5.Enabled = false;
                button5.Text = "Next Question";
                x++;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button1.Enabled = true;
                scoreLabel.Text = "Score:" + score.ToString();
            }
            switch (x)
            {
                case 1:
                    questionLabel1.Visible = true;
                    questionLabel2.Visible = true;
                    questionLabel1.Text = "The main function of the CPU is to perform arithmetic";
                    questionLabel2.Text=  "and logic operations on data taken from ____?";
                    button1.Text = "Permanent Memory";
                    button2.Text = "Control Unit";
                    button3.Text = "Main Memory";
                    button4.Text = "CPU";
                   
                    break;
                case 2:
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = false;
                    button1.Enabled = false;
                    completeQuestion1.Visible = true;
                    completeQuestion2.Visible = true;
                    completeQuestion1.Text = "What is the initial page of the";
                    completeQuestion2.Text =  "Web site?";
                    answerBox.Visible = true;
                    button6.Visible = true;               
                    break;
                case 3:
                    completeQuestion1.Visible = false;
                    completeQuestion2.Visible = false;
                    answerBox.Visible = false;
                    button6.Visible = false;
                    questionLabel1.Visible = true;
                    questionLabel2.Visible = false;
                    button2.Visible = true;
                    button3.Visible = true;
                    button4.Visible = true;
                    button1.Visible = true;
                    questionLabel1.Text = "What does computer RAM stand for?";
                    button1.Text = "Random Origin Money";
                    button2.Text = "Random Only Memory";
                    button3.Text = "Read Only Memory";
                    button4.Text = "Random Access Memory";                   
                    break;
                case 4:
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = false;
                    button1.Enabled = false;
                    completeQuestion1.Visible = true;
                    completeQuestion2.Visible = true;
                    completeQuestion1.Text = "Write the code for a simple";
                    completeQuestion2.Text = "'Hello world!' program in C#";
                    answerBox.Visible = true;
                    button6.Visible = true;
                    button6.Enabled = true;
                    break;
                case 5:
                    completeQuestion1.Visible = false;
                    completeQuestion2.Visible = false;
                    answerBox.Visible = false;
                    button6.Visible = false;
                    questionLabel1.Visible = true;
                    questionLabel2.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                    button4.Visible = true;
                    button1.Visible = true;
                    questionLabel1.Text = "Which ______ Program can be harmful ";
                    questionLabel2.Text = "to computer operations?";
                    button1.Text = "C-language";
                    button2.Text = "Fortan";
                    button3.Text = "Virus";
                    button4.Text = "None";
                    break;
                case 6:
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = false;
                    button1.Enabled = false;
                    completeQuestion1.Visible = true;
                    completeQuestion2.Visible = true;
                    completeQuestion1.Text = "Which is the special program that loads";
                    completeQuestion2.Text = "automatically when you start your computer? ";
                    answerBox.Visible = true;
                    button6.Visible = true;
                    button6.Enabled = true;
                
                    break;
                case 7:
                    completeQuestion1.Visible = false;
                    completeQuestion2.Visible = false;
                    answerBox.Visible = false;
                    button6.Visible = false;
                    questionLabel1.Visible = true;
                    questionLabel2.Visible = false;
                    button2.Visible = true;
                    button3.Visible = true;
                    button4.Visible = true;
                    button1.Visible = true;
                    questionLabel1.Text = "The Computer System consists of:";
                    button1.Text = "Peripheral devices";
                    button2.Text = "All of these";
                    button3.Text = "Internal devices";
                    button4.Text = "Software";
                    break;
                case 8:
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = false;
                    button1.Enabled = false;
                    completeQuestion1.Visible = true;
                    completeQuestion2.Visible = true;
                    completeQuestion1.Text = "The following softwares: Explorer, Firefox or";
                    completeQuestion2.Text = "Chrome are referred as:";
                    answerBox.Visible = true;
                    button6.Visible = true;
                    button6.Enabled = true;
                    
                    break;
                case 9:
                    completeQuestion1.Visible = false;
                    completeQuestion2.Visible = false;
                    answerBox.Visible = false;
                    button6.Visible = false;
                    questionLabel1.Visible = true;
                    questionLabel2.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                    button4.Visible = true;
                    button1.Visible = true;
                    questionLabel1.Text = "The process of transferring files from";
                    questionLabel2.Text = "the Internet to your PC is called?";
                    button1.Text = "Downloading";
                    button2.Text = "Forwarding";
                    button3.Text = "Uploading";
                    button4.Text = "None";
                    break;
                case 10:
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = false;
                    button1.Enabled = false;
                    completeQuestion1.Visible = true;
                    completeQuestion2.Visible = true;
                    completeQuestion1.Text = "Write the key combination needed in";
                    completeQuestion2.Text = "order to swicth tabs:";
                    answerBox.Visible = true;
                    button6.Visible = true;
                    button6.Enabled = true;
                    button5.Text = "Finish";
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
                    Form5 f5 = new Form5(MyVal);
                    f5.ShowDialog();
                    break;
            }
        }
    }
}
