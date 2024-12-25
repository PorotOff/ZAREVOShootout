using System.IO;
using UnityEngine;
using TMPro;

public class ShowPlayerCoins : MonoBehaviour
{
    private TMP_Text coinsTMP;

    private JSONSaveLoad playerWalletJson;
    private Wallet wallet;

    private void Awake()
    {
        coinsTMP = GetComponent<TMP_Text>();

        string fileDirectory = Path.Combine(Application.persistentDataPath, "GameResources", "Saves");
        string fileName = "PlayerWallet.json";
        playerWalletJson = new JSONSaveLoad(fileDirectory, fileName);

        UpdateData();
    }

    private void OnEnable()
    {
        CoinsAdding.OnCoinsAdded += UpdateData;
    }
    private void OnDisable()
    {
        CoinsAdding.OnCoinsAdded -= UpdateData;
    }

    private void UpdateData()
    {
        wallet = playerWalletJson.Load<Wallet>();

        coinsTMP.text = $"coins: {wallet.GetCoinsAmmount()}";
    }
}