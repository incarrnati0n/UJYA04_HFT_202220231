﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UJYA04_HFT_20222023.Models;
using UJYA04_HFT_20222023.Repository.BaseRepository;
using UJYA04_HFT_20222023.Repository.DBContext;

namespace UJYA04_HFT_20222023.Repository.ModelRepositories
{
    public class TeamsRepository : Repository<Teams>, IRepository<Teams>
    {
        public TeamsRepository(FootyDbContext ctx) : base(ctx)
        {

        }

        public override Teams Read(int id)
        {
            return ctx.Teams.FirstOrDefault(t => t.TeamId == id);
        }

        public override void Update(Teams item)
        {
            var old = Read(item.TeamId);
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
