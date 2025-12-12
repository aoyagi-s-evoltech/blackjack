public class Card
{
    public string Rank {get;}   // A, 2, 3, ..., K
    public int Value {get;}     // 点数

    public Card(string rank)
    {
        Rank = rank;
        Value = CalculateValue(rank);
    }

    private int CalculateValue(string rank)
    {
        if (rank == "A") return 1;       // Aは1点
        if (rank == "J" || rank == "Q" || rank == "K") return 10;
        return int.Parse(rank);          // 2〜10はそのまま数値
    }

    public override string ToString()
    {
        return "{Rank}";
    }
}
