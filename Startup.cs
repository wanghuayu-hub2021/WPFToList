using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Regions;
using Prism;
using System.ComponentModel;
using System.Windows.Navigation;
using System.Windows;
using WPFToDoList.View;
using WPFToDoList.ViewModel;

namespace WPFToDoList
{
    public class Startup : PrismApplicationBase
    {
        private readonly NavigationService _navigationService;

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // 注册应用程序所需的类型
            containerRegistry.RegisterForNavigation<TaskViewModel, TaskView>();
            containerRegistry.RegisterForNavigation<RandomGameViewModel, RandomGameView>();
            // 注册其他类型...
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            _navigationService.Navigate("Main", null);
        }

        protected override IContainerExtension CreateContainerExtension()
        {
            throw new NotImplementedException();
        }
    }
}
