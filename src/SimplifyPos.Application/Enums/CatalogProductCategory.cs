using System.Text.Json.Serialization;

namespace SimplifyPos.Application.Enums;

[JsonConverter(typeof(JsonStringEnumConverter<CatalogProductCategory>))]
public enum CatalogProductCategory
{
    Books,
    Toys,
    Clothing
}