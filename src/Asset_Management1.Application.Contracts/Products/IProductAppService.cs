using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Asset_Management1.Products
{
	public interface IProductAppService : IApplicationService
	{
        Task<List<ProductDto>> GetListAsync();

        Task<ProductDto> GetAsync(Guid id);

        Task<ProductDto> CreateAsync(CreateUpdateProductDto input);

        Task<ProductDto> UpdateAsync(Guid id, CreateUpdateProductDto input);

        Task DeleteAsync(Guid id);
    }
}
