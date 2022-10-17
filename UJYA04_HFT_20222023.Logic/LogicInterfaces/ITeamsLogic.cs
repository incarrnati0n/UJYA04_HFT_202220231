using System.Linq;
using UJYA04_HFT_20222023.Models;

namespace UJYA04_HFT_20222023.Logic
{
    public interface ITeamsLogic
    {
        void Create(Teams item);
        void Delete(int id);
        double GetAverageFoundationYear();
        Teams Read(int id);
        IQueryable<Teams> ReadAll();
        void Update(Teams item);
    }
}