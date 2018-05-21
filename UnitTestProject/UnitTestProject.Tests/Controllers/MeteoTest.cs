using System;
using Moq;
using NUnit.Framework;
using UnitTestProject.Models;

namespace UnitTestProject.Tests.Controllers
{
	[TestFixture]
    public class MeteoTest
    {
		Mock<IDal> mock;

		[SetUp]
        public void Init()
        {          
            mock = new Mock<IDal>();
            
		}

		[Test]
        public void WhenLaMeteoDuJour_ThenRetourneSoleil()
        {
			//GIVEN
            Meteo fausseMeteo = new Meteo
            {
                Temperature = 25,
                Temps = Temps.Soleil
            };
			mock.Setup(dal => dal.ObtenirLaMeteoDuJour()).Returns(fausseMeteo);         
            IDal fausseDal = mock.Object;

            //When
            Meteo meteoDuJour = fausseDal.ObtenirLaMeteoDuJour();

            //Then
            Assert.AreEqual(25, meteoDuJour.Temperature);
            Assert.AreEqual(Temps.Soleil, meteoDuJour.Temps);
        }
    }
}
