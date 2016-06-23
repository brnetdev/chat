using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.FE.Web.App_Start
{
    public class IocConfig
    {
        private static Castle.Windsor.WindsorContainer container = new Castle.Windsor.WindsorContainer();

        public static void RegisterComponents()
        {
            container.Install();
            //container.Register
        }
    }
}
