using System.Text.Json.Serialization;

namespace GatheringTheMagic.Application.ExternalServices.DTOS.Response;

public class CardResponse
{
    public string? Name { get; set; }
    public List<string>? Names { get; set; }
    public string? ManaCost { get; set; }
    public decimal? Cmc { get; set; }
    public List<string>? Colors { get; set; }
    public List<string>? ColorIdentity { get; set; }
    public string? Type { get; set; }
    public List<string>? Supertypes { get; set; }
    public List<string>? Types { get; set; }
    public List<string>? Subtypes { get; set; }
    public string? Rarity { get; set; }
    public string? Set { get; set; }
    public string? Text { get; set; }
    public string? Artist { get; set; }
    public string? Number { get; set; }
    public string? Power { get; set; }
    public string? Toughness { get; set; }
    public string? Layout { get; set; }
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public int? Multiverseid { get; set; }
    public string? ImageUrl { get; set; }
    public List<Ruling>? Rulings { get; set; }
    public List<ForeignName>? ForeignNames { get; set; }
    public List<string>? Printings { get; set; }
    public string? OriginalText { get; set; }
    public string? OriginalType { get; set; }
    public string? Id { get; set; }
}

public class ForeignName
{
    public string? Name { get; set; }
    public string? Language { get; set; }
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public int? Multiverseid { get; set; }
}

public class Ruling
{
    public DateTime? Date { get; set; }
    public string? Text { get; set; }
}
