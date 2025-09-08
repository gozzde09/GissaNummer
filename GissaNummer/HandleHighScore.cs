
namespace GuessNumberGameApp
{
  internal class HandleHighScore
  {
    private string filePath = "highscore.txt";

    public bool SaveHighScore(List<Score> scores)
    {
      try
      {
        using (StreamWriter writer = new StreamWriter(filePath, true)) // Öppna filen, true = append
        {
          foreach (Score s in scores)
          {
            writer.WriteLine($"{s.PlayerName};{s.Attempts}");
          }
        }
        return true;
      }
      catch
      {
        return false;
      }
    }

    public List<Score> FetchHighScore()
    {
      List<Score> scores = new List<Score>();

      if (!File.Exists(filePath))
        return scores;

      // Läsa filen
      using (StreamReader reader = new StreamReader(filePath))
      {
        string line;
        // Null-forgiving operator ! används för att indikera att vi vet att ReadLine inte returnerar null här
        while ((line = reader.ReadLine()!) != null)
        {
          string[] parts = line.Split(';');
          if (parts.Length == 2 && int.TryParse(parts[1], out int attempts))
          {
            scores.Add(new Score(parts[0], attempts));
          }
        }
      }

      scores.Sort(); // bästa (lägsta försök) först
      return scores;
    }
  }
}
