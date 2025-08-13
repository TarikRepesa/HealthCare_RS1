namespace HealthCare.ViewModels.Asistent
{
    public class AsistentPrikazVM
    {
        public string asistentId { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public string email { get; set; }
        public string brojTelefona { get; set; }
        public string specijalizacija { get; set; }
        public string kvalifikacija { get; set; }
        public byte[]? slika_korisnika { get; set; }
    }
}
