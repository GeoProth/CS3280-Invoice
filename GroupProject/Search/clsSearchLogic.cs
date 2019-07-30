using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject.Search
{
    public class clsSearchLogic
    {
        #region Variables
        public clsSearchSQL SQL;
        #endregion

        #region Methods
        public clsSearchLogic()
        {
            try
            {
                SQL = new clsSearchSQL();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " --> " + ex.Message);
            }
        }
        #endregion
    }
}
