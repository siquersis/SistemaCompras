using MediatR;
using System;

namespace SistemaCompra.Application.SolicitacaoCompra.Query
{
    public class ObterSolicatacaoCompraQuery : IRequest<ObterSolicatacaoCompraViewModel>
    {
        public Guid Id { get; set; }
    }
}
