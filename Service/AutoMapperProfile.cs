using AutoMapper;
using Common.Dto.Customers;
using Common.Dto.Discount;
using Common.Dto.Invoice;
using Common.Dto.User;
using Repository.Entities;
using System;

namespace Service
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>();

            CreateMap<InvoiceDto, Invoices>();
            CreateMap<Invoices, InvoiceDto>();

            CreateMap<DiscountDto, Discount>();
            CreateMap<Discount, DiscountDto>();

            CreateMap<CustomerRoleDto, CustomerRole>();
            CreateMap<CustomerRole, CustomerRoleDto>();

            CreateMap<CustomersDto, Customers>();
            CreateMap<Customers, CustomersDto>();

        }
    }
}
