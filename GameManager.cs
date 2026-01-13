using System.Text;

/// <summary>
/// ゲームの進行を管理するクラス
/// </summary>
public class GameManager
{
    /// <summary>
    /// ゲーム開始時に表示する挨拶
    /// </summary>
    private const string WelcomeMessage = "==ブラックジャックへようこそ！==";
    
    /// <summary>
    /// ゲーム開始時に表示する開始メッセージ
    /// </summary>
    private const string StartMessage = "ゲームを開始します\n";
    
    /// <summary>
    /// プレイヤーの手札を表示する際のメッセージ
    /// </summary>
    private const string PlayerHandLabel = "プレイヤーの手札:";
    
    /// <summary>
    /// ディーラーの手札を表示する際のメッセージ
    /// </summary>
    private const string DealerHandLabel = "ディーラーの手札:";
    
    /// <summary>
    /// ディーラーの2枚目のカードが伏せられていることを示すメッセージ
    /// </summary>
    private const string HiddenCardMessage = "もう1枚は伏せられています";
    
    /// <summary>
    /// プレイヤーのターン開始時に表示するメッセージ
    /// </summary>
    private const string PlayerTurnMessage = "---プレイヤーのターンです---";
    
    /// <summary>
    /// ディーラーのターン開始時に表示するメッセージ
    /// </summary>
    private const string DealerTurnMessage = "---ディーラーのターンです---";
    
    /// <summary>
    /// ディーラーの伏せカードを公開する際のメッセージ
    /// </summary>
    private const string RevealDealerCardMessage = "ディーラーのカードを公開します:";

    /// <summary>
    /// ゲーム開始時に配る最初の手札の枚数(ブラックジャックの基本ルールにより2枚で固定)
    /// </summary>
    private const int InitialHandCount = 2;

    /// <summary>
    /// ゲームで使用するデッキ。変更不可。
    /// </summary>
    private readonly Deck Deck = new Deck();

    /// <summary>
    /// プレイヤーの情報
    /// </summary>
    private readonly Player Player = new Player();

    /// <summary>
    /// ディーラーの情報
    /// </summary>
    private readonly Dealer Dealer = new Dealer();

    /// <summary>
    /// ゲームをスタートさせる(初期手札の配布と表示)
    /// </summary>
    public void StartGame()
    {
        // 出力用のStringBuilderを用意
        var sb = new StringBuilder(); 
        sb.AppendLine(WelcomeMessage);
        sb.AppendLine(StartMessage);

        // プレイヤーに2枚
        DealCards(Player);
        // ディーラーに2枚
        DealCards(Dealer);

        // プレイヤーの手札と点数をまとめて表示
        sb.AppendLine(AppendHand(PlayerHandLabel, Player));

        // ディーラーの手札を1枚だけ表示
        sb.AppendLine(DealerHandLabel);
        sb.AppendLine(Dealer.GetFirstCardRank());
        sb.AppendLine(HiddenCardMessage);

        // 出力
        Console.WriteLine(sb.ToString());
    }

    /// <summary>
    /// プレイヤーのターンを進行する（表示と入力を担当）
    /// </summary>
    /// <returns> true:プレイヤーがスタンドした/ false:バーストした</returns>
    public bool PlayerTurn()
    {
        Console.WriteLine(PlayerTurnMessage);
        ShowPlayerHand();

        while (true)
        {
            Console.WriteLine("カードを引きますか？ (yes/no)");
            string? input = Console.ReadLine();

            if (input == null)
            {
                Console.WriteLine("入力が確認できませんでした。yes または no を入力してください。");
                continue;
            }

            input = input.ToLower();

            if (input == "yes")
            {
                // プレイヤーは Hit（ロジックのみ）
                Player.Hit(Deck);
                // 手札を表示（UI は GameManager の責務）
                ShowPlayerHand();

                // バースト判定（ロジックは Player の責務）
                if (Player.IsBurst())
                {
                    Console.WriteLine("21点を超えました！プレイヤーの負けです");
                    return false;
                }
            }
            else if (input == "no")
            {
                Console.WriteLine("プレイヤーはスタンドしました");
                return true;
            }
            else
            {
                Console.WriteLine("yes か no を入力してください。");
            }
        }   
    }

    /// <summary>
    /// プレイヤーの手札と点数を表示
    /// </summary>
    private void ShowPlayerHand()
    {
        Console.WriteLine(AppendHand(PlayerHandLabel, Player));
    }

    /// <summary>
    /// ディーラーのターンを進める
    /// </summary>
    /// <returns> true:ディーラーがバーストせず生存/ false:バースト</returns>
    public bool DealerTurn()
    {
        var sb = new StringBuilder();

        sb.AppendLine(DealerTurnMessage);

        // 伏せていたカードを公開
        sb.AppendLine(RevealDealerCardMessage);
        sb.AppendLine(Dealer.GetHandString());

        // ディーラーのターンを実行
        bool dealerAlive = Dealer.PlayTurn(Deck);

        // ディーラーがバーストしていなければ、最終的な手札と点数を表示
        if(dealerAlive)
        {
            sb.AppendLine(AppendHand(DealerHandLabel, Dealer));
        }
        else
        {
            sb.AppendLine("21点を超えました！プレイヤーの勝ちです");
        }
        Console.WriteLine(sb.ToString());
        return dealerAlive;
    }

    /// <summary>
    /// 勝敗判定
    /// </summary>
    public void JudgeWinner()
    {
        var sb = new StringBuilder();

        if (Player.IsBurst())
        {
            sb.AppendLine("プレイヤーはバースト！ディーラーの勝ち！");
        }
        else if (Dealer.IsBurst())
        {
            sb.AppendLine("ディーラーはバースト！プレイヤーの勝ち！");
        }
        else
        {
            int playerScore = Player.CalculateHandValue();
            int dealerScore = Dealer.CalculateHandValue();

            if(playerScore > dealerScore)
            {
                sb.AppendLine("プレイヤーの勝ち！");
            }
            else if (playerScore < dealerScore)
            {
                sb.AppendLine("ディーラーの勝ち！");
            }
            else
            {
                sb.AppendLine("引き分け！");
            }
        }
        Console.WriteLine(sb.ToString());
    }

    /// <summary>
    /// 初期手札(2枚)を配る
    /// </summary>
    /// <param name="participant">カードを受け取る対象者</param>
    private void DealCards(PlayerBase participant)
    {
        for(int i = 0; i < InitialHandCount; i++)
        {
            participant.AddCard(Deck.DrawCard());
        }
    }

    /// <summary>
    /// 手札と点数をまとめた文字列を返す
    /// </summary>
    /// <param name="label">手札の見出し（プレイヤー／ディーラー）</param>
    /// <param name="participant">対象の参加者</param>
    /// <returns>表示用に整えた文字列</returns>
    private string AppendHand(string label, PlayerBase participant)
    {
        var sb = new StringBuilder();
        sb.AppendLine(label);
        sb.AppendLine(participant.GetHandString());
        sb.AppendLine($"{label.Replace("手札", "点数")}: {participant.CalculateHandValue()}");
        return sb.ToString();
    }
}