using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phoneJWT
{
    public class Startup
    {
        public static IServiceProvider? ServiceProvider { get; set; }

        public static void Initialize(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        public static T GetService<T>()
        {
            return ServiceProvider.GetService<T>();
        }
    }
}
