using System;
using System.Linq.Expressions;
using Common.Models;
using NUnit.Framework;

namespace Common.UnitTests
{
    public class ReflectionFluentExtsTests : TestData
    {
        [Test]
        public void UpdateOldModel_With_UpdatedModel()
        {
            // Arrange
            Car old = new Car("Bmw","Black");
            Car newCar = new Car("Audi","White");

            // Act
            old = old.UpdateWith(newCar, new Expression<Func<Car, object>>[] 
            { x => x.Name, x => x.Color });

            // Assert
            Assert.IsNotNull(old);
            Assert.AreEqual(newCar.Name, old.Name);
            Assert.AreEqual(10, newCar.Id);
            Assert.AreEqual(10, old.Id);
            Assert.AreEqual(newCar.Color, old.Color);
        }
        [Test]
        public void GetPropertyUpdates()
        {
            // Arrange
            Car old = new Car("Bmw", "Black");
            Car newCar = new Car("Audi", "White");

            // Act
            UpdateResult<Car> result = old.GetPropertyUpdates(newCar, new Expression<Func<Car, object>>[]
            { x => x.Name, x => x.Color });

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(old, result.BaseModel);
            Assert.AreEqual(newCar, result.UpdatedModel);
            Assert.AreEqual(2, result.PropertyUpdates.Count);
            Log(string.Join("\n", result.GetChangesAsString()));
        }
    }
}