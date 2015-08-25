using Alfred.Framework.Models;
using System.Collections.Generic;

namespace Alfred.Framework.Data
{
    public interface IFindCardInfoByNameQueryHandler : IQueryHandler<FindCardInfoByNameQuery, IEnumerable<CardInfo>> { }
}
