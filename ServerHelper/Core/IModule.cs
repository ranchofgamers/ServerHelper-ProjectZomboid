using System;

namespace ServerHelper.Core
{
    public interface IModule
    {
        Guid ModuleID { get; }

        IModule GetModule();
    }
}