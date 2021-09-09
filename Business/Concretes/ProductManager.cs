using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingCorcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace Business.Concretes
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public IResult Add(Product product)
        {
            var context = new ValidationContext<Product>(product);
            ProductValidator productValidator = new ProductValidator();
            var result= productValidator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            ValidationTool.Validate(new ProductValidator(), product);

            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }
        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour==5)
            {
                return new ErrorDataResult<List<Product>>(Messages.SystemsystemInMaintenance);
            }
            return new DataResult<List<Product>>(_productDal.GetAll(),true,Messages.ProductAll);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id),Messages.ProductAll);
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId),Messages.ProductAll);
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max),Messages.ProductAll);
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails(),Messages.ProductAll);
        }
    }
}
