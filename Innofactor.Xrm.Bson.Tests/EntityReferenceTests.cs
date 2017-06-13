namespace Innofactor.Xrm.Bson.Tests
{
    using Microsoft.Xrm.Sdk;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization;
    using System;
    using NUnit.Framework;

    public class EntityReferenceTests
    {
        #region Public Methods

        [Test, Category("Bson Tests")]
        public void DeSerializeEntityEntityReference_Success()
        {
            // Arrange
            var expectedValue = new EntityReference("contact", Guid.NewGuid());
            var expectedEntity = new Entity("account");
            expectedEntity.Attributes.Add("key", expectedValue);
            var bson = expectedEntity.ToBsonDocument();

            // Act
            var actualEntity = BsonSerializer.Deserialize<Entity>(bson);
            var actualValue = actualEntity.Attributes["key"];

            // Assert
            Assert.AreEqual(typeof(EntityReference), actualValue.GetType());
            Assert.AreEqual(expectedValue.LogicalName, (actualValue as EntityReference).LogicalName);
            Assert.AreEqual(expectedValue.Id, (actualValue as EntityReference).Id);
        }

        [Test, Category("Bson Tests")]
        public void SerializeEntityEntityReference_Success()
        {
            // Arrange
            var expectedValue = new EntityReference("contact", Guid.NewGuid());
            var entity = new Entity("account");
            entity.Attributes.Add("key", expectedValue);

            // Act
            var bson = entity.ToBsonDocument();
            var actualValue = bson["key"];

            // Assert
            Assert.AreEqual(true, actualValue.IsBsonDocument);

            // Checking logical name
            Assert.AreEqual(expectedValue.LogicalName, actualValue.AsBsonDocument["_name"].AsString);

            // Checking id
            Assert.AreEqual(expectedValue.Id, actualValue.AsBsonDocument["_id"].AsGuid);
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