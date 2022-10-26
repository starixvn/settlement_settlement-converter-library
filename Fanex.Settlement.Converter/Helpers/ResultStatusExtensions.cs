namespace Fanex.Settlement.Converter.Helpers;

public static class ResultStatusExtensions
{
    private enum ResultStatus
    {
        Initial,
        Running,
        AutoSettled,
        ManuallyUpdatedScore,
        NoTicket,
        ManuallySettled
    }

    private enum SettlementStatus
    {
        Running,
        Refund,
        RefundHt,
        RefundFt,
        Completed,
        Abandoned1H,
        Abandoned2H,
        RefundSdt
    }

    public static string ResultName(this byte? resultStatusId, byte? settlementStatusId)
    {
        switch (resultStatusId)
        {
            case (byte)ResultStatus.Initial:
            case (byte)ResultStatus.Running:
            case (byte)ResultStatus.ManuallyUpdatedScore:
                return "Running";

            case (byte)ResultStatus.AutoSettled:
                return "Completed (Auto)";

            case (byte)ResultStatus.ManuallySettled:
                return settlementStatusId switch
                {
                    (byte)SettlementStatus.Completed => "Completed (Manual)",
                    (byte)SettlementStatus.Refund => "Refund",
                    (byte)SettlementStatus.RefundSdt => "Refund SDT",
                    _ => string.Empty
                };

            default:
                return "No Result";
        }
    }
}