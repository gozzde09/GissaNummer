namespace GuessNumberGameApp
{
  internal class GuessNumberGame
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

      List<Score> scores = new List<Score>();
      Random random = new Random();

      while (runGame)
      {
        int numberToGuess = random.Next(1, 101);
        int guess;
        int attempts = 0;
        bool correct = false;

        Console.WriteLine("\nJag har valt ett tal mellan 1 och 100. Gissa!");

        while (!correct)
        {
          Console.Write("Din gissning: ");
          string input = Console.ReadLine();

          if (!int.TryParse(input, out guess))
          {
            Console.WriteLine("❌ Ange ett giltigt heltal.");
            continue;
          }

          attempts++;

          if (guess > numberToGuess)
            Console.WriteLine("För högt!");
          else if (guess < numberToGuess)
            Console.WriteLine("För lågt!");
          else
          {
            Console.WriteLine($"🎉 Rätt gissat! Du har gjort {attempts} antal gissningar.");
            Console.Write("Vad heter du? ");
            string name = Console.ReadLine();

            gameScore = new Score(name, attempts);
            scores.Add(gameScore);

            correct = true;
          }
        }

        Console.WriteLine("Vill du spela igen? (Y/N)");
        answer = Console.ReadLine();
        runGame = WillPlay(answer);
      }

      if (scores.Count > 0)
      {
        bool saved = saveScoreList.SaveHighScore(scores);
        if (saved)
          Console.WriteLine("✅ Dina resultat har sparats.");
        else
          Console.WriteLine("❌ Något gick fel vid sparning.");
      }
    }

    private bool WillPlay(string answer)
    {
      return answer.ToLower() == "Y";
    }
  }
}
