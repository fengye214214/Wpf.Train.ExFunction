﻿using System;
using WPF.MvvmLight.UI.Model;

namespace WPF.MvvmLight.UI.Design
{
    public class DesignDataService : IDataService
    {
        public void GetData(Action<DataItem, Exception> callback)
        {
            // Use this to create design time data

            var item = new DataItem("Welcome to Hello World[Design]");
            callback(item, null);
        }
    }
}