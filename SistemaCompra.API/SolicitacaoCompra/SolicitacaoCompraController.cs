using MediatR;
using Microsoft.AspNetCore.Mvc;

using SistemaCompra.Application.Produto.Command.RegistrarProduto;
using SistemaCompra.Application.Produto.Query.ObterProduto;
using SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra;
using SistemaCompra.Application.SolicitacaoCompra.Query;

using System;

namespace SistemaCompra.API.SolicitacaoCompra
{
    public class SolicitacaoCompraController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SolicitacaoCompraController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet, Route("solicitacaocompra/{id}")]
        public IActionResult Obter(Guid id)
        {
            var query = new ObterSolicatacaoCompraQuery() { Id = id };
            var solicitacaoCompraViewModel = _mediator.Send(query);
            return Ok(solicitacaoCompraViewModel);
        }

        [HttpPost, Route("solicitacaocompra/cadastro")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult CadastrarProduto([FromBody] RegistrarSolicitacaoCompraCommand command)
        {
            _mediator.Send(command);
            return StatusCode(201);
        }
    }
}
