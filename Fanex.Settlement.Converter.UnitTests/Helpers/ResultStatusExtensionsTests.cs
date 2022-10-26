using Fanex.Settlement.Converter.Helpers;
using Xunit;

namespace Fanex.Settlement.Converter.UnitTests.Helpers;

public class ResultStatusExtensionsTests
{
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(3)]
    public void ResultStatus_FromRunningResultStatusId_ReturnsRunning(byte resultStatusId)
    {
        // Act
        var resultStatus = ResultStatusExtensions.ResultName(resultStatusId, null);

        // Arrange
        Assert.Equal("Running", resultStatus);
    }

    [Fact]
    public void ResultStatus_FromCompletedAutoResultStatusId_ReturnsCompletedAuto()
    {
        // Arrange
        const byte CompletedAutoResultStatusId = 2;

        // Act
        var resultStatus = ResultStatusExtensions.ResultName(CompletedAutoResultStatusId, null);

        // Arrange
        Assert.Equal("Completed (Auto)", resultStatus);
    }

    [Theory]
    [InlineData(4, "Completed (Manual)")]
    [InlineData(1, "Refund")]
    [InlineData(7, "Refund SDT")]
    [InlineData(0, "")]
    public void ResultStatus_FromCompletedResultStatusIdAndSettlementStatusId_ReturnsExpectedStatus(
        byte settlementStatusId,
        string expectedResultStatus)
    {
        // Arrange
        const byte CompletedResultStatusId = 5;

        // Act
        var resultStatus = ResultStatusExtensions.ResultName(CompletedResultStatusId, settlementStatusId);

        // Arrange
        Assert.Equal(expectedResultStatus, resultStatus);
    }

    [Fact]
    public void ResultStatus_FromResultStatusIdNotDefined_ReturnsNoResult()
    {
        // Act
        var resultStatus = ResultStatusExtensions.ResultName(null, null);

        // Arrange
        Assert.Equal("No Result", resultStatus);
    }
}