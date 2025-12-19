using System.Runtime.CompilerServices;
using System.Text;

/// <summary>
/// プレイヤーの行動
/// ターン内の行動(カードを引く／スタンドする)を管理
/// </summary>
public class Player : PlayerBase
{
    /// <summary>
    /// プレイヤーのターンを進める
    /// 入力(yes/no)に応じて「ヒット(カードを引く)」もしくは「スタンド(カードを引かない)を選択できる」
    /// </summary>
    public void PlayerTurn(Deck deck)
    {
        Console.WriteLine("=== あなたのターンです ===");
        ShowHandStatus("プレイヤーのターン開始: ");

        // プレイヤーがヒットするかスタンドするかを選択
        while (true)
        {
            Console.WriteLine("カードを引きますか？ (yes: ヒット / no: スタンド)");
            string input = Console.ReadLine();

            // yes: ヒットを選んだ場合(カードを引く)
            if(input != null && input.ToLower() == "yes")
            {
                // バーストしたら終了
                if(Hit(deck)) break;
            }
            // No: スタンドを選んだ場合(カードを引かない)
            else if(input != null && input.ToLower() == "no")
            {
                // スタンド（ターン終了）
                Console.WriteLine("プレイヤーはスタンドしました。");
                break;
            }
            // yes/no以外が入力された場合
            else
            {
                Console.WriteLine("入力が正しくありません。yes または no を入力してください。");
            }
        }
    }

    /// <summary>
    /// プレイヤーの手札と点数を表示
    /// </summary>
    /// <param name="header">最初に出す文字列</param>
    private void ShowHandStatus(string header = "プレイヤーの手札: ")
    {
        var sb = new StringBuilder();
        sb.AppendLine(header);

        foreach (Card card in Hand)
        {
            sb.AppendLine(card.ToString());
        }
        sb.AppendLine($"プレイヤーの点数: {CalculateHandValue()}");
        Console.WriteLine(sb.ToString());
    }

    /// <summary>
    /// カードを引いて状態を更新、バースト判定
    /// </summary>
    /// <returns>true: バーストしているので負け/false: 続ける</returns>
    private bool Hit(Deck deck)
    {
        AddCard(deck.DrawCard());
        ShowHandStatus();

        if (CalculateHandValue() > 21)
        {
            Console.WriteLine("21点を超えてしまいました！プレイヤーの負けです");
            return true;
        }
        return false;
    }
}