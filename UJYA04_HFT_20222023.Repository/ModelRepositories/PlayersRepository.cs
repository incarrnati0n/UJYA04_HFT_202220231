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
    public class PlayersRepository : Repository<Players>, IRepository<Players>
    {
        public PlayersRepository(FootyDbContext ctx) : base(ctx)
        {
        }

        public override Players Read(int id)
        {
            return ctx.Players.FirstOrDefault(p => p.PlayerId == id);
        }

        public override void Update(Players item)
        {
            var old = Read(item.PlayerId);
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
