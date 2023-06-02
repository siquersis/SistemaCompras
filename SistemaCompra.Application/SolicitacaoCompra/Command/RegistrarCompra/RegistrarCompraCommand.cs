using System;
using System.Collections.Generic;
using MediatR;
using SistemaCompra.Domain.Core.Model;
using SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra
{
    public class RegistrarCompraCommand : IRequest<bool>
    {
        public string NomeFornecedor { get; set; }
        public string UsuarioSolicitante { get; set; }
        public decimal TotalGeral { get; set; }
    }
}