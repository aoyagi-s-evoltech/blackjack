class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            GameManager game = new GameManager();

            game.StartGame();
            bool playerAlive = game.PlayerTurn();

            if(playerAlive)
            {
                bool dealerAlive = game.DealerTurn();

                if(dealerAlive)
                {
                    game.JudgeWinner();
                }            
            }
            
            Console.WriteLine("\nもう一度遊びますか？ (yes/それ以外は終了)");
            string input = Console.ReadLine()?.ToLower();

            if (input == "yes")
            {
                Console.WriteLine("\nもう一度遊びます！\n");
            }
            else
            {
                Console.WriteLine("ゲームを終了します。また遊んでね！");
                return;
            }
        }    
    }
}