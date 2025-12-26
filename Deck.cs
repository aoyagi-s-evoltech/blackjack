/// <summary>
/// トランプの山札を管理するクラス
/// </summary>
public class Deck
{
    /// <summary>
    /// トランプのスート(ハート・スペード・クラブ)の種類数
    /// </summary>
    private const int SuitCount = 4;

    /// <summary>
    /// デッキの中身(変更できない)
    /// </summary>
    private readonly List<Card> Cards = new List<Card>();

    /// <summary>
    /// コンストラクタ：トランプのカードを作りシャッフルする
    /// </summary>
    public Deck()
    {
        GenerateCards();
        Shuffle();
    }

    /// <summary>
    /// トランプを52枚生成する
    /// </summary>
    private void GenerateCards()
    {  
        string[] ranks = {"A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K"};
        // スート分の4回繰り返す(ハート、スペード、ダイヤ、クローバー)
        for (int suitIndex = 0; suitIndex < SuitCount; suitIndex++)
        {
            foreach (string rank in ranks)
            {
                Cards.Add(new Card(rank));
            }
        }
    }
    /// <summary>
    /// シャッフルする
    /// </summary>
    public void Shuffle()
    {
        Random random = new Random();
        for (int i  = Cards.Count -1; i > 0; i--)
        {
            int randomIndex = random.Next(i + 1); 
            // 入れ替え処理(まだ混ぜていないカードの中だけランダムに入れ替えるため、後ろから順に処理する)
            Card temp = Cards[i];
            Cards[i] = Cards[randomIndex];
            Cards[randomIndex] = temp;
        }
    }

    /// <summary>
    /// カードを引く
    /// </summary>
    /// <returns>引いたカード</returns>
    public Card DrawCard()
    {
        int lastIndex = Cards.Count - 1;
        Card drawnCard = Cards[lastIndex];
        // 山札から削除
        Cards.RemoveAt(lastIndex);
        return drawnCard;
    }
}


