/// <summary>
/// トランプのデッキを管理するクラス
/// </summary>
public class Deck
{
    /// <summary>
    /// トランプのスート(ハート・スペード・クラブ・ダイヤ)の種類数
    /// </summary>
    private const int SuitCount = 4;

    /// <summary>
    /// デッキの中身(変更できない)
    /// </summary>
    private readonly List<Card> Cards = new List<Card>();

    /// <summary>
    /// トランプのカードを作りシャッフルする
    /// </summary>
    public Deck()
    {
        GenerateCards();
        Shuffle();
    }

    /// <summary>
    /// トランプを52枚生成する
    /// スート4種類　× 13種類 = 52枚
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
    /// デッキをシャッフルする
    /// 後ろから順に、混ざっていないカードとランダムに入れ替える
    /// </summary>
    public void Shuffle()
    {
        Random random = new Random();

        // デッキの後ろから順にカードを入れ替え
        for (int i  = Cards.Count -1; i > 0; i--)
        {
            int randomIndex = random.Next(i + 1); 
            Card temp = Cards[i];
            Cards[i] = Cards[randomIndex];
            Cards[randomIndex] = temp;
        }
    }

    /// <summary>
    /// デッキの末尾からカードを1枚引く
    /// </summary>
    /// <returns>引いたカード</returns>
    public Card DrawCard()
    {
        // デッキの1番後ろのカードのインデックスを取得
        int lastIndex = Cards.Count - 1;
        // 引くカードを取得
        Card drawnCard = Cards[lastIndex];
        // デッキから削除
        Cards.RemoveAt(lastIndex);
        return drawnCard;
    }
}