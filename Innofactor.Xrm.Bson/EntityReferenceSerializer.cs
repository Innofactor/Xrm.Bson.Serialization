namespace Innofactor.Xrm.Bson
{
    using Extensions;
    using Microsoft.Xrm.Sdk;
    using MongoDB.Bson.Serialization;
    using System;

    internal class EntityReferenceSerializer : IBsonSerializer<EntityReference>
    {
        public Type ValueType => typeof(EntityReference);

        public object Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            throw new NotImplementedException();
        }

        public void Serialize(BsonSerializationContext context, BsonSerializationArgs args, object value)
        {
            Serialize(context, args, value as EntityReference;
        }

        public void Serialize(BsonSerializationContext context, BsonSerializationArgs args, EntityReference value)
        {
            context.Writer.WriteStartDocument();
            context.Writer.WriteReference(value);
            context.Writer.WriteEndDocument();
        }

        EntityReference IBsonSerializer<EntityReference>.Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            throw new NotImplementedException();
        }
    }
}