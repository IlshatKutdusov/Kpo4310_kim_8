using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Kpo4310.Lib;

namespace Kpo4310.kim.Lib
{
    public class AccessoryListSplitFileLoader : IAccessoryListLoader
    {
        private readonly string _dataFileName;

        public AccessoryListSplitFileLoader()
        {
            _dataFileName = AppGlobalSettings.dataFileName;
        }

        private List<Accessory> _accessoryList = null;
        private LoadStatus _status = LoadStatus.None;
        private int i = 0;

        public List<Accessory> accessoryList { get { return _accessoryList; } }
        public LoadStatus status { get { return _status; } }

        /*public OnLoadFileDelegate onAfterRowConvert = null;

        public void SetAfterRowConvert(OnLoadFileDelegate onAfterRowConvert)
        {
            this.onAfterRowConvert = onAfterRowConvert;
        }

        public OnLoadFileDelegate AfterRowConvert
        {
            get => onAfterRowConvert;
        }
        */

        public void Execute()
        {
            //Инициализировать статус выполнения чтения данных
            _status = LoadStatus.None;

            //Если имя файла не указано
            if (_dataFileName == "")
            {
                _status = LoadStatus.FileNameIsEmpty;
                throw new Exception("Путь к файлу не указан");
            }

            //Если файл не существует
            if (!File.Exists(_dataFileName))
            {
                _status = LoadStatus.FileNotExists;
                throw new Exception("Файл не найден");
            }

            StreamReader sr = null;
            using (sr = new StreamReader(_dataFileName))
            {
                i = 0;
                while (!sr.EndOfStream)
                {
                    string str = sr.ReadLine();

                    try
                    {
                        string[] arr = str.Split('#');
                        Accessory accessory = new Accessory
                        {
                            name = arr[0],
                            type = arr[1],
                            value = arr[2],
                            quantity = arr[3]

                        };
                        if (_accessoryList == null)
                            _accessoryList = new List<Accessory>();
                        i++;
                        System.Threading.Thread.Sleep(500);
                        //onAfterRowConvert("Количество загруженных строк: " + i);
                        _accessoryList.Add(accessory);
                    }
                    catch (Exception ex)
                    {
                        LogUtility.ErrorLog(ex);
                        _status = LoadStatus.GeneralError;
                    }
                }
            }

            _status = LoadStatus.Success;
        }
    }
}
