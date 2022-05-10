using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Infra.Bus;
using MicroService_RabbitMQ.Domain.Core.Bus;
using MicroRabbit.Banking.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroRabbit.Banking.Data.Context;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Banking.Data.Repository;

namespace MicroRabbit.Infra.IOC
{
   public  class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
           // //Domain Bus
           // services.AddTransient<IEventBus, RabbitMQBus>();

           // //Application Service

           // services.AddTransient<IAccountServices, AccountServices>();

           // //Data
           //// services.AddTransient<BankingDBContext>();
           // services.AddTransient<IAccountRepository,AccountRepository>();

        }
    }
}
