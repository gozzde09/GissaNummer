
namespace GuessNumberGameApp
{
  public class GuessNumberGame
  {
    private bool runGame;
    private Score gameScore;
    private HandleHighScore saveScoreList;

    public GuessNumberGame()
    {
      gameScore = new Score();
      saveScoreList = new HandleHighScore();
    }

    public void PlayGame(string answer)
    {
      runGame = WillPlay(answer);
      List<Score> gameScores = new List<Score>();

      while (runGame)
      {
        Random random = new Random();
        int numberToGuess = random.Next(1, 101);
        int guessCount = 0;
        bool correct = false;

        Console.WriteLine("Jag har valt ett tal mellan 1 och 100. Gissa vilket!");

        while (!correct)
        {
          Console.Write("Din gissning: ");
          int guess = Convert.ToInt32(Console.ReadLine());
          guessCount++;

          if (guess > numberToGuess)
            Console.WriteLine("För högt!");
          else if (guess < numberToGuess)
            Console.WriteLine("För lågt!");
          else
          {
            Console.WriteLine($"Rätt gissat! Det tog dig {guessCount} försök.");
            Console.Write("Vad heter du? ");
            string name = Console.ReadLine();

            gameScore = new Score(name, guessCount);
            gameScores.Add(gameScore);

            correct = true;
          }
        }

        Console.Write("Vill du spela igen? (ja/nej): ");
        string again = Console.ReadLine();
        runGame = WillPlay(again);
      }

      if (gameScores.Count > 0)
      {
        bool saved = saveScoreList.SaveHighScore(gameScores);
        Console.WriteLine(saved ? "Spelet sparades!" : "Fel vid sparning!");
      }
    }

    private bool WillPlay(string answer)
    {
      return answer.ToLower() == "ja";
    }
  }
}
