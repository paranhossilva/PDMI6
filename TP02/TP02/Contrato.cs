using System;
using System.Collections.Generic;
using System.Text;

namespace TP02
{
    class Contrato
    {
        public String Nome { get; set; }
        public int Idade { get; set; }
        public String Profissao { get; set; }
        public String Pais { get; set; }

        public override String ToString()
        {
            return Nome;
        }
    }
}
