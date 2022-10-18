
/* ================= 예제 6.62: 확장 모듈 로드 ================= */

using System;
using System.IO;
using System.Reflection;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string pluginFolder = @".\plugin";
            if (Directory.Exists(pluginFolder) == true)
            {
                ProcessPlugIn(pluginFolder);
            }
        }

        private static void ProcessPlugIn(string rootPath)
        {
            foreach (string dllPath in Directory.EnumerateFiles(rootPath, "*.dll"))
            {
                // 확장 모듈을 현재의 AppDomain에 로드
                Assembly pluginDll = Assembly.LoadFrom(dllPath);
                Type entryType = FindEntryType(pluginDll);
                if (entryType == null)
                {
                    continue;
                }

                // 타입에 해당하는 객체를 생성하고,
                object instance = Activator.CreateInstance(entryType);
                
                // 약속된 메서드를 구하고,
                MethodInfo entryMethod = FindStartupMethod(entryType);
                if (entryMethod == null)
                {
                    continue;
                }
                
                // 메서드를 호출한다.
                entryMethod.Invoke(instance, null);
            }
        }

        private static Type FindEntryType(Assembly pluginDll)
        {
            foreach (Type type in pluginDll.GetTypes())
            {
                foreach (object objAttr in type.GetCustomAttributes(false))
                {
                    if (objAttr.GetType().Name == "PluginAttribute")
                    {
                        return type;
                    }
                }
            }

            return null;
        }

        private static MethodInfo FindStartupMethod(Type entryType)
        {
            foreach (MethodInfo methodInfo in entryType.GetMethods())
            {
                foreach (object objAttribute in methodInfo.GetCustomAttributes(false))
                {
                    if (objAttribute.GetType().Name == "StartupAttribute")
                    {
                        return methodInfo;
                    }
                }
            }

            return null;
        }
    }
}


