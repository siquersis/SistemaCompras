using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SistemaCompra.Domain.SolicitacaoCompraAggregate;
using SistemaCompra.Infra.Data.Produto;
using SolicitacaoAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Application.SolicitacaoCompra.Query.ObterSolicitacaoCompra
{
    public class ObterSolicitacaoCompraQueryHandler : IRequestHandler<ObterSolicitacaoCompraQuery, ObterSolicitacaoCompraViewModel>
    {
        private readonly IMapper _mapper;
        private readonly ISolicitacaoCompraRepository _solicitacaoCompraRepository;

        public ObterSolicitacaoCompraQueryHandler(ISolicitacaoCompraRepository solicitacaoCompraRepository, IMapper mapper)
        {
            this._solicitacaoCompraRepository = solicitacaoCompraRepository;
            this._mapper = mapper;
        }

        public Task<ObterSolicitacaoCompraViewModel> Handle(ObterSolicitacaoCompraQuery request, CancellationToken cancellationToken)
        {
            var solicitacaoCompra = _solicitacaoCompraRepository.Obter(request.Id);

            var solicitacaoViewModel = _mapper.Map<ObterSolicitacaoCompraViewModel>(solicitacaoCompra);

            return Task.FromResult(solicitacaoViewModel);
        }
    }
}

