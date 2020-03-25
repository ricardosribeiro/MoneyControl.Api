using MoneyControl.Domain.Enums;
using MoneyControl.Domain.Shared;
using System;
using System.Collections.Generic;

namespace MoneyControl.Domain.Entities
{
    public class Conta: Entity
    {
        public DateTime DataCadastro { get; set; }
        public Titular Titular { get; set; }
        public int Numero { get; set; }
        public int Agencia { get; set; }
        public string Banco { get; set; }
        public EContaTipo Tipo { get; set; }
        public IEnumerable<Lancamento> Lancamentos { get; set; }

    }
}
