using System;
using System.Collections.Generic;

public class Deck
{
    // デッキの中身(変更できない)
    private List<Card> cards = new List<Card>();
    // 山札の残り枚数を返すプロパティ
    public int CardCount
    {
        get
        {
            return cards.Count;
        }
    }
    // コンストラクタ
    public Deck()
    {
       GenerateCards(); // トランプのカードを作る(52枚)
       Shuffle();       // シャッフル
    }

    private void GenerateCards()
    {  
        // ランクを作成
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
    // シャッフルメソッド
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
    // カードを引くメソッド
    public Card DrawCard()
    {
        // カードを取り出す
        int lastIndex = cards.Count - 1;
        Card drawnCard = cards[lastIndex];
        // 山札から削除
        cards.RemoveAt(lastIndex);
        // 引いたカードを返す
        return drawnCard;
    }
}


