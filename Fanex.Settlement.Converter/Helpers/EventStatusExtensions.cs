namespace Fanex.Settlement.Converter.Helpers;

public static class EventStatusExtensions
{
    private const string Closed = "Closed";
    private const string Running = "Running";
    private const string Completed = "Completed";
    private const string ResultPending = "Result Pending";
    private const string Refund = "Refund";
    private const string RefundHt = "Refund HT";
    private const string RefundFt = "Refund FT";
    private const string Abandoned1H = "Abandoned 1H";
    private const string Abandoned2H = "Abandoned 2H";

    public static string MapToString(this string eventStatus, string betStatus, bool isPending)
    {
        return !IsCompleted(eventStatus)
            ? StatusWhenEventStatusIsNotCompleted(eventStatus, betStatus, isPending)
            : StatusWhenEventStatusIsCompleted(betStatus);
    }

    private static bool IsCompleted(string eventStatus)
    {
        return eventStatus.IgnoreCaseEquals(Completed);
    }

    private static bool IsClosedAndRunning(string eventStatus, string betStatus)
    {
        return (eventStatus.IgnoreCaseEquals(Closed) || eventStatus.IgnoreCaseEquals(Running))
            && betStatus.IgnoreCaseContains(RefundHt);
    }

    private static string StatusWhenEventStatusIsNotCompleted(string eventStatus, string betStatus, bool isPending)
    {
        if (isPending)
        {
            return ResultPending;
        }

        return IsClosedAndRunning(eventStatus, betStatus) ? RefundHt : eventStatus;
    }

    private static string StatusWhenEventStatusIsCompleted(string betStatus)
    {
        if (betStatus.IgnoreCaseContains(RefundHt))
        {
            return RefundHt;
        }

        if (betStatus.IgnoreCaseContains(RefundFt))
        {
            return RefundFt;
        }

        if (betStatus.IgnoreCaseContains(Refund))
        {
            return Refund;
        }

        if (betStatus.IgnoreCaseContains(Abandoned1H))
        {
            return Abandoned1H;
        }

        return betStatus.IgnoreCaseContains(Abandoned2H) ? Abandoned2H : Completed;
    }
}