

namespace GuessNumberGameApp
{
  internal class Program
  {
    static void Main(string[] args)
    {
  
      UI ui = new UI();

      // Om användaren vill spela
      string answer = ui.DrawUI();

      // Starta spelet
      GuessNumberGame game = new GuessNumberGame();
      game.PlayGame(answer);
    }
  }
}
