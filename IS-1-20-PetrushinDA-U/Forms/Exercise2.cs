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
    public partial class Exercise2 : Form
    {
        public Exercise2()
        {
            InitializeComponent();
        }

        public MySqlConnection conn;
        Connect MySql;
        class Connect
        {
            public string ConnStr;
            public string connection()// строка подключения
            {
                //return ConnStr = $"server=10.90.12.110;port=33333;user=uchebka;database=uchebka;password=uchebka;";
                return ConnStr = $"server=chuc.caseum.ru;port=33333;user=uchebka;database=uchebka;password=uchebka;";
            }
        }
        private void Exercise2_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MySql = new Connect();
                MySql.connection();
                conn = new MySqlConnection(MySql.ConnStr);
                conn.Open();
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка!" + ex.Message);
            }
            finally
            {
                MessageBox.Show("Подключение успешно!");
                conn.Close();
            }
        }
    }
}
