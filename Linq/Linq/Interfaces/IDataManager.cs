using System.Collections.Generic;
using System.Threading.Tasks;
using Linq.Entities;

namespace Linq.Interfaces
{
    public interface IDataManager
    {
        Task<IEnumerable<User>> PrepareDataForQuerying();
    }
}