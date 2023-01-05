using Xunit;
using FluentAssertions;
using System;

namespace BiggestNumber.Test;

public class TestBiggestNumber
{
  [Theory(DisplayName = "IdentifyBiggestNumber should return the biggest int")]
  [InlineData(7, 8, 9, 9)]
  public void TestIdentifyBiggestNumberSucess(int first, int second, int third, int expectedNumber)
  {
    int biggest = BiggestNumber.IdentifyBiggestNumber(first, second, third);
    biggest.Should().Be(expectedNumber);
  }
}