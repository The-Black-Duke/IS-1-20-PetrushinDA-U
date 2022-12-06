using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace ConnectDB
{
    public class Class1
    {
        
        public string ConnStr;
        public string Connecting()// строка подключения
        {
            return ConnStr = $"server=chuc.caseum.ru;port=33333;user=st_1_20_24;database=is_1_20_st24_KURS;password=83259142;";
        }
    }
}
