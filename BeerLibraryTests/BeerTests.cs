using Microsoft.VisualStudio.TestTools.UnitTesting;
using BeerLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace BeerLibraryTests
{
    [TestClass]
    public class BeerTests
    {

        private readonly Beer _beer = new() { Id = 1, BeerName = "Tuborg", Abv = 6.5 };
        //private readonly Beer _yearLow = new() { Id = 4, BeerName = "The Matrix", Abv = 1894 };

        [TestMethod()]
        public void ToStringTest()
        {

            Assert.AreEqual("1 Tuborg 6,5", _beer.ToString());

        }

        [TestMethod]
        public void TestBeerCreation_ValidInputs()
        {

            // Assert
            Assert.AreEqual(1, _beer.Id);
            Assert.AreEqual("Tuborg", _beer.BeerName);
            Assert.AreEqual(6.5, _beer.Abv);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestBeerCreation_InvalidId()
        {

            // Arrange & Act
            int id = -1;
            string name = "Tuborg";
            double abv = 6.5;
            Beer beer = new(id, name, abv);

            // Assert
            // Expects ArgumentOutOfRangeException

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestBeerCreation_NullName()
        {
            // Arrange
            int id = 1;
            string name = null;
            double abv = 6.5;

            // Act
            Beer beer = new(id, name, abv);

            // Assert
            // Expects ArgumentException
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestBeerCreation_ShortName()
        {
            // Arrange
            int id = 1;
            string name = "IPA"; // Too short, should be at least 4 characters
            double abv = 6.5;

            // Act
            Beer beer = new Beer(id, name, abv);

            // Assert
            // Expects ArgumentException
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestBeerCreation_InvalidAbv()
        {
            // Arrange
            int id = 1;
            string name = "Tuborg";
            double abv = 70; // Above the allowed range

            // Act
            Beer beer = new Beer(id, name, abv);

            // Assert
            // Expects ArgumentOutOfRangeException
        }
    }
}   