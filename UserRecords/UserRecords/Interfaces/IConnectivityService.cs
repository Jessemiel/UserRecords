﻿namespace UserRecords.Interfaces
{
    public interface IConnectivityService
    {
        bool IsConnected();
        void CheckConnectivity();
    }
}
