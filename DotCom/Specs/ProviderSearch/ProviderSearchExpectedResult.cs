using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace DotCom.Specs.ProviderSearch
{
    /// <summary>
    /// This is a simple data structure representing data that comes back in a provider search result.
    /// We use this object to setup the results that we expect to get back from a test and then compare
    /// it with the data that actually came back from the test.
    /// </summary>
    public class ProviderSearchExpectedResult
    { 
        public string Name { get; set; }
        public string Specialty { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }

    }
}
