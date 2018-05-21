using System;
using Moq;
using NUnit.Framework;
using UnitTestProject.Models;

namespace UnitTestProject.Tests.Controllers
{
	[TestFixture]
    public class GeneratorTest
    {

		Mock<IGenerateur> IGenerateurMock;

        [SetUp]
        public void Init()
        {
			IGenerateurMock = new Mock<IGenerateur>();

        }

		[Test]
        public void WhenGeneratorCall_ThenReturnIntValue()
        {
			//Given
            IGenerateurMock = new Mock<IGenerateur>();

            //When
            IGenerateurMock.Setup(generateur => generateur.Valeur).Returns(5);

            //Then
            Assert.AreEqual(5, IGenerateurMock.Object.Valeur);
        }
    }
}
