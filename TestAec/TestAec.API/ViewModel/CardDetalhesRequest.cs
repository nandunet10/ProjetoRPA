using System.Runtime.Serialization;

namespace TestAec.API.Requests
{
    public class CardDetalhesViewModel
    {
        [DataMember(Name = "cardId")]
        public Guid CardId { get; set; }

        [DataMember(Name = "titulo")]
        public string? Titulo { get; set; }

        [DataMember(Name = "area")]
        public string? Area { get; set; }

        [DataMember(Name = "autor")]
        public string? Autor { get; set; }

        [DataMember(Name = "descricao")]
        public string? Descricao { get; set; }

        [DataMember(Name = "dataPublicacao")]
        public DateTime DataPublicacao { get; set; }


    }
}
