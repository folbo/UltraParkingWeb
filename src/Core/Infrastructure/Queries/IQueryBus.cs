namespace Ultra.Core.Infrastructure.Queries
{
    public interface IQueryBus
    {
        TResult Perform<TResult>(IQuery<TResult> query);
        bool Check(IQuery<bool> query);
    }

    public class QueryBus : IQueryBus
    {
        public TResult Perform<TResult>(IQuery<TResult> query)
        {
            var handlerType = typeof (IQueryPerformer<,>).MakeGenericType(query.GetType(), typeof (TResult));

            var performer = IoC.Resolve(handlerType);
            return (TResult) ((dynamic) performer).Perform((dynamic) query);
        }

        public bool Check(IQuery<bool> check)
        {
            return Perform(check);
        }

        public void CastToMyType<T>(object givenObject) where T : class
        {
            var newObject = givenObject as T;
        }
    }
}