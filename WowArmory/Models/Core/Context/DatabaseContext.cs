﻿using Microsoft.EntityFrameworkCore;
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

        //public DbSet<IData> Data { get; set; }
        public DbSet<ClassModel> Classes { get; set; }
        //public DbSet<DataModel> Data { get; set; }
        //public DbSet<ProfessionsModel> Professions { get; set; }
        //public DbSet<QuestModel> Quests { get; set; }
        //public DbSet<SourceModel> Sources { get; set; }
        //public DbSet<SpecsModel> Specs { get; set; }
        //public DbSet<TalentsModel> Talents { get; set; }
        //public DbSet<TooltipModel> Tooltips { get; set; }
        //public DbSet<ZonesModel> Zones { get; set; }
    }
}
