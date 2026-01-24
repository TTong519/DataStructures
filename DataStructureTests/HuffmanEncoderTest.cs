using DataStructures;
namespace DataStructuresTests;

[TestClass]
public class HuffmanEncoderTest
{
    [TestMethod]
    [DataRow(3203739)]
    [DataRow(5930276)]
    [DataRow(9345878)]
    [DataRow(1582596)]
    [DataRow(7293840)]
    [DataRow(4829102)]
    public void Test(int seed)
    {
        Random random = new Random(seed);
        for (int i = 0; i < random.Next(1000); i++)
        {
            string input = new string(Enumerable.Range(0, 100).Select(_ => (char)random.Next(32, 127)).ToArray());
            input = "streets are stone stars are not";
            var encoder = new HuffmanEncoder();
            (byte[] encoded, var codes) = encoder.Encode(input);
            string decoded = encoder.Decode(encoded, codes);
            Assert.AreEqual(input, decoded);
        }
    }
}
