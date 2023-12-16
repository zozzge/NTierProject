using Business.Abstract;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationException = System.ComponentModel.DataAnnotations.ValidationException;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ILogger _logger;

        public ProductManager(IProductDal productDal,ILogger logger)
        {
                _productDal = productDal;
                _logger = logger;   
        }

        //[ValidationAspect(typeof(ProductValidator))]    
        public IResults Add(Product product)
        {
            _logger.Log();
            try
            {
                _productDal.Add(product);
                return new Result(true, Messages.ProductAdded);
            }
            catch (Exception)
            {

                throw;
            }
            

            
        }

        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 02)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SucceedDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SucceedDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<List<Product>> GetAllByUnitPrice(decimal min, decimal max)
        {
            return new SucceedDataResult<List<Product>>(_productDal.GetAll(p=>p.UnitPrice>=min && p.UnitPrice<=max)); 
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SucceedDataResult<Product>(_productDal.Get(p=>p.ProductId==productId));
        }

        public IDataResult<List<ProductDetailDto> >GetProductDetails()
        {
            return new SucceedDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }
    }
}
