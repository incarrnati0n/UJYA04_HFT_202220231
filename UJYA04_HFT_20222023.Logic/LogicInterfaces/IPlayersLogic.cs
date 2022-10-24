using System.Linq;
using UJYA04_HFT_20222023.Models;

namespace UJYA04_HFT_20222023.Logic.LogicClasses
{
    public interface IPlayersLogic
    {
        void Create(Players item);
        void Delete(int id);
        IQueryable<Players> HighestRatingByTeamAndAge(int age, string teamname);
        IQueryable<Managers> ListPlayerByShirtNumber(int shirtnumber);
        Players Read(int id);
        IQueryable<Players> ReadAll();
        IQueryable<string> TeamsOfPlayersUnder25();
        void Update(Players item);
    }
}