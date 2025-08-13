using System.ComponentModel.DataAnnotations;

namespace HealthCare.Models
{
    public class ZdravstvenaLegitimacija
    {
        [Key]
        public int Id { get; set; }
        public string JMBG { get; set; }
        public DateTime DatumIzdavanja { get; set; }
        public string DopunskoOsiguranje { get; set; }
        public string SrodstvoOsiguranika { get; set; }

        public string PacijentId { get; set; }
        public Pacijent Pacijent { get; set; }
    }
}
