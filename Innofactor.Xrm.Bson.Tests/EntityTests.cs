namespace Innofactor.Xrm.Bson.Tests
{
    using Microsoft.Xrm.Sdk;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization;
    using System;
    using NUnit.Framework;

    public class EntityTests
    {
        #region Public Methods

        [Test, Category("Bson Tests")]
        public void DeSerializeEntity_Success()
        {
            // Arrange
            var expectedEntity = new Entity("account", Guid.NewGuid());
            var bson = expectedEntity.ToBsonDocument();

            // Act
            var actualEntity = BsonSerializer.Deserialize<Entity>(bson);

            // Assert
            // Checking logical name
            Assert.AreEqual(expectedEntity.LogicalName, actualEntity.LogicalName);

            // Checking id
            Assert.AreEqual(expectedEntity.Id, actualEntity.Id);
        }

        [Test, Category("Bson Tests")]
        public void SerializeEntity_Success()
        {
            // Arrange
            var expectedEntity = new Entity("account", Guid.NewGuid());

            // Act
            var bson = expectedEntity.ToBsonDocument();

            // Assert
            // Checking logical name
            Assert.AreEqual(true, bson["_name"].IsString);
            Assert.AreEqual(expectedEntity.LogicalName, bson["_name"].AsString);

            // Checking id
            Assert.AreEqual(true, bson["_id"].IsGuid);
            Assert.AreEqual(expectedEntity.Id, bson["_id"].AsGuid);
        }

        [TestInitialize]
        public void Setup()
        {
            // Setting up serializers
            BsonSerializer.RegisterSerializationProvider(new SerializationPrivider());
        }

        #endregion Public Methods
    }
}