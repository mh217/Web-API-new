using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uvod.Repository.Common;

namespace Uvod.Repository
{
    public class RepositoryDIModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AnimalRepository>().As<IAnimalRepository>().InstancePerDependency();
            builder.RegisterType<OwnerRepository>().As<IOwnerRepository>().InstancePerDependency();
        }
    }
}
