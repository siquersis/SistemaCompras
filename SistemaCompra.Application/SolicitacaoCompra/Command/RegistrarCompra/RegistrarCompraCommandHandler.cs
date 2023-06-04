using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SistemaCompra.Domain.ProdutoAggregate;
using SistemaCompra.Domain.SolicitacaoCompraAggregate;
using SistemaCompra.Infra.Data.UoW;
using SolicitacaoAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra
{
    public class RegistrarCompraCommandHandler : CommandHandler, IRequestHandler<RegistrarCompraCommand, bool>
    {
        private readonly SolicitacaoAgg.ISolicitacaoCompraRepository _solicitacaoRepository;
        private readonly IProdutoRepository _produtoRepository;
        public RegistrarCompraCommandHandler(SolicitacaoAgg.ISolicitacaoCompraRepository solicitacaoRepository,
            IProdutoRepository produtoRepository,
            IUnitOfWork uow,
            IMediator mediator
            ) : base(uow, mediator)
        {
            this._solicitacaoRepository = solicitacaoRepository;
            _produtoRepository = produtoRepository;
        }

        public Task<bool> Handle(RegistrarCompraCommand request, CancellationToken cancellationToken)
        {
            var solicitacaoCompra = new SolicitacaoAgg.SolicitacaoCompra(request.UsuarioSolicitante, request.NomeFornecedor);

            foreach (var item in request.Item)
            {
                var produto = _produtoRepository.Obter(item.ProdutoId);

                if (produto != null)
                    solicitacaoCompra.AdicionarItem(produto, item.Quantidade);
            }
            solicitacaoCompra.CalculaTotalGeral();

            _solicitacaoRepository.RegistrarCompra(solicitacaoCompra);

            Commit();
            PublishEvents(solicitacaoCompra.Events);

            return Task.FromResult(true);
        }
    }
}