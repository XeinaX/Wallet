using CryptoSim.Models;
using CryptoSim.Data;

namespace CryptoSim.Services;
//класс для создания сервисов crud операций
public class WalletService
{
    //создание кошелька (всегда с нулевым балансом)
    public Wallet CreateWallet(string name)
    {
        var wallet = new Wallet
        {
            Id = Guid.NewGuid(),
            Name = name,
            Balance = 0
        };
        
        PsevdoDataBase.Wallets.Add(wallet);
        return wallet;
    }
    
    //получение всех кошельков
    public List<Wallet> GetAllWallets()
    {
        return PsevdoDataBase.Wallets;
    }
    
    //получение одного кошелька по id 
    public Wallet? GetWalletById(Guid id)
    {
        return PsevdoDataBase.Wallets.FirstOrDefault(x => x.Id == id);
    }
    
    //изменение баланса одного кошелька по id (возможно возвращение null)
    public Wallet? UpdateWalletBalanceById(Guid id, decimal balance)
    {
        var wallet = GetWalletById(id);

        if (wallet != null)
        {
            wallet.Balance = balance;
        }
        return wallet;
    }
    
    //удаление кошелька по id (если его нет то возвращает false)
    public bool DeleteWalletById(Guid id)
    {
        var wallet = GetWalletById(id);
        if (wallet == null)
        {
            return false;
        }
        PsevdoDataBase.Wallets.Remove(wallet);
        return true;
    }
}