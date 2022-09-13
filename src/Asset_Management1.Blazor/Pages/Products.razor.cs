using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Asset_Management1.Products;

namespace Asset_Management1.Blazor.Pages
{
    public partial class Products
    {
        [Inject]
        private IProductAppService ProductAppService { get; set; }

        private IReadOnlyList<ProductDto> ProductList { get; set; }
        private CreateUpdateProductDto NewProductDto { get; set; }
        private CreateUpdateProductDto EditingProductDto { get; set; }
        private Guid EditingProductId { get; set; }
        private bool Loading { get; set; }
        private bool NewDialogOpen { get; set; }
        private bool EditingDialogOpen { get; set; }

        public Products()
        {
            ProductList = new List<ProductDto>();
            NewProductDto = new CreateUpdateProductDto();
            EditingProductDto = new CreateUpdateProductDto();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await GetProductsAsync();
            }

            await base.OnAfterRenderAsync(firstRender);
        }

        private async Task GetProductsAsync()
        {
            try
            {
                Loading = true;

                await InvokeAsync(() => StateHasChanged());

                ProductList = await ProductAppService.GetListAsync();
            }
            finally
            {
                Loading = false;

                await InvokeAsync(() => StateHasChanged());
            }
        }

        private Task OpenCreateProductModalAsync()
        {
            NewDialogOpen = true;
            NewProductDto = new CreateUpdateProductDto();

            return Task.CompletedTask;
        }

        private async Task CreateProductAsync()
        {
            try
            {
                await ProductAppService.CreateAsync(NewProductDto);

                await GetProductsAsync();
            }
            finally
            {
                NewDialogOpen = false;
            }
        }

        private Task OpenEditingProductModalAsync(ProductDto product)
        {
            EditingDialogOpen = true;
            EditingProductId = product.Id;
            EditingProductDto = new CreateUpdateProductDto
            {
                Name = product.Name,
                Price = product.Price,
                PublishDate = product.PublishDate,
            };

            return Task.CompletedTask;
        }

        private async Task UpdateProductAsync()
        {
            try
            {
                await ProductAppService.UpdateAsync(EditingProductId, EditingProductDto);
            }
            finally
            {
                EditingDialogOpen = false;

                await GetProductsAsync();
            }
        }

        private async Task DeleteProductAsync(ProductDto product)
        {
            var confirmMessage = L["ProductDeletionConfirmationMessage", product.Name];
            if (!await Message.Confirm(confirmMessage))
            {
                return;
            }

            await ProductAppService.DeleteAsync(product.Id);
            await GetProductsAsync();
        }
    }
}
