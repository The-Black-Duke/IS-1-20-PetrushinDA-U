using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConnectDB;
using MySql.Data.MySqlClient;


namespace IS_1_20_PetrushinDA_U
{
    public partial class Exercise5 : Form
    {
        public Exercise5()
        {
            InitializeComponent();
        }

        MySqlConnection conn;
        Class1 connecting;

        private void Exercise5_Load(object sender, EventArgs e)
        {
            connecting = new Class1();
            connecting.Connecting();
            conn = new MySqlConnection(connecting.ConnStr);
        }
        private void select()
        {

            try
            {
                connecting = new Class1();
                connecting.Connecting();
                conn = new MySqlConnection(connecting.ConnStr);
                conn.Open();
                string sql = $"SELECT id_Stud, fio_Stud, datetime_Stud FROM t_Uchebka_Petrushin";
                dataGridView1.Columns.Add("id_Stud", "ID");
                dataGridView1.Columns["id_Stud"].Width = 51;
                dataGridView1.Columns.Add("fio_Stud", "ФИО");
                dataGridView1.Columns["fio_Stud"].Width = 150;
                dataGridView1.Columns.Add("datetime_Stud", "Дата");
                dataGridView1.Columns["datetime_Stud"].Width = 150;
                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) //ридер читает данные из бд
                {
                    dataGridView1.Rows.Add(reader["id_Stud"].ToString(), reader["fio_Stud"].ToString(), reader["datetime_Stud"].ToString());

                }
                reader.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBox1.Text; //фио берётся из текстбокса
                string datetimeStud = textBox2.Text;// дата берётся из текстбокса
                //DateTime date = DateTime.Now;//раскоментировать если нужна текущая дата
                conn.Open();
                string add =
                    $"INSERT INTO t_Uchebka_Petrushin(fio_Stud, datetime_Stud) " +
                    $"VALUES ('{name}', '{String.Format("{0:s}", datetimeStud)}');" +
                    $"SELECT id_Stud FROM t_Uchebka_Petrushin WHERE(id_Stud = LAST_INSERT_ID());";
                MySqlCommand command = new MySqlCommand(add, conn);
                command.ExecuteScalar();
                MessageBox.Show("Запись добавлена!");
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Данное поле обязательно!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message );
            }
            finally
            {
                conn.Close();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            select();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
