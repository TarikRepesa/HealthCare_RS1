
namespace HealthCare.ViewModels.Uputnica
{
    public class UputnicaPrikazVM
    {
        public int uputnicaId { get; set; }
        public string odjeljenje { get; set; }
        public string odsjek { get; set; }
        public string dijagnoza { get; set; }
        public string datum_izdavanja { get; set; }
        public string datum_vazenja { get; set; }
        public string ljekarId { get; set; }
        public string izdaoLjekar { get; set; }
        public string specijalizacija_ljekara { get; set; }
        
        public string primjedba { get; set; }
        public List<string> sifreBolesti { get; set; }
        public List<int> sifreBolestiId { get; set; }
        public int odjeljenjeId { get; internal set; }
        public int odsjekId { get; internal set; }
    }
}
