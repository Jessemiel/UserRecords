using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using UserRecords.Models;

namespace UserRecords.ViewModels
{
    public class UserDetailsPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        #region Fields
        private string _name;
        private string _imageUrl;
        #endregion
        public UserDetailsPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
            Title = "User Details";
        }
        #region Properties        
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }
        public string ImageUrl
        {
            get => _imageUrl;
            set => SetProperty(ref _imageUrl, value);
        }
        #endregion

        #region Commands

        #endregion

        #region Methods / Functions / Navigations
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            if (parameters.TryGetValue<UserModel>(nameof(UserModel), out var user))
            {
                Name = user.Name;
                ImageUrl = user.ImageUrl;
            }
        }
        #endregion

    }
}
