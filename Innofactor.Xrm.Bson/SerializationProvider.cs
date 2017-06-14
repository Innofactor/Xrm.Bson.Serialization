using System;
using Microsoft.Xrm.Sdk;
using MongoDB.Bson.Serialization;

namespace Innofactor.Xrm.Bson
{
    public class SerializationPrivider : IBsonSerializationProvider
    {
        #region Public Methods

        public IBsonSerializer GetSerializer(Type type)
        {
            if (type == typeof(Entity))
            {
                return new EntitySerializer();
            }
            if (type == typeof(EntityReference))
            {
                return new EntityReferenceSerializer();
            }
            if (type == typeof(OptionSetValue))
            {
                return new OptionSetValueSerializer();
            }
            return type == typeof(Money) ? new MoneySerializer() : default(IBsonSerializer);
        }

        #endregion Public Methods
    }
}