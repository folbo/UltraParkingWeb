using System.Collections.Generic;
using System.Linq;
using AutoMapper.QueryableExtensions;
using Ultra.Core.Domain.ViewModels;
using Ultra.Core.Infrastructure.Queries;

namespace Ultra.Core.Domain.Queries.Admin
{
    public class AllOwners : IQuery<IEnumerable<OwnerVM>>
    {
    }

    public class AllOwnersQueryPerformer : QueryPerformer<AllOwners, IEnumerable<OwnerVM>>
    {
        public override IEnumerable<OwnerVM> Perform(AllOwners query)
        {
            return Data.Owners.ProjectTo<OwnerVM>().ToList();
        }
    }
}