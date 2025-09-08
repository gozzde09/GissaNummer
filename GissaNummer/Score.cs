
namespace GuessNumberGameApp
{
  internal class Score : IComparable<Score>
  {
    public string PlayerName { get; set; } = string.Empty; // Initialize to avoid CS8618
    public int Attempts { get; set; }

    public Score() { } // Parameterlös konstructor

    public Score(string playerName, int attempts) // Konstruktor med parametrar
    {
      PlayerName = playerName;
      Attempts = attempts;
    }

    public int CompareTo(Score? other)
    {
      if (other == null) return 1;
      return Attempts.CompareTo(other.Attempts); // sortera stigande
    }
  }
}
