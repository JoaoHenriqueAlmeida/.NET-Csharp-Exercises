using Xunit;
using System.IO;
using System;
using TikTakToe;
using FluentAssertions;

namespace TikTakToe.Test;

[Collection("Sequential")]
public class TestTikTakToeGame
{
    [Theory(DisplayName = "Deve preencher o tabuleiro com o caractere correto na posição adequada")]
    [InlineData(
        1,
        1,
        'x',
        new char[] {
            ' ', ' ', ' ',
            ' ', 'x', ' ',
            ' ', ' ', ' '
        }
    )]
    public void TestMakeMove(int lineEntry, int columnEntry, char playerEntry, char[] expected)
    {
        var game = new TikTakToeGame();
        game.makeMove(lineEntry, columnEntry, playerEntry);
        char[] unidimensionalArray = new char[9];
        for (int xAxis = 0; xAxis < 3; xAxis++)
        {
            for (int yAxis = 0; yAxis < 3; yAxis++)
            {
                unidimensionalArray[xAxis * 3 + yAxis] = game.board[xAxis, yAxis];
            }
        }
        unidimensionalArray.Should().BeEquivalentTo(expected);
    }

    [Theory(DisplayName = "Deve imprimir o tabuleiro")]
    [InlineData(
        new char[] {
            'x', 'x', 'x',
            'x', 'x', 'x',
            'x', 'x', 'x'
        },
        new string[] {
            "x x x",
            "x x x",
            "x x x"
        }
    )]
    public void TestPrintBoard(char[] entry, string[] expected)
    {
        using (var stringWriter = new StringWriter())
        {
            Console.SetOut(stringWriter);
            var game = new TikTakToeGame();
            game.board = fromArrayToMultiDimArray(entry, 3, 3);
            game.printBoard();
            var result = stringWriter.ToString().Trim().Split('\n');
            result.Should().BeEquivalentTo(expected);
        }
    }

    [Theory(DisplayName = "Deve retornar corretamente se o jogo acabou ou não")]
    [InlineData(
        new char[] {
            'x', 'x', 'x',
            'x', 'x', 'x',
            'x', 'x', 'x'
        },
        'x',
        true
    )]
    public void TestIsGameOver(char[] entry, char expectedWinner, bool expectedReturn)
    {
        throw new NotImplementedException();
    }

    [Theory(DisplayName = "Deve imprimir o vencedor correto do jogo")]
    [InlineData(' ', "Empate! Deu velha!")]
    public void TestPrintResults(char entry, string expected)
    {
        throw new NotImplementedException();
    }

    public static char[,] fromArrayToMultiDimArray(char[] array, int lines, int columns)
    {
        char[,] result = new char[lines, columns];
        for (int i = 0; i < array.Length; i++)
        {
            result[i / columns, i % columns] = array[i];
        }
        return result;
    }
}
