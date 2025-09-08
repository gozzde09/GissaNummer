

namespace GuessNumberGameApp
{
  internal class UI
  {
    private HandleHighScore scoreList; 
    private List<Score> scores; 

    public UI() // Konstructor
    { 
      scoreList = new HandleHighScore(); 
      scores = new List<Score>(); 
    }

    public string DrawUI() // Show messages and return answer
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
        Console.WriteLine("\n Highscores-lista:");
        int index = 1; 
        foreach (Score s in scores)
        {
          Console.WriteLine($"{index}. {s.PlayerName} - {s.Attempts} gissningar");
          index++; 
        }
      }

      Console.WriteLine("\nTryck på Y för att spela eller på en annan knapp för att avsluta:");

      // Svar - nullable string
      string? answer = Console.ReadLine();
      return answer ?? string.Empty;  // Om svar är null, returnera tom sträng

      // *** Alternativt utan null-coalescing operator ***
      // string? answer = Console.ReadLine();
      // return answer!;

    }
  }
}
