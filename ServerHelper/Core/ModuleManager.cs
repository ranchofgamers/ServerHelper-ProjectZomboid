using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerHelper.Core
{
    public static class ModuleManager
    {
        public static List<IModule> Modules { get; private set; } = new List<IModule>();

        public static void RegisterModules(List<IModule> modules)
        {
            foreach (var m in modules)
            {
                RegisterModule(m);
            }
        }
        public static void RegisterModule(IModule module)
        {
            if (Modules.Contains(module))
                throw new ArgumentException($"Модуль {module} уже зарегистрирован");

            Modules.Add(module);
        }
    }
}
