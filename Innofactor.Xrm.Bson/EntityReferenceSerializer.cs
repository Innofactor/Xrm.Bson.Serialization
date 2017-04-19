namespace Innofactor.Xrm.Bson
{
    using Extensions;
    using Microsoft.Xrm.Sdk;
    using MongoDB.Bson.Serialization;
    using System;

    internal class EntityReferenceSerializer : IBsonSerializer<EntityReference>
    {
        #region Public Properties

        public Type ValueType => typeof(EntityReference);

        #endregion Public Properties

        #region Public Methods

        public object Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            return Deserialize(context, args);
        }

        EntityReference IBsonSerializer<EntityReference>.Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            context.Reader.ReadStartDocument();

            var result = new EntityReference(context.Reader.ReadString(), new Guid(context.Reader.ReadBinaryData().AsByteArray));

            context.Reader.ReadEndDocument();

            return result;
        }

        public void Serialize(BsonSerializationContext context, BsonSerializationArgs args, object value)
        {
            Serialize(context, args, value as EntityReference);
        }

        public void Serialize(BsonSerializationContext context, BsonSerializationArgs args, EntityReference value)
        {
            context.Writer.WriteStartDocument();
            context.Writer.WriteReference(value);
            context.Writer.WriteEndDocument();
        }

        #endregion Public Methods
    }
}