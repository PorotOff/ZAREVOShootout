using UnityEngine;
using UnityEngine.Events;

public class CoinsAdding : MonoBehaviour
{
    public static UnityEvent OnCoinsAdded = new UnityEvent();

    [SerializeField] private int coinsAmmount;

    private JSONFileManager playerWalletJson;
    private Wallet wallet;

    public void AddCoinsAndSave()
    {
        playerWalletJson = new JSONFileManager("PlayerWallet.json");

        wallet = playerWalletJson.Load<Wallet>();

        wallet.AddCoins(coinsAmmount);

        playerWalletJson.Save(wallet);

        OnCoinsAdded?.Invoke();
    }
}