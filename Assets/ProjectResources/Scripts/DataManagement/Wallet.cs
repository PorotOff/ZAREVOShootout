using System;

[Serializable]
public class Wallet
{
    public int coins;

    public Wallet() { }
    public Wallet(int coinsAmmount)
    {
        coins = coinsAmmount;
    }

    public void AddCoins(int coinsAmmount)
    {
        coins += coinsAmmount;

        if (coins < 0)
        {
            coins = 0;
        }
    }

    public int GetCoinsAmmount()
    {
        return coins;
    }
}