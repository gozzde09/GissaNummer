using System;
using System.Collections.Generic;
using System.IO;

namespace GuessNumberGameApp
{
  internal class HandleHighScore
  {
    private string filePath = "highscore.txt";

    public bool SaveHighScore(List<Score> scores)
    {
      try
      {
        using (StreamWriter writer = new StreamWriter(filePath, true)) // true = append
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

      using (StreamReader reader = new StreamReader(filePath))
      {
        string line;
        while ((line = reader.ReadLine()) != null)
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
