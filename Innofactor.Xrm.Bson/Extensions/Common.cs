namespace Innofactor.Xrm.Bson.Extensions
{
    using Microsoft.Xrm.Sdk;
    using MongoDB.Bson;
    using MongoDB.Bson.IO;

    internal static class Common
    {
        internal static void WriteReference(this IBsonWriter writer, EntityReference value)
        {
            writer.WriteName("_name");
            writer.WriteString(value.LogicalName);

            writer.WriteName("_id");
            writer.WriteBinaryData(new BsonBinaryData(value.Id));
        }
    }
}
