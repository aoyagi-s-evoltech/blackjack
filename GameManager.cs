using System.Text;

/// <summary>
/// ゲームの進行を管理するクラス
/// </summary>
public class GameManager
{
    /// <summary>
    /// ゲームで使用するデッキ
    /// </summary>
    private Deck Deck;

    /// <summary>
    /// プレイヤー
    /// </summary>
    private Player Player;

    /// <summary>
    /// ディーラー
    /// </summary>
    private Dealer Dealer;

    /// <summary>
    /// コンストラクタ:デッキとプレイヤー・ディーラーを初期化
    /// </summary>
    public GameManager()
    {
        Deck = new Deck();
        Player = new Player();
        Dealer = new Dealer();
    }
    /// <summary>
    /// 指定の枚数を手札に配る
    /// </summary>
    /// <param name="hand">カードを受け取る対象者</param>
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
        // プレイヤーに2枚
        DealCards(Player, 2);
        // ディーラーに2枚
        DealCards(Dealer, 2);

        // 出力用のStringBuilderを用意
        var sb = new StringBuilder();

        // プレイヤーの手札を表示
        sb.AppendLine("プレイヤーの手札:");
        foreach (Card card in Player.Hand)
        {
            sb.AppendLine(card.ToString());
        }
        // プレイヤーの点数を表示
        sb.AppendLine($"プレイヤーの点数: {Player.CalculateHandValue()}");

        // ディーラーの手札を表示
        sb.AppendLine("ディーラーの手札:");
        sb.AppendLine(Dealer.Hand[0].ToString());
        sb.AppendLine("もう1枚は伏せられています");

        // 出力
        Console.WriteLine(sb.ToString());
    }
}