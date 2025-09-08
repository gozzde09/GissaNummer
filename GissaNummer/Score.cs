using System;

namespace GuessNumberGameApp
{
  internal class Score : IComparable<Score>
  {
    public string PlayerName { get; set; }
    public int Attempts { get; set; }

    public Score() { }

    public Score(string playerName, int attempts)
    {
      PlayerName = playerName;
      Attempts = attempts;
    }

    public int CompareTo(Score other)
    {
      if (other == null) return 1;
      return Attempts.CompareTo(other.Attempts); // sortera stigande
    }
  }
}
