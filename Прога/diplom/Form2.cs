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
    public partial class Form2 : Form
    {
        SqlConnection sqlConnection = null;
        SqlDataAdapter adapter1 = null;
        SqlDataAdapter adapter2 = null;
        SqlDataAdapter adapter3 = null;
        SqlDataAdapter adapter4 = null;
        DataTable table1 = null;
        DataTable table2 = null;
        DataTable table3 = null;
        DataTable table4 = null;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-OOL2QO2\;Initial Catalog=diplom;Integrated Security=True";//рядок з'єднання
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();// відкривається з'єднання
            //Звітність складу
            adapter1 = new SqlDataAdapter("SELECT [Назва],[Номер],[Кількість],[Ціна закупівлі],[Ціна продажу] FROM[Storage]", sqlConnection); //посилання команди та отримання результату
            table1 = new DataTable();//нова таблиця даник
            adapter1.Fill(table1);//заповнення таблиці даних результатом запросу
            dataGridView1.DataSource = table1;//заповнення dataGridView1 вмістом таблиці даних
            //Зарплатная відомість
            adapter2 = new SqlDataAdapter("SELECT ПІБ,Ставка,Надбавка,Зарплатня FROM[Human_Resources_Department]", sqlConnection);
            table2 = new DataTable();
            adapter2.Fill(table2);
            dataGridView2.DataSource = table2;
            //список робітників
            adapter3 = new SqlDataAdapter("SELECT ПІБ,Посада,[Дата народження],Стаж,Освіта,Спеціальність FROM[Human_Resources_Department]", sqlConnection);
            table3 = new DataTable();
            adapter3.Fill(table3);
            dataGridView3.DataSource = table3;
            //ваші накази
            adapter4 = new SqlDataAdapter("SELECT * FROM[Director orders]", sqlConnection);
            table4 = new DataTable();
            adapter4.Fill(table4);
            dataGridView5.DataSource = table4;

        }

       
       

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Введіть ознаку");
            }
            if (comboBox1.SelectedIndex!=-1)
            {
                if (!string.IsNullOrEmpty(Prioritet.Text) && !string.IsNullOrWhiteSpace(Prioritet.Text) &&
                   !string.IsNullOrEmpty(Order_text.Text) && !string.IsNullOrWhiteSpace(Order_text.Text))
                {
                    SqlCommand command = new SqlCommand("INSERT  [Director orders] VALUES(@Пріоритет,@Відділ,@Дата,@Текст_Наказу)", sqlConnection);
                    command.Parameters.AddWithValue("Пріоритет", Prioritet.Text);
                    command.Parameters.AddWithValue("Відділ", comboBox1.SelectedItem);
                    command.Parameters.AddWithValue("Дата", dateTimePicker1.Value.Date);
                    command.Parameters.AddWithValue("Текст_наказу", Order_text.Text);
                    command.ExecuteNonQuery();
                    Order_number.Text = "";
                    Prioritet.Text = "";
                    comboBox1.SelectedIndex = -1;
                    Data_prikaza.Text = "";
                    Order_text.Text = "";
                }
                else
                {
                    MessageBox.Show("Заполните все поля");
                }
            }
            

        }


        private void DataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            table1.Clear();
            adapter1.Fill(table1);
            dataGridView1.DataSource = table1;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
            {
                sqlConnection.Close();
            }
            Application.Exit();
        }

        private void DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            table2.Clear();
            adapter2.Fill(table2);
            dataGridView2.DataSource = table2;
        }

        private void DataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            table2.Clear();
            adapter2.Fill(table2);
            dataGridView2.DataSource = table2;
        }

        private void DataGridView3_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            table3.Clear();
            adapter3.Fill(table3);
            dataGridView3.DataSource = table3;
        }

        private void DataGridView5_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            table4.Clear();
            adapter4.Fill(table4);
            dataGridView5.DataSource = table4;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox6.Text) && !string.IsNullOrWhiteSpace(textBox6.Text))
            {
                SqlCommand command = new SqlCommand("DELETE FROM [Director orders] WHERE [Номер_наказу]=@Номер_наказу", sqlConnection);
                command.Parameters.AddWithValue("Номер_наказу", textBox6.Text);
                command.ExecuteNonQuery();
                textBox6.Text = "";

            }
            else
            {
                MessageBox.Show("Введіть номер наказу");
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Prioritet.Text) && !string.IsNullOrWhiteSpace(Prioritet.Text) &&
               !string.IsNullOrEmpty(Order_text.Text) && !string.IsNullOrWhiteSpace(Order_text.Text))
            {
                SqlCommand command = new SqlCommand("UPDATE [Director orders] SET [Пріоритет]=@Пріоритет, [Відділ]=@Відділ, [Дата]=@Дата, [Текст_наказу]=@Текст_наказу WHERE [Номер_наказу]=@Номер_наказу", sqlConnection);
                command.Parameters.AddWithValue("Номер_наказу", Order_number.Text);
                command.Parameters.AddWithValue("Пріоритет", Prioritet.Text);
                command.Parameters.AddWithValue("Відділ", comboBox1.SelectedItem);
                command.Parameters.AddWithValue("Дата", dateTimePicker1.Value.Date);
                command.Parameters.AddWithValue("Текст_наказу", Order_text.Text);
                command.ExecuteNonQuery();
                Order_number.Text = "";
                Prioritet.Text = "";
                comboBox1.SelectedIndex = -1;
                Order_text.Text = "";
            }
            else
            {
                MessageBox.Show("Заполните все поля");
            }
        }
    }
}
