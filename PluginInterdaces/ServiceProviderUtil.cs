using System;
namespace PluginInterdaces
{
    public static class ServiceProviderUtil
    {
        public static T GetService<T>(this IServiceProvider provider) where T : class
        {
            return (T)provider.GetService(typeof(T));
        }
    }
}
