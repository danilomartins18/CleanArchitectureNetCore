using Application.Dtos;
using Application.Exceptions;
using Application.Interfaces.Services;
using AutoMapper;
using Domain.Bases;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Serrvices
{
    public class ProductService : IProductService
    {
        private readonly IBaseRepository<Product> _repository;
        private readonly IMapper _mapper;
        private readonly IValidator<Product> _validator;

        public ProductService(IBaseRepository<Product> repository, IMapper mapper, IValidator<Product> validator)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
        }
        public async Task<BaseHttpResponse<bool>> Proccess()
        {
            try
            {
                List<ProductDto> dtos = File.ReadAllLines(@"F:\Tmp\products.csv")
                                        .Skip(1)
                                        .Select(v => ProductDto.FromCsv(v))
                                        .ToList();

                var products = _mapper.Map<List<Product>>(dtos);
                for (int i = 0; i < products.Count - 1; i++)
                {
                    var product = products[i];
                    var validator = await _validator.ValidateAsync(product);
                    //if (!validator.IsValid) throw new ValidationException($"Ocorreu um ou mais erros na linha {i}.", validator.Errors);
                    if (!validator.IsValid) return new BaseHttpResponse<bool>($"Ocorreu um ou mais erros na linha {i}.", validator.Errors);
                }

                return new BaseHttpResponse<bool>(true);
            }
            catch (Exception)
            {
                throw;
            }
            


            
        }
    }
}
