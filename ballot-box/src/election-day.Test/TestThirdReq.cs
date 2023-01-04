using Xunit;
using System.IO;
using System;
using election_day;
using FluentAssertions;

namespace election_day.Test;

[Collection("Sequential")]
public class TestThirdReq
{
    [Theory(DisplayName = "Should Print the result")]
    [InlineData(new string[] { "6", "1", "1", "5", "A", "3", "2" }, 2, 1, 1, 2)]
    public void TestPrintResult(
        string[] entrys,
        int expectedReceivedOption1,
        int expectedReceivedOption2,
        int expectedReceivedOption3,
        int expectedOptionNull)
    {
        var ballotBox = new BallotBox();
        for (int i = 1; i < entrys.Length; i += 1)
        {
            switch (entrys[i])

            {
                case "1":
                    ballotBox.receivedOption1 += 1;
                    break;
                case "2":
                    ballotBox.receivedOption2 += 1;
                    break;
                case "3":
                    ballotBox.receivedOption3 += 1;
                    break;
                default:
                    ballotBox.optionNull += 1;
                    break;
            }
        }
        ballotBox.receivedOption1.Should().Be(expectedReceivedOption1);
        ballotBox.receivedOption2.Should().Be(expectedReceivedOption2);
        ballotBox.receivedOption3.Should().Be(expectedReceivedOption3);
        ballotBox.optionNull.Should().Be(expectedOptionNull);
        
        using var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        
        var expected = (
             $"A opção 1 recebeu: {expectedReceivedOption1} voto(s)\n" +
            $"A opção 2 recebeu: {expectedReceivedOption2} voto(s)\n" +
            $"A opção 3 recebeu: {expectedReceivedOption3} voto(s)\n" +
            $"Total de votos anulados:{expectedOptionNull}voto(s)"
        );
        
        ballotBox.PrintResult();
        
        stringWriter.ToString().Trim().Should().Be(expected);
    }
}