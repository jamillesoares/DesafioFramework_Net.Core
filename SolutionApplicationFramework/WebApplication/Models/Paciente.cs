using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        [DisplayName("País")]
        public int PaisId { get; set; }
        [DisplayName("Estado")]
        public int EstadoId { get; set; }
        [DisplayName("Cidade")]
        public int CidadeId { get; set; }
        [DisplayName("País")]
        public virtual Pais Pais { get; set; }
        public virtual Estado Estado { get; set; }
        public virtual Cidade Cidade { get; set; }

    }
}
