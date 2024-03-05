using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BeerLibrary;

namespace BeerLibraryTests
{
    [TestClass]
    public class BeersRepositoryTests
    {
        [TestMethod]
        public void TestGet()
        {
            // Arrange
            BeersRepository repository = new BeersRepository();

            // Act
            List<Beer> beers = repository.Get();

            // Assert
            Assert.IsNotNull(beers);
            Assert.AreEqual(5, beers.Count);
        }


        [TestMethod]
        public void TestGetById_ExistingId()
        {
            // Arrange
            BeersRepository repository = new BeersRepository();
            int id = 3;

            // Act
            Beer beer = repository.GetById(id);

            // Assert
            Assert.IsNotNull(beer);
            Assert.AreEqual("Heineken", beer.BeerName);
        }

        [TestMethod]
        public void TestAdd()
        {
            // Arrange
            BeersRepository repository = new BeersRepository();
            Beer newBeer = new Beer { Id = 6, BeerName = "Stella Artois", Abv = 5.0 };

            // Act
            Beer addedBeer = repository.Add(newBeer);

            // Assert
            Assert.IsNotNull(addedBeer);
            Assert.AreEqual(6, addedBeer.Id);
        }
    }
}