using WoodPelletsLib;

namespace UnitTest1
{
    [TestClass]
    public class UnitTest1
    {
        WoodPellet actor = new WoodPellet { Id = 1, Brand = "Traeger", Price = 79.99, Quality = 2 };

        WoodPellet brand = new WoodPellet { Id = 2, Brand = "Lignetics", Price = 79.99, Quality = 2 };
        WoodPellet brandShort = new WoodPellet { Id = 2, Brand = "L", Price = 79.99, Quality = 2 };

        WoodPellet price = new WoodPellet { Id = 3, Brand = "Bear Mountain", Price = 89.99, Quality = 3 };
        WoodPellet priceOutOfRange = new WoodPellet { Id = 3, Brand = "Bear Mountain", Price = -89.99, Quality = 3 };

        WoodPellet quality = new WoodPellet { Id = 4, Brand = "Green Supreme", Price = 89.99, Quality = 3 };
        WoodPellet qualityOutOfRangeBelow = new WoodPellet { Id = 4, Brand = "Green Supreme", Price = 89.99, Quality = 0};
        WoodPellet qualityOutOfRangeAbove = new WoodPellet { Id = 4, Brand = "Green Supreme", Price = 89.99, Quality = 6};

        [TestMethod()]
        public void ToStringTest()
        {
            Assert.AreEqual("1 Traeger 79,99 2", actor.ToString());
        }

        [TestMethod]
        public void ValidateBrandTest()
        {
            brand.ValidateBrand();
            Assert.ThrowsException<ArgumentException>(() => brandShort.ValidateBrand());
        }

        [TestMethod]
        public void ValidatePriceTest()
        {
            price.ValidatePrice();
            Assert.ThrowsException<ArgumentException>(() => priceOutOfRange.ValidatePrice());
        }

        [TestMethod]
        public void ValidateQualityTest()
        {
            quality.ValidateQuality();
            Assert.ThrowsException<ArgumentException>(() => qualityOutOfRangeBelow.ValidateQuality());
            Assert.ThrowsException<ArgumentException>(() => qualityOutOfRangeAbove.ValidateQuality());
        }
    }
}