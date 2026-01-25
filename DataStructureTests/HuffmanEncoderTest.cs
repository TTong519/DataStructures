using DataStructures;
using System.Text;
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
        for (int i = 0; i < 1000; i++)
        {
            string input = new string(Enumerable.Range(0, 100).Select(_ => (char)random.Next(32, 127)).ToArray());
            var encoder = new HuffmanEncoder();
            (byte[] encoded, var codes, uint len) = encoder.Encode(input);
            string decoded = encoder.Decode(encoded, codes, len);
            Assert.AreEqual(input, decoded);
        }
    }
    [TestMethod]
    public void ComptessionTest()
    {
        string inputfilepath = "..\\..\\..\\Harry Potter and the Sorcerer's Sto.txt";
        var encoder = new HuffmanEncoder();
        string input = File.ReadAllText(inputfilepath);
        (byte[] encoded, var codes, uint len) = encoder.Encode(input);
        string encodedString = "";
        StringBuilder encodedBuilder = new();
        foreach (var b in encoded)
        {
            encodedBuilder.Append(b.ToString("B8"));
        }
        encodedString = encodedBuilder.ToString();
        string decoded = encoder.Decode(encoded, codes, len);
        Assert.IsTrue(encodedString.Length < input.Length*8);
    }
}
