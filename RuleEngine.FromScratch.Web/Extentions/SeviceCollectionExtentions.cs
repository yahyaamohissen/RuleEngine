using RuleEngine.FromScratch.Web.Flows;

namespace RuleEngine.FromScratch.Web.Extentions
{
    public static class SeviceCollectionExtentions
    {
        public static object? AddFlow<T>(this IServiceCollection services) where T : FlowBase
        {
            DepotSelectionManager.Flows.Add(typeof(T));
            services.AddSingleton<T>();
            return services;
        }

        
    }
}
