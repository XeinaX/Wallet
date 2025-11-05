namespace CryptoSim.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Login { get; set; }
        public string? PaswwordHash { get; set; }
        public List<Wallet>? Wallets { get; set; }

        public readonly bool Isadmin;

        public User(int id, string? login, string? paswwordHash, List<Wallet>? wallets, bool isadmin)
        {
            Id = id;
            Login = login;
            PaswwordHash = paswwordHash;
            Wallets = wallets;
            Isadmin = isadmin;
        }
    }
}
