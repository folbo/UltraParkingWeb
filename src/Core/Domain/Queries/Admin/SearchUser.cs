using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper.QueryableExtensions;
using Ultra.Core.Domain.ViewModels;
using Ultra.Core.Infrastructure.Queries;

namespace Ultra.Core.Domain.Queries.Admin
{
    public class SearchUser : IQuery<IEnumerable<UserVM>>
    {
        public string Term { get; set; }
    }

    public class SearchUserQueryPerformer : QueryPerformer<SearchUser, IEnumerable<UserVM>>
    {
        public override IEnumerable<UserVM> Perform(SearchUser query)
        {
            query.Term = query.Term ?? "";
            return Data.Users
                .Where(user=>!Data.Owners.Any(owner => owner.Id.ToString().Equals(user.Id,StringComparison.InvariantCultureIgnoreCase)))
                .Where(user => user.UserName.Contains(query.Term))
                .ToList()
                .Select(user => new UserVM()
                {
                    Id = Guid.Parse(user.Id),
                    Name = user.UserName,
                });
        }
    }
}