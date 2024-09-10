using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uvod.Repository.Common;
using Uvod.Repository;
using Uvod.Service.Common;

namespace Uvod.Service
{
    public class ServiceDIModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AnimalService>().As<IAnimalService>().InstancePerDependency();
            builder.RegisterType<OwnerService>().As<IOwnerService>().InstancePerDependency();
        }
    }
}
