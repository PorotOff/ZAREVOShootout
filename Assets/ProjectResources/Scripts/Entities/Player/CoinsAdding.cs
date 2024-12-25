using System.IO;
using UnityEngine;
using System;

public class CoinsAdding : MonoBehaviour
{
    public static event Action OnCoinsAdded;

    [SerializeField] private int coinsAmmount;

    private JSONSaveLoad playerWalletJson;
    private Wallet wallet;

    private void Awake()
    {
        string fileDirectory = Path.Combine(Application.persistentDataPath, "GameResources", "Saves");
        string fileName = "PlayerWallet.json";
        playerWalletJson = new JSONSaveLoad(fileDirectory, fileName);

        wallet = playerWalletJson.Load<Wallet>();
    }

    public void AddCoinsAndSave()
    {
        wallet.AddCoins(coinsAmmount);

        playerWalletJson.Save(wallet);

        OnCoinsAdded?.Invoke();
    }
}