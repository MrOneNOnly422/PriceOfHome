using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity5_PriceOfHome_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Accept data from user
            double homePrice = InputValues("Price of home >>   ");
            double interestRate = InputValues("Interest rate >>  ");
            double downPaymentPercentage = InputValues("Percent as Down Payment >>  ");

            // Compute down payment, financed amount, and monthly payment
            double downPayment = DownPayment(homePrice, downPaymentPercentage);
            double financedAmount = FinancedAmount(homePrice, downPayment);
            double monthlyPayment = MonthlyPayment(financedAmount, interestRate);

            // Compute total interest paid over 30 years
            double totalInterest = TotalInterest(financedAmount, interestRate);

            Console.WriteLine("\n");

            // Display computed values
            Console.WriteLine("Down payment             :        {0:C}", downPayment);
            Console.WriteLine("Financed amount          :        {0:C}", financedAmount);
            Console.WriteLine("Monthly payment          :        {0:C}", monthlyPayment);
            Console.WriteLine("Total interest           :        {0:C}", totalInterest);
        }




        static double InputValues(string message)
        {
            Console.Write(message);
            double value;
            while (!double.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                Console.Write(message);
            }
            return value;
        }

        static double DownPayment(double homePrice, double downPaymentPercentage)
        {
            return homePrice * (downPaymentPercentage / 100);
        }

        static double FinancedAmount(double homePrice, double downPayment)
        {
            return homePrice - downPayment;
        }

        static double MonthlyPayment(double financedAmount, double interestRate)
        {
            int numberOfPayments = 30 * 12; // 30 years of monthly payments
            double monthlyInterestRate = interestRate / 1200; // Convert annual interest rate to monthly
            return financedAmount * monthlyInterestRate / (1 - Math.Pow(1 + monthlyInterestRate, -numberOfPayments));
        }

        static double TotalInterest(double financedAmount, double interestRate)
        {
            int numberOfPayments = 30 * 12; // 30 years of monthly payments
            double monthlyInterestRate = interestRate / 1200; // Convert annual interest rate to monthly
            double totalPayments = numberOfPayments * MonthlyPayment(financedAmount, interestRate);
            return totalPayments - financedAmount;
        }
    }
}
