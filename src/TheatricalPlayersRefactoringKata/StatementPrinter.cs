using System;
using System.Collections.Generic;
using System.Globalization;

namespace TheatricalPlayersRefactoringKata
{
    public class StatementPrinter
    {
        public string Print(Invoice invoice, Dictionary<string, Play> plays)
        {
            var totalAmount = 0;
            var volumeCredits = 0;
            var result = GetStatement(invoice.Customer);
            CultureInfo cultureInfo = new CultureInfo("en-US");

            foreach(var perf in invoice.Performances) 
            {
                var play = plays[perf.PlayID];
                var thisAmount = GetAmount(play, perf);
                volumeCredits += GetVolumeCredits(perf, play);               

                // print line for this order
                result += GetPlayLine(play, perf, cultureInfo, thisAmount);
                totalAmount += thisAmount;
            }

            result += GetAmountOwned(cultureInfo, totalAmount); 
            result += GetEarnedCredits(volumeCredits);
            return result;
        }

        private string GetPlayLine(Play play, Performance perf, CultureInfo cultureInfo, int thisAmount)
        {
            return string.Format(cultureInfo, "  {0}: {1:C} ({2} seats)\n", play.Name, Convert.ToDecimal(thisAmount / 100), perf.Audience);
        }

        private string GetAmountOwned(CultureInfo cultureInfo, int totalAmount)
        {
            return string.Format(cultureInfo, "Amount owed is {0:C}\n", Convert.ToDecimal(totalAmount / 100));
        }

        private string GetEarnedCredits(int volumeCredits)
        {
            return $"You earned {volumeCredits} credits\n";
        }

        private string GetStatement(string customer)
        {
            return $"Statement for {customer}\n";
        }
 
        private int GetVolumeCredits(Performance perf, Play play)
        {
            // add volume credits
            var volumeCredits = Math.Max(perf.Audience - 30, 0);
            // add extra credit for every ten comedy attendees
            if ("comedy" == play.Type) volumeCredits += (int)Math.Floor((decimal)perf.Audience / 5);
            return volumeCredits;
        }
        
        private static int GetAmount(Play play, Performance perf)
        {
            int thisAmount;
            switch (play.Type) 
            {
                case "tragedy":
                    thisAmount = 40000;
                    if (perf.Audience > 30) {
                        thisAmount += 1000 * (perf.Audience - 30);
                    }
                    break;
                case "comedy":
                    thisAmount = 30000;
                    if (perf.Audience > 20) {
                        thisAmount += 10000 + 500 * (perf.Audience - 20);
                    }
                    thisAmount += 300 * perf.Audience;
                    break;
                default:
                    throw new Exception("unknown type: " + play.Type);
            }

            return thisAmount;
        }
    }
}
