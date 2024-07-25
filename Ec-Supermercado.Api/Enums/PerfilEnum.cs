using System.Text.Json.Serialization;

namespace Ec_Supermercado.Api.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PerfilEnum
    {
        Usuario,
        Administrador,
        SuperAdministrador
    }
}
