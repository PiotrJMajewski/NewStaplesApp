using Ninject;
using StaplesAppDAL.Interfaces;
using StaplesAppDAL.Models;
using StaplesAppDAL.Repositories;

namespace StaplesAppDAL.Support
{
    public static class Bindings
    {
        public static void AddBindings(IKernel kernel)
        {
            kernel.Bind<IPersonLogRepository>().To<PersonLogRepository>();
            kernel.Bind<IPersonXmlRepository>().To<PersonXmlRepository>();
            kernel.Bind<IRepository<Person>>().To<PersonDbRepository>();
        }
    }
}
