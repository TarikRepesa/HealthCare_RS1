namespace HealthCare.ViewModels.Termin
{
    public class TerminGetByIdVM
    {
        public int terminId { get; set; }
        public DateTime pocetakPosjete { get; set; }
        public DateTime? krajPosjete { get; set; }
        public string vrsta { get; set; }
        public string prioritet { get; set; }

        //Pacijent podaci
        public string imePacijenta { get; set; }
        public string prezimePacijenta { get; set; }
        public DateTime datumRodenjaPacijenta { get; set; }
        public string mjestoRodenjaPacijenta { get; set; }
        public string brojTelefonaPacijenta { get; set; }
        public string emailPacijenta { get; set; }

        //Ambulanta podaci
        public string nazivAmbulante { get; set; }

        //Ljekar podaci
        public string imeLjekara { get; set; }
        public string prezimeLjekara { get; set; }
        public string brojTelefonaLjekara { get; set; }
        public string emailLjekara { get; set; }

    }
}
