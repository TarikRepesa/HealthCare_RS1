namespace HealthCare.ViewModels.Lijek
{
    public class LijekAddVM
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Vrsta { get; set; }
        public double KolicinaNaStanju { get; set; }
        public string NacinUpotrebe { get; set; }
        public string Nuspojave { get; set; }
        public string Upozorenja { get; set; }
        public double Cijena { get; set; }
        public int ProizvodjacId { get; set; }
        public int ApotekaId { get; set; }
    }
}
