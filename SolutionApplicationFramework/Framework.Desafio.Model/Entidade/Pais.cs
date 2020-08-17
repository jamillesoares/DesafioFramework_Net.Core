using System.ComponentModel;

namespace Framework.Desafio.Model.Entidade
{
    public class Pais
    {
        public int Id { get; set; }    
        [DisplayName("Descrição")]
        public string Descricao { get; set; }
    }
}
