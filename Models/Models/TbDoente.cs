using System;
using System.Collections.Generic;

namespace Models
{
    public class TbDoente
    {

        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public DateTime DataNascimento { get; set; } = DateTime.Now;
        public string Sexo { get; set; } = null!;

        public TbDoente()
        {
            Id = 0;
            Nome = "";
            DataNascimento = DateTime.Now;
            Sexo = "";
        }

    }
}
