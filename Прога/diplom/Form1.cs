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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
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
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            String loginUser = textBox1.Text;
            String passUser = textBox2.Text;

            loginUser = loginUser.Trim();
            passUser = passUser.Trim();
            loginUser = loginUser.Replace(" ", "");
            passUser = passUser.Replace(" ", "");

            DataTable table = new DataTable();

            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-OOL2QO2\;Initial Catalog=diplom;Integrated Security=True");

            String commandText = "SELECT * FROM [Authorization] WHERE [Login] = '" + loginUser + "' AND [Password] = '" + passUser + "'";

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand(commandText, conn);

            conn.Open();
            string otdel = "";
            adapter.SelectCommand = command;
            adapter.Fill(table);
            SqlDataReader sqlReader = null;
            try
            {
                sqlReader = command.ExecuteReader();
                while(sqlReader.Read())
                {
                    otdel = Convert.ToString(sqlReader["Відділ"]);
                }
                
            }
            catch { }

            if (table.Rows.Count == 1)
            {
                if(otdel=="Директор")
                {
                    Form2 form2 = new Form2();
                    this.Hide();
                    form2.Show();
                }
                if(otdel=="Відділ кадрів")
                {
                    Form3 frm3 = new Form3();
                    frm3.Show();
                    this.Hide();
                }
                if(otdel=="Склад")
                {
                    Form4 frm4 = new Form4();
                    frm4.Show();
                    this.Hide();
                }

            }
            else
            {
                MessageBox.Show("Ошибка! Зарегистрирован больше чем один пользователь с таким логином или ваш логин недействителен.");
            }
            conn.Close();
        }



        private void Button3_Click_1(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
           // this.Hide();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.Show();
            //this.Hide();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();
            frm4.Show();
           // this.Hide();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            this.Hide();
            form5.Show();
        }
    }
}
