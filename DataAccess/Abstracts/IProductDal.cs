using Core.DataAccess;
using Entities.Concretes;
using Entities.DTOs;
using System.Collections.Generic;

namespace DataAccess.Abstracts
{
    public interface IProductDal:IEntityRepository<Product>
    {
        List<ProductDetailDto> GetProductDetails();
    }
}
