
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using epitecture.Services;

namespace epitecture.UnitTests
{
    [TestClass]
    public class ImgurServiceUnitTests
    {
        private int _toto;
        [TestInitialize]
        public void Init()
        {
            _toto = 42;
        }

        [TestMethod]
        public void SearchImagesWithResult()
        {
        }
        [TestMethod]
        public void werwef()
        {
            Assert.AreEqual(42, _toto);
            _toto = 0;
        }
    }
}
