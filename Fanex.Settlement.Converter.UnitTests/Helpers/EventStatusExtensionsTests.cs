using Fanex.Settlement.Converter.Helpers;
using NSubstitute;
using Xunit;

namespace Fanex.Settlement.Converter.UnitTests.Helpers;

public class EventStatusExtensionsTests
{
    [Theory]
    [InlineData("completed", "FL:0-0;Refund HT;", "Refund HT")]
    [InlineData("Completed", "FL:0-0;Refund FT;", "Refund FT")]
    [InlineData("Completed", "FL:0-0;Refund;", "Refund")]
    [InlineData("completed", "FL:2-1;Abandoned 1H;", "Abandoned 1H")]
    [InlineData("Completed", "FL:0-0;Abandoned 2H;", "Abandoned 2H")]
    [InlineData("completed", "FL:0-0;", "Completed")]
    public void MapToString_EventStatusIsCompleted_ReturnsRightExpectedMatchStatus(string eventStatus, string betStatus, string expectedMatchStatus)
    {
        // Act
        var actualMatchStatus = eventStatus.MapToString(betStatus, false);

        // Assert
        Assert.Equal(expectedMatchStatus, actualMatchStatus);
    }

    [Theory]
    [InlineData("running")]
    [InlineData("closed")]
    [InlineData("internal")]
    [InlineData("postponed")]
    public void MapToString_IsPending_ReturnsResultPending(string eventStatus)
    {
        // Act
        var actualMatchStatus = eventStatus.MapToString(Arg.Any<string>(), true);

        // Assert
        var expectedMatchStatus = "Result Pending";
        Assert.Equal(expectedMatchStatus, actualMatchStatus);
    }

    [Theory]
    [InlineData("Closed", "", "Closed")]
    [InlineData("Closed", "FL:0-0;Refund HT;", "Refund HT")]
    [InlineData("Running", "", "Running")]
    [InlineData("running", "FL:0-0;Refund HT;", "Refund HT")]
    [InlineData("internal", "", "internal")]
    [InlineData("internal", "FL:0-0;Refund HT;", "internal")]
    [InlineData("postponed", "", "postponed")]
    [InlineData("postponed", "FL:0-0;Refund HT;", "postponed")]
    public void MapToString_IsNotPending_ReturnsExpectedMatchStatus(string eventStatus, string betStatus, string expectedMatchStatus)
    {
        // Act
        var actualMatchStatus = eventStatus.MapToString(betStatus, false);

        // Assert
        Assert.Equal(expectedMatchStatus, actualMatchStatus);
    }
}