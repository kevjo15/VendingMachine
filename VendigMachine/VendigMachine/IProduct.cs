using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendigMachine
{
    public interface IProduct
    {
        bool Buy(string name, int price);
        void Description(string description);
        void Use(string name);  
    }
}
