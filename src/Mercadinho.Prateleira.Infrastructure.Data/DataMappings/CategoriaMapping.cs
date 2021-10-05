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
    public class CategoriaMapping : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("CATEGORIA");//Nome da tabela Categoria
            builder.Property(p => p.Id)//Tem uma coluna ID
                .HasColumnName("ID")
                .UseIdentityColumn();//Que é auto-incremento

            builder.Property(p => p.Descricao)
                .HasColumnName("DESCRICAO")//Tem uma coluna Descrição
                .HasColumnType("varchar")//Do tipo varchar
                .HasMaxLength(50)//Com 50 caracteres
                .IsRequired();//De ocorrência obrigatória
        }
    }
}
