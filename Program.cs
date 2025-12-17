class Program
{
    static void Main(string[] args)
    {
        GameManager gameManager = new GameManager();
        // ゲーム開始
        gameManager.StartGame();
        // ディーラーのターンを実行
        gameManager.DealerTurn();
    }
}