namespace TheatricalPlayersRefactoringKata;

public class Performance
{
    public Performance(string playID, int audience)
    {
        PlayID = playID;
        Audience = audience;
    }

    public string PlayID { get; set; }

    public int Audience { get; set; }
}
