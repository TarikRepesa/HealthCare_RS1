namespace HealthCare.ViewModels.Termin
{
    public class TerminGetAllVM
    {
        public int terminId { get; set; }
        public DateTime vrijemeOd { get; set; }
        public DateTime? vrijemeDo { get; set; }
        public string vrsta { get; set; }
        public string prioritet { get; set; }
        public string imePrezime_pacijenta { get; set; }
        public string datumRodenja_pacijenta { get; set; }
        public string mjestoRodenja_pacijenta { get; set; }
        public string brojTelefona_pacijenta { get; set; }
        public string naziv_ambulante { get; set; }
    }
}
