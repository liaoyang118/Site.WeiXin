using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Site.Untity.WeiXinCore.Handle
{
    public interface IHandleBase
    {
        string Handle(string xml);
    }
}
