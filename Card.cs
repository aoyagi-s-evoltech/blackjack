/// <summary>
/// トランプのカードを表すクラス
/// </summary>
public class Card
{
    /// <summary>
    /// カードのランク(A,2~10,J,Q,K)
    /// </summary>
    public string Rank { get; }

    /// <summary>
    /// カードの点数(A=1, 数字はそのまま, J/Q/K=10) 
    /// </summary>
    public int PointValue { get; }

    /// <summary>
    /// コンストラクタ:カードの生成時ランクを渡す
    /// </summary>
    /// <param name="rank">カードのランク</param>
    public Card(string rank)
    {
        Rank = rank;
        PointValue = CalculateValue(rank);
    }

    /// <summary>
    /// 点数を計算するメソッド
    /// </summary>
    /// <param name="rank">カードのランク</param>
    /// <returns>カードの点数</returns>
    private int CalculateValue(string rank)
    {
        if (rank == "A") return 1;
        if (rank == "J" || rank == "Q" || rank == "K") return 10;
        return int.Parse(rank);
    }
}
