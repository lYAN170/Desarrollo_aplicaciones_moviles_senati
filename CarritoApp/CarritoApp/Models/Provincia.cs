using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritoApp.Models
{
    public class Provincia
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string NombreProvincia { get; set; }

      
        public int DepartamentoId { get; set; }

    }
}