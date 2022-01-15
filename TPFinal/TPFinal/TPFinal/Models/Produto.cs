using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TPFinal.Models
{
    public class Produto
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public String Nome { get; set; }
        public float Peso { get; set; }
        public String Produtor { get; set; }
        public String Email { get; set; }
        public int NCM { get; set; }
    }
}
