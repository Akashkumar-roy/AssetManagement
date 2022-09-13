using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Asset_Management1.Projects;

namespace Asset_Management1.Blazor.Pages
{
    public partial class Projects
    {

        [Inject]
        private IProjectAppService ProjectAppService { get; set; }

        private IReadOnlyList<ProjectDto> ProjectList { get; set; }
        private CreateUpdateProjectDto NewProjectDto { get; set; }
        private CreateUpdateProjectDto EditingProjectDto { get; set; }
        private Guid EditingProjectId { get; set; }
        private bool Loading { get; set; }
        private bool NewDialogOpen { get; set; }
        private bool EditingDialogOpen { get; set; }

        public Projects()
        {
            ProjectList = new List<ProjectDto>();
            NewProjectDto = new CreateUpdateProjectDto();
            EditingProjectDto = new CreateUpdateProjectDto();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await GetProjectsAsync();
            }

            await base.OnAfterRenderAsync(firstRender);
        }

        private async Task GetProjectsAsync()
        {
            try
            {
                Loading = true;

                await InvokeAsync(() => StateHasChanged());

                ProjectList = await ProjectAppService.GetListAsync();
            }
            finally
            {
                Loading = false;

                await InvokeAsync(() => StateHasChanged());
            }
        }

        private Task OpenCreateProjectModalAsync()
        {
            NewDialogOpen = true;
            NewProjectDto = new CreateUpdateProjectDto();

            return Task.CompletedTask;
        }

        private async Task CreateProjectAsync()
        {
            try
            {
                await ProjectAppService.CreateAsync(NewProjectDto);

                await GetProjectsAsync();
            }
            finally
            {
                NewDialogOpen = false;
            }
        }

        private Task OpenEditingProjectModalAsync(ProjectDto project)
        {
            EditingDialogOpen = true;
            EditingProjectId = project.Id;
            EditingProjectDto = new CreateUpdateProjectDto
            {
                Name = project.Name,
                Description = project.Description,
                url = project.url,
            };

            return Task.CompletedTask;
        }

        private async Task UpdateProjectAsync()
        {
            try
            {
                await ProjectAppService.UpdateAsync(EditingProjectId, EditingProjectDto);
            }
            finally
            {
                EditingDialogOpen = false;

                await GetProjectsAsync();
            }
        }

        private async Task DeleteProjectAsync(ProjectDto project)
        {
            var confirmMessage = L["ProjectDeletionConfirmationMessage", project.Name];
            if (!await Message.Confirm(confirmMessage))
            {
                return;
            }

            await ProjectAppService.DeleteAsync(project.Id);
            await GetProjectsAsync();
        }
    }
}
