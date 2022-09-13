using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Asset_Management1.Data;
using Volo.Abp.Application.Services;


namespace Asset_Management1.Products
{
    public class ProductAppService : ApplicationService, IProductAppService
    {
        private readonly SampleDataService _sampleProductDataService;

        public ProductAppService(SampleDataService sampleProductDataService)
        {
            _sampleProductDataService = sampleProductDataService;
        }

        public async Task<List<ProductDto>> GetListAsync()
        {
            return await Task.Run(() => _sampleProductDataService.GetDigitalTwins());
        }

        public async Task<ProductDto> GetAsync(Guid id)
        {
            var product = await Task.Run(() => _sampleProductDataService.GetProduct(id));

            return product;
        }

        public async Task<ProductDto> CreateAsync(CreateUpdateProductDto input)
        {
            var newProduct = new ProductDto
            {
                Id = GuidGenerator.Create(),
                Name = input.Name,
                PublishDate = input.PublishDate,
                Price = input.Price
            };

            newProduct = await Task.Run(() => _sampleProductDataService.CreateProduct(newProduct));

            return newProduct;
        }

        public async Task<ProductDto> UpdateAsync(Guid id, CreateUpdateProductDto input)
        {
            var product = await Task.Run(() => _sampleProductDataService.GetProduct(id));

            product.Name = input.Name;
            product.Price = input.Price;
            product.PublishDate = input.PublishDate;

            product = await Task.Run(() => _sampleProductDataService.UpdateProduct(product));

            return product;
        }

        public async Task DeleteAsync(Guid id)
        {
            var product = await Task.Run(() => _sampleProductDataService.GetProduct(id));

            await Task.Run(() => _sampleProductDataService.DeleteProduct(product));
        }
    }
}
