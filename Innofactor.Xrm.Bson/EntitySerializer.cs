namespace Innofactor.Xrm.Bson
{
    using Innofactor.Xrm.Bson.Extensions;
    using Microsoft.Xrm.Sdk;
    using MongoDB.Bson.Serialization;
    using System;

    internal class EntitySerializer : IBsonSerializer
    {
        public Type ValueType => typeof(Entity);

        public object Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            throw new NotImplementedException();
        }

        public void Serialize(BsonSerializationContext context, BsonSerializationArgs args, object value)
        {
            context.Writer.WriteStartDocument();
            context.Writer.WriteReference((value as Entity).ToEntityReference());
            context.Writer.WriteEndDocument();
        }
    }
}