using System.Collections.Generic;

namespace TheatricalPlayersRefactoringKata;

public class Invoice
{
    public Invoice(string customer, List<Performance> performance)
    {
        Customer = customer;
        Performances = performance;
    }

    public string Customer { get; set; }

    public List<Performance> Performances { get; set; }
}
