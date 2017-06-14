namespace Innofactor.Xrm.Bson.Tests
{
    using Microsoft.Xrm.Sdk;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization;
    using NUnit.Framework;

    public class MoneyTests
    {
        #region Public Constructors

        public MoneyTests()
        {
            // Setting up serializers
            BsonSerializer.RegisterSerializationProvider(new SerializationPrivider());
        }

        #endregion Public Constructors

        #region Public Methods

        [Test, Category("Bson Tests")]
        public void DeSerializeEntityMoney_Success()
        {
            // Arrange
            const decimal expectedValue = 1.95m;
            var expectedEntity = new Entity("account");
            expectedEntity.Attributes.Add("key", new Money(expectedValue));
            var bson = expectedEntity.ToBsonDocument();

            // Act
            var actualEntity = BsonSerializer.Deserialize<Entity>(bson);
            var actualValue = actualEntity.Attributes["key"];

            // Assert
            Assert.AreEqual(typeof(Money), actualValue.GetType());
            Assert.AreEqual(expectedValue, (actualValue as Money).Value);
        }

        [Test, Category("Bson Tests")]
        public void SerializeEntityMoney_Success()
        {
            // Arrange
            const decimal expectedValue = 1.95m;
            var entity = new Entity("account");
            entity.Attributes.Add("key", new Money(expectedValue));

            // Act
            var bson = entity.ToBsonDocument();
            var actualValue = bson["key"];

            // Assert
            Assert.AreEqual(true, actualValue.IsBsonDocument);

            // Checking value
            Assert.AreEqual(expectedValue, actualValue.AsBsonDocument["_money"].AsDecimal);
        }

        #endregion Public Methods
    }
}