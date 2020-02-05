using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using MathsProgression.Utilities;

namespace MathsProgression.Controllers
{
    /// <summary>
    /// Description résumée de MathsProgressionService
    /// </summary>
    [WebService(Name = "mathprogression")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Pour autoriser l'appel de ce service Web depuis un script à l'aide d'ASP.NET AJAX, supprimez les marques de commentaire de la ligne suivante. 
    // [System.Web.Script.Services.ScriptService]
    public class MathsProgressionService : WebService
    {

        [WebMethod]
        public int Fibonacci(int i)
        {
            if (i > 100 || i < 0)
                return -1;
            return MathsUtilities.Fibonacci(0, 1, 1, i);
        }
    }
}
