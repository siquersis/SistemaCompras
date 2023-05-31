using SistemaCompra.Domain.Core;
using SistemaCompra.Domain.Core.Model;
using System;
using System.Collections.Generic;

namespace SistemaCompra.Domain.SolicitacaoCompraAggregate
{
    public class CondicaoPagamento : Entity
    {
        private IList<int> _valoresPossiveis = new List<int>() { 0, 30, 60, 90 };
        public int Valor { get; private set; }

        private CondicaoPagamento() { }

        public CondicaoPagamento(int condicao)
        {
            if (!_valoresPossiveis.Contains(condicao)) throw new BusinessRuleException("Condição de pagamento deve ser " + _valoresPossiveis.ToString());

            Valor = condicao;
        }
    }
}