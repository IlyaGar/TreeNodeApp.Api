using TreeNodeApp.DataAccess.Repository.Interface.UserJournals.Interfaces;
using TreeNodeApp.DataAccess.Repository.Interface.UserTrees.Interfaces;
using TreeNodeApp.DataAccess.Repository.UserJournals;
using TreeNodeApp.DataAccess.Repository.UserTrees;
using TreeNodeApp.Provider.Service.Interface.UserJournals.Interfaces;
using TreeNodeApp.Provider.Service.Interface.UserTreeNodes.Interfaces;
using TreeNodeApp.Provider.Service.Interface.UserTrees.Interfaces;
using TreeNodeApp.Provider.Service.UserJournals;
using TreeNodeApp.Provider.Service.UserTreeNodes;
using TreeNodeApp.Provider.Service.UserTrees;

namespace TreeNodeApp.Api.WebApplicationBuilder
{
    internal static class DependencyConfig
    {
        internal static void ConfigureServices(IServiceCollection services)
        {
            ConfigureProviderServices(services);
            ConfigureDalRepository(services);
        }

        private static void ConfigureProviderServices(IServiceCollection services)
        {
            services.AddScoped<IUserJournalService, UserJournalService>();
            services.AddScoped<IUserTreeService, UserTreeService>();
            services.AddScoped<IUserTreeNodeService, UserTreeNodeService>();
        }

        private static void ConfigureDalRepository(IServiceCollection services)
        {
            services.AddScoped<IUserJournalRepository, UserJournalRepository>();
            services.AddScoped<IUserTreeRepository, UserTreeRepository>();
            
        }
    }
}
