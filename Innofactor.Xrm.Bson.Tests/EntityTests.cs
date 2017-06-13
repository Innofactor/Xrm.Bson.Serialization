namespace Innofactor.Xrm.Bson.Tests
{
    using System;
    using Microsoft.Xrm.Sdk;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization;
    using NUnit.Framework;

    public class EntityTests
    {
        #region Public Constructors

        public EntityTests()
        {
            // Setting up serializers
            BsonSerializer.RegisterSerializationProvider(new SerializationPrivider());
        }

        #endregion Public Constructors

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

        #endregion Public Methods
    }
}