using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace DotCom.Specs.ProviderSearch
{
    public class ProviderSearchBasicResult
    {
        private string name;
        private string specialty;
        private string line1;
        private string line2;
        private string city;
        private string state;
        private string zip;
        private string phone;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Specialty
        {
            get
            {
                return specialty;
            }

            set
            {
                specialty = value;
            }
        }

        public string Line1
        {
            get
            {
                return line1;
            }

            set
            {
                line1 = value;
            }
        }

        public string Line2
        {
            get
            {
                return line2;
            }

            set
            {
                line2 = value;
            }
        }

        public string City
        {
            get
            {
                return city;
            }

            set
            {
                city = value;
            }
        }

        public string State
        {
            get
            {
                return state;
            }

            set
            {
                state = value;
            }
        }

        public string Zip
        {
            get
            {
                return zip;
            }

            set
            {
                zip = value;
            }
        }

        public string Phone
        {
            get
            {
                return phone;
            }

            set
            {
                phone = value;
            }
        }
    }
}
