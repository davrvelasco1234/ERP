using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host.WindowLocator
{
    public class ViewModelLocator
    {

        //public static MainViewModel MainViewModel => Ioc.Default.GetService<MainViewModel>();
        //public static ControlsViewModel ControlsViewModel => Ioc.Default.GetService<ControlsViewModel>();
        //public static BottomViewModel BottomViewModel => Ioc.Default.GetService<BottomViewModel>();
        //
        //
        //static ViewModelLocator()
        //{
        //    Ioc.Default.ConfigureServices(ConfigureService());
        //}
        //
        //
        //private static IServiceProvider ConfigureService()
        //{
        //    var services = new ServiceCollection();
        //
        //    //ViewModels
        //    services.AddSingleton<MainViewModel>();
        //    services.AddSingleton<ControlsViewModel>();
        //
        //
        //
        //    //Services
        //    //services.AddTransient<IExecQuery>(EX => new ExecQuery("Default"));
        //
        //
        //
        //    //Templates
        //    services.AddSingleton<BottomViewModel>();
        //
        //    return services.BuildServiceProvider();
        //}
    }
}


