using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IS_1_20_PetrushinDA_U
{
    public partial class Exercise1 : Form
    {
        public abstract class Equipment<G> // Абстракный класс Коплектующие обобщенный  
        {
            public int Price;
            public int Year_of_realese;
            public G Artic;

            public Equipment(int price, int year_of_realese, G artic) // конструктор Коплектующих
            {
                this.Price = price;
                this.Year_of_realese = year_of_realese;
                this.Artic = artic;
            }
            public virtual void  Display() // метод дисплей
            {
                MessageBox.Show($"Цена:{Price},Год выпуска:{Year_of_realese},Артикул:{Artic}");
            }
        }

        class Harddrives<O> : Equipment<O> // Класс Жесткий диск наследует Коплектующие
        {
            protected int Turns;
            int Turn
            {
                get
                {
                    return Turns;
                }
                set
                {
                    Turns = value;
                }
            }
            protected string Interface;
            string inter
            {
                get
                {
                    return Interface;
                }
                set
                {
                    Interface = value;
                }
            }
            protected int volume;
            int vol
            {
                get
                {
                    return volume;
                }
                set
                {
                    volume = value;
                }
            }

            public Harddrives( int Price, int Year_of_realese, O Artic, int Turns, string Interface, int Volume)
                : base(Price, Year_of_realese, Artic) // конструктор Жеского диска
            {
                this.Turns = Turns;
                this.Interface = Interface;
                this.volume = Volume;
            }
            public override void Display() // метод дисплей
            {
                MessageBox.Show($"Цена: {Price}, Год выпуска: {Year_of_realese}, артикул: {Artic}, Количество: {Turns}, Интерфейс: {Interface}, Объем HDD: {volume}");
            }
        }
        class Videoscard<D> : Equipment<D> // Класс видеократы наследует Коплектующие
        {
            protected int gpu_frequency;
            int freq
            {
                get
                {
                    return gpu_frequency;
                }
                set
                {
                    gpu_frequency = value;
                }
            }
            protected string manuf;
            string manufa
            {
                get
                {
                    return manuf;
                }
                set
                {
                    manuf = value;
                }
            }

            protected int memory_size;
            int size
            {
                get
                {
                    return memory_size;
                }
                set
                {
                    memory_size = value;
                }
            }

            public Videoscard( int GPU_frequency, string manuf, int Memory_size, int Price, int Year_of_realese, D Artic)
                : base(Price, Year_of_realese, Artic) // конструктор Видеокарты
            {
                this.gpu_frequency = GPU_frequency;
                this.manuf = manuf;
                this.memory_size = Memory_size;
            }
            public override void Display() // метод дисплей
            {
                MessageBox.Show($"Цена: {Price}, Год выпуска: {Year_of_realese}, Артикул: {Artic}, Частота: {gpu_frequency}, Производитель: {manuf}, Объем памяти: {memory_size}гб.");
            }

        }

        public Exercise1()
        {
            InitializeComponent();
        }

        private void Exercise1_Load(object sender, EventArgs e)
        {

        }

        Harddrives<int> hdd;
        Videoscard<int> vc;
        private void button1_Click(object sender, EventArgs e)
        {
            {

                    int Price = Convert.ToInt32(textBox1.Text);
                    int year_of_realese = Convert.ToInt32(textBox2.Text);
                    int artic = Convert.ToInt32(textBox3.Text);
                    int Turns = Convert.ToInt32(textBox4.Text);
                    string Interface = textBox5.Text;
                    int Volume = Convert.ToInt32(textBox6.Text);
                    listBox1.Items.Clear();
                    listBox1.Items.Add($"Цена: {textBox1.Text}");
                    listBox1.Items.Add($"Год выпуска: {textBox2.Text}");
                    listBox1.Items.Add($"Артикул: {textBox3.Text}");
                    listBox1.Items.Add($"Количество оборотов: {textBox4.Text}");
                    listBox1.Items.Add($"Интерфейс: {textBox5.Text}");
                    listBox1.Items.Add($"Объем HDD: {textBox6.Text}");
                    hdd = new Harddrives<int>(Price, year_of_realese, artic, Turns, Interface, Volume);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            
                int Price = Convert.ToInt32(textBox1.Text);
                int year_of_realese = Convert.ToInt32(textBox2.Text);
                int gpu_frequency = Convert.ToInt32(textBox6.Text);
                string manuf = textBox7.Text;
                int Memory_size = Convert.ToInt32(textBox8.Text);
                int artic = Convert.ToInt32(textBox9.Text);
                listBox1.Items.Clear();
                listBox1.Items.Add($"Цена: {textBox1.Text}");
                listBox1.Items.Add($"Год выпуска: {textBox2.Text}");
                listBox1.Items.Add($"Артикул: {textBox3.Text}");
                listBox1.Items.Add($"Частота GPU: {textBox7.Text}");
                listBox1.Items.Add($"Производитель: {textBox8.Text}");
                listBox1.Items.Add($"Объем памяти: {textBox9.Text}");
                vc = new Videoscard<int>( gpu_frequency, manuf, Memory_size, Price, year_of_realese, artic);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
