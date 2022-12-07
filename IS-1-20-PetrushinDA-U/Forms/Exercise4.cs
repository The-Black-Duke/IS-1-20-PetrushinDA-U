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
using ConnectDB;


namespace IS_1_20_PetrushinDA_U
{
    public partial class Exercise4 : Form
    {
        public Exercise4()
        {
            InitializeComponent();
        }

        MySqlConnection conn;
        Class1 connecting;

        private void Exercise4_Load(object sender, EventArgs e)
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
                string sql = $"SELECT Fio, Date_of_Birth FROM t_datatime";
                dataGridView1.Columns.Add("Fio", "ФИО");
                dataGridView1.Columns["Fio"].Width = 100;
                dataGridView1.Columns.Add("Date_of_Birth", "День рождения");
                dataGridView1.Columns["Date_of_Birth"].Width = 150;
                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) //ридер читает данные из бд
                {
                    dataGridView1.Rows.Add(reader["Fio"].ToString(), reader["Date_of_Birth"].ToString());

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

        private void button1_Click(object sender, EventArgs e)
        {
            select();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            conn.Open();
            int id = dataGridView1.SelectedCells[0].RowIndex + 1;
            string url = $"SELECT photoUrl FROM t_datatime WHERE ID = {id}";
            MySqlCommand com = new MySqlCommand(url, conn);
            string picture = com.ExecuteScalar().ToString(); 
            conn.Close();
            pictureBox1.ImageLocation = picture;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
