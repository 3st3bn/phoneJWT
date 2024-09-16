using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phoneJWT.Services.Interfaces
{
     public interface ILoginService
    {
        Task<string> LoginAsync(string name, string password);

    }
}
