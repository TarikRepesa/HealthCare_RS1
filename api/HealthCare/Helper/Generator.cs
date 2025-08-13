using System.Security.Cryptography;
using System.Text;

namespace HealthCare.Helper
{
    public class Generator
    {
        private static string[] Names = { "Anja", "John", "Emily", "Michael", "Sophia", "William", "Olivia", "Kristian", "Florian", "Michelle", "Sarah", "Benjamin", "Steffen", "Ines" };
        private static string[] Surnames = { "Smith", "Johnson", "Williams", "Brown", "Jones", "Miller", "Gaertner", "Hartmann", "Engel", "Bader", "Berg", "Hofmann", "Mueller" };
        private static string[] PlaceOfBirht = { "Sarajevo", "Mostar", "Tuzla", "Zenica", "Travnik", "BanjaLuka" };
        private static string[] DopunskoOsiguranje = { "Dodatne usluge i terapije", "Pokrivenost lijekova", "Pokrivenost specijalističkih pregleda" };

        public static string GenerateRandomName()
        {
            Random random = new Random();
            int randomIndex = random.Next(Names.Length);
            string randomName = Names[randomIndex];
            return randomName;
        }

        public static string GenerateRandomSurname()
        {
            Random random = new Random();
            int randomIndex = random.Next(Surnames.Length);
            string randomSurname = Surnames[randomIndex];
            return randomSurname;
        }

        public static string GenerateRandomPlaceOfBirth()
        {
            Random random = new Random();
            int randomIndex = random.Next(PlaceOfBirht.Length);
            string randomPlaceOfBirth = PlaceOfBirht[randomIndex];
            return randomPlaceOfBirth;
        }

        public static string GenerateJMBG()
        {
            Random random = new Random();
            const int numberSize = 12;
            string randomNumber = "";

            for (int i = 0; i < numberSize; i++)
            {
                int digit = random.Next(10);
                randomNumber += digit.ToString();
            }

            return randomNumber;
        }

        public static string GenerateSifra()
        {
            const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            const int codeSize = 5;

            Random random = new Random();
            string randomCode = new string(Enumerable.Repeat(characters, codeSize)
                                          .Select(s => s[random.Next(s.Length)]).ToArray());

            return randomCode;
        }

        public static string GenerateDopunskoOsiguranje()
        {
            Random random = new Random();
            int randomIndex = random.Next(DopunskoOsiguranje.Length);
            string randomDopunskoOsiguranje = DopunskoOsiguranje[randomIndex];

            return randomDopunskoOsiguranje;
        }

        public static string GenerateStringId()
        {
            // Generate a Guid (Globally Unique Identifier) and convert it to a string
            Guid generatedId = Guid.NewGuid();
            string idString = generatedId.ToString();

            return idString;
        }

        public static string GenerisiKorisnickoIme(int size)
        {
            // Characters except I, l, O, 1, and 0 to decrease confusion when hand typing tokens
            var charSet = "ABCDEFGHJKLMNPQRSTUVWXYZ".ToLower();
            var chars = charSet.ToCharArray();
            var data = new byte[1];
#pragma warning disable SYSLIB0023 // Type or member is obsolete
            var crypto = new RNGCryptoServiceProvider();
#pragma warning restore SYSLIB0023 // Type or member is obsolete
            crypto.GetNonZeroBytes(data);
            data = new byte[size];
            crypto.GetNonZeroBytes(data);
            var result = new StringBuilder(size);
            foreach (var b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }

            var s = result.ToString();

            return result.ToString();
        }
    }
}
