using System;

namespace Ultra.Core.Infrastructure
{
    public interface IDateTimeGetter
    {
        DateTime GetCurrentDateTime();
    }

    public class DateTimeGetter : IDateTimeGetter
    {
        public DateTime GetCurrentDateTime()
        {
            return DateTime.UtcNow;
        }
    }
}