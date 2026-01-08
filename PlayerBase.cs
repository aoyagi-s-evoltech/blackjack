using System.Text;

/// <summary>
/// プレイヤー／ディーラー共通の動きをもつクラス
/// </summary>
public class PlayerBase
{
    /// <summary>
    /// プレイヤー／ディーラーの手札
    /// </summary>
    private List<Card> Hand { get; } = new List<Card>();

    /// <summary>
    /// ブラックジャックの上限値（21）
    /// </summary>
    private const int BlackjackLimit = 21;

    /// <summary>
    /// 手札にカードを追加
    /// </summary>
    /// <param name="card">追加するカード</param>
    public void AddCard(Card card)
    {
        Hand.Add(card);
    }

    /// <summary>
    /// 手札の合計点を計算する
    /// </summary>
    /// <returns>手札の合計点</returns>
    public int CalculateHandValue()
    {
        int total = 0;
        foreach (Card card in Hand)
        {
            total += card.PointValue;
        }
        return total;
    }

    /// <summary>
    /// バースト判定を行う
    /// 手札の合計が21点を超えた場合trueを返す
    /// </summary>
    /// <returns>true: バースト/false: 続行可能</returns>
    public bool IsBurst()
    {
        return CalculateHandValue() > BlackjackLimit;
    }

    /// <summary>
    /// 手札を表示用の文字列として返す
    /// </summary>
    /// <returns>手札を改行しながら並べた文字列</returns>
    public string GetHandString()
    {
        var sb = new StringBuilder();
        foreach (var card in Hand)
        {
            sb.AppendLine(card.Rank);
        }
        return sb.ToString();
    }

    /// <summary>
    /// 手札の1枚目のランクを返す
    /// </summary>
    /// <returns>1枚目のカードのランク</returns>
    public string GetFirstCardRank()
    {
        return Hand[0].Rank;
    }
}