using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JTTT.DaoModels;

namespace JTTT.Repository
{
    class JtttContext : DbContext
    {
        public JtttContext() : base("Jttt2017")
        {
            Database.SetInitializer<JtttContext>(null);
            this.Configuration.ProxyCreationEnabled = true;
        }

        public DbSet<JtttTask> Tasks { get; set; }
        public DbSet<JtttAction> Actions { get; set; }
        public DbSet<JtttCondition> Conditions { get; set; }
    }
}
