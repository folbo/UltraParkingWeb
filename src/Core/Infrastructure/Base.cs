using Ultra.Core.Infrastructure.Data;

namespace Ultra.Core.Infrastructure
{
    public class Base
    {
        public Base()
        {
            Data = IoC.Resolve<CoreDbContext>();
            Please = IoC.Resolve<IAssistant>();
            DateTimeGetter = IoC.Resolve<IDateTimeGetter>();
        }

        public CoreDbContext Data { get; }
        public IAssistant Please { get; }
//        public ILogger Logger { get; set; }
        public IDateTimeGetter DateTimeGetter { get; }
    }
}