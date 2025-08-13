using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HealthCare.ViewModels.Odjeljenje
{
    public class OdjeljenjeVM {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public int BrojOsoblja { get; set; }
        public string Vrsta { get; set; }
    }
}
