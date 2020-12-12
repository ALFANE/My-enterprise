using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace diplom
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            String regLogin = textBox1.Text;
            String regPass = textBox2.Text;
            String regREPass = textBox3.Text;

            if (regLogin == "")
            {

                MessageBox.Show("Введіть логін.");
                return;
            }

            if (regPass == "")
            {

                MessageBox.Show("Введіть пароль.");
                return;
            }

            regLogin = regLogin.Trim();
            regPass = regPass.Trim();
            regREPass = regREPass.Trim();
            regLogin = regLogin.Replace(" ", "");
            regPass = regPass.Replace(" ", "");
            regREPass = regREPass.Replace(" ", "");

            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-OOL2QO2\;Initial Catalog=diplom;Integrated Security=True");

            if (regPass == regREPass)
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                connection.Open();

                SqlCommand register = new SqlCommand("SELECT * FROM [Authorization] WHERE [Login] = '" + regLogin + "';", connection);
                DataTable table = new DataTable();
                adapter.SelectCommand = register;
                adapter.Fill(table);
                if (table.Rows.Count == 0)
                {
                    if(comboBox1.SelectedIndex==0)
                    {
                        String commandText = "INSERT INTO [Authorization] (Login, Password, Відділ) VALUES ('" + regLogin + "', '" + regPass + "', @Відділ)";

                        SqlCommand command = new SqlCommand(commandText, connection);
                        command.Parameters.AddWithValue("Відділ", "Директор");


                        if (command.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Ви успішно зареєструвалися.");
                            Form1 form1 = new Form1();
                            this.Hide();
                            form1.Show();

                        }


                        connection.Close();
                    }
                    if (comboBox1.SelectedIndex == 1)
                    {
                        String commandText = "INSERT INTO [Authorization] (Login, Password, Відділ) VALUES ('" + regLogin + "', '" + regPass + "', @Відділ)";

                        SqlCommand command = new SqlCommand(commandText, connection);
                        command.Parameters.AddWithValue("Відділ", "Відділ кадрів");


                        if (command.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Ви успішно зареєструвалися.");
                            Form1 form1 = new Form1();
                            this.Hide();
                            form1.Show();

                        }


                        connection.Close();
                    }
                    if (comboBox1.SelectedIndex == 2)
                    {
                        String commandText = "INSERT INTO [Authorization] (Login, Password, Відділ) VALUES ('" + regLogin + "', '" + regPass + "', @Відділ)";

                        SqlCommand command = new SqlCommand(commandText, connection);
                        command.Parameters.AddWithValue("Відділ", "Склад");


                        if (command.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Ви успішно зареєструвалися.");
                            Form1 form1 = new Form1();
                            this.Hide();
                            form1.Show();

                        }


                        connection.Close();
                    }
                    if(comboBox1.SelectedIndex==-1)
                    {
                        MessageBox.Show("Оберіть з якого ви відділу");
                    }
                }
                else
                {
                    MessageBox.Show("Такий аккаунт вже існує.");
                }
            }
            else
            {
                MessageBox.Show("Паролі не співпадають.");
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }
    }
}
