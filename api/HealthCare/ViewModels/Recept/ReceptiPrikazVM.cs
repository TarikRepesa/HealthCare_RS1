namespace HealthCare.ViewModels.Recept
{
    public class ReceptiPrikazVM
    {
        public int receptId { get; set; }
        public DateTime datumIzdavanja { get; set; }
        public string doza { get; set; }
        public string napomena { get; set; }
        public string sifraBolesti { get; set; }
        public string ljekarId { get; set; }
        public string imePrezime_ljekara { get; set; }
        public string specijalizacija_ljekara { get; set; }
    }
}
