using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UserRecords.Constants;
using UserRecords.Interfaces;
using UserRecords.Models;

namespace UserRecords.Services
{
    public class UserService : IUserService
    {
        private readonly IConnectivityService _connectivity;

        public UserService(IConnectivityService connectivity)
        {
            _connectivity = connectivity;
        }
        public async Task<List<UserModel>> GetUsers()
        {
            _connectivity.CheckConnectivity();
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetStringAsync(AppConstant.BaseUri);
                if (response == null)
                {
                    return new List<UserModel>();
                }
                var ret = JsonConvert.DeserializeObject<List<UserModel>>(response);
                return ret;
            }
        }
    }
}
