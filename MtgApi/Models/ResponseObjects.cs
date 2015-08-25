using System;
using System.Collections.Generic;

namespace MtgApi.Models
{
    public class Query
    {
        public string Command { get; set; }
        public string Key { get; set; }
        public string Conditional { get; set; }
        public string Value { get; set; }
    }

    public abstract class ResponseBase
    {
        public Query[] Query { get; set; }
    }

    public class CardInformationResponse : ResponseBase
    {
        public IEnumerable<CardInfo> Cards { get; set; }
        public int Total { get; set; }
        public int PerPage { get; set; }
        public object Links { get; set; }
    }

    public class ForeignName
    {
        public string Language { get; set; }
        public string Name { get; set; }
        public int MultiverseId { get; set; }
    }

    public class Ruling
    {
        public DateTime Date { get; set; }
        public string Text { get; set; }
    }

    public class CardInfo
    {
        public string Artist { get; set; }
        public string Border { get; set; }
        public float Cmc { get; set; }
        public string[] Colors { get; set; }
        public string Flavor { get; set; }
        public ForeignName[] ForeignNames { get; set; }
        public int? Hand { get; set; }
        public object Images { get; set; }
        public string Layout { get; set; }
        public object Legalities { get; set; }
        public int? Life { get; set; }
        public object Links { get; set; }
        public int? Loyalty { get; set; }
        public string ManaCost { get; set; }
        public int MultiverseId { get; set; }
        public string Name { get; set; }
        public string[] Names { get; set; }
        public string Number { get; set; }
        public string OriginalText { get; set; }
        public string OriginalType { get; set; }
        public string Power { get; set; }
        public string[] Printings { get; set; }
        public string Rarity { get; set; }
        public Ruling[] Rulings { get; set; }
        public string Set { get; set; }
        public string[] Subtypes { get; set; }
        public string[] Supertypes { get; set; }
        public string Text { get; set; }
        public string Toughness { get; set; }
        public string Type { get; set; }
        public string[] Types { get; set; }
        public int[] Variations { get; set; }
        public string Watermark { get; set; }
    }
}
