using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyApp.Services;
using MyApp.Services.Impl;
using MyApp.ViewModels;
using MyApp.Views;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using Xamarin.Forms;

namespace MyApp
{
	public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer)
        {

        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //
            //  Xamarin
            containerRegistry.RegisterForNavigation<NavigationPage>();

            //
            //  Services
            containerRegistry.RegisterSingleton<IItemsService, ItemsService>();

            //
            //  View Models
            containerRegistry.RegisterForNavigation<LoginPage, LoginViewModel>();
            containerRegistry.RegisterForNavigation<ItemsPage, ItemsViewModel>();
        }

        protected override void OnInitialized()
        {
            NavigationService.NavigateAsync(new Uri("/NavigationPage/LoginPage", UriKind.Absolute));
        }
    }
}
