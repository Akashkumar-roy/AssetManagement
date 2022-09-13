using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Asset_Management1.Data;
using Volo.Abp.Application.Services;


namespace Asset_Management1.Projects
{
    public class ProjectAppService : ApplicationService, IProjectAppService
    {
        private readonly SampleDataService _sampleProjectDataService;

        public ProjectAppService(SampleDataService sampleProjectDataService)
        {
            _sampleProjectDataService = sampleProjectDataService;
        }

        public async Task<List<ProjectDto>> GetListAsync()
        {
            return await Task.Run(() => _sampleProjectDataService.GetProjects());
        }

        public async Task<ProjectDto> GetAsync(Guid id)
        {
            var project = await Task.Run(() => _sampleProjectDataService.GetProject(id));

            return project;
        }

        public async Task<ProjectDto> CreateAsync(CreateUpdateProjectDto input)
        {
            var newProject = new ProjectDto
            {
                Id = GuidGenerator.Create(),
                Name = input.Name,
                Description = input.Description,
                url = input.url
            };

            newProject = await Task.Run(() => _sampleProjectDataService.CreateProject(newProject));

            return newProject;
        }

        public async Task<ProjectDto> UpdateAsync(Guid id, CreateUpdateProjectDto input)
        {
            var project = await Task.Run(() => _sampleProjectDataService.GetProject(id));

            project.Name = input.Name;
            project.Description = input.Description;
            project.url = input.url;

            project = await Task.Run(() => _sampleProjectDataService.UpdateProject(project));

            return project;
        }

        public async Task DeleteAsync(Guid id)
        {
            var project = await Task.Run(() => _sampleProjectDataService.GetProject(id));

            await Task.Run(() => _sampleProjectDataService.DeleteProject(project));
        }
    }
}