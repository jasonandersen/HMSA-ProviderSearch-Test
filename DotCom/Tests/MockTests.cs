using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using OpenQA.Selenium;

namespace DotCom.Tests
{
    [TestFixture]
    class MockTests
    {
        [Test]
        public void TestMocks()
        {
            Mock<IWebElement> mock = new Mock<IWebElement>();
            mock.Setup(m => m.Displayed).Returns(true);
            IWebElement element = mock.Object;
            Assert.IsTrue(element.Displayed);  
        }
    }
}
