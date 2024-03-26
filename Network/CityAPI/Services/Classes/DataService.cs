using CityAPI.Messages;
using CityAPI.Models;
using CityAPI.Services.Interfaces;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityAPI.Services.Classes
{
    public class DataService : IDataService
    {
        private readonly IMessenger _messenger;

        public DataService(IMessenger messenger)
        {
            _messenger = messenger;
        }

        public void SendData<T>(T? data) where T : IData
        {
            if (data != null)
                _messenger.Send(new DataMessage()
                {
                    Data = data
                });
            else
                throw new NullReferenceException("null");
        }
    }
}
