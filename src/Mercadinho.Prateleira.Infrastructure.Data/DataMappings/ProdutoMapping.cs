using Mercadinho.Prateleira.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercadinho.Prateleira.Infrastructure.Data.DataMappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("PRODUTO")//Nome da tabela
                 .HasOne(n => n.Estoque)//Tabela de produto pode ter um estoque (Relacionamento)
                 .WithOne(n => n.Produto)//E o estoque tem um produto
                 .OnDelete(DeleteBehavior.Cascade)//No caso de deletar um produto, deleta também um estoque
                 .HasForeignKey<Estoque>(f => f.ProdutoId);//Produto será refernciado por uma FireingKey

            builder.HasMany(n => n.Categorias)//Relacionamento será um N pra N com categoria
                .WithMany(n => n.Produtos);//E a categoria tem uma coleção de produtos

            builder.Property(p => p.Id)
                .HasColumnName("ID")//Nome da coluna
                .UseIdentityColumn();//Auto-incremento

            builder.Property(p => p.Descricao)
                .HasColumnName("DESCRICAO")//Nome da coluna descrição
                .HasColumnType("varchar")//Tipo da columa
                .HasMaxLength(300)//Tamanho máximo de 300 caracteres
                .IsRequired();//De ocorrência obrigatória

        }
    }
}
