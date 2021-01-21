﻿using System.Collections.Generic;

namespace Kpo4310.kim.Lib
{
    public enum LoadStatus
    {
        None = 0,
        Success = 1,
        FileNameIsEmpty = -1,
        FileNotExists = -2,
        NoData = -3,
        GeneralError = -100
    }
    public interface IAccessoryListLoader
    {
        List<Accessory> accessoryList { get; }
        LoadStatus status { get; }

        void Execute();
        //void SetAfterRowConvert(OnLoadFileDelegate onAfterRowConvert);
        //OnLoadFileDelegate AfterRowConvert { get; }
    }
}