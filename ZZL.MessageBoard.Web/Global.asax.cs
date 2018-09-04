using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ZZL.MessageBoard.Service.IService;
using ZZL.MessageBoard.Service.Service;

namespace ZZL.MessageBoard.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Autofac 实现构造函数注入;
            var builder = new ContainerBuilder();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<MessageService>().As<IMessageService>();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            //此处必须添加,如果不添加会出现无法找到无参数构造函数错误;
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
