using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alfred.Framework.Models;

namespace Alfred.Framework.Data
{
    public class DesignFindCardInfoByNameQueryHandler : IFindCardInfoByNameQueryHandler
    {
        public Task<IEnumerable<CardInfo>> Handle(FindCardInfoByNameQuery query)
        {
            return Task.FromResult(new List<CardInfo>
            {
                new CardInfo { Name = "Baron Sengir" },
                new CardInfo { Name = "Auntie Em" },
            }.AsEnumerable());
        }
    }
}
