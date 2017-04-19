namespace Innofactor.Xrm.Bson
{
    using MongoDB.Bson.Serialization;
    using System;

    internal class MoneySerializer : IBsonSerializer
    {
        #region Public Properties

        public Type ValueType => throw new NotImplementedException();

        #endregion Public Properties

        #region Public Methods

        public object Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            throw new NotImplementedException();
        }

        public void Serialize(BsonSerializationContext context, BsonSerializationArgs args, object value)
        {
            throw new NotImplementedException();
        }

        #endregion Public Methods
    }
}