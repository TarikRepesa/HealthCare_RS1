namespace HealthCare.ViewModels.Termin
{
    public class TerminiGetByLjekar
    {
        public int terminId { get; set; }
        public DateTime vrijemeOd { get; set; }
        public DateTime? vrijemeDo { get; set; }
        public string vrsta { get; set; }
        public string prioritet { get; set; }
        public string ime_pacijenta { get; set; }
        public string prezime_pacijenta { get; set; }
        public DateTime datumRodenja_pacijenta { get; set; }
        public string mjestoRodenja_pacijenta { get; set; }
    }
}
