using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CoreAPI.Helpers
{
    public static class ServiceCollectionExtension
    {
        /// <summary>
        /// 获取程序集种的实现类对应的多个接口
        /// </summary>
        /// <param name="assemblyName"></param>
        /// <returns></returns>
        private static Dictionary<Type, Type[]> GetClassName(string assemblyName)
        {
            var result = new Dictionary<Type, Type[]>();
            if (!string.IsNullOrEmpty(assemblyName))
            {
                Assembly assembly = Assembly.Load(assemblyName);
                List<Type> ts = new List<Type>(assembly.GetTypes());
                foreach (var item in ts.Where(s => !s.IsInterface))
                {
                    var interfaceType = item.GetInterfaces();
                    result.Add(item, interfaceType);
                }
            }
            return result;
        }

        /// <summary>
        /// 注册多个程序集服务
        /// </summary>
        /// <param name="services"></param>
        /// <param name="assemblyNames"></param>
        public static void RegisterServices(this IServiceCollection services, List<string> assemblyNames)
        {
            foreach (var assemblyName in assemblyNames)
            {
                services.RegisterService(assemblyName);
            }
        }

        /// <summary>
        /// 注册单个程序集服务
        /// </summary>
        /// <param name="services"></param>
        /// <param name="assemblyName"></param>
        public static void RegisterService(this IServiceCollection services, string assemblyName)
        {
            foreach (var item in GetClassName(assemblyName))
            {
                foreach (var interfaceArray in item.Value)
                {
                    //使用.Net Core 自带依赖注入(注入使用的类)
                    services.AddSingleton(interfaceArray, item.Key);
                }
            }
        }
    }
}
