/// <summary>
/// プレイヤーのロジックのみを担当するクラス
/// 表示・入力やターン進行は GameManager が担当
/// </summary>
public class Player : PlayerBase
{
   /// <summary>
   /// デッキからカードを1枚引き、手札に追加する
   /// </summary>
   /// <param name="deck">カードを引く対象のデッキ</param>
    public void Hit(Deck deck)
    {
        AddCard(deck.DrawCard());
    }
}