using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Votedress.Entities.Messages;
using Votedress.Entities.VeritabaniModellerim;

namespace Votedress.Entities.Modellerim.BusinessLayerResult
{
    public class UserManagerResult
    {
        public List<ErrorMessageObj> Errors { get; set; }

        public List<string> HataNerece { get; set; }
        public VotedressUser User{ get; set; }

        public UserDetail UserDetail { get; set; }





        public UserManagerResult()
        {
            Errors = new List<ErrorMessageObj>();
            HataNerece = new List<string>();
        }


        public void AddError(ErrorMessageCode code, string  message)
        {
            Errors.Add(new ErrorMessageObj() { Code=code,Message=message});
        }
    }
}

