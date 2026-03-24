namespace FlightLogNet.Tests.Operation
{
    using FlightLogNet.Operation;

    using Xunit;

    public class GetExportToCsvOperationTests(GetExportToCsvOperation getExportToCsvOperation)
    {
        // TODO 6.1: Odstraňte skip a doplňte test, aby otestoval vrácený CSV soubor.
        [Fact(Skip = "Not implemented.")]
        public void Execute_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            //TestDatabaseGenerator.DeleteOldDatabase(configuration);
            //DateTime fixedDate = new DateTime(2020, 1, 2, 16, 57, 10, DateTimeKind.Local);
            //TestDatabaseGenerator.CreateTestDatabaseWithFixedTime(fixedDate, configuration);
            var expectedCsv = ExpectedResult.export;

            // Act
            var result = getExportToCsvOperation.Execute();

            // Assert
            //Assert.Equal(expectedCsv, result);
        }
    }
}
