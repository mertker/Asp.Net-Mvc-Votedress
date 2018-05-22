using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Votedress.DataAccessLayer;

namespace Votedress.DataAccessLayer.EntitiyFramework
{
    public class RepositoryBase
    {
        protected static DatabaseContext context;
        private static object _lockSync = new object();

        protected RepositoryBase()
        {
           context= CreateContext();
        }
        
        private static DatabaseContext CreateContext()
        {
      
            if(context==null)
            {
                lock(_lockSync)
                {
                    if(context==null)
                    {
                        context = new DatabaseContext();  
                    }
                }
            }

            return context;

           
        }
    }
}
