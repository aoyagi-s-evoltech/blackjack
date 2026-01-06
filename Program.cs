class Program
{
    /// <summary>
    /// 無効な入力が行われたときにメッセージを表示
    /// </summary>
    static void WarnInvalid()
    {
        Console.WriteLine("入力が確認できませんでした。yes または no を入力してください。");
    }

    /// <summary>
    /// 初回の開始確認と、ゲーム全体の流れを管理。
    /// </summary>
    /// <param name="args">コマンドラインから渡される値</param>
    static void Main(string[] args)
    {
        bool isFirstGame = true;

        while (true)
        {
            // (初回のみ)ゲーム開始の確認
            if(isFirstGame)
            {
                Console.WriteLine("==ブラックジャックへようこそ！==");
                Console.WriteLine("ゲームを開始しますか？(yes/no)");

                string? start = Console.ReadLine();

                if(start == null)
                {
                    WarnInvalid();
                    continue;
                }

                start = start.ToLower();
                if(start != "yes")
                {
                    Console.WriteLine("ゲームを終了します。また遊んでね！");
                    return;
                }
                isFirstGame = false;
            }

            // ゲーム本編の処理
            GameManager game = new GameManager();

            game.StartGame();
            bool playerAlive = game.PlayerTurn();

            // プレイヤーがバーストしていなかった場合の処理
            if(playerAlive)
            {
                bool dealerAlive = game.DealerTurn();

                if(dealerAlive)
                {
                    game.JudgeWinner();
                }            
            }
            
            // 再プレイするか確認
            Console.WriteLine("\nもう一度遊びますか？ (yes/それ以外は終了)");
            string? input = Console.ReadLine();

            if(input == null)
            {
                WarnInvalid();
                continue;
            }

            input = input.ToLower();

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