using System.Data.Entity;

namespace HighMaintenance.Models
{
    public partial class ENTIDADES : DbContext
    {
        public ENTIDADES()
            : base("name=ModeloDeDados")
        {
        }

        public virtual DbSet<APLICACOES> APLICACOES { get; set; }
        public virtual DbSet<APPXINVESTIDOR> APPXINVESTIDOR { get; set; }
        public virtual DbSet<BENS> BENS { get; set; }
        public virtual DbSet<INVESTIDOR> INVESTIDOR { get; set; }
        public virtual DbSet<INVESTIDORXUSER> INVESTIDORXUSER { get; set; }
        public virtual DbSet<USUARIO> USUARIO { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<APLICACOES>()
                .Property(e => e.APP_NOME)
                .IsUnicode(false);

            modelBuilder.Entity<APLICACOES>()
                .Property(e => e.APP_DESCRICAO)
                .IsUnicode(false);

            modelBuilder.Entity<APLICACOES>()
                .Property(e => e.APP_TIPO)
                .IsUnicode(false);

            modelBuilder.Entity<APLICACOES>()
                .Property(e => e.APP_VALIDADE)
                .IsUnicode(false);

            modelBuilder.Entity<APLICACOES>()
                .Property(e => e.APP_RENTABILIDADE)
                .IsUnicode(false);

            modelBuilder.Entity<APLICACOES>()
                .Property(e => e.APP_VALORMINIMO)
                .HasPrecision(10, 2);

            modelBuilder.Entity<APLICACOES>()
                .Property(e => e.APP_VALORMAXIMO)
                .HasPrecision(10, 2);

            modelBuilder.Entity<APPXINVESTIDOR>()
                .Property(e => e.APPIN_VALORINVESTIDO)
                .HasPrecision(10, 2);

            modelBuilder.Entity<APPXINVESTIDOR>()
                .Property(e => e.APPIN_VALORRETIRADO)
                .HasPrecision(10, 2);

            modelBuilder.Entity<BENS>()
                .Property(e => e.BENS_NOME)
                .IsUnicode(false);

            modelBuilder.Entity<BENS>()
                .Property(e => e.BENS_TIPO)
                .IsUnicode(false);

          modelBuilder.Entity<BENS>()
                .Property(e => e.BENS_VALOR)
                .HasPrecision(10, 2);

            modelBuilder.Entity<BENS>()
                .Property(e => e.BENS_DESCRICAO)
                .IsUnicode(false);

            modelBuilder.Entity<INVESTIDOR>()
                .Property(e => e.INV_NOME)
                .IsUnicode(false);

            modelBuilder.Entity<INVESTIDOR>()
                .Property(e => e.INV_CPF)
                .IsUnicode(false);

            modelBuilder.Entity<INVESTIDOR>()
                .Property(e => e.INV_RG)
                .IsUnicode(false);

            modelBuilder.Entity<INVESTIDOR>()
                .Property(e => e.INV_TELEFONE)
                .IsUnicode(false);

            modelBuilder.Entity<INVESTIDOR>()
                .Property(e => e.INV_CELULAR)
                .IsUnicode(false);

            modelBuilder.Entity<INVESTIDOR>()
                .Property(e => e.INV_CIDADE)
                .IsUnicode(false);

            modelBuilder.Entity<INVESTIDOR>()
                .Property(e => e.INV_CEP)
                .IsUnicode(false);

            modelBuilder.Entity<INVESTIDOR>()
                .Property(e => e.INV_ESTADO)
                .IsUnicode(false);

            modelBuilder.Entity<INVESTIDOR>()
                .Property(e => e.INV_EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<INVESTIDOR>()
                .Property(e => e.INV_VALORGERAL)
                .HasPrecision(10, 2);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.USER_NOME)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.USER_SENHA)
                .IsUnicode(false);
        }
    }
}
