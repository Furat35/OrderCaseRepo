using AutoMapper;
using OrderCaseRepo.Business.Dtos.Addresses;
using OrderCaseRepo.Business.Dtos.Catalogs;
using OrderCaseRepo.Business.Dtos.OrderItems;
using OrderCaseRepo.Business.Dtos.Orders;
using OrderCaseRepo.Data.Entities;

namespace OrderCaseRepo.Business.EntityTypeConfigurations
{
    public class OrderTypeConfigurations : Profile
    {
        public OrderTypeConfigurations()
        {
            CreateMap<OrderCreateDto, Order>();
            CreateMap<Order, OrderListDto>();
        }
    }

    public class OrderItemTypeConfigurations : Profile
    {
        public OrderItemTypeConfigurations()
        {
            CreateMap<OrderItemCreateDto, OrderItem>();
            CreateMap<OrderItem, OrderItemListDto>();
        }
    }

    public class CatalogTypeConfigurations : Profile
    {
        public CatalogTypeConfigurations()
        {
            CreateMap<Catalog, CatalogListDto>();
        }
    }

    public class AddressTypeConfigurations : Profile
    {
        public AddressTypeConfigurations()
        {
            CreateMap<AddressCreateDto, Address>();
            CreateMap<Address, AddressListDto>();
        }
    }
}
