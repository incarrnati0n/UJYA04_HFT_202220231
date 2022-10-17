using System.Linq;
using UJYA04_HFT_20222023.Models;

namespace UJYA04_HFT_20222023.Logic.LogicClasses
{
    internal interface IPlayersLogic
    {
        void Create(Players item);
        void Delete(int id);
        double GetAverageRatingByShirtNum(int shirtnumber);
        Players Read(int id);
        IQueryable<Players> ReadAll();
        void Update(Players item);
    }
}