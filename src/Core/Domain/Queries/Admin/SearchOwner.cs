using System.Collections.Generic;
using System.Linq;
using AutoMapper.QueryableExtensions;
using Ultra.Core.Domain.ViewModels;
using Ultra.Core.Infrastructure.Queries;

namespace Ultra.Core.Domain.Queries.Admin
{
    public class SearchOwner : IQuery<IEnumerable<OwnerVM>>
    {
        public string Term { get; set; }
    }

    public class SearchOwnerQueryPerformer : QueryPerformer<SearchOwner, IEnumerable<OwnerVM>>
    {
        public override IEnumerable<OwnerVM> Perform(SearchOwner query)
        {
            query.Term = query.Term ?? "";
            return Data.Owners.Where(owner => owner.Name.Contains(query.Term)).ProjectTo<OwnerVM>().ToList();
        }
    }
}