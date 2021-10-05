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
    public class EstoqueMapping : IEntityTypeConfiguration<Estoque>
    {
        public void Configure(EntityTypeBuilder<Estoque> builder)
        {
            builder.ToTable("ESTOQUE")//Nome da tabela
                .OwnsOne(n => n.InfoCompra)//Faz com que as propriedades da classe Qualitativo (infoCompra) sejam criadas em formato de coluna na tabela estoque
                .Property(p => p.PrecoUnidade)//Propridade com nome específico
                .HasColumnName("PRECO_UNITARIO")
                .HasPrecision(16, 4);//Com precisão de 4 casas decimais

            builder.OwnsOne(n => n.InfoCompra)
                .Property(p => p.Quantidade)
                .HasColumnName("QUATIDADE");

            builder.OwnsOne(n => n.InfoCompra)
                .Property(p => p.UnidadeMedida)
                .HasColumnName("UNIDADE_MEDIDA");//Vai criar como um campo inteiro por ser um Enumaration

            builder.HasOne(n => n.Produto)
                .WithOne(n => n.Estoque)
                .HasForeignKey<Estoque>(k => k.ProdutoId);
        }
    }
}
