using System;
namespace SistemaCompra.Application.SolicitacaoCompra.Query.ObterSolicitacaoCompra
{
    public class ObterSolicitacaoCompraViewModel
    {

        public string CondicaoPagamento { get; set; }

        public string NomeFornecedor { get; set; }

        public string UsuarioSolicitante { get; set; }

        public decimal TotalGeral { get; set; }
    }
}

