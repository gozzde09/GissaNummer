

namespace GuessNumberGameApp
{
  internal class UI
  {
    private HandleHighScore scoreList;
    private List<Score> scores;

    public UI()
    {
      scoreList = new HandleHighScore();
      scores = new List<Score>();
    }

    public string DrawUI()
    {
      Console.WriteLine("🎲 Välkommen till Gissa Nummer!");
      Console.WriteLine("====================================");

      // Hämta tidigare highscore
      scores = scoreList.FetchHighScore();

      if (scores.Count == 0)
      {
        Console.WriteLine("Ingen har spelat tidigare. Bli den första! 😎");
      }
      else
      {
        Console.WriteLine("Highscore-lista:");
        foreach (Score s in scores)
        {
          Console.WriteLine($"{s.PlayerName} - {s.Attempts} gissningar");
        }
      }

      Console.WriteLine("\nVill du spela? (ja/nej)");
      string answer = Console.ReadLine();
      return answer;
    }
  }
}
