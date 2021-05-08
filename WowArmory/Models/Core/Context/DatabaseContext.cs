using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WowArmory.Models.Core.Context
{
    public class DatabaseContext : DbContext
    {

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<ClassModel> Classes { get; set; }
        public DbSet<DataModel> Data { get; set; }
        public DbSet<ProfessionModel> Professions { get; set; }
        public DbSet<QuestModel> Quests { get; set; }
        public DbSet<SourceModel> Sources { get; set; }
        public DbSet<SpecModel> Specs { get; set; }
        public DbSet<TalentModel> Talents { get; set; }
        public DbSet<TooltipModel> Tooltips { get; set; }
        public DbSet<ZoneModel> Zones { get; set; }
    }
}
