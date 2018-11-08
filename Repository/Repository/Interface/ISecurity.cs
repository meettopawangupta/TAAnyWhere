using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.Interface
{
   public interface ISecurity
    {
        string GenerateSHA256String(string inputString);
        string GenerateSHA512String(string inputString);

    }
}
