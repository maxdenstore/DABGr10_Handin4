namespace SGT_DocDB.Interfaces
{
    public interface ITransaction
    {
        int transactionId { get; set; }
        string transactionType { get; set; }
        string buyerType { get; set; }

        int buyerId { get; set; }
        string sellerType { get; set }
        int sellerId { get; set; }
        int amount { get; set; }
    }
    }
}