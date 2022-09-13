using Asset_Management1.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Asset_Management1.DigitalTwins
{
    public interface IDigitalTwinAppService : IApplicationService
    {
        Task<List<DigitalTwinDto>> GetListAsync();

        Task<DigitalTwinDto> GetAsync(Guid id);

        Task<DigitalTwinDto> CreateAsync(CreateUpdateDigitalTwinDto input);

        Task<DigitalTwinDto> UpdateAsync(Guid id, CreateUpdateDigitalTwinDto input);

        Task DeleteAsync(Guid id);
    }
}
