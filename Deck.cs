using System;
using System.Collections.Generic;

/// <summary>
/// トランプの山札を管理するクラス
/// </summary>
public class Deck
{
    /// <summary>
    /// デッキの中身(変更できない)
    /// </summary>
    private List<Card> cards = new List<Card>();
    /// <summary>
    /// 山札の残り枚数を返すプロパティ
    /// </summary>
    public int CardCount
    {
        get
        {
            return cards.Count;
        }
    }
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
        // スート分の4回繰り返す(♡、♤、♧、♢)
        for (int suitIndex = 0; suitIndex < 4; suitIndex++)
        {
            foreach (string rank in ranks)
            {
                cards.Add(new Card(rank));
            }
        }
    }
    /// <summary>
    /// シャッフルするメソッド
    /// </summary>
    public void Shuffle()
    {
        Random random = new Random();
        for (int currentIndex  = cards.Count -1; currentIndex > 0; currentIndex--)
        {
            int randomIndex = random.Next(currentIndex + 1); 
            // 入れ替え処理
            Card temp = cards[currentIndex];
            cards[currentIndex] = cards[randomIndex];
            cards[randomIndex] = temp;
        }
    }

    /// <summary>
    /// カードを引くメソッド
    /// </summary>
    /// <returns></returns>
    public Card DrawCard()
    {
        int lastIndex = cards.Count - 1;
        Card drawnCard = cards[lastIndex];
        // 山札から削除
        cards.RemoveAt(lastIndex);
        return drawnCard;
    }
}


