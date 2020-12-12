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

    public partial class Form4 : Form
    {
        SqlConnection sqlConnection = null;
        SqlDataAdapter adapter1 = null;
        SqlDataAdapter adapter2 = null;
        DataTable table1 = null;
        DataTable table2 = null;
        public Form4()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-OOL2QO2\;Initial Catalog=diplom;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            adapter1 = new SqlDataAdapter("SELECT * FROM[Storage]", sqlConnection);
            table1 = new DataTable();
            adapter1.Fill(table1);
            dataGridView1.DataSource = table1;
            adapter2 = new SqlDataAdapter("SELECT Пріоритет, Дата, [Текст наказу] FROM [Director orders] WHERE [Відділ]='Склад'", sqlConnection);
            table2 = new DataTable();
            adapter2.Fill(table2);
            dataGridView2.DataSource = table2;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text) &&
               !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) &&
               !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text) &&
               !string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox4.Text) &&
               !string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrWhiteSpace(textBox5.Text) &&
               !string.IsNullOrEmpty(textBox6.Text) && !string.IsNullOrWhiteSpace(textBox6.Text))
            {
                SqlCommand command = new SqlCommand("INSERT  [Storage] VALUES(@Назва,@Номер,@Кількість,@Ціна_закупівлі,@Ціна_продажу,@Опис)", sqlConnection);
                command.Parameters.AddWithValue("Назва", textBox1.Text);
                command.Parameters.AddWithValue("Номер", textBox3.Text);
                command.Parameters.AddWithValue("Кількість", textBox2.Text);
                command.Parameters.AddWithValue("Ціна_закупівлі", textBox4.Text);
                command.Parameters.AddWithValue("Ціна_продажу", textBox5.Text);
                command.Parameters.AddWithValue("Опис", textBox6.Text);
                command.ExecuteNonQuery();

                //очистка
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
            }
            else
            {
                MessageBox.Show("Заполните все поля");
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text) &&
               !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) &&
               !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text) &&
               !string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox4.Text) &&
               !string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrWhiteSpace(textBox5.Text) &&
               !string.IsNullOrEmpty(textBox6.Text) && !string.IsNullOrWhiteSpace(textBox6.Text))
            {
                SqlCommand command = new SqlCommand("UPDATE [Storage] SET [Назва]=@Назва, [Кількість]=@Кількість, [Ціна закупівлі]=@Ціна_закупівлі, [Ціна продажу]=@Ціна_продажу, [Опис]=@Опис WHERE [Номер]=@Номер", sqlConnection);
                command.Parameters.AddWithValue("Назва", textBox1.Text);
                command.Parameters.AddWithValue("Номер", textBox3.Text);
                command.Parameters.AddWithValue("Кількість", textBox2.Text);
                command.Parameters.AddWithValue("Ціна_закупівлі", textBox4.Text);
                command.Parameters.AddWithValue("Ціна_продажу", textBox5.Text);
                command.Parameters.AddWithValue("Опис", textBox6.Text);
                command.ExecuteNonQuery();

                //очистка
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
            }
            else
            {
                MessageBox.Show("Заполните все поля");
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                if (!string.IsNullOrEmpty(textBox7.Text) && !string.IsNullOrWhiteSpace(textBox7.Text))
                {
                    SqlCommand command = new SqlCommand("DELETE FROM [Storage] WHERE [Назва]=@Назва", sqlConnection);
                    command.Parameters.AddWithValue("Назва", textBox7.Text);
                    command.ExecuteNonQuery();
                    textBox7.Text = "";

                }
                else
                {
                    MessageBox.Show("Введіть інформацію");
                }
            }
            if (comboBox1.SelectedIndex == 1)
            {
                if (!string.IsNullOrEmpty(textBox7.Text) && !string.IsNullOrWhiteSpace(textBox7.Text))
                {
                    SqlCommand command = new SqlCommand("DELETE FROM [Storage] WHERE [Номер]=@Номер", sqlConnection);
                    command.Parameters.AddWithValue("Номер", textBox7.Text);
                    command.ExecuteNonQuery();
                    textBox7.Text = "";

                }
                else
                {
                    MessageBox.Show("Введіть інформацію");
                }
            }
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Введіть ознаку");
            }
        }

        private void DataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            table1.Clear();
            adapter1.Fill(table1);
            dataGridView1.DataSource = table1;
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
            {
                sqlConnection.Close();
            }
            Application.Exit();
        }

        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
            table2.Clear();
            adapter2.Fill(table2);
            dataGridView2.DataSource = table2;
        }
    }
}
