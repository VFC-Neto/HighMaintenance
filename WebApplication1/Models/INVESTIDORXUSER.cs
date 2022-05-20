namespace HighMaintenance.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("INVESTIDORXUSER")]
    public partial class INVESTIDORXUSER
    {
        [Key]
        public int INVUS_ID { get; set; }

        [Display(Name = "Investidor")]
        public int? INV_ID { get; set; }

        [Display(Name = "Usuario")]
        public int? USER_ID { get; set; }

        [Display(Name = "Data do registro")]

        public DateTime? DATA_REGISTRO { get; set; }

        public virtual INVESTIDOR INVESTIDOR { get; set; }

        public virtual USUARIO USUARIO { get; set; }
    }
}
