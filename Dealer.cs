using System.Diagnostics.Contracts;
/// <summary>
/// ディーラーの行動
/// 手札の合計が17以上になるまでカードを引き続ける
/// </summary>
/// <param name="deck">カードを引くデッキ</param>
public class Dealer : PlayerBase
{
    public void PlayTurn(Deck deck)
    {
        while(CalculateHandValue() < 17)
        {
            AddCard(deck.DrawCard());
        }
    }
}