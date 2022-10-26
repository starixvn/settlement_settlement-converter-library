namespace Fanex.Settlement.Converter.Helpers;

public static class ScoreExtensions
{
    private const string Abandoned1H = "Abandoned 1H";
    private const string Abandoned2H = "Abandoned 2H";

    public static bool IsKeyScore(
        this string betStatus,
        int? halfTimeHomeScore,
        int? halfTimeAwayScore,
        int? finalHomeScore,
        int? finalAwayScore)
    {
        return betStatus.IsAbandonedHalftime(halfTimeHomeScore, halfTimeAwayScore)
            || betStatus.IsAbandonedFullTime(finalHomeScore, finalAwayScore)
            || HasScore(halfTimeHomeScore, halfTimeAwayScore, finalHomeScore, finalAwayScore);
    }

    private static bool HasScore(
        int? halfTimeHomeScore,
        int? halfTimeAwayScore,
        int? finalHomeScore,
        int? finalAwayScore)
    {
        return halfTimeHomeScore != null
            && halfTimeAwayScore != null
            && finalHomeScore != null
            && finalAwayScore != null;
    }

    private static bool IsAbandonedHalftime(this string betStatus, int? halfTimeHomeScore, int? halfTimeAwayScore)
    {
        return betStatus.IgnoreCaseContains(Abandoned1H)
            && halfTimeHomeScore != null
            && halfTimeAwayScore != null;
    }

    private static bool IsAbandonedFullTime(this string betStatus, int? finalHomeScore, int? finalAwayScore)
    {
        return betStatus.IgnoreCaseContains(Abandoned2H)
            && finalHomeScore != null
            && finalAwayScore != null;
    }
}