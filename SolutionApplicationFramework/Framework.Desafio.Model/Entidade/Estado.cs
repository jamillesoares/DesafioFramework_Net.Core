using System.ComponentModel;

namespace Framework.Desafio.Model.Entidade
{
    public class Estado
    {
        public int Id { get; set; }
        [DisplayName("Descrição")]
        public string Descricao { get; set; }
        [DisplayName("País")]
        public int PaisId { get; set; }
        [DisplayName("País")]
        public virtual Pais Pais { get; set; }

    }
}
