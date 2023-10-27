namespace WoodPelletsLib
{
    public class WoodPelletRepository
    {
        private int nextId = 1;

        private readonly List<WoodPellet> listOfWood = new List<WoodPellet>
        {
            new WoodPellet { Brand = "Traeger", Price = 79.99, Quality = 2 },
            new WoodPellet { Brand = "Lignetics", Price = 79.99, Quality = 2 },
            new WoodPellet { Brand = "Bear Mountain", Price = 89.99, Quality = 3 },
            new WoodPellet { Brand = "Green Supreme", Price = 89.99, Quality = 3 },
            new WoodPellet { Brand = "Hamers Hot Ones", Price = 99.99, Quality = 5 }
        };

        public List<WoodPellet> GetAll()
        {
            return listOfWood;
        }

        public WoodPellet? GetById(int id)
        {
            return listOfWood.Find(wood => wood.Id == id);
        }

        public WoodPellet Add(WoodPellet wood)
        {
            wood.ValidateBrand();
            wood.ValidatePrice();
            wood.ValidateQuality();

            wood.Id = nextId++;
            listOfWood.Add(wood);
            return wood;
        }

        //kontroller om de eksisterende id og objekter er valide.
        public WoodPellet? Update(int id, WoodPellet wood)
        {
            wood.ValidateBrand();
            wood.ValidatePrice();
            wood.ValidateQuality();

            //hvis der ikke eksisterer det objekt med dét id, så returneres der null. så er opdateringen ikke mulig.
            WoodPellet? existingBook = GetById(id);
            if (existingBook == null)
            {
                return null;
            }
            //hvis produktet med id findes, så opdateres brand, prisen og quality med de nye oplysninger.
            //og det eksisterende objekt returneres som bekræftelse på opdateringen.
            existingBook.Brand = wood.Brand;
            existingBook.Price = wood.Price;
            existingBook.Quality = wood.Quality;
            return existingBook;
        }
    }
}
