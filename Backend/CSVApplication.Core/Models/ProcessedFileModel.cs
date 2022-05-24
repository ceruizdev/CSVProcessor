using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVApplication.Core.Models
{
    public class ProcessedFileModel
    {
        public string fullContent { get; set; }
        public List<string> splittedContent { get; set; }

        public void SetSplittedText(string delimiter) {
            splittedContent = fullContent.Split(delimiter).ToList();
        }
    }
}
