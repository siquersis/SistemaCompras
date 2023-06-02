using SistemaCompra.Domain.Core;
using SistemaCompra.Domain.Core.Model;
using SistemaCompra.Domain.ProdutoAggregate.Events;
using System;

namespace SistemaCompra.Domain.ProdutoAggregate
{
    public class Produto : Entity
    {
        public Categoria Categoria { get; set; }
        public Money Preco { get; set; }
        public string Descricao { get; set; }
        public string Nome { get; set; }

        public Situacao Situacao { get; set; }

        private Produto() { }

        public Produto(string nome, string descricao, string categoria, decimal preco)
        {
            Id = Guid.NewGuid();
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
            Descricao = descricao ?? throw new ArgumentNullException(nameof(descricao));
            Preco = new Money(preco);
            Categoria = (Categoria)Enum.Parse(typeof(Categoria), categoria);
            Situacao = Situacao.Ativo;
        }

        public void Ativar()
        {
            Situacao = Situacao.Ativo;
        }

        public void Suspender()
        {
            Situacao = Situacao.Suspenso;
        }

        public void AtualizarPreco(decimal preco)
        {
            if (Situacao != Situacao.Ativo)
                throw new BusinessRuleException("Produto deve estar ativo!");

            Preco = new Money(preco);

            AddEvent(new PrecoAtualizadoEvent(Id, Preco.Value));
        }
    }
}
