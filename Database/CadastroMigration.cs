using aws_test.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace aws_test.Database
{
    public class CadastroMigration : BaseMigration
    {
        private readonly EntityTypeBuilder<Cadastro> Entity;

        public CadastroMigration(EntityTypeBuilder<Cadastro> entity)
        {
            this.Entity = entity;
        }

        internal override void Create()
        {
            Entity.ToTable("cadastro");
            Entity.HasKey(cadastro => cadastro.Id);
            Entity.Property(cadastro => cadastro.Idade).IsRequired();
            Entity.Property(cadastro => cadastro.Nome).IsRequired();
        }
    }
}