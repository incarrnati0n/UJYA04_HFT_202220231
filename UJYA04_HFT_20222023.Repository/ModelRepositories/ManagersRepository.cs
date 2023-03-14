using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UJYA04_HFT_20222023.Models;
using UJYA04_HFT_20222023.Repository.BaseRepository;
using UJYA04_HFT_20222023.Repository.DBContext;

namespace UJYA04_HFT_20222023.Repository.ModelRepositories
{
    public class ManagersRepository : Repository<Managers>, IRepository<Managers>
    {
        public ManagersRepository(FootyDbContext ctx) : base(ctx)
        {

        }

        public override Managers Read(int id)
        {
            return ctx.Managers.FirstOrDefault(m => m.ManagerId == id);
        }

        public override void Update(Managers item)
        {
            var old = Read(item.ManagerId);
            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(item));
                }
            }
            ctx.SaveChanges();
        }
    }
}
