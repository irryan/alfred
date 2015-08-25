using Alfred.Framework.Models;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Diagnostics;
using Alfred.Framework.Extensions;

namespace Alfred.Framework.Data
{
    namespace MtgApi.Models
    {
        class Query
        {
            public string Command { get; set; }
            public string Key { get; set; }
            public string Conditional { get; set; }
            public string Value { get; set; }
        }

        abstract class ResponseBase
        {
            public Query[] Query { get; set; }
        }

        class CardInformationResponse : ResponseBase
        {
            public IEnumerable<CardInfo> Cards { get; set; }
            public int Total { get; set; }
            public int PerPage { get; set; }
            public object Links { get; set; }
        }

        class ForeignName
        {
            public string Language { get; set; }
            public string Name { get; set; }
            public int MultiverseId { get; set; }
        }

        class Ruling
        {
            public DateTime Date { get; set; }
            public string Text { get; set; }
        }

        class CardInfo
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

    public class FindCardInfoByNameQueryHandler : IFindCardInfoByNameQueryHandler
    {
        public async Task<IEnumerable<CardInfo>> Handle(FindCardInfoByNameQuery query)
        {
            var uri = new Uri("https://api.mtgapi.com/v2/cards")
                .AddQuery("name", query?.Name);

            var request = WebRequest.Create(uri);

            using (var response = await request.GetResponseAsync())
            using (var stream = response.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var body = await reader.ReadToEndAsync();
                try
                {
                    var apiResponseObj = JsonConvert.DeserializeObject<MtgApi.Models.CardInformationResponse>(body);
                    return apiResponseObj.Cards.Select(c => new Models.CardInfo { Name = c.Name });
                }
                catch (Exception ex)
                {
                    Debugger.Break();
                    throw;
                }
            }
        }
    }
}
