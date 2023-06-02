using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SistemaCompra.Domain.SolicitacaoCompraAggregate;
using SistemaCompra.Infra.Data.UoW;
using SolicitacaoAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra
{
    public class RegistrarCompraCommandHandler : CommandHandler, IRequestHandler<RegistrarCompraCommand, bool>
    {
        private readonly SolicitacaoAgg.ISolicitacaoCompraRepository _solicitacaoRepository;

        public RegistrarCompraCommandHandler(SolicitacaoAgg.ISolicitacaoCompraRepository solicitacaoRepository,
            IUnitOfWork uow,
            IMediator mediator
            ) : base(uow, mediator)
        {
            this._solicitacaoRepository = solicitacaoRepository;
        }

        public Task<bool> Handle(RegistrarCompraCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var solicitacaoCompra = new SolicitacaoAgg.SolicitacaoCompra(request.UsuarioSolicitante, request.NomeFornecedor);

                _solicitacaoRepository.RegistrarCompra(solicitacaoCompra);

                Commit();
                PublishEvents(solicitacaoCompra.Events);

                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                var errorMessage = ex.Message;
                return Task.FromResult(false);
            }
        }
    }
}

