using System.Threading.Tasks;

namespace Linq.Interfaces
{
    public interface IMenu
    {
        Task SetUp();
        void Start(bool showMenu);
    }
}