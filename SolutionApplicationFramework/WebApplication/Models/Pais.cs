using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class Pais
    {
        public int Id { get; set; }
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

    }
}
