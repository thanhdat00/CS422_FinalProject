using System.ComponentModel;

namespace Supermarket.API.Domain.Models
{
    public enum EPaymentMethod : byte
    {
        [Description("COD")]
        CODPayment = 1,

        [Description("Momo")]
        Momo = 2,
    }
}
