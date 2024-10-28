using UnityEngine;

public class DataManager : MonoBehaviour
{
    private JSONFileManager jsonFileManager;
    private Wallet wallet;

    private void Awake()
    {
        jsonFileManager = new JSONFileManager("PlayerWallet.json");
        wallet = jsonFileManager.Load(new Wallet(100));
    }

    public void SaveWallet()
    {
        jsonFileManager.Save(wallet);
    }

    public void UpdateWallet(int ammount)
    {
        wallet.AddCoins(ammount);
        SaveWallet();
    }
}