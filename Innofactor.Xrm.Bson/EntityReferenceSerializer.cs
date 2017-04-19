namespace Innofactor.Xrm.Bson
{
    using System;
    using MongoDB.Bson.Serialization;

    internal class EntityReferenceSerializer : IBsonSerializer
    {
        public Type ValueType => throw new NotImplementedException();

        public object Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            throw new NotImplementedException();
        }

        public void Serialize(BsonSerializationContext context, BsonSerializationArgs args, object value)
        {
            throw new NotImplementedException();
        }
    }
}