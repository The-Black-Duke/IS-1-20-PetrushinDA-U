using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace IS_1_20_PetrushinDA_U
{
    public partial class Exercise3 : Form
    {
        public Exercise3()
        {
            InitializeComponent();
        }

        string connStr = "server=chuc.caseum.ru;port=33333;user=st_1_20_24;database=is_1_20_st24_KURS;password=83259142;";
        MySqlConnection conn;
        private void Exercise3_Load(object sender, EventArgs e)
        {
            conn = new MySqlConnection(connStr);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string sql = "SELECT id_console, title, `condition`, price, id_cl, fio, number, email FROM T_Console INNER JOIN T_client ON id_console = id_cl;";
                dataGridView1.Columns.Add("id_cl", "id клиента");
                dataGridView1.Columns["id_cl"].Width = 150;

                dataGridView1.Columns.Add("fio", "фио Клиента");
                dataGridView1.Columns["fio"].Width = 150;

                dataGridView1.Columns.Add("number", "Номер Клиента");
                dataGridView1.Columns["number"].Width = 150;

                dataGridView1.Columns.Add("email", "электронная почта");
                dataGridView1.Columns["email"].Width = 150;

                dataGridView1.Columns.Add("id_console", "id консоли");
                dataGridView1.Columns["id_console"].Width = 150;

                dataGridView1.Columns.Add("title", "название");
                dataGridView1.Columns["title"].Width = 150;

                dataGridView1.Columns.Add("condition", "состояние");
                dataGridView1.Columns["condition"].Width = 150;

                dataGridView1.Columns.Add("price", "цена");
                dataGridView1.Columns["price"].Width = 150;

                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader["id_cl"].ToString(), reader["fio"].ToString(), reader["number"].ToString(), reader["email"].ToString(), reader["id_console"].ToString(), reader["title"].ToString(), reader["condition"].ToString(), reader["price"].ToString());
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

        }
    }
}
