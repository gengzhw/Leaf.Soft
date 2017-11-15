using Leaf.Services.Demo;
using Leaf.Services.Users;
using Leaf.Core.Configuration;
using Leaf.Core.Domain.Users;
using Leaf.Core.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Linq;
using Leaf.Core.Domain.Spreads;
using System.Collections.Generic;
using Leaf.Services.Spreads;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration;
using Leaf.Services.Helpers;

namespace Leaf.Con
{
    class Program
    {
        public static IServiceCollection services = new ServiceCollection();
        public static IEngine Engine { get; private set; }
        static void Main(string[] args)
        {
            LoadConn();
           
            //LeafConfig.connStr = "Data Source=192.168.0.214;Initial Catalog=coredb;Persist Security Info=True;User ID=sa;Password=Dzcye@2016;";
            //获取引擎上下文实例
            Engine = EngineContext.Current;

           // IServiceCollection services = new ServiceCollection();


            Engine.ConfigureServices(services);

            //var test = EngineContext.Current.Resolve<ITest>().GetStrTest();
            //Console.WriteLine(test);
            //var userService = EngineContext.Current.Resolve<IUserServices>();
            //var data = userService.SearchPage(0, 15);

            ////var data = userService.GetAll(o => o.Id > 0);
            ////Console.WriteLine("数量:"+data.Count());
            //foreach (var u in data)
            //{
            //    Console.WriteLine("{0} {1}", u.Account, u.Id);
            //}

            //var user1 = data.LastOrDefault();
            //var user2 = data.Skip(5).Take(1).FirstOrDefault();
            ////var user3 = data.Skip(10).Take(1).FirstOrDefault();

            //user2.Password = "7758521";
            //var user = new User() { Account="张三丰", Password="1233444", CreateTime=DateTime.Now, LastEditTime=DateTime.Now, DelFlag=0, RoleID=2, Status=0 };

            //userService.Delete(user1);
            //userService.Update(user2);
            //userService.Insert(user);

            // Console.WriteLine(userService.ExecSql("delete from Users where Id =@p0", "52062"));


            ImportQiChacha();

            Console.WriteLine("end...");

            Console.ReadLine();
        }

        public static void LoadConn()
        {
            //string path = Path.Combine(Directory.GetCurrentDirectory(), "config.json");
            //var provider = new JsonConfigurationProvider(new JsonConfigurationSource())
            //provider.Load();

            //string conn = null;
            //provider.TryGet("conn", out conn);
            //Console.WriteLine($"conn={conn}");

            string path = Path.Combine(Directory.GetCurrentDirectory(), "config.json");
                        var builder = new ConfigurationBuilder();
                      builder.AddJsonFile(path);
                       var conn = builder.Build().GetConnectionString("default");

            LeafConfig.connStr = conn;

            Console.WriteLine(conn);

        }
        public static void ImportQiChacha()
        {
            var qichachaServices = EngineContext.Current.Resolve<IQichachaServices>();
            var xlsHelper = EngineContext.Current.Resolve<IXlsHelper>();
            Console.WriteLine("请输入检测目录....");
            string path = Console.ReadLine();

            if (!string.IsNullOrEmpty(path))
            {
                var files = Directory.GetFiles(path, "*.xls").ToList().OrderBy(x => x).ToList();

                foreach (var file in files)
                {
                    Console.WriteLine(file);
                }
                //清除之前记录
                qichachaServices.ExecSql("delete from qichachatb1;");
                //IList<Qichacha> qlist=new List<Qichacha>();
                //foreach (var file in files)
                for (int i = 0; i < files.Count(); i++)
                {
                    //qlist.Clear();
                    Console.WriteLine(files[i]);

                    var qlist = xlsHelper.LoadFromXls(files[i]);

                    Console.WriteLine("获取条数:{0}", qlist.Count());
                    int cur = 0;
                    foreach (var item in qlist)
                    {
                        cur++;
                        //Console.WriteLine(item.Name);
                        if (cur == qlist.Count())
                        {
                            qichachaServices.Insert(item, true);
                        }
                        else if (cur % 500 == 0)
                        {
                            qichachaServices.Insert(item, true);
                        }
                        else
                        {
                            qichachaServices.Insert(item, false);
                        }
                    }
                    Console.WriteLine("导入条数:{0}", qlist.Count());
                }

                Console.WriteLine("导入完成:");
            }
            else {
                Console.WriteLine("导入取消...");
            }
        }


        public static void ImportTianYancha()
        {
            var qichachaServices = EngineContext.Current.Resolve<IQichachaServices>();
            var xlsHelper = EngineContext.Current.Resolve<IXlsHelper>();
            Console.WriteLine("请输入检测目录....");
            string path = Console.ReadLine();

            if (!string.IsNullOrEmpty(path))
            {
                var files = Directory.GetFiles(path, "*.xls").ToList().OrderBy(x => x).ToList();

                foreach (var file in files)
                {
                    Console.WriteLine(file);
                }

                qichachaServices.ExecSql("delete from qichachatb1;");
                //IList<Qichacha> qlist=new List<Qichacha>();
                //foreach (var file in files)
                for (int i = 0; i < files.Count(); i++)
                {
                    //qlist.Clear();
                    Console.WriteLine(files[i]);

                    var qlist = xlsHelper.LoadFromXls(files[i]);

                    Console.WriteLine("获取条数:{0}", qlist.Count());
                    int cur = 0;
                    foreach (var item in qlist)
                    {
                        cur++;
                        //Console.WriteLine(item.Name);
                        if (cur == qlist.Count())
                        {
                            qichachaServices.Insert(item, true);
                        }
                        else if (cur % 500 == 0)
                        {
                            qichachaServices.Insert(item, true);
                        }
                        else
                        {
                            qichachaServices.Insert(item, false);
                        }
                    }
                    Console.WriteLine("导入条数:{0}", qlist.Count());
                }

                Console.WriteLine("导入完成:");
            }
            else
            {
                Console.WriteLine("导入取消...");
            }
        }
    }
}
