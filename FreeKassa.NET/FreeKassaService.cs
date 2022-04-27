using System;
using System.Globalization;

namespace FreeKassa.NET
{
    public class FreeKassaService : IFreeKassaService
    {
        private readonly FreeKassaOptions _options;

        public FreeKassaService(FreeKassaOptions options)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
        }

        public string GetPayLink(string orderId, decimal amount, string currency = "USD")
        {
            const string host = "https://pay.freekassa.ru/?";

            var amountStr = decimal.Round(amount, 2).ToString(CultureInfo.InvariantCulture);
            var sign = MD5Helper.Create($"{_options.MerchantId}:{amountStr}:{_options.Secret1}:{currency}:{orderId}");

            return $"{host}m={_options.MerchantId}&oa={amountStr}&currency={currency}&o={orderId}&s={sign}";
        }

        public string GetNotificationSign(string orderId, decimal amount)
        {
            var amountStr = decimal.Round(amount, 2).ToString(CultureInfo.InvariantCulture);

            return MD5Helper.Create($"{_options.MerchantId}:{amountStr}:{_options.Secret2}:{orderId}");
        }
    }
}
