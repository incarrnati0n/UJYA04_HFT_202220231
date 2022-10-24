using System.Linq;
using UJYA04_HFT_20222023.Models;

namespace UJYA04_HFT_20222023.Logic.LogicClasses
{
    public interface IManagersLogic
    {
        void Create(Managers item);
        void Delete(int id);
        IQueryable<string> ManagerName(int id);
        Managers Read(int id);
        IQueryable<Managers> ReadAll();
        void Update(Managers item);
    }
}