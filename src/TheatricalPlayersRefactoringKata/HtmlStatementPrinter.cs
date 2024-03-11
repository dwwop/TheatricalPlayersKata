using System;
using System.Globalization;

namespace TheatricalPlayersRefactoringKata;

public class HtmlStatementPrinter : StatementPrinter
{
    
    
    protected override string GetPlayLine(Play play, Performance perf, CultureInfo cultureInfo, int thisAmount)
    {
        return "<p>" + base.GetPlayLine(play, perf, cultureInfo, thisAmount) + "</p>";
    }

    protected override string GetAmountOwned(CultureInfo cultureInfo, int totalAmount)
    {
        return "<p>" + base.GetAmountOwned(cultureInfo, totalAmount) + "</p>";
    }

    protected override string GetEarnedCredits(int volumeCredits)
    {
        return "<p>" + base.GetEarnedCredits(volumeCredits) + "</p>";
    }

    protected override string GetStatement(string customer)
    {
        return "<p>" + base.GetStatement(customer) + "</p>";
    }
}
