using MoneyControl.Domain.Shared;
using System;
namespace MoneyControl.Domain.Entities
{
    public class Titular: Entity
    {
        public DateTime DataCadastro { get; set; }
        public string Nome { get; set; }
        public string ImagemUpload { get; set; }
        public string Imagem { get; set; }

    }
}
