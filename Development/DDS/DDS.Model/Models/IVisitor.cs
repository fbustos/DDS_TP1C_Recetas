using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDS.Model.Models
{
    public interface IVisitor
    {
        void Visit(Visitable visitable);
    }
}
