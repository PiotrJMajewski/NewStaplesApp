using Ninject;
using StaplesAppSL.Interfaces;
using StaplesAppSL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StaplesAppSL.Support
{
    public static class Bindings
    {
        public static void AddBindings(IKernel kernel)
        {
            StaplesAppDAL.Support.Bindings.AddBindings(kernel);
            kernel.Bind<IPersonStorageService>().To<PersonStorageService>();
        }
    }
}