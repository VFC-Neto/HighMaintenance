namespace HighMaintenance.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("INVESTIDOR")]
    public partial class INVESTIDOR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public INVESTIDOR()
        {
            APPXINVESTIDOR = new HashSet<APPXINVESTIDOR>();
            BENS = new HashSet<BENS>();
            INVESTIDORXUSER = new HashSet<INVESTIDORXUSER>();
        }

        [Key]
        public int INV_ID { get; set; }

        [StringLength(100)]

        [Display(Name = "Nome investidor")]
        public string INV_NOME { get; set; }

        [StringLength(20)]

        [Display(Name = "Cpf")]
        public string INV_CPF { get; set; }

        [StringLength(10)]

        [Display(Name = "Rg")]
        public string INV_RG { get; set; }

        [Display(Name = "Nascimento")]
        public DateTime? INV_NASCIMENTO { get; set; }

        [StringLength(10)]
        [Display(Name = "Telefone")]
        public string INV_TELEFONE { get; set; }

        [StringLength(10)]
        [Display(Name = "Celular")]
        public string INV_CELULAR { get; set; }

        [StringLength(10)]
        [Display(Name = "Cidade")]
        public string INV_CIDADE { get; set; }

        [StringLength(10)]
        [Display(Name = "Cep")]
        public string INV_CEP { get; set; }

        [StringLength(10)]
        [Display(Name = "Estado")]
        public string INV_ESTADO { get; set; }

        [StringLength(50)]
        [Display(Name = "Email")]
        public string INV_EMAIL { get; set; }

        [Display(Name = "Valor Geral")]
        public decimal? INV_VALORGERAL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<APPXINVESTIDOR> APPXINVESTIDOR { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BENS> BENS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INVESTIDORXUSER> INVESTIDORXUSER { get; set; }
    }
}
