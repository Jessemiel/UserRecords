using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using UserRecords.Interfaces;
using UserRecords.Models;
using UserRecords.Views;
using Xamarin.Forms;

namespace UserRecords.ViewModels
{
    public class UserListPageViewModel : ViewModelBase
    {
        #region Fields
        private readonly INavigationService _navigationService;
        private readonly IUserService _userService;        
        private ObservableCollection<UserModel> _users;
        private bool _isRefreshing;
        #endregion
        public UserListPageViewModel(INavigationService navigationService,
            IUserService userService) : base(navigationService)
        {
            _navigationService = navigationService;
            _userService = userService;            

            SelectItemCommand = new DelegateCommand<object>(ExecuteSelectItemCommand, CanExecuteSelectItem);
            RefreshCommand = new DelegateCommand(ExecuteRefreshCommand);
            Users = new ObservableCollection<UserModel>();
            Title = "User Records";
            InitializeData();

        }        

        #region Properties        
        public ObservableCollection<UserModel> Users
        {
            get => _users;
            set => SetProperty(ref _users, value);
        }
        #endregion

        #region Commands
        public ICommand SelectItemCommand { get; set; }
        public ICommand RefreshCommand { get; set; }
        
        public bool IsRefreshing
        {
            get => _isRefreshing;
            set => SetProperty(ref _isRefreshing, value);
        }
        #endregion

        #region Methods / Functions / Navigations
        private async void InitializeData()
        {
            try
            {
                var users = await _userService.GetUsers();
                if (users != null)
                {
                    //remove duplicates
                    users.GroupBy(user => user.Id).Select(x => x.FirstOrDefault()).ToList().ForEach(x => Users.Add(x));
                }
            }
            catch (Exception e)
            {
                await _navigationService.NavigateAsync(nameof(ErrorPage));
            }
        }
        private void ExecuteRefreshCommand()
        {
            IsRefreshing = true;
            Users = new ObservableCollection<UserModel>();
            InitializeData();
            IsRefreshing = false;
        }
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);            
        }

        private bool CanExecuteSelectItem(object arg)
        {
            return arg != null;
        }

        private async void ExecuteSelectItemCommand(object userList)
        {
            var selectedUser = (userList as CollectionView).SelectedItem as UserModel;
            var param = new NavigationParameters()
            {
                { nameof(UserModel), selectedUser }
            };
            await _navigationService.NavigateAsync(nameof(UserDetailsPage), param);
        }
        #endregion
    }
}