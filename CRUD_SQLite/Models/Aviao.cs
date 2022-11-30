using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_SQLite.Models
{
    public class Aviao
    {
        public int AviaoId { get; set; }
        public string Fabricante { get; set; }
        public string Nome { get; set; }
        public int QuantidadePassageiros { get; set; }
    }
}
