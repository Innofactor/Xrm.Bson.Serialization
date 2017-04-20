namespace Innofactor.Xrm.Bson
{
    using Microsoft.Xrm.Sdk;
    using MongoDB.Bson.Serialization;
    using System;

    internal class OptionSetValueSerializer : IBsonSerializer<OptionSetValue>
    {
        #region Public Properties

        public Type ValueType => typeof(OptionSetValue);

        #endregion Public Properties

        #region Public Methods

        public object Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            return Deserialize(context, args);
        }

        OptionSetValue IBsonSerializer<OptionSetValue>.Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            context.Reader.ReadStartDocument();

            var result = new OptionSetValue(context.Reader.ReadInt32());

            context.Reader.ReadEndDocument();

            return result;
        }

        public void Serialize(BsonSerializationContext context, BsonSerializationArgs args, object value)
        {
            Serialize(context, args, value as OptionSetValue);
        }

        public void Serialize(BsonSerializationContext context, BsonSerializationArgs args, OptionSetValue value)
        {
            context.Writer.WriteStartDocument();

            context.Writer.WriteName("_option");
            context.Writer.WriteInt32(value.Value);

            context.Writer.WriteEndDocument();
        }

        #endregion Public Methods
    }
}