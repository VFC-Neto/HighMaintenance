namespace HighMaintenance.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("USUARIO")]
    public partial class USUARIO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USUARIO()
        {
            INVESTIDORXUSER = new HashSet<INVESTIDORXUSER>();
        }

        [Key]
        public int USER_ID { get; set; }

        [StringLength(100)]
        [Display(Name = "Nome do usuario")]
        public string USER_NOME { get; set; }

        [StringLength(20)]
        [Display(Name = "Senha do usuario")]
        public string USER_SENHA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INVESTIDORXUSER> INVESTIDORXUSER { get; set; }
    }
}
