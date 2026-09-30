using ManualDictionary.Data.Configurations;
using ManualDictionary.Data.Contracts.DAO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManualDictionary.Data.Context
{
 
     public class ManualDictionaryContext : DbContext
    {
        public DbSet<AttemptDao> AttemptDaoSet { get; set; }
        public DbSet<AttemptStatisticDao> AttemptStatisticDaoSet { get; set; }
        public DbSet<DictionaryDao> DictionaryDaoSet { get; set; }
        public DbSet<DictionaryHistoryDao> DictionaryHistoryDaoSet { get; set; }
        public DbSet<DictionaryWordDao> DictionaryWordDaoSet { get; set; }
        public DbSet<SeansDao> SeansDaoSet { get; set; }
        public DbSet<UsersHistoryDao> UsersHistoryDaoSet { get; set; }
        public DbSet<WordStatisticDao> WordStatisticDaoSet { get; set; }
        public ManualDictionaryContext() : base(ManualDictionaryConstants.ManualDictionaryConnectionString)
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public ManualDictionaryContext(string connectionStringName) : base(connectionStringName)
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        /// <summary>
        /// Configure the entities in the data context.
        /// </summary>
        /// <param name="modelBuilder">The builder that defines the model for the context being created.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<ManualDictionaryContext>(null);

            modelBuilder.Configurations.Add(new AttemptConfiguration());
            modelBuilder.Configurations.Add(new AttemptStatisticConfiguration());
            modelBuilder.Configurations.Add(new DictionaryConfiguration());
            modelBuilder.Configurations.Add(new DictionaryHistoryConfiguration());
            modelBuilder.Configurations.Add(new DictionaryWordConfiguration());
            modelBuilder.Configurations.Add(new SeansConfiguration());
            modelBuilder.Configurations.Add(new UsersHistoryConfiguration());
            modelBuilder.Configurations.Add(new WordStatisticConfiguration());

        }

    }
}
