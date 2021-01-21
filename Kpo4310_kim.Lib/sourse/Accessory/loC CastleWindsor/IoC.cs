using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Kpo4310.Lib;

namespace Kpo4310.kim.Lib
{
    public static class IoC
    {
        public static WindsorContainer container { get; private set; }

        static IoC()
        {
            container = new WindsorContainer();

            if (AppGlobalSettings.mode == "SplitFile")
            {
                container.Register(Component
                    .For<IAccessoryListLoader>()
                    .ImplementedBy<AccessoryListSplitFileLoader>()
                    .LifeStyle.Singleton);

                container.Register(Component
                    .For<IAccessoryListSaver>()
                    .ImplementedBy<AccessoryListSplitFileSaver>()
                    .LifeStyle.Singleton);
            }
            else
            {
                container.Register(Component
                    .For<IAccessoryListLoader>()
                    .ImplementedBy<AccessoryListTestLoader>()
                    .LifeStyle.Singleton);

                container.Register(Component
                    .For<IAccessoryListSaver>()
                    .ImplementedBy<AccessoryListTestSaver>()
                    .LifeStyle.Singleton);
            }


        }
    }
}
