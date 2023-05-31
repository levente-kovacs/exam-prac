using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csudh
{
    public class IpAddress
    {
        public string DomainName { get; private set; }
        public string IpAddress_ { get; private set; }

        public IpAddress(string line)
        {
            string[] lineParts = line.Split(';');
            DomainName = lineParts[0];
            IpAddress_ = lineParts[1];
        }

        public override string ToString()
        {
            return $"{DomainName} {IpAddress_}";
        }
    }
}
