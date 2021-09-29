using System;
using UserRecords.Interfaces;
using Xamarin.Essentials;

namespace UserRecords.Services
{
    public class ConnectivityService : IConnectivityService
    {
        public void CheckConnectivity()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
                throw new Exception("No Internet Connection");
        }
        public bool IsConnected()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                return false;
            }
            return true;
        }
    }
}
