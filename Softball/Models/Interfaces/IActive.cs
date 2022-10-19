using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sport.Models.Interfaces
{
    interface IActive
    {
        bool IsActive { get; }

        void Activate();
        void Inactivate();
    }
}
