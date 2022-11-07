using CalculatorWPF.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorWPF
{
    public class ServiceLocator
    {
        private readonly ServiceProvider serviceProvider;

        public ServiceLocator()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton<MainWindowViewModel>();
        }

        public MainWindowViewModel MainWindowVM => 
            serviceProvider.GetService<MainWindowViewModel>();
    }
}
