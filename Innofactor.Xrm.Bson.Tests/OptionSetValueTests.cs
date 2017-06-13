namespace Innofactor.Xrm.Bson.Tests
{
    using Microsoft.Xrm.Sdk;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization;
    using NUnit.Framework;

    public class OptionSetValueTests
    {
        #region Public Constructors

        public OptionSetValueTests()
        {
            // Setting up serializers
            BsonSerializer.RegisterSerializationProvider(new SerializationPrivider());
        }

        #endregion Public Constructors

        #region Public Methods

        [Test, Category("Bson Tests")]
        public void DeSerializeEntityOptionSetValue_Success()
        {
            // Arrange
            var expectedValue = 1;
            var expectedEntity = new Entity("account");
            expectedEntity.Attributes.Add("key", new OptionSetValue(expectedValue));
            var bson = expectedEntity.ToBsonDocument();

            // Act
            var actualEntity = BsonSerializer.Deserialize<Entity>(bson);
            var actualValue = actualEntity.Attributes["key"];

            // Assert
            Assert.AreEqual(typeof(OptionSetValue), actualValue.GetType());
            Assert.AreEqual(expectedValue, (actualValue as OptionSetValue).Value);
        }

        [Test, Category("Bson Tests")]
        public void SerializeEntityOptionSet_Success()
        {
            // Arrange
            var expectedValue = 1;
            var entity = new Entity("account");
            entity.Attributes.Add("key", new OptionSetValue(expectedValue));

            // Act
            var bson = entity.ToBsonDocument();
            var actualValue = bson["key"];

            // Assert
            Assert.AreEqual(true, actualValue.IsBsonDocument);
            Assert.AreEqual(expectedValue, actualValue.AsBsonDocument["_option"].AsInt32);
        }

        #endregion Public Methods
    }
}