namespace HighMaintenance.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class APLICACOES
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public APLICACOES()
        {
            APPXINVESTIDOR = new HashSet<APPXINVESTIDOR>();
        }

        [Key]
        public int APP_ID { get; set; }

        [StringLength(500)]
        [Display(Name = "Nome da aplica��o")]
        public string APP_NOME { get; set; }

        [StringLength(1000)]
        [Display(Name = "Descri��o da aplica��o")]
        public string APP_DESCRICAO { get; set; }

        [StringLength(100)]
        [Display(Name = "Tipo de aplica��o")]
        public string APP_TIPO { get; set; }

        [StringLength(100)]
        [Display(Name = "Validade da aplica��o")]
        public string APP_VALIDADE { get; set; }

        [StringLength(100)]
        [Display(Name = "Rentabilidade da aplica��o")]
        public string APP_RENTABILIDADE { get; set; }

        [Display(Name = "Valor M�nimo da aplica��o")]
        public decimal? APP_VALORMINIMO { get; set; }

        [Display(Name = "Valor M�ximo da aplica��o")]
        public decimal? APP_VALORMAXIMO { get; set; }

        [Display(Name = "Vencimento")]
        public DateTime? APP_VENCIMENTO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<APPXINVESTIDOR> APPXINVESTIDOR { get; set; }
    }
}
