namespace HealthCare.ViewModels.Odjeljenje
{
    public class OdjeljenjeAddVM
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public int BrojOsoblja { get; set; }
        public string Vrsta { get; set; }
        public int BolnicaId { get; set; }
    }
}
