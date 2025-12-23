using System.Text;
/// <summary>
/// ディーラーの行動を管理するクラス
/// 手札の合計が17以上になるまでカードを引き続ける
/// </summary>
public class Dealer : PlayerBase
{
    /// <summary>
    /// ディーラーのターンを進める
    /// 手札が17点以上になるまでカードを引き続ける
    /// バーストした場合はプレイヤーの勝ち
    /// </summary>
    /// <param name="deck"></param>
    public bool PlayTurn(Deck deck)
    {
        Console.WriteLine("---ディーラーのターンです---");
        ShowHandStatus("ディーラーのターン開始: ");

        while(CalculateHandValue() < 17)
        {
            Console.WriteLine("ディーラーはカードを引きます");
            // デッキから1枚引いて手札に追加
            AddCard(deck.DrawCard());
            ShowHandStatus();

            // バーストしたら終了
            if(IsBurst())
            {
                Console.WriteLine("21点を超えました！プレイヤーの勝ちです");
                return false;
            }
        }
        Console.WriteLine("ディーラーはスタンドしました");
        return true;
    }

    /// <summary>
    /// ディーラーの手札と点数を表示
    /// </summary>
    /// <param name="header">表示の先頭に出す文字列</param>
    private void ShowHandStatus(string header = "ディーラーの手札: ")
    {
        var sb = new StringBuilder();
        sb.AppendLine(header);

        // 手札のカードを表示
        foreach (Card card in Hand)
        {
            sb.AppendLine(card.ToString());
        }
        // 現在の合計点を表示
        sb.AppendLine($"ディーラーの点数: {CalculateHandValue()}");
        Console.WriteLine(sb.ToString());
    }
}