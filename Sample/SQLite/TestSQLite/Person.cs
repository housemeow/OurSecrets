using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSQLite
{
    public class Person
    {
        [SQLite.AutoIncrement, SQLite.PrimaryKey]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
