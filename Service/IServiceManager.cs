using Common;
using Service.Services;
using System.Threading.Tasks;

namespace Service
{
    public interface IServiceManager
    {
        ServiceContext serviceContext { get; }

        UserService User_Service { get; }

        InvoiceService Invoice_Service { get; }

        CustomerService Customer_Service { get; }
        DiscountService Discount_Service { get; }
        CustomerRoleService CustomerRole_Service { get; }

        Task CommitAsync();
    }
}
