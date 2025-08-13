namespace HealthCare.ViewModels.Karton
{
    public class ZdravstvenaLegitimacijaVM
    {
        public int zdravstvenaLegitimacijaId { get; set; }
        public string jmbg { get; set; }
        public DateTime datum_izdavanja { get; set; }
        public string dopunsko_osiguranje { get; set; }
        public string srodstvo_osiguranika { get; set; }
    }
}
