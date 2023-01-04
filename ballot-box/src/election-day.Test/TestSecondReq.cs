using Xunit;
using System.IO;
using System;
using election_day;
using FluentAssertions;

namespace election_day.Test;

[Collection("Sequential")]
public class TestSecondReq
{
    [Theory(DisplayName = "Start() should read the votes")]
    [InlineData(2, 2)]
    [InlineData(3, 3)]
    [InlineData(0, 0)]
    public void TestStart(int countVoters, int printExpected)
    {
        
        if (countVoters != printExpected || countVoters < 0) throw new Xunit.Sdk.XunitException();
        using StringWriter stringWriter = new StringWriter();
        using StringReader stringReader = new(String.Join("\n", countVoters));

        Console.SetOut(stringWriter);
        Console.SetIn(stringReader);

        var ballotBox = new BallotBox();
        ballotBox.Start(countVoters);

        int expected = stringWriter.ToString().Trim().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Length;
        expected.Should().Be(printExpected * 2);

    }
}