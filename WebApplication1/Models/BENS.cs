namespace HighMaintenance.Models
{
    using System.ComponentModel.DataAnnotations;

    public partial class BENS
    {
        [Key]

        public int BENS_ID { get; set; }

        [Display(Name = "Investidor")]
        public int? INV_ID { get; set; }

        [StringLength(100)]

        [Display(Name = "Nome do bem")]
        public string BENS_NOME { get; set; }

        [StringLength(100)]

        [Display(Name = "Tipo do Bem")]
        public string BENS_TIPO { get; set; }

        [StringLength(1000)]

        [Display(Name = "Descrição do bem")]
        public string BENS_DESCRICAO { get; set; }

        [Display(Name = "Valor do bem")]
        public decimal? BENS_VALOR { get; set; }

        public virtual INVESTIDOR INVESTIDOR { get; set; }
    }
}
