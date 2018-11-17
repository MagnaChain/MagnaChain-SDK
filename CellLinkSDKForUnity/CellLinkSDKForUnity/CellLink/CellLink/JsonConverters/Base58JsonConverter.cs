﻿#if !NOJSONNET
using CellLink;
using Newtonsoft.Json;
using System;
using System.Reflection;

namespace CellLink.JsonConverters
{
#if !NOJSONNET
	public
#else
	internal
#endif
	class Base58DataJsonConverter : JsonConverter
    {
		public Base58DataJsonConverter()
		{

		}
		public Base58DataJsonConverter(Network network)
		{
			Network = network;
		}
        public override bool CanConvert(Type objectType)
        {
            return IxFuck.IsIsAssignableFrom(typeof(Base58Data), objectType)
                || IxFuck.IsIsAssignableFrom(typeof(IDestination), objectType)
                || objectType.AssemblyQualifiedName.Contains("CellLink");

            //return
            //    typeof(Base58Data).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo()) ||
            //    (typeof(IDestination).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo()) && objectType.GetTypeInfo().AssemblyQualifiedName.Contains("CellLink"));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            var result = Base58Data.GetFromBase58Data(reader.Value.ToString());
            if (result == null)
            {
                throw new JsonObjectException("Invalid Base58Check data", reader);
            }
            if (Network != null)
            {
                if (result.Network != Network)
                {
                    throw new JsonObjectException("Invalid Base58Check network", reader);
                }
            }
            //if (!objectType.GetTypeInfo().IsAssignableFrom(result.GetType().GetTypeInfo()))
            if ( !IxFuck.IsIsAssignableFrom(objectType, result.GetType()))
            {
                throw new JsonObjectException("Invalid Base58Check type expected " + objectType.Name + ", actual " + result.GetType().Name, reader);
            }
            return result;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var base58 = value as Base58Data;
            if (base58 != null)
            {
                writer.WriteValue(value.ToString());
            }
        }

        public Network Network
        {
            get;
            set;
        }
    }
}
#endif