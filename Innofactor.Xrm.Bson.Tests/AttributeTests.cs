namespace Innofactor.Xrm.Bson.Tests
{
    using System;
    using Microsoft.Xrm.Sdk;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization;
    using NUnit.Framework;

    public class AttributeTests
    {
        #region Public Constructors

        public AttributeTests()
        {
            // Setting up serializers
            BsonSerializer.RegisterSerializationProvider(new SerializationPrivider());
        }

        #endregion Public Constructors

        #region Public Methods

        [Test, Category("Bson Tests")]
        public void DeSerializeEntityBoolean_Success()
        {
            // Arrange
            const bool expectedValue = true;
            var expectedEntity = new Entity("account");
            expectedEntity.Attributes.Add("key", expectedValue);
            var bson = expectedEntity.ToBsonDocument();

            // Act
            var actualEntity = BsonSerializer.Deserialize<Entity>(bson);
            var actualValue = actualEntity.Attributes["key"];

            // Assert
            Assert.AreEqual(typeof(bool), actualValue.GetType());
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test, Category("Bson Tests")]
        public void DeSerializeEntityDateTime_Success()
        {
            // Arrange
            var expectedValue = DateTime.Now;
            var expectedEntity = new Entity("account");
            expectedEntity.Attributes.Add("key", expectedValue);
            var bson = expectedEntity.ToBsonDocument();

            // Act
            var actualEntity = BsonSerializer.Deserialize<Entity>(bson);
            var actualValue = (DateTime)actualEntity.Attributes["key"];

            // Assert
            Assert.AreEqual(typeof(DateTime), actualValue.GetType());
            Assert.AreEqual(expectedValue.ToShortTimeString(), actualValue.ToShortTimeString());
        }

        [Test, Category("Bson Tests")]
        public void DeSerializeEntityInteger_Success()
        {
            // Arrange
            const int expectedValue = 1;
            var expectedEntity = new Entity("account");
            expectedEntity.Attributes.Add("key", expectedValue);
            var bson = expectedEntity.ToBsonDocument();

            // Act
            var actualEntity = BsonSerializer.Deserialize<Entity>(bson);
            var actualValue = actualEntity.Attributes["key"];

            // Assert
            Assert.AreEqual(typeof(int), actualValue.GetType());
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test, Category("Bson Tests")]
        public void DeSerializeEntityString_Success()
        {
            // Arrange
            const string expectedValue = "value";
            var expectedEntity = new Entity("account");
            expectedEntity.Attributes.Add("key", expectedValue);
            var bson = expectedEntity.ToBsonDocument();

            // Act
            var actualEntity = BsonSerializer.Deserialize<Entity>(bson);
            var actualValue = actualEntity.Attributes["key"];

            // Assert
            Assert.AreEqual(typeof(string), actualValue.GetType());
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test, Category("Bson Tests")]
        public void SerializeEntityBoolean_Success()
        {
            // Arrange
            const bool expectedValue = true;
            var entity = new Entity("account");
            entity.Attributes.Add("key", expectedValue);

            // Act
            var bson = entity.ToBsonDocument();
            var actualValue = bson["key"];

            // Assert
            Assert.AreEqual(true, actualValue.IsBoolean);
            Assert.AreEqual(expectedValue, actualValue.AsBoolean);
        }

        [Test, Category("Bson Tests")]
        public void SerializeEntityDateTime_Success()
        {
            // Arrange
            var expectedValue = DateTime.Now;
            var entity = new Entity("account");
            entity.Attributes.Add("key", expectedValue);

            // Act
            var bson = entity.ToBsonDocument();
            var actualValue = bson["key"];

            // Assert
            Assert.AreEqual(true, actualValue.IsValidDateTime);
            Assert.AreEqual(expectedValue.ToShortTimeString(), actualValue.ToUniversalTime().ToShortTimeString());
        }

        [Test, Category("Bson Tests")]
        public void SerializeEntityInteger_Success()
        {
            // Arrange
            const int expectedValue = 1;
            var entity = new Entity("account");
            entity.Attributes.Add("key", expectedValue);

            // Act
            var bson = entity.ToBsonDocument();
            var actualValue = bson["key"];

            // Assert
            Assert.AreEqual(true, actualValue.IsInt32);
            Assert.AreEqual(expectedValue, actualValue.AsInt32);
        }

        [Test, Category("Bson Tests")]
        public void SerializeEntityString_Success()
        {
            // Arrange
            const string expectedValue = "value";
            var entity = new Entity("account");
            entity.Attributes.Add("key", expectedValue);

            // Act
            var bson = entity.ToBsonDocument();
            var actualValue = bson["key"];

            // Assert
            Assert.AreEqual(true, actualValue.IsString);
            Assert.AreEqual(expectedValue, actualValue.AsString);
        }

        #endregion Public Methods
    }
}