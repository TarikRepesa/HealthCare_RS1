using System.ComponentModel.DataAnnotations;

namespace HealthCare.ViewModels.Termin
{
    public class TerminUpdateVM
    {
        [Required(ErrorMessage = "Obavezno polje!")]
        public DateTime pocetakPosjete { get; set; }


        [Required(ErrorMessage = "Obavezno polje!")]
        public DateTime krajPosjete { get; set; }
    }
}
