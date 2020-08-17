using System.ComponentModel;

namespace Framework.Desafio.Model.Entidade
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
        [DisplayName("Estado")]
        public virtual Estado Estado { get; set; }
        [DisplayName("Cidade")]
        public virtual Cidade Cidade { get; set; }

    }
}
