using System.Data;
using System.Data.SqlClient;

namespace _01_Disconnected_layer_proj._01_Model
{
    interface IModel
    {
       DataSet MyUsersDataSet { get; }
       SqlDataAdapter SqlDataAdapter { get; }
    }
}
