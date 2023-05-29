using System;

namespace WpfHost.Interfaces
{
    public static class ServiceProviderUtil
    {
        public static T GetService<T>(this IServiceProvider provider) where T : class
        {
            return (T)provider.GetService(typeof(T));
        }
    }
}
