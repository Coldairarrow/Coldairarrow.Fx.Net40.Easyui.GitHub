using AutoMapper;
using Coldairarrow.Business.Base_SysManage;
using Coldairarrow.DataRepository;
using Coldairarrow.Entity.Base_SysManage;
using Coldairarrow.Util;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Coldairarrow.Web
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            InitAutoMapper();
            InitEF();
        }

        void Application_End()
        {
            AutoStartWeb();
        }

        /// <summary>
        /// 初始化AutoMapper
        /// </summary>
        private void InitAutoMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Base_User, Base_UserModel>();
            });
        }

        /// <summary>
        /// EF预热
        /// </summary>
        private void InitEF()
        {
            Task.Factory.StartNew(() =>
            {
                using (var dbcontext = new BaseDbContext(GlobalSwitch.DefaultDbConName, GlobalSwitch.DatabaseType, GlobalSwitch.DefaultEntityNamespace))
                {
                    var objectContext = ((IObjectContextAdapter)dbcontext).ObjectContext;
                    var mappingCollection = (StorageMappingItemCollection)objectContext.MetadataWorkspace.GetItemCollection(DataSpace.CSSpace);
                    mappingCollection.GenerateViews(new List<EdmSchemaError>());
                }
            });
        }

        /// <summary>
        /// 自动启动网站
        /// 注：当网站被回收或关闭时，会通过VBS脚本自动启动网站，解决第一次访问慢的问题
        /// </summary>
        private void AutoStartWeb()
        {
            try
            {
                string vbs = $@"wscript.sleep 10*1000
Dim http
Set http = CreateObject(""Msxml2.ServerXMLHTTP"")
http.open ""GET"",""{GlobalSwitch.WebRootUrl}"",False
http.send
CreateObject(""scripting.filesystemobject"").deletefile wscript.scriptfullname
";
                string file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "startWeb.vbs");
                File.WriteAllText(file, vbs, Encoding.Default);
                Process.Start(file);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog_LocalTxt(ExceptionHelper.GetExceptionAllMsg(ex));
            }
        }
    }
}