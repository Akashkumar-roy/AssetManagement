using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Asset_Management1.Products;
using Asset_Management1.Projects;
using Volo.Abp.DependencyInjection;

namespace Asset_Management1.Data
{
    public class SampleDataService : ISingletonDependency
    {
        private List<ProductDto> DataSource = new List<ProductDto>
            {
                new ProductDto
                {
                    Id = Guid.NewGuid(),
                    Name = "vivo v21e 5G",
                    PublishDate = DateTime.Today,
                    Price = 25000F
                },
                new ProductDto
                {
                    Id = Guid.NewGuid(),
                    Name = "Realme6 pro",
                    PublishDate = DateTime.Now,
                    Price = 16000F
                },
                 new ProductDto
                {
                    Id = Guid.NewGuid(),
                    Name = "lenovo p1m40",
                    PublishDate = DateTime.Now,
                    Price = 11000F
                }

            };
        public List<ProductDto> GetDigitalTwins()
        {
            return DataSource;
        }

        public ProductDto GetProduct(Guid id)
        {
            return DataSource.SingleOrDefault(x => x.Id == id);
        }

        public ProductDto CreateProduct(ProductDto input)
        {
            DataSource.Add(new ProductDto
            {
                Id = input.Id,
                Name = input.Name,
                Price = input.Price,
                PublishDate = input.PublishDate
            });

            return input;
        }

        public ProductDto UpdateProduct(ProductDto input)
        {
            DeleteProduct(input);
            CreateProduct(input);

            return input;
        }

        public void DeleteProduct(ProductDto input)
        {
            DataSource.Remove(input);
        }

        // Projects

        private List<ProjectDto> DataSource1 = new List<ProjectDto>
            {
                new ProjectDto
                {
                    Id = Guid.NewGuid(),   
                    Name = "Project no 1",
                    Description = " Block Chain Based Company",
                    url = "https://www.karpine.com/"
                },
                 new ProjectDto
                {
                    Id = Guid.NewGuid(),
                    Name = "Project no 2",
                    Description = " Describe the person",
                    url = "https://www.portfolio.com/"
                },
                  new ProjectDto
                {
                    Id = Guid.NewGuid(),
                    Name = "Project no 3",
                    Description = " connector to web 2.0",
                    url = "https://www.metamask.com/"
                },
            };
        public List<ProjectDto> GetProjects()
        {
            return DataSource1;
        }
        public ProjectDto GetProject(Guid id)
        {
            return DataSource1.SingleOrDefault(x => x.Id == id);
        }

        public ProjectDto CreateProject(ProjectDto input) 
        {
            DataSource1.Add(new ProjectDto
            {
                Id = input.Id,
                Name = input.Name,
                Description = input.Description,
                url = input.url
            });

            return input;
        }
        public ProjectDto UpdateProject(ProjectDto input)
        {
            DeleteProject(input);
            CreateProject(input);

            return input;
        }
        public void DeleteProject(ProjectDto input)
        {
            DataSource1.Remove(input);
        }
    }


}