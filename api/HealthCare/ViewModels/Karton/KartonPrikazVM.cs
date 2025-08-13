namespace HealthCare.ViewModels.Karton
{
    public class KartonPrikazVM
    {
        public string pacijentId { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public string datum_rodenja { get; set; }
        public string mjesto_rodenja { get; set; }
        public string email { get; set; }
        public string brojTelefona { get; set; }
        public byte[]? slika_korisnika { get; set; }

        public ZdravstvenaLegitimacijaVM zdravstvenaLegitimacija { get; set; }
        public KartonPacijentaVM karton { get; set; }

    }
}
