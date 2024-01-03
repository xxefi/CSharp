using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonefyApp.Model;

namespace MonefyApp.Service.Command
{
    public interface IFileService
    {
        List<Data> Open(string fileName);
        void Save(string fileName, List<Data> actions);
    }
}
