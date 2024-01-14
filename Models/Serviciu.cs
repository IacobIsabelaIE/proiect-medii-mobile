using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ProiectMobile.Models
{
    public class Serviciu
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string NumeServiciu { get; set; }
        public string DescriereServiciu { get; set; }
        public int PretServiciu { get; set; }
        public DateTime DurataServiciu { get; set; }

    }
}
