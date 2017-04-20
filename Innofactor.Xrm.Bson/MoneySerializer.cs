namespace Innofactor.Xrm.Bson
{
    using Microsoft.Xrm.Sdk;
    using MongoDB.Bson.Serialization;
    using System;

    internal class MoneySerializer : IBsonSerializer<Money>
    {
        #region Public Properties

        public Type ValueType => typeof(Money);

        #endregion Public Properties

        #region Public Methods

        public object Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            return Deserialize(context, args);
        }

        Money IBsonSerializer<Money>.Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            context.Reader.ReadStartDocument();

            var result = new Money((decimal)context.Reader.ReadDecimal128());

            context.Reader.ReadEndDocument();

            return result;
        }

        public void Serialize(BsonSerializationContext context, BsonSerializationArgs args, object value)
        {
            Serialize(context, args, value as Money);
        }

        public void Serialize(BsonSerializationContext context, BsonSerializationArgs args, Money value)
        {
            context.Writer.WriteStartDocument();

            context.Writer.WriteName("_money");
            context.Writer.WriteDecimal128(value.Value);

            context.Writer.WriteEndDocument();
        }

        #endregion Public Methods
    }
}