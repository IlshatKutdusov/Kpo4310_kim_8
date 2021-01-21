﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kpo4310.kim.Lib
{
    public class AccessoryListTestSaver : IAccessoryListSaver
    {
        private List<Accessory> _accessoryList;
        public AccessoryListTestSaver()
        {
            _accessoryList = null;
        }

        public List<Accessory> accessoryList
        {
            set => _accessoryList = value;
        }

        private LoadStatus _status = LoadStatus.None;
        private int i = 3;
        public LoadStatus status { get => _status; }

        /*public OnLoadFileDelegate onAfterRowConvert = null;

        public void SetAfterRowConvert(OnLoadFileDelegate onAfterRowConvert)
        {
            this.onAfterRowConvert = onAfterRowConvert;
        }

        public OnLoadFileDelegate AfterRowConvert
        {
            get => onAfterRowConvert;
        }*/

        public void Execute()
        {
            try
            {
                if (_accessoryList == null) throw new Exception("Данных нет");
                _status = LoadStatus.Success;
                MessageBox.Show("Сохранено! (AccessoryListTestSaver)");
                i++;
                System.Threading.Thread.Sleep(500);
                //onAfterRowConvert("Количество сохраненных строк: " + i);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
                LogUtility.ErrorLog(ex);
                _status = LoadStatus.NoData;
            }
        }

    }
}
