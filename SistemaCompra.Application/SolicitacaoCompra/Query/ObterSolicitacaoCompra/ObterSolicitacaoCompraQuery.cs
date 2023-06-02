using System;
using MediatR;
using SistemaCompra.Application.Produto.Query.ObterProduto;

namespace SistemaCompra.Application.SolicitacaoCompra.Query.ObterSolicitacaoCompra
{
    public class ObterSolicitacaoCompraQuery : IRequest<ObterSolicitacaoCompraViewModel>
    {
        public Guid Id { get; set; }
    }
}