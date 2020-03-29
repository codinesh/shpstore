namespace Groc.Models
{
    public enum OrderStatus
    {
        Creating,
        Processing,
        PendingPayment,
        ReceivedPayment,
        PendingFulfillment,
        Completed
    }
}