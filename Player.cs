/// <summary>
/// プレイヤーのロジックのみを担当するクラス
/// 表示・入力やターン進行は GameManager が担当
/// </summary>
public class Player : PlayerBase
{
    /// <summary>
    /// ブラックジャックの上限値（21）
    /// </summary>
    private const int BlackjackLimit = 21;

    /// <summary>
    /// デッキからカードを1枚引き、手札に追加する
    /// </summary>
    public void Hit(Deck deck)
    {
        AddCard(deck.DrawCard());
    }

    /// <summary>
    /// 手札の合計値がブラックジャックの上限を超えているか判定する
    /// </summary>
    public bool IsBurst()
    {
        return CalculateHandValue() > BlackjackLimit;
    }
}