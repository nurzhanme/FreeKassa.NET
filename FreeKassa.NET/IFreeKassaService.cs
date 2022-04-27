namespace FreeKassa.NET
{
    public interface IFreeKassaService
    {
        string GetNotificationSign(string orderId, decimal amount);
        string GetPayLink(string orderId, decimal amount, string currency = "USD");
    }
}