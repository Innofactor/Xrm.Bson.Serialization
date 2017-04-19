namespace Innofactor.Xrm.Bson
{
    using System;
    using Microsoft.Xrm.Sdk;
    using MongoDB.Bson.Serialization;

    public class SerializationPrivider : IBsonSerializationProvider
    {
        #region Public Methods

        public IBsonSerializer GetSerializer(Type type)
        {
            if (type == typeof(Entity))
            {
                return new EntitySerializer();
            }
            else if (type == typeof(EntityReference))
            {
                return new EntityReferenceSerializer();
            }
            else if (type == typeof(OptionSetValue))
            {
                return new OptionSetValueSerializer();
            }
            else if (type == typeof(Money))
            {
                return new MoneySerializer();
            }

            return default(IBsonSerializer);
        }

        #endregion Public Methods
    }
}
