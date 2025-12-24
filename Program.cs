class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            GameManager game = new GameManager();

            game.StartGame();
            bool PlayerAlive = game.PlayerTurn();

            if(PlayerAlive)
            {
                bool DealerAlive = game.DealerTurn();

                if(DealerAlive)
                {
                    game.JudgeWinner();
                }            
            }
            
            Console.WriteLine("\nもう一度遊びますか？ (yes/no)");
            string input = Console.ReadLine().ToLower();

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