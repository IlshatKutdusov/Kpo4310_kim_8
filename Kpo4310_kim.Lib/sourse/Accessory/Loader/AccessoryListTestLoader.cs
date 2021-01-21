using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Kpo4310.kim.Lib.AccessoryListSplitFileLoader;

namespace Kpo4310.kim.Lib
{
    public class AccessoryListTestLoader : IAccessoryListLoader
    {
        private List<Accessory> _accessoryList = new List<Accessory>();
        private LoadStatus _status = LoadStatus.None;
        private int i = 0;
        public LoadStatus status { get { return _status; } }

        public List<Accessory> accessoryList
        {
            get { return _accessoryList; }
        }

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
            i = 0;
            try
            {
                {
                    Accessory accessory = new Accessory()
                    {
                        name = "RT-11-24",
                        type = "R",
                        value = "100000",
                        quantity = "12"
                    };
                    i++;
                    System.Threading.Thread.Sleep(500);
                    //onAfterRowConvert("Количество загруженных строк: " + i);
                    accessoryList.Add(accessory);
                }

                {
                    Accessory accessory = new Accessory()
                    {
                        name = "RT-11-24",
                        type = "R",
                        value = "50000",
                        quantity = "10"
                    };
                    i++;
                    System.Threading.Thread.Sleep(500);
                    //onAfterRowConvert("Количество загруженных строк: " + i);
                    accessoryList.Add(accessory);
                }

                {
                    Accessory accessory = new Accessory()
                    {
                        name = "CGU-12K",
                        type = "C",
                        value = "17.5",
                        quantity = "3"
                    };
                    i++;
                    System.Threading.Thread.Sleep(500);
                    //onAfterRowConvert("Количество загруженных строк: " + i);
                    accessoryList.Add(accessory);
                }
            }
            catch (Exception ex)
            {
                LogUtility.ErrorLog(ex);
            }

            _status = LoadStatus.Success;
        }
    }
}
