using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutorial.Persistence.EF.Context;

namespace Tutorial.Bootstraper
{
  public  class Bootstrap
    {
        public static void WireUp(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<TutorialDbContext>
                (optionsAction => optionsAction
                .UseSqlServer(connectionString), ServiceLifetime.Scoped);
        }
    }
}
