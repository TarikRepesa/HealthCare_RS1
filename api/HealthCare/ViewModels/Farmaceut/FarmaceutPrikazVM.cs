namespace HealthCare.ViewModels.Farmaceut
{
    public class FarmaceutPrikazVM
    {
        public string farmaceutId { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public string email { get; set; }
        public string brojTelefona { get; set; }
        public string radnik { get; set; }
        public byte[]? slika_korisnika { get; set; }
    }
}
