using Restataurentapplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restataurentapplication.Interface
{
     public interface IItemTypes
    {
        List<ItemModel> GetAllitems(string connectionString);
        decimal GetItempricebyitem(string connectionString, int itemid);
    }
}
