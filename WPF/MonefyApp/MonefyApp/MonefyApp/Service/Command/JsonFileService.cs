using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using MonefyApp.Model;

namespace MonefyApp.Service.Command
{
    class JsonFileService : IFileService
    {
        public void Save(string fileName, List<Data> data)
        {
            DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(typeof(List<Data>));
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                dataContractJsonSerializer.WriteObject(fs, data);
            }
        }

        List<Data> IFileService.Open(string fileName)
        {
            DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(typeof(List<Data>));
            try
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Open))
                {
                    return (List<Data>)dataContractJsonSerializer.ReadObject(fs);
                }
            }
            catch (FileNotFoundException)
            {
                return new List<Data>();
            }
        }
    }
}
