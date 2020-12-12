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
    public partial class Form3 : Form
    {
        SqlConnection sqlConnection = null;
        SqlDataAdapter adapter1 = null;
        SqlDataAdapter adapter2 = null;
        SqlDataAdapter adapter3 = null;
        DataTable table1 = null;
        DataTable table2 = null;
        DataTable table3 = null;
        public Form3()
        {
            InitializeComponent();
        }

      

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                if (!string.IsNullOrEmpty(textBox15.Text) && !string.IsNullOrWhiteSpace(textBox15.Text) &&
                    !string.IsNullOrEmpty(textBox8.Text) && !string.IsNullOrWhiteSpace(textBox8.Text))
                {
                    SqlCommand command = new SqlCommand("UPDATE [Human_Resources_Department] SET [Посада]=@Посада WHERE [Номер]=@Номер", sqlConnection);
                    command.Parameters.AddWithValue("Номер", textBox15.Text);
                    command.Parameters.AddWithValue("Посада", textBox8.Text);
                    command.ExecuteNonQuery();
                    textBox15.Text = "";
                    textBox8.Text = "";

                }
                else
                {
                    MessageBox.Show("Введіть інформацію");
                }
            }
            if (comboBox2.SelectedIndex == 1)
            {
                if (!string.IsNullOrEmpty(textBox15.Text) && !string.IsNullOrWhiteSpace(textBox15.Text) &&
                    !string.IsNullOrEmpty(textBox8.Text) && !string.IsNullOrWhiteSpace(textBox8.Text))
                {
                    SqlCommand command = new SqlCommand("UPDATE [Human_Resources_Department] SET [Посада]=@Посада WHERE [ПІБ]=@ПІБ", sqlConnection);
                    command.Parameters.AddWithValue("ПІБ", textBox15.Text);
                    command.Parameters.AddWithValue("Посада", textBox8.Text);
                    command.ExecuteNonQuery();
                    textBox15.Text = "";
                    textBox8.Text = "";

                }
                else
                {
                    MessageBox.Show("Введіть інформацію");
                }
            }
            if (comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Введіть ознаку");
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
            string connectionString = @"Data Source=DESKTOP-OOL2QO2\;Initial Catalog=diplom;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            adapter1 = new SqlDataAdapter("SELECT * FROM[Human_Resources_Department]", sqlConnection);
            table1 = new DataTable();
            adapter1.Fill(table1);
            dataGridView1.DataSource = table1;
            adapter2 = new SqlDataAdapter("SELECT [Пріоритет], [Дата], [Текст наказу] FROM [Director orders] WHERE [Відділ]='Відділ кадрів'", sqlConnection);
            table2 = new DataTable();
            adapter2.Fill(table2);
            dataGridView2.DataSource = table2;
            adapter3 = new SqlDataAdapter("SELECT * FROM [Vacancies]", sqlConnection);
            table3 = new DataTable();
            adapter3.Fill(table3);
            dataGridView3.DataSource = table3;

        }



        private void DataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            table1.Clear();
            adapter1.Fill(table1);
            dataGridView1.DataSource = table1;
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
            {
                sqlConnection.Close();
            }
            Application.Exit();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text) &&
               !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) &&
               !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text)&&
               !string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox4.Text) &&
               !string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrWhiteSpace(textBox5.Text) &&
               !string.IsNullOrEmpty(textBox7.Text) && !string.IsNullOrWhiteSpace(textBox7.Text)&&
               !string.IsNullOrEmpty(textBox11.Text) && !string.IsNullOrWhiteSpace(textBox11.Text) &&
               !string.IsNullOrEmpty(textBox12.Text) && !string.IsNullOrWhiteSpace(textBox12.Text))
            {
                SqlCommand command = new SqlCommand("INSERT  [Human_Resources_Department] VALUES(@ПІБ,@Ставка,@Посада,@Сумісник,@Пенсіонер,@Дата_народження,@Дата_прийняття,@Стаж,@Освіта,@Спеціальність)", sqlConnection);
                command.Parameters.AddWithValue("ПІБ", textBox1.Text);
                command.Parameters.AddWithValue("Ставка", textBox3.Text);
                command.Parameters.AddWithValue("Посада", textBox2.Text);
                command.Parameters.AddWithValue("Сумісник", textBox4.Text);
                command.Parameters.AddWithValue("Пенсіонер", textBox5.Text);
                command.Parameters.AddWithValue("Дата_народження", dateTimePicker1.Value.Date);
                command.Parameters.AddWithValue("Дата_прийняття", dateTimePicker2.Value.Date);
                command.Parameters.AddWithValue("Стаж", textBox7.Text);
                command.Parameters.AddWithValue("Освіта", textBox11.Text);
                command.Parameters.AddWithValue("Спеціальність", textBox12.Text);
                command.ExecuteNonQuery();
                
                //очистка
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox7.Text = "";
                textBox11.Text = "";
                textBox12.Text = "";
            }
            else
            {
                MessageBox.Show("Заполните все поля");
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex==0)
            {
                if (!string.IsNullOrEmpty(textBox13.Text) && !string.IsNullOrWhiteSpace(textBox13.Text))
                {
                    SqlCommand command = new SqlCommand("DELETE FROM [Human_Resources_Department] WHERE [Номер]=@Номер", sqlConnection);
                    command.Parameters.AddWithValue("Номер", textBox13.Text);
                    command.ExecuteNonQuery();
                    textBox13.Text = "";

                }
                else
                {
                    MessageBox.Show("Введіть інформацію");
                }
            }
            if(comboBox1.SelectedIndex==1)
            {
                if (!string.IsNullOrEmpty(textBox13.Text) && !string.IsNullOrWhiteSpace(textBox13.Text))
                {
                    SqlCommand command = new SqlCommand("DELETE FROM [Human_Resources_Department] WHERE [ПІБ]=@ПІБ", sqlConnection);
                    command.Parameters.AddWithValue("ПІБ", textBox13.Text);
                    command.ExecuteNonQuery();
                    textBox13.Text = "";

                }
                else
                {
                    MessageBox.Show("Введіть інформацію");
                }
            }
            if(comboBox1.SelectedIndex==-1)
            {
                MessageBox.Show("Введіть ознаку");
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text) &&
               !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) &&
               !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text) &&
               !string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox4.Text) &&
               !string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrWhiteSpace(textBox5.Text) &&
               !string.IsNullOrEmpty(textBox7.Text) && !string.IsNullOrWhiteSpace(textBox7.Text) &&
               !string.IsNullOrEmpty(textBox11.Text) && !string.IsNullOrWhiteSpace(textBox11.Text) &&
               !string.IsNullOrEmpty(textBox12.Text) && !string.IsNullOrWhiteSpace(textBox12.Text))
            {
                SqlCommand command = new SqlCommand("UPDATE [Human_Resources_Department] SET [ПІБ]=@ПІБ, [Ставка]=@Ставка, [Посада]=@Посада, [Сумісник]=@Сумісник, [Пенсіонер]=@Пенсіонер, [Дата народження]=@Дата народження, [Дата прийняття]=@Дата_прийняття, [Стаж]=@Стаж, [Освіта]=@Освіта, [Спеціальність]=@Спеціальність WHERE [Номер]=@Номер", sqlConnection);
                command.Parameters.AddWithValue("Номер", textBox16.Text);
                command.Parameters.AddWithValue("ПІБ", textBox1.Text);
                command.Parameters.AddWithValue("Ставка", textBox3.Text);
                command.Parameters.AddWithValue("Посада", textBox2.Text);
                command.Parameters.AddWithValue("Сумісник", textBox4.Text);
                command.Parameters.AddWithValue("Пенсіонер", textBox5.Text);
                command.Parameters.AddWithValue("Дата_народження", dateTimePicker1.Value.Date);
                command.Parameters.AddWithValue("Дата_прийняття", dateTimePicker2.Value.Date);
                command.Parameters.AddWithValue("Стаж", textBox7.Text);
                command.Parameters.AddWithValue("Освіта", textBox11.Text);
                command.Parameters.AddWithValue("Спеціальність", textBox12.Text);
                command.ExecuteNonQuery();

                //очистка
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox7.Text = "";
                textBox11.Text = "";
                textBox12.Text = "";
                textBox16.Text = "";
            }
            else
            {
                MessageBox.Show("Заполните все поля");
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex == 0)
            {
                if (!string.IsNullOrEmpty(textBox14.Text) && !string.IsNullOrWhiteSpace(textBox14.Text) &&
                    !string.IsNullOrEmpty(textBox9.Text) && !string.IsNullOrWhiteSpace(textBox9.Text))
                {
                    SqlCommand command = new SqlCommand("UPDATE [Human_Resources_Department] SET [Ставка]=@Ставка WHERE [Номер]=@Номер", sqlConnection);
                    command.Parameters.AddWithValue("Номер", textBox14.Text);
                    command.Parameters.AddWithValue("Ставка", textBox9.Text);
                    command.ExecuteNonQuery();
                    textBox14.Text = "";
                    textBox9.Text = "";

                }
                else
                {
                    MessageBox.Show("Введіть інформацію");
                }
            }
            if (comboBox3.SelectedIndex == 1)
            {
                if (!string.IsNullOrEmpty(textBox14.Text) && !string.IsNullOrWhiteSpace(textBox14.Text) &&
                    !string.IsNullOrEmpty(textBox9.Text) && !string.IsNullOrWhiteSpace(textBox9.Text))
                {
                    SqlCommand command = new SqlCommand("UPDATE [Human_Resources_Department] SET [Ставка]=@Ставка WHERE [ПІБ]=@ПІБ", sqlConnection);
                    command.Parameters.AddWithValue("ПІБ", textBox14.Text);
                    command.Parameters.AddWithValue("Ставка", textBox9.Text);
                    command.ExecuteNonQuery();
                    textBox14.Text = "";
                    textBox9.Text = "";

                }
                else
                {
                    MessageBox.Show("Введіть інформацію");
                }
            }
            if (comboBox3.SelectedIndex == -1)
            {
                MessageBox.Show("Введіть ознаку");
            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox17.Text) && !string.IsNullOrWhiteSpace(textBox17.Text) &&
               !string.IsNullOrEmpty(textBox18.Text) && !string.IsNullOrWhiteSpace(textBox18.Text) )
            {
                SqlCommand command = new SqlCommand("INSERT  [Vacancies]  VALUES(@Посада, @Залишилося_місць, @Загальна_кількість_місць)", sqlConnection);
                command.Parameters.AddWithValue("Посада", textBox17.Text);
                command.Parameters.AddWithValue("Залишилося_місць", textBox18.Text);
                command.Parameters.AddWithValue("Загальна_кількість_місць", textBox18.Text);
                command.ExecuteNonQuery();

                //очистка
                textBox17.Text = "";
                textBox18.Text = "";
            }
            else
            {
                MessageBox.Show("Заполните все поля");
            }
        }

        private void DataGridView3_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //обьявляю таблицу
            DataTable tbl = new DataTable();
            //обьявляю масиив типа List
            List<string> vacancies = new List<string>();
            //обьявляю строку подключения
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-OOL2QO2\;Initial Catalog=diplom;Integrated Security=True");
            //открываю подключение
            con.Open();
            //с помощью адаптера заполняю таблицу
            SqlDataAdapter cmd = new SqlDataAdapter("SELECT [Посада] FROM [Vacancies] ORDER BY [Номер]", con);
            cmd.Fill(tbl);
            //запускаю цыкл до общего количества строк в таблице
            for (int r = 0; r < tbl.Rows.Count; r++)
            {
                //переменная для получения значения из текущей строки
                var temp = tbl.Rows[r];
                //преобразование строки в тип string
                string temp2 = temp.Field<string>("Посада");
                //добавляем посаду в массив
                vacancies.Add(temp2);
            }
            //обьявляю вторую таблицу
            DataTable tbl2 = new DataTable();
            //обьявляю третью таблицу
            DataTable tbl3 = new DataTable();
            //заполняю третью таблицу значенияли столбца Кількість місць
            using (var cmdTbl3 = new SqlDataAdapter("SELECT [Загальна кількість місць] FROM [Vacancies]", con))
            {
                cmdTbl3.Fill(tbl3);
            }
            int ra = 0;
            //цыкл для получения значений из массива типа List
            foreach (string i in vacancies)
            {
                //получаю значение из столбца Кількість місць по строке rа
                var countPlacestemp = tbl3.Rows[ra];
                //преобразовываю значение в int
                int countPlaces = countPlacestemp.Field<int>("Загальна кількість місць");
                //заполняю таблицу 2
                SqlDataAdapter adaptr = new SqlDataAdapter("SELECT [Посада] FROM [Human_Resources_Department] WHERE [Посада]='" + i + "'", con);
                adaptr.Fill(tbl2);
                //считаю количество сторок в таблице 2
                int countTbl2 = tbl2.Rows.Count;
                //считаю количество оставшихся мест
                var k = countPlaces - countTbl2;
                //обновляю таблицу в базе данных
                String queryText = "UPDATE [Vacancies] SET [Залишилося місць] =" + k + " WHERE [Посада]='" + i + "'";
                SqlCommand ex = new SqlCommand(queryText, con);
                ex.ExecuteNonQuery();
                //очищаю таблицу 2
                tbl2.Clear();
                //обнуляю значения что бы расчеты были верны
                countTbl2 = 0;
                k = 0;
                ra++;
            }
            //закрываю подключение
            con.Close();
            table3.Clear();
            adapter3.Fill(table3);
            dataGridView3.DataSource = table3;
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            if (comboBox4.SelectedIndex == 0)
            {
                if (!string.IsNullOrEmpty(textBox19.Text) && !string.IsNullOrWhiteSpace(textBox19.Text))
                {
                    SqlCommand command = new SqlCommand("DELETE FROM [Vacancies] WHERE [Номер]=@Номер", sqlConnection);
                    command.Parameters.AddWithValue("Номер", textBox19.Text);
                    command.ExecuteNonQuery();
                    textBox19.Text = "";

                }
                else
                {
                    MessageBox.Show("Введіть інформацію");
                }
            }
            if (comboBox4.SelectedIndex == 1)
            {
                if (!string.IsNullOrEmpty(textBox19.Text) && !string.IsNullOrWhiteSpace(textBox19.Text))
                {
                    SqlCommand command = new SqlCommand("DELETE FROM [Vacancies] WHERE [Посада]=@Посада", sqlConnection);
                    command.Parameters.AddWithValue("Посада", textBox19.Text);
                    command.ExecuteNonQuery();
                    textBox19.Text = "";

                }
                else
                {
                    MessageBox.Show("Введіть інформацію");
                }
            }
            if (comboBox4.SelectedIndex == -1)
            {
                MessageBox.Show("Введіть ознаку");
            }
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            if (comboBox5.SelectedIndex == 0)
            {
                if (!string.IsNullOrEmpty(textBox20.Text) && !string.IsNullOrWhiteSpace(textBox20.Text) &&
                    !string.IsNullOrEmpty(textBox21.Text) && !string.IsNullOrWhiteSpace(textBox21.Text))
                {
                    SqlCommand command = new SqlCommand("UPDATE [Vacancies] SET [Загальна кількість місць]=@Місця WHERE [Номер]=@Номер", sqlConnection);
                    command.Parameters.AddWithValue("Номер", textBox20.Text);
                    command.Parameters.AddWithValue("Місця", textBox21.Text);
                    command.ExecuteNonQuery();
                    textBox20.Text = "";
                    textBox21.Text = "";

                }
                else
                {
                    MessageBox.Show("Введіть інформацію");
                }
            }
            if (comboBox5.SelectedIndex == 1)
            {
                if (!string.IsNullOrEmpty(textBox20.Text) && !string.IsNullOrWhiteSpace(textBox20.Text) &&
                    !string.IsNullOrEmpty(textBox21.Text) && !string.IsNullOrWhiteSpace(textBox21.Text))
                {
                    SqlCommand command = new SqlCommand("UPDATE [Vacancies] SET [Загальна кількість місць]=@Місця WHERE [Посада]=@Посада", sqlConnection);
                    command.Parameters.AddWithValue("Посада", textBox20.Text);
                    command.Parameters.AddWithValue("Місця", textBox21.Text);
                    command.ExecuteNonQuery();
                    textBox20.Text = "";
                    textBox21.Text = "";

                }
                else
                {
                    MessageBox.Show("Введіть інформацію");
                }
            }
            if (comboBox5.SelectedIndex == -1)
            {
                MessageBox.Show("Введіть ознаку");
            }
        }

        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
            table2.Clear();
            adapter2.Fill(table2);
            dataGridView2.DataSource = table2;
        }
    }
}
