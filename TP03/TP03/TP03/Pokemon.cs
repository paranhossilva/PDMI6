using System;
using System.Collections.Generic;
using System.Text;

namespace TP03
{
    class Pokemon
    {
        public int id { get; set; }
        public String name { get; set; }
        public List<object> types { get; set; }
        public float weight { get; set; }
        public float height { get; set; }
    }

    public class type
    {
        public string name { get; set; }
    }

    public class root
    {
        public type type { get; set; }
    }

    class Contexto
    {
        public String id { get; set; }
        public String nome { get; set; }
        public String tipo { get; set; }
        public String peso { get; set; }
        public String altura { get; set; }

        public String url { get; set; }
    }
}
