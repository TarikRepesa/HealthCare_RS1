namespace HealthCare.ViewModels.Tehnicar
{
    public class TehnicarPrikazVM
    {
        public string tehnicarId { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public string email { get; set; }
        public string brojTelefona { get; set; }
        public string specijalizacija { get; set; }
        public string kvalifikacija { get; set; }
        public byte[]? slika_korisnika { get; set; }
    }
}
