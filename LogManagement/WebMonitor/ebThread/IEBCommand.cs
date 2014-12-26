using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebMonitor.ebThread
{
 
    public interface IEBCommand
    {
        void execute(object data_);
    }
}
