using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritoApp.Models
{
    public class Departamento
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string NombreDepartamento { get; set; }
    }

}
