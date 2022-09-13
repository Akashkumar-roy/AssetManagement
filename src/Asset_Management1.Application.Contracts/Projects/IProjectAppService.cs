using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Asset_Management1.Projects
{
    public interface IProjectAppService : IApplicationService
    {
        Task<List<ProjectDto>> GetListAsync();

        Task<ProjectDto> GetAsync(Guid id);

        Task<ProjectDto> CreateAsync(CreateUpdateProjectDto input);

        Task<ProjectDto> UpdateAsync(Guid id, CreateUpdateProjectDto input);

        Task DeleteAsync(Guid id);
    }
}