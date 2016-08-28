using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BusinessLayer
{
    public class Files
    {
        public IEnumerable<HttpPostedFileBase> ListOfFiles { get; set; }
    }
}
