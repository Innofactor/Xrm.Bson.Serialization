namespace Innofactor.Xrm.Bson.Extensions
{
    using Microsoft.Xrm.Sdk;
    using MongoDB.Bson;
    using MongoDB.Bson.IO;
    using MongoDB.Bson.Serialization;
    using System.Collections.Generic;

    internal static class Common
    {
        #region Internal Methods

        internal static KeyValuePair<string, object> ReadDocument(this IBsonReader reader)
        {
            var key = reader.ReadName();
            var value = default(object);

            // Setting bookmark to beginning of the document to rewind reader later
            var beginning = reader.GetBookmark();

            reader.ReadStartDocument();

            // Reading type before rewinding to the start
            var field = reader.ReadName();

            // Rewinding back to the start
            reader.ReturnToBookmark(beginning);

            switch (field)
            {
                case "_name":
                    value = BsonSerializer.Deserialize<EntityReference>(reader);
                    break;

                case "_money":
                    value = BsonSerializer.Deserialize<Money>(reader);
                    break;

                case "_option":
                    value = BsonSerializer.Deserialize<OptionSetValue>(reader);
                    break;
            }

            reader.ReadEndDocument();

            return new KeyValuePair<string, object>(key, value);
        }

        internal static void WriteReference(this IBsonWriter writer, EntityReference value)
        {
            writer.WriteName("_name");
            writer.WriteString(value.LogicalName);

            writer.WriteName("_id");
            writer.WriteBinaryData(new BsonBinaryData(value.Id));
        }

        #endregion Internal Methods
    }
}