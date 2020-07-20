using System.Collections.Generic;

namespace _01_Disconnected_layer_proj._01_Model
{
    interface IModel
    {
       List<User> Users { get; set; }
       void Fill();
       void Edit(User user);
       void Delete(User user);
       void Add(User user);
    }
}
