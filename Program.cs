class Program
{
    static void Main(string[] args)
    {
        bool playAgain = true;

        while (playAgain)
        {
            GameManager game = new GameManager();

            game.StartGame();
            game.PlayerTurn();
            game.DealerTurn();
            game.JudgeWinner();

            Console.WriteLine("\nもう一度遊びますか？ (yes/no)");
            string input = Console.ReadLine().ToLower();

            if (input == "yes")
            {
                Console.WriteLine("\nもう一度遊びます！\n");
            }
            else
            {
                playAgain = false;
                Console.WriteLine("ゲームを終了します。また遊んでね！");
            }
        }       
    }
}