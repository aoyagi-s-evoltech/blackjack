public class Card
{
    public string Rank {get;}   // A, 2, 3, ..., K(変更できない)
    public int Value {get;}     // 点数(変更できない)

    // コンストラクタ：カードの生成時ランクを渡す
    public Card(string rank)
    {
        Rank = rank;
        Value = CalculateValue(rank);
    }

    /// <summary>
    /// 点数を計算するメソッド
    /// </summary>
    /// <param name="rank"></param>
    /// <returns></returns>
    private int CalculateValue(string rank)
    {
        if (rank == "A") return 1;       // Aは1点（）
        if (rank == "J" || rank == "Q" || rank == "K") return 10;
        return int.Parse(rank);          // 2〜10はそのまま数値
    }
    // カードを文字列として表示
    public override string ToString()
    {
        return "Rank";
    }
}
