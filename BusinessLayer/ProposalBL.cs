
using DatabaseLayer;
using ModelsClassLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ProposalBL
    {
        public static bool Save(ProposalModel prpsl)
        {
            bool returnValue = false;
            try
            {
                returnValue = DatabaseLayer.PersistProposals.SaveProposals(prpsl);
            }
            catch (Exception e)
            {
                returnValue = false;
                throw e;
            }
            finally
            {
            }
            return returnValue;
        }

        public static System.Data.DataSet GetAllProposals()
        {
            string sqlQuery = "select * from Proposal order by ProposalId desc";
            DataSet ds = new DataSet();
            ds = DatabaseBroker.GetDataSet(sqlQuery);
            return ds;
        }

        public static bool Update(ProposalModel prpsl)
        {
            bool returnValue = false;
            try
            {
                returnValue = PersistProposals.UpdateProposals(prpsl);
            }
            catch (Exception e)
            {
                returnValue = false;
                throw e;
            }
            finally
            {
            }
            return returnValue;
        }
    }
}
