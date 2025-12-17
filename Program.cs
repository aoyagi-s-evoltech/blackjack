class Program
{
    static void Main(string[] args)
    {
        Deck deck = new Deck();
        deck.Shuffle();

        Dealer dealer = new Dealer();

        // 最初にカードを2枚配る
        dealer.AddCard(deck.DrawCard());
        dealer.AddCard(deck.DrawCard());

        Console.WriteLine($"ディーラーの点数: {dealer.CalculateHandValue()}");

        dealer.PlayTurn(deck);

        // 終了時の点数17点以上であればOK
        Console.WriteLine($"ディーラーの点数: {dealer.CalculateHandValue()}");
        Console.WriteLine("ディーラーのターン終了");
    }
}