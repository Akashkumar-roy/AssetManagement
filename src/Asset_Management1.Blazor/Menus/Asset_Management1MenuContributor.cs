using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Asset_Management1.Localization;
using Volo.Abp.Account.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.UI.Navigation;
using Volo.Abp.Users;

namespace Asset_Management1.Blazor.Menus;

public class Asset_Management1MenuContributor : IMenuContributor
{
    private readonly IConfiguration _configuration;

    public Asset_Management1MenuContributor(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
        else if (context.Menu.Name == StandardMenus.User)
        {
            await ConfigureUserMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var l = context.GetLocalizer<Asset_Management1Resource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                Asset_Management1Menus.Home,
                l["Menu:Home"],
                "/",
                icon: "fas fa-home"
            )
        );

        context.Menu.AddItem(
              new ApplicationMenuItem(
                  "Asset_Management1",
                  l["Menu:Asset Progress"],
                  icon: "fa fa-Kanban"
              ).AddItem(
                  new ApplicationMenuItem(
                      "Asset_Management1.Kanban",
                      l["Menu:ProgressReport"],
                      url: "/kanban"
                  )
             )

      );

        context.Menu.AddItem(
               new ApplicationMenuItem(
                   "Asset_Management1",
                   l["Menu:Product"],
                   icon: "fa fa-product"
               ).AddItem(
                   new ApplicationMenuItem(
                       "Asset_Management1.Products",
                       l["Menu:Products"],
                       url: "/products"
                   )
              )
                
       );

        context.Menu.AddItem(
               new ApplicationMenuItem(
                   "Asset_Management1",
                   l["Menu:Project"],
                   icon: "fa fa-product"
               ).AddItem(
                   new ApplicationMenuItem(
                       "Asset_Management1.Projects",
                       l["Menu:Projects"],
                       url: "/projects"
                  )
              )
        );
       



        return Task.CompletedTask;
    }

    private Task ConfigureUserMenuAsync(MenuConfigurationContext context)
    {
        var accountStringLocalizer = context.GetLocalizer<AccountResource>();

        var identityServerUrl = _configuration["AuthServer:Authority"] ?? "";

        context.Menu.AddItem(new ApplicationMenuItem(
            "Account.Manage",
            accountStringLocalizer["MyAccount"],
            $"{identityServerUrl.EnsureEndsWith('/')}Account/Manage?returnUrl={_configuration["App:SelfUrl"]}",
            icon: "fa fa-cog",
            order: 1000,
            null).RequireAuthenticated());

        return Task.CompletedTask;
    }
}
