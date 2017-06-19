using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XcelerTask.Models;

namespace XcelerTask.DependencyServices
{
    public interface IJsonData
    {
        UserProfileList ReadDataFromJson();
        //bool WriteDatatoJson();
    }
}
