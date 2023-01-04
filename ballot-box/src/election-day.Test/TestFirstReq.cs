using Xunit;
using System.IO;
using System;
using election_day;
using FluentAssertions;

namespace election_day.Test;

[Collection("Sequential")]
public class TestFirstReq
{
    [Theory(DisplayName = "GetCountVoters Should return the user input")]
    [InlineData(1)]
    [InlineData(-1)]
    public void TestGetCountVoters(int countVoters)
    {
        using (var stringReader = new StringReader(countVoters.ToString()))
        {

            var ballotBox = new BallotBox();
            Console.SetIn(stringReader);
            var result = ballotBox.GetCountVoters();
            if (countVoters < 1)
            {
                throw new Xunit.Sdk.XunitException();
            }
            else
            {
                result.Should().Be(countVoters);
            }
        }
    }
}
