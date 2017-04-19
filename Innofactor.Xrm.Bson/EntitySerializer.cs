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

            foreach (var pair in value.Attributes)
            {
                context.Writer.WriteName(pair.Key);

                if (pair.Value.GetType().Equals(typeof(string)))
                {
                    context.Writer.WriteString((string)pair.Value);
                }
                else if (pair.Value.GetType().Equals(typeof(int)))
                {
                    context.Writer.WriteInt32((int)pair.Value);
                }
                else if (pair.Value.GetType().Equals(typeof(bool)))
                {
                    context.Writer.WriteBoolean((bool)pair.Value);
                }
                else if (pair.Value.GetType().Equals(typeof(DateTime)))
                {
                    var date = (DateTime)pair.Value;
                    var stamp = (long)date.Subtract(new DateTime(1970, 1, 1)).TotalMilliseconds;

                    context.Writer.WriteDateTime(stamp);
                }
                else if (pair.Value.GetType().Equals(typeof(EntityReference)))
                {
                    BsonSerializer.Serialize(context.Writer, pair.Value as EntityReference);
                }
                else if (pair.Value.GetType().Equals(typeof(OptionSetValue)))
                {
                    BsonSerializer.Serialize(context.Writer, pair.Value as OptionSetValue);
                }
                else if (pair.Value.GetType().Equals(typeof(Money)))
                {
                    BsonSerializer.Serialize(context.Writer, pair.Value as Money);
                }
                else
                {
                    context.Writer.WriteNull();
                }
            }

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
                    case BsonType.String:
                        entity.Attributes.Add(context.Reader.ReadName(), context.Reader.ReadString());
                        break;

                    case BsonType.Int32:
                        entity.Attributes.Add(context.Reader.ReadName(), context.Reader.ReadInt32());
                        break;

                    case BsonType.Boolean:
                        entity.Attributes.Add(context.Reader.ReadName(), context.Reader.ReadBoolean());
                        break;

                    case BsonType.DateTime:
                        entity.Attributes.Add(context.Reader.ReadName(), new DateTime(1970, 1, 1).AddMilliseconds(context.Reader.ReadDateTime()));
                        break;

                    case BsonType.Document:
                        entity.Attributes.Add(context.Reader.ReadDocument());
                        break;

                    case BsonType.EndOfDocument:
                        context.Reader.ReadEndDocument();
                        break;
                }
            }

            return entity;
        }
    }
}