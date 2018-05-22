using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Votedress.Entities.Messages;
using Votedress.Entities.VeritabaniModellerim;

namespace Votedress.Entities.Modellerim.BusinessLayerResult
{
    public class CollectionManagerResult
    {
        public List<ErrorMessageObj> Errors { get; set; }

        public Category Kategori { get; set; }


        public CollectionManagerResult()
        {
            Errors = new List<ErrorMessageObj>();
        }


        public void AddError(ErrorMessageCode code, string message)
        {
            Errors.Add(new ErrorMessageObj() { Code = code, Message = message });
        }
    }
}
