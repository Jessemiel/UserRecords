using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using UserRecords.Views;

namespace UserRecords.ViewModels
{
    public class ErrorPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        #region Fields

        #endregion
        public ErrorPageViewModel(INavigationService navigationService) : base (navigationService)
        {
            _navigationService = navigationService;

            BackCommand = new DelegateCommand(ExecuteBackCommand);
        }
        #region Properties

        #endregion

        #region Commands
        public ICommand BackCommand { get; set; }
        #endregion

        #region Methods / Functions / Navigations
        private void ExecuteBackCommand()
        {
            _navigationService.NavigateAsync($"/NavigationPage/{nameof(UserListPage)}");
        }
        #endregion
    }
}
