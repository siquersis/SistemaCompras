using AutoMapper;
using SistemaCompra.Application.Produto.Query.ObterProduto;
using SistemaCompra.Application.SolicitacaoCompra.Query.ObterSolicitacaoCompra;
using ProdutoAgg = SistemaCompra.Domain.ProdutoAggregate;
using SolicitacaoAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<ProdutoAgg.Produto, ObterProdutoViewModel>()
                .ForMember(d => d.Preco, o => o.MapFrom(src => src.Preco.Value));

            CreateMap<SolicitacaoAgg.SolicitacaoCompra, ObterSolicitacaoCompraViewModel>()
                .ForMember(dest => dest.NomeFornecedor, opt => opt.MapFrom(src => src.NomeFornecedor.Nome))
                .ForMember(dest => dest.UsuarioSolicitante, opt => opt.MapFrom(src => src.UsuarioSolicitante.Nome))
                .ForMember(dest => dest.CondicaoPagamento, opt => opt.MapFrom(src => src.CondicaoPagamento.Valor))
                .ForMember(dest => dest.TotalGeral, opt => opt.MapFrom(src => src.TotalGeral.Value))
                ;
        }
    }
}
