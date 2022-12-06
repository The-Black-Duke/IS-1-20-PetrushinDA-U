using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IS_1_20_PetrushinDA_U
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Menu());
        }
       public class Connect
        {
            public string ConnStr;
            public string connection()// строка подключения
            {
                //return ConnStr = $"10.90.12.110;port=33333;user=uchebka;database=uchebka;password=uchebka;";
                return ConnStr = $"server=chuc.caseum.ru;port=33333;user=uchebka;database=uchebka;password=uchebka;";
            }
        }


    }
}
