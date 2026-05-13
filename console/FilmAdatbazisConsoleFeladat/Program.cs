namespace FilmAdatbazisConsoleFeladat
{
    public class FilmAdatbazis
    {
        public string Cim {  get; set; }

        public string Mufaj { get; set; }

        public string Rendezo { get; set; }

        public int MegjelenesiEv {  get; set; }

        public double IMDb { get; set; }

        public override string ToString()
        {
            return $"{Cim} - {Mufaj} - {Rendezo} - {MegjelenesiEv} - {IMDb}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string fajl = "filmek.txt";

            List<FilmAdatbazis> filmek = File.ReadAllLines(fajl).Select(sor =>
            {
                var adatok = sor.Split(";");

                return new FilmAdatbazis
                {
                    Cim = adatok[0],
                    Mufaj = adatok[1],
                    Rendezo = adatok[2],
                    MegjelenesiEv = int.Parse(adatok[3]),
                    IMDb = double.Parse(adatok[4].Replace('.', ','))

                };

            }).ToList();

            Console.WriteLine("Filmadatbázis tartalma:");

            foreach (var film in filmek)
            {
                Console.WriteLine($"{film.Cim} - {film.Mufaj} - {film.Rendezo} - {film.MegjelenesiEv} - {film.IMDb}");
            }

            Console.WriteLine($"A filmadatbázisban található filmek száma: {filmek.Count}");

            var kategoriak = filmek
            .GroupBy(f => f.Mufaj)
            .Select(g => new
            {
                Mufaj = g.Key,
                Darabszam = g.Count()

            });

            Console.WriteLine("\r\nMűfajok szerinti csoportosítás:");

            foreach (var film in kategoriak)
            {
                Console.WriteLine($"{film.Mufaj} - {film.Darabszam} film");
            }

            var legmagasErtekeles = filmek.Max(f => f.IMDb);
            var legmagasErtekelesFilm = filmek.Where(f => f.IMDb == legmagasErtekeles);

            Console.WriteLine("\n Legmagasabb IMDb értékelésű film(ek):");

            foreach (var film in legmagasErtekelesFilm)
            {
                Console.WriteLine($"{film.Cim} - {film.Mufaj} - {film.Rendezo} - {film.MegjelenesiEv} - {film.IMDb}");
            }

            var idoSzerintRendezett = filmek.Where(f => f.MegjelenesiEv > 2000);

            Console.WriteLine("\n2000 után megjelent filmek: ");

            foreach (var film in idoSzerintRendezett)
            {
                Console.WriteLine($"{film.Cim} - {film.Mufaj} - {film.Rendezo} - {film.MegjelenesiEv} - {film.IMDb}");
            }

            
        }
    }
}
