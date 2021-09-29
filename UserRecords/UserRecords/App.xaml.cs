using Prism;
using Prism.Ioc;
using UserRecords.Interfaces;
using UserRecords.Services;
using UserRecords.ViewModels;
using UserRecords.Views;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace UserRecords
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/UserListPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IUserService, UserService>();
            containerRegistry.Register<IConnectivityService, ConnectivityService>();

            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();            
            containerRegistry.RegisterForNavigation<UserListPage, UserListPageViewModel>();
            containerRegistry.RegisterForNavigation<UserDetailsPage, UserDetailsPageViewModel>();
            containerRegistry.RegisterForNavigation<ErrorPage, ErrorPageViewModel>();
        }
    }
}
