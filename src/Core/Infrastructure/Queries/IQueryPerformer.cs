namespace Ultra.Core.Infrastructure.Queries
{
    public interface IQueryPerformer<in TQuery, out TResult> where TQuery : IQuery<TResult>
    {
        TResult Perform(TQuery query);
    }

    public abstract class QueryPerformer<TQuery,TResult> : Base, IQueryPerformer<TQuery,TResult> where TQuery : IQuery<TResult>
    {
        public abstract TResult Perform(TQuery query);
    }
}