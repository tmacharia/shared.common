using System;
using NUnit.Framework;

namespace Common.UnitTests
{
    public class ReflectionExtsTests : TestData
    {
        [Test]
        public void GetPropertyDescriptors_ConfirmPropsCount()
        {
            // Arrange
            Car car = new Car();

            // Act
            var props = car.GetPropertyDescriptors();

            // Assert
            Log(props.Length);
        }
        [Test]
        public void GetPropertyValue_In_SpecifiedCastType()
        {
            // Arrange
            Car car = new Car(CarNames[0]);

            // Act
            string name = car.GetPropertyValue<Car,string>("Name");
            string color = car.GetPropertyValue<Car,string>("Color");
            DateTime? time = car.GetPropertyValue<Car, DateTime?>("Timestamp");

            // Assert
            Assert.AreEqual(CarNames[0], name);
            Assert.AreEqual(Color1, color);
            Assert.IsFalse(time.HasValue);
        }
        [Test]
        public void GetPropertyValue_As_Object()
        {
            // Arrange
            Car car = new Car(CarNames[0]);

            // Act
            string name = car.GetPropertyValue("Name").ToString();
            string color = car.GetPropertyValue("Color").ToString();
            DateTime? time = car.GetPropertyValue("Timestamp") as DateTime?;

            // Assert
            Assert.AreEqual(CarNames[0], name);
            Assert.AreEqual(Color1, color);
            Assert.IsFalse(time.HasValue);
        }
        [Test]
        public void SetPropertyValue_As_Object()
        {
            // Arrange
            Car car = new Car(CarNames[0]);
            DateTime time = DateTime.Now;
            int newId = 11;

            // Act
            car.SetPropertyValue("Id", newId);
            car.SetPropertyValue("Name", CarNames[1]);
            car.SetPropertyValue("Color", Color2);
            car.SetPropertyValue("Timestamp", (object)time);

            // Assert
            Assert.AreEqual(newId, car.Id);
            Assert.AreEqual(CarNames[1], car.Name);
            Assert.AreEqual(Color2, car.Color);
            Assert.IsTrue(car.Timestamp.HasValue);
            Assert.AreEqual(time, car.Timestamp);
        }
        [Test]
        public void GetPropertyType_ReturnsValid_Type()
        {
            // Arrange
            Car car = new Car();
            // Act
            Type type = car.GetPropertyType("Timestamp");
            // Assert
            Assert.IsNotNull(type);
            Assert.AreEqual(typeof(DateTime?), type);
        }
        [Test]
        public void GetPropertyType_Of_NonExistentProperty_ThrowsException()
        {
            // Arrange
            Car car = new Car();
            // Act;Assert
            Assert.Throws<Exception>(() => car.GetPropertyType("IsOk"));
        }
    }
}