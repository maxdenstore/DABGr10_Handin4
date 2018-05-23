namespace SGT_DocDB.Interfaces
{
    public interface ITransaction
    {
        string transactionId { get; set; }
        string transactionType { get; set; }
        string buyerType { get; set; }

        string buyerId { get; set; }
        string sellerType { get; set; }
        string sellerId { get; set; }
        int amount { get; set; }
    }
}
