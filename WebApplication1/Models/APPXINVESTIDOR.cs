namespace HighMaintenance.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("APPXINVESTIDOR")]
    public partial class APPXINVESTIDOR
    {
        [Key]
        public int APPIN_ID { get; set; }

        [Display(Name = "Aplicação")]
        public int? APP_ID { get; set; }

        [Display(Name = "Investidor")]
        public int? INV_ID { get; set; }

        [Display(Name = "Valor investido")]
        public decimal APPIN_VALORINVESTIDO { get; set; }

        [Display(Name = "Rendimento")]
        public decimal? APPIN_VALORRETIRADO { get; set; }

        public virtual APLICACOES APLICACOES { get; set; }

        public virtual INVESTIDOR INVESTIDOR { get; set; }
    }
}
