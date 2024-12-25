using System;

[Serializable] public class Wallet
{
    public int Coins { get; private set; }

    public Wallet() { }
    public Wallet(int coinsAmmount)
    {
        Coins = coinsAmmount;
    }

    public void AddCoins(int coinsAmmount)
    {
        Coins += coinsAmmount;

        if (Coins < 0)
        {
            Coins = 0;
        }
    }

    public int GetCoinsAmmount()
    {
        return Coins;
    }
}