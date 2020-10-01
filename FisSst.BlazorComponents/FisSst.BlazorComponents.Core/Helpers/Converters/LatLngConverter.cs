using FisSst.Maps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FisSst.Maps.Helpers.Converters
{
    class LatLngConverter : JsonConverter<LatLng>
    {
        public override LatLng Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            double latitude = reader.GetDouble();
            double longitude = reader.GetDouble();
            return new LatLng(latitude, longitude);
        }

        public override void Write(
            Utf8JsonWriter writer,
            LatLng latLng,
            JsonSerializerOptions options)
        {
            writer.WriteStartArray();
            writer.WriteNumberValue(latLng.Value[0]);
            writer.WriteNumberValue(latLng.Value[1]);
            writer.WriteEndArray();
        }                
    }
}
