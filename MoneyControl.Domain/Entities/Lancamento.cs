using MoneyControl.Domain.Enums;
using MoneyControl.Domain.Shared;
using System;

namespace MoneyControl.Domain.Entities
{
    public class Lancamento: Entity
    {
        public DateTime DataCadastro { get; set; }
        public decimal Valor { get; set; }
        public ELancamentoTipo Tipo { get; set; }
        public Guid ContaId { get; set; }

    }
}
