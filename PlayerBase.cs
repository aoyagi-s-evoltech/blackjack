/// <summary>
/// プレイヤー／ディーラー共通の動きをもつクラス
/// </summary>
public class PlayerBase
{
    /// <summary>
    /// プレイヤー／ディーラーの手札
    /// </summary>
    public List<Card> Hand {get;} = new List<Card>();

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
            total += card.Value;
        }
        return total;
    }
    
    /// <summary>
    /// バースト判定を行う
    /// 手札の合計が21点以上の場合trueを返す
    /// </summary>
    /// <returns>true: バースト/false: 続行可能</returns>
    public bool IsBurst()
    {
        return CalculateHandValue() > 21;
    }
}