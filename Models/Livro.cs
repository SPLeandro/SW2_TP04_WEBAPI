using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TP04_WEBAPI.Models
{
    public class Livro { 
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Autor { get; set; }
        public decimal Preco { get; set; }
    }
}
