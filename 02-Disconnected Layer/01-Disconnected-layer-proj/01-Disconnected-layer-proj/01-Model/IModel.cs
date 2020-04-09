using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Disconnected_layer_proj._01_Model
{
    interface IModel
    {
       DataSet MyUsersDataSet { get; }
       SqlDataAdapter SqlDataAdapter { get; }
    }
}
