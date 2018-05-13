using Ninject;
using StaplesAppUI.Controllers;
using StaplesAppUI.Interfaces;

namespace StaplesAppUI.Support
{
    public static class Bindings
    {
        public static void AddBindings(IKernel kernel)
        {
            StaplesAppSL.Support.Bindings.AddBindings(kernel);
            kernel.Bind<IPersonController>().To<PersonController>();
        }
    }
}