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
    /// 初回のゲーム開始確認・ゲーム本編・再プレイ確認の流れを管理
    /// </summary>
    /// <param name="args">コマンドラインから渡される値</param>
    static void Main(string[] args)
    {
        // (初回のみ)ゲーム開始の確認
        if(!AskToStartGame())
        {
            Console.WriteLine("ゲームを終了します。また遊んでね！");
            return;
        }

        // ゲーム本編
        while (true)
        {
            // ゲームを1回一通り実行
            RunGame();

            // 再プレイするか確認
            if(!AskReplay())
            {
                Console.WriteLine("ゲームを終了します。また遊んでね！");
                return;
            }
            Console.WriteLine("\nもう一度遊びます！\n");
        }
    }

    /// <summary>
    /// ゲーム開始時、開始するか確認（yes/no）
    /// yes：ゲーム開始
    /// no：ゲーム終了
    /// </summary>
    /// <returns>true：ゲーム開始/false：ゲーム終了</returns>
    static bool AskToStartGame()
    {
        Console.WriteLine("==ブラックジャックへようこそ！==");
        Console.WriteLine("ゲームを開始しますか？(yes/no)");

        while (true)
        {
            string? start = Console.ReadLine()?.ToLower();

            if(start == "yes")
            {
                return true;
            }
            if(start == "no")
            {
                return false;
            }
            WarnInvalid();
        }
    }       

    /// <summary>
    /// ゲームを1回分進行する(処理はGameManager側)
    /// </summary>
    static void RunGame()
    {
        // ゲームを管理するクラス
        GameManager game = new GameManager();

        // ゲームの準備(カード配布)
        game.StartGame();

        // プレイヤーのターン(true：続行/false：バースト)
        bool playerAlive = game.PlayerTurn();

        // プレイヤーがバーストしていない場合ディーラーのターン
        if(playerAlive)
        {
            bool dealerAlive = game.DealerTurn();
            
            // ディーラーもバーストしていない場合、勝敗判定する
            if(dealerAlive)
            {
                game.JudgeWinner();
            }            
        }
    }

    /// <summary>
    /// 再プレイするか確認（yes/no）
    /// yes：ゲーム続行
    /// no：ゲーム終了
    /// </summary>
    /// <returns>true：ゲーム続行/false：ゲーム終了</returns>
    static bool AskReplay()
    {
        Console.WriteLine("\nもう一度遊びますか？ (yes/それ以外は終了)");
        
        while(true)
        {
            string? input = Console.ReadLine()?.ToLower();

            if (input == "yes")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
