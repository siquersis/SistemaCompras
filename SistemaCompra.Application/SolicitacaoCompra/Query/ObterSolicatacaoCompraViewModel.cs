using SistemaCompra.Domain.Core.Model;
using SistemaCompra.Domain.SolicitacaoCompraAggregate;

using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaCompra.Application.SolicitacaoCompra.Query
{
    public class ObterSolicatacaoCompraViewModel
    {
        public string UsuarioSolicitante { get; set; }
        public string NomeFornecedor { get; set; }
        public string Itens { get; set; }
        public DateTime Data { get; set; }
        public decimal TotalGeral { get; set; }
        public string Situacao { get; set; }
    }
}
