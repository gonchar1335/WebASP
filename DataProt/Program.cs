using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;

namespace DataProt
{
    public class DIClass
    {
        private IDataProtectionProvider provider;
        public DIClass(IDataProtectionProvider provider) => this.provider = provider;
        public IDataProtector GetProtector(string[] purpose) => provider.CreateProtector(purpose);
        
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string test = "some text to project";
            var services = new ServiceCollection();
            services.AddDataProtection();
            var provider = services.BuildServiceProvider();

            var instance = ActivatorUtilities.CreateInstance<DIClass>(provider);
            var protector = instance.GetProtector(new string[] { "abcd", "a2" });
            string save = protector.Protect(test);
            Console.WriteLine(save);
            Console.WriteLine(protector.Unprotect(save));

        }
    }
}
