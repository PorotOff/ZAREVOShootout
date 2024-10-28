using TMPro;
using UnityEngine;

public class ShowPlayerCoins : MonoBehaviour
{
    private TMP_Text coinsTMP;

    private JSONFileManager playerWalletJson;
    private Wallet wallet;

    private void Awake()
    {
        coinsTMP = GetComponent<TMP_Text>();

        UpdateData();
    }

    private void OnEnable()
    {
        CoinsAdding.OnCoinsAdded.AddListener(UpdateData);
    }
    private void OnDisable()
    {
        CoinsAdding.OnCoinsAdded.RemoveListener(UpdateData);
    }

    private void UpdateData()
    {
        playerWalletJson = new JSONFileManager("PlayerWallet.json");

        wallet = playerWalletJson.Load<Wallet>();

        coinsTMP.text = $"coins: {wallet.GetCoinsAmmount()}";
    }
}