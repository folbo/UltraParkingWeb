using System.Collections.Generic;
using System.Linq;
using Ultra.Core.Domain.Entities;
using Ultra.Core.Infrastructure.Queries;

namespace Ultra.Core.Domain.Queries
{
    public class AllProjects : IQuery<IEnumerable<Project>>
    {}

    public class GetNewsQueryPerformer : QueryPerformer<AllProjects, IEnumerable<Project>>
    {
        public override IEnumerable<Project> Perform(AllProjects query)
        {
            return Data.Projects.ToList();
        }
    }
}