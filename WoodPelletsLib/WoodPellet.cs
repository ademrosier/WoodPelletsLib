namespace WoodPelletsLib
{
    public class WoodPellet
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public double Price { get; set; }
        public int Quality { get; set; }

        public override string ToString()
        {
            return $"{Id} {Brand} {Price} {Quality}";
        }

        public void ValidateBrand()
        {
            if (Brand.Length <= 1)
            {
                throw new ArgumentException("The title must be at least 2 characters!");
            }
        }

        public void ValidatePrice()
        {
            if (Price < 0)
            {
                throw new ArgumentException("The price must be above 0!");
            }
        }

        public void ValidateQuality()
        {
            if (Quality <= 0 || Quality >= 6)
            {
                throw new ArgumentException("The quality must be above 0 and below 6");
            }
        }
    }
}