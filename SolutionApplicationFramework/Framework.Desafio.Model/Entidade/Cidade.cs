using System.ComponentModel;

namespace Framework.Desafio.Model.Entidade
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
