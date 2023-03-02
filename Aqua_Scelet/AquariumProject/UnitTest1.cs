using Aqua;
using NUnit.Framework;
using System;

namespace AquariumProject
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void FishConstructorShouldInicializeCorrectly()
        {
            Fish fish = new Fish("Salmon", 6);

            Assert.AreEqual("Salmon", fish.Type);
            Assert.AreEqual(6, fish.Price);

        }
        [Test]
        public void AquariumConstructorShouldInicializeCorrectly()
        {
            Aquarium aquarium = new Aquarium("Square",100);
            Assert.AreEqual("Square", aquarium.Shape);
            Assert.AreEqual(100, aquarium.Capacity);
        }
        [Test]
        public void RemoveMethodShoudThrowExIfListIsEmpty()
        {
            Aquarium aquarium = new Aquarium("Square", 100);
            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish("Salmon"));
        }
        [Test]
        public void RemoveMethodShoudThrowExactExceptionMessageIfListIsEmpty()
        {
            Aquarium aquarium = new Aquarium("Square", 100);
            var ex=Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish("Salmon"));
            Assert.AreEqual("Invalid operation", ex.Message);

        }
        [Test]
        public void RemoveMethodShoudThrowExeptionIfFishIsMissing()
        {
            Aquarium aquarium = new Aquarium("Square", 100);
            Fish fish = new Fish("Salmon", 6);
            aquarium.AddFish(fish);
            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish("Clownfish"));



        }
        [Test]
        public void RemoveMethodShoudThrowExactMessageIfFishIsMissing()
        {
            Aquarium aquarium = new Aquarium("Square", 100);
            Fish fish = new Fish("Salmon", 6);
            aquarium.AddFish(fish);
            var ex=Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish("Clownfish"));
            Assert.AreEqual("Invalid operation", ex.Message);
        }
        [Test]
        public void RemoveMethodShoudWorkCorrectlyAndDecreseNumberOfFishesInTheList()
        {
            Aquarium aquarium = new Aquarium("Square", 100);
            Fish fish = new Fish("Salmon", 6);
            Fish fish2 = new Fish("Clownfish", 10);
            aquarium.AddFish(fish);
            aquarium.AddFish(fish2);
            aquarium.RemoveFish("Salmon");

            Assert.AreEqual(1, aquarium.Fishes.Count);


        }
        [Test]
        public void RemoveMethodShoudIncreaseFreeCapacity()
        {
            Aquarium aquarium = new Aquarium("Square", 100);
            Fish fish = new Fish("Clownfish", 10);
            aquarium.AddFish(fish);
            aquarium.RemoveFish("Clownfish");
            Assert.AreEqual(100, aquarium.Capacity);

        }
        [Test]
        public void RemoveMethodShoudRemoveExactFish()
        {
            Aquarium aquarium = new Aquarium("Square", 100);
            Fish fish = new Fish("Clownfish", 10);
            aquarium.AddFish(fish);
            aquarium.RemoveFish("Clownfish");

            bool isFish = false;
            if (aquarium.Fishes.Contains(fish))
            {
                isFish = true;
            }
            Assert.AreEqual(false, isFish);
        }
        [Test]
        public void ReportRemoveFishShoudPrintExactSuccessfulMessage()
        {
            Aquarium aquarium = new Aquarium("Square", 100);
            Fish fish = new Fish("Clownfish", 10);
            aquarium.AddFish(fish);
            aquarium.RemoveFish("Clownfish");
            Assert.AreEqual("You successfully remove a fish!", aquarium.ReportRemoveFish());
        }
        [Test]
        public void EmptyMethodShoudWorkCorrectly()
        {
            Aquarium aquarium = new Aquarium("Square", 100);
            Fish fish = new Fish("Clownfish", 10);
            aquarium.AddFish(fish);
            aquarium.Empty();

            Assert.AreEqual(0, aquarium.Fishes.Count);
            Assert.AreEqual(100, aquarium.Capacity);
        }
    }
}