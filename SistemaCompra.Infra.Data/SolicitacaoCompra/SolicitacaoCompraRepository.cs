using System;
using System.Linq;
using SolicitacaoAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Infra.Data.SolicitacaoCompra
{
    public class SolicitacaoCompraRepository : SolicitacaoAgg.ISolicitacaoCompraRepository
    {
        private readonly SistemaCompraContext context;

        public SolicitacaoCompraRepository(SistemaCompraContext context)
        {
            this.context = context;
        }

        public SolicitacaoAgg.SolicitacaoCompra Obter(Guid id)
        {
            return context.Set<SolicitacaoAgg.SolicitacaoCompra>()
                          .Where(c => c.Id == id).FirstOrDefault();
        }

        public void RegistrarCompra(SolicitacaoAgg.SolicitacaoCompra entity)
        {
            context.Set<SolicitacaoAgg.SolicitacaoCompra>().Add(entity);
        }
    }
}

