using CSVApplication.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVApplication.Core.Interfaces
{
    public interface ICSVBody
    {
        public CSVBodyModel Create(CSVBodyModel CSV);
        public CSVBodyModel Update(CSVBodyModel CSV);
        public List<CSVBodyModel> GetAll();
        public void Delete(int id);
        public List<string> ProcessString(string CSVContent, string delimiter);
    }
}
