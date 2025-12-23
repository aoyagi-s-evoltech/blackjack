using System.Reflection;
using System.Text;

/// <summary>
/// ゲームの進行を管理するクラス
/// </summary>
public class GameManager

{
    private const string WelcomeMessage = "==ブラックジャックへようこそ！==";
    private const string StartMessage = "ゲームを開始します\n";
    public const string PlayerHandLabel = "プレイヤーの手札:";
    public const string DealerHandLabel = "ディーラーの手札:";
    private const string HiddenCardMessage = "もう1枚は伏せられています";
    public const string PlayerTurnMessage = "---プレイヤーのターンです---";
    public const string DealerTurnMessage = "---ディーラーのターンです---";
    private const string RevealDealerCardMessage = "ディーラーのカードを公開します:";


    /// <summary>
    /// ゲーム開始時に配る最初の手札の枚数
    /// </summary>
    private const int InitialHandCount = 2;

    /// <summary>
    /// ゲームで使用するデッキ
    /// </summary>
    private Deck Deck = new Deck();

    /// <summary>
    /// プレイヤー
    /// </summary>
    private Player Player = new Player();

    /// <summary>
    /// ディーラー
    /// </summary>
    private Dealer Dealer = new Dealer();

    /// <summary>
    /// 指定の枚数を手札に配る
    /// </summary>
    /// <param name="participant">カードを受け取る対象者</param>
    /// <param name="count">配る枚数</param>
    private void DealCards(PlayerBase participant, int count)
    {
        for(int i = 0; i < count; i++)
        {
            participant.AddCard(Deck.DrawCard());
        }
    }

    /// <summary>
    /// ゲームをスタートさせる
    /// </summary>
    public void StartGame()
    {
        Console.WriteLine(WelcomeMessage);
        Console.WriteLine(StartMessage);
        // プレイヤーに2枚
        DealCards(Player, InitialHandCount);
        // ディーラーに2枚
        DealCards(Dealer, InitialHandCount);

        // 出力用のStringBuilderを用意
        var sb = new StringBuilder();

        // プレイヤーの手札を表示
        sb.AppendLine(PlayerHandLabel);
        foreach (Card card in Player.Hand)
        {
            sb.AppendLine(card.ToString());
        }
        // プレイヤーの点数を表示
        sb.AppendLine($"プレイヤーの点数: {Player.CalculateHandValue()}");

        // ディーラーの手札を表示
        sb.AppendLine(DealerHandLabel);
        sb.AppendLine(Dealer.Hand[0].ToString());
        sb.AppendLine(HiddenCardMessage);

        // 出力
        Console.WriteLine(sb.ToString());
    }

    /// <summary>
    /// プレイヤーのターンを進める
    /// </summary>
    public bool PlayerTurn()
    {
        Console.WriteLine(PlayerTurnMessage);
        return Player.PlayerTurn(Deck);
    }

    /// <summary>
    /// ディーラーのターンを進める
    /// </summary>
    public bool DealerTurn()
    {
        Console.WriteLine(DealerTurnMessage);
        var sb = new StringBuilder();

        // 伏せていたカードを公開
        sb.AppendLine(RevealDealerCardMessage);
        foreach (Card card in Dealer.Hand)
        {
            sb.AppendLine(card.ToString());
        }

        // ディーラーのターンを実行
        bool DealerAlive = Dealer.PlayTurn(Deck);

        // ディーラーがバーストしていなければ、最終的な手札と点数を表示
        if(DealerAlive)
        {
            sb.AppendLine(DealerHandLabel);
            foreach (Card card in Dealer.Hand)
            {
                sb.AppendLine(card.ToString());
            }
            sb.AppendLine($"ディーラーの点数: {Dealer.CalculateHandValue()}");
        }
        return DealerAlive;
    }

    /// <summary>
    /// 勝敗判定
    /// </summary>
    public void JudgeWinner()
    {
        int PlayerScore = Player.CalculateHandValue();
        int DealerScore = Dealer.CalculateHandValue();

        if(PlayerScore > 21)
        {
            Console.WriteLine("プレイヤーはバースト！。ディーラーの勝ち！");
        }
        else if (DealerScore > 21)
        {
            Console.WriteLine("ディーラーはバースト！プレイヤーの勝ち！");
        }
        else if (PlayerScore > DealerScore)
        {
            Console.WriteLine("プレイヤーの勝ち！");
        }
        else if (DealerScore > PlayerScore)
        {
            Console.WriteLine("ディーラーの勝ち！");
        }
        else
        {
            Console.WriteLine("引き分け！");
        }
    }
}