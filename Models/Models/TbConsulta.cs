using System;
using System.Collections.Generic;

namespace Models
{
    public class TbConsulta
    {
        public int Id { get; set; }
        public DateTime Data { get; set; } = DateTime.Now ;
        public string Especialidade { get; set; } = null!;
        
        //Uma consulta vai ter um doente, vai ser guardado o ID
        public int IdDoente { get; set; }

        

        public TbConsulta()
        {
            Id = 0;
            Data = DateTime.Now;
            Especialidade = "";
            IdDoente = 0;
            
        }

        
    }
}
