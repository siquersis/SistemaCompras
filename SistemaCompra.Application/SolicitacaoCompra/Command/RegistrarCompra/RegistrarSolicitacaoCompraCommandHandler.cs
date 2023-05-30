using MediatR;
using SistemaCompra.Application.Produto.Command.RegistrarProduto;


namespace SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra
{
    public class RegistrarSolicitacaoCompraCommandHandler : CommandHandler, 
                                                            IRequestHandler<RegistrarProdutoCommand, bool>
    {
        public RegistrarSolicitacaoCompraCommandHandler()
        {
            
        }

    }
}
