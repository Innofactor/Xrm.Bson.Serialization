namespace Innofactor.Xrm.Bson
{
    using Innofactor.Xrm.Bson.Extensions;
    using Microsoft.Xrm.Sdk;
    using MongoDB.Bson;
    using MongoDB.Bson.IO;
    using MongoDB.Bson.Serialization;
    using System;

    internal class EntitySerializer : IBsonSerializer<Entity>
    {
        public Type ValueType => typeof(Entity);

        public object Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            return Deserialize(context, args);
        }

        public void Serialize(BsonSerializationContext context, BsonSerializationArgs args, object value)
        {
            Serialize(context, args, value as Entity);
        }

        public void Serialize(BsonSerializationContext context, BsonSerializationArgs args, Entity value)
        {
            context.Writer.WriteStartDocument();
            context.Writer.WriteReference(value.ToEntityReference());
            context.Writer.WriteEndDocument();
        }

        Entity IBsonSerializer<Entity>.Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            context.Reader.ReadStartDocument();

            var entity = new Entity(context.Reader.ReadString(), new Guid(context.Reader.ReadBinaryData().AsByteArray));

            while (context.Reader.State != BsonReaderState.Done && context.Reader.State != BsonReaderState.Initial)
            {
                var type = context.Reader.ReadBsonType();
                switch (type)
                {
                    case BsonType.EndOfDocument:
                        context.Reader.ReadEndDocument();
                        break;
                }
            }

            return entity;
        }
    }
}