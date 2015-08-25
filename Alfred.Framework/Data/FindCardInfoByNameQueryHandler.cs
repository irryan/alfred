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
