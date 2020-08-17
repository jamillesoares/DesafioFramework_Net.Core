using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class Cidade
    {
        public int Id { get; set; }
        [DisplayName("Descrição")]
        public string Descricao { get; set; }
        [DisplayName("Estado")]
        public int EstadoId { get; set; }
        public virtual Estado Estado { get; set; }
    }
}
