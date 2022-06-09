using ExpectedObjects;
using KTCommon.EventBus;
using KTCommon.Interfaces;
using KTCommon.Security;
using KTCommon.Structures;
using NUnit.Framework;
using System.Threading;

namespace KTCommonTests
{
    [TestFixture]
    public class CryptographyHelperTests
    {
        [Test]
        public void GenerateKeyAndIV_ReturnCorrect()
        {
            var param = CryptographyHelper.CreateAesKeyAndIV();

            Assert.IsTrue(param.Item1.Length > 0, "The key is empty.");
            Assert.IsTrue(param.Item2.Length > 0, "The iv is empty.");
        }

        [Test]
        [TestCase("Hello Cryptography.")]
        [TestCase("這是中文字")]
        public void EncryptAndDecryptAes_ReturnCorrect(string expected)
        {
            var param = CryptographyHelper.CreateAesKeyAndIV();
            var encrypt = CryptographyHelper.EncryptAes(expected, param.Item1, param.Item2);
            var actual = CryptographyHelper.DecryptAes(encrypt, param.Item1, param.Item2);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase("Hello Cryptography.")]
        [TestCase("這是中文字")]
        public void CreateMD5_ReturnCorrect(string expected)
        {
            var encrypt1 = CryptographyHelper.CreateMD5(expected);
            var encrypt2 = CryptographyHelper.CreateMD5(expected);

            Assert.AreEqual(encrypt1, encrypt2);
        }
    }
}
