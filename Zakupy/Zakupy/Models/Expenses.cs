using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zakupy.Models
{
    public class Expenses
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public static string Name { get; set; }
        public string Date { get; set; }
        public double Price { get; set; }
    
    }
}
