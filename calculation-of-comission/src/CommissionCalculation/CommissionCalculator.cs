using System;

namespace CommissionCalculation;
public class CommissionCalculator
{
  public const decimal CommissionPerCarSold = 250;
  const decimal THREE_PERCENT = 0.03M;
  public decimal FixedSalary { get; set; }
  public int AmountCarsSold { get; set; }
  public decimal TotalSalesValue { get; set; }
  public decimal FinalSalary { get; set; }
  public decimal CommissionFromAmountOfCars { get; set; }
  public decimal CommissionFromTotal { get; set; }

  public void CalculateFinalSalary(decimal fixedSalary, int amountCarsSold, decimal totalSalesValue)
  {
    FixedSalary = fixedSalary;
    AmountCarsSold = amountCarsSold;
    TotalSalesValue = totalSalesValue;
    CommissionFromAmountOfCars = AmountCarsSold * CommissionPerCarSold;
    CommissionFromTotal = TotalSalesValue * THREE_PERCENT;
    FinalSalary = FixedSalary + CommissionFromAmountOfCars + CommissionFromTotal;
  }

  public void ShowFinalSalary(string contributorName, string month)
  {
    Console.WriteLine(
          "O colaborador " + contributorName + " neste mês de " + month + " obteve o salário final de R$" + FinalSalary.ToString("N2") + " referente à:\n" +
          "SALARIO FIXO: R$" + FixedSalary.ToString("N2") + "\n" +
          "TOTAL DE CARROS VENDIDOS: " + AmountCarsSold + "\n" +
          "VALOR TOTAL DE VENDAS NO MES: R$" + TotalSalesValue.ToString("N2") + "\n" +
          "COMISSÃO POR CARROS VENDIDOS: R$" + CommissionFromAmountOfCars.ToString("N2") + "\n" +
          "COMISSÃO DE 3% DO TOTAL DE VENDAS: R$" + CommissionFromTotal.ToString("N2") + "\n"
        );
  }
}
