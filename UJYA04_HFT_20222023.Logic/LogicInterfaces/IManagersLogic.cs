using System.Linq;
using UJYA04_HFT_20222023.Models;

namespace UJYA04_HFT_20222023.Logic.LogicClasses
{
    internal interface IManagersLogic
    {
        void Create(Managers item);
        void Delete(int id);
        double GetAverageSalary();
        Managers Read(int id);
        IQueryable<Managers> ReadAll();
        void Update(Managers item);
    }
}