using Alfred.Framework.Models;
using System.Collections.Generic;

namespace Alfred.Framework.Data
{
    public class FindCardInfoByNameQuery : IQuery<IEnumerable<CardInfo>>
    {
        public string Name { get; set; }
    }
}
