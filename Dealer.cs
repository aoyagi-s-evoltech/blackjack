/// <summary>
/// ディーラーの行動を管理するクラス
/// 手札の合計が17以上になるまでカードを引き続ける
/// </summary>
public class Dealer : PlayerBase
{
    /// <summary>
    /// ディーラーがスタンドする基準値
    /// 17以上ならスタンド、16以下ならヒット
    /// </summary>
    private const int DealerStandValue = 17;

    /// <summary>
    /// ディーラーのターンを進める
    /// 手札が17点以上になるまでカードを引き続ける
    /// バーストした場合は false を返す。スタンドした場合は true を返す。
    /// </summary>
    /// <param name="deck">カードを引くデッキ</param>
    /// <returns>true: スタンドしてターン終了 / false: バーストして負け</returns>
    public bool PlayTurn(Deck deck)
    {
        while (CalculateHandValue() < DealerStandValue)
        {
            AddCard(deck.DrawCard());

            if (IsBurst())
            {
                return false; 
            }
        }
        return true;
    }
}