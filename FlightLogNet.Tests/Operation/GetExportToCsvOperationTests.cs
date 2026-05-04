namespace FlightLogNet.Tests.Operation
{
    using System;
    using System.Collections.Generic;
    using Castle.Core.Configuration;
    using FlightLogNet.Operation;
    using Microsoft.Extensions.Configuration;
    using Xunit;

    public class GetExportToCsvOperationTests(GetExportToCsvOperation getExportToCsvOperation)
    {
        // TODO 6.1: Odstraňte skip a doplňte test, aby otestoval vrácený CSV soubor.
        [Fact]
        public void Execute_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string> {}).Build();

            TestDatabaseGenerator.DeleteOldDatabase(configuration);
            DateTime fixedDate = new DateTime(2020, 1, 2, 16, 57, 10, DateTimeKind.Local);
            TestDatabaseGenerator.CreateTestDatabaseWithFixedTime(fixedDate, configuration);
            var expectedCsv = ExpectedResult.export;

            // Act
            var result = getExportToCsvOperation.Execute();

            // Assert
            Assert.Equal(expectedCsv, result);
        }
    }
}
