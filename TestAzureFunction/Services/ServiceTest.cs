using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAzureFunction.Services
{
    internal class ServiceTest : IServiceTest
    {
        public bool isTrue(string name)
        {
            if (name == null)
                return false;
            return true;
        }
    }
}
