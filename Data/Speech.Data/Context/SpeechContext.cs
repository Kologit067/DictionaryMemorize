using Speech.Data.Configurations;
using Speech.Data.Contracts.DAO;
using System.Data.Entity;

namespace Speech.Data.Context
{
    public class SpeechContext : DbContext
    {
        public DbSet<SpeechGroupDao> SpeechGroupSet { get; set; }
        public DbSet<SpeechPhraseDao> SpeechPhraseSet { get; set; }
        public SpeechContext() : base(SpeechConstants.SpeechConnectionString)
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public SpeechContext(string connectionStringName) : base(connectionStringName)
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
            Database.SetInitializer<SpeechContext>(null);

            modelBuilder.Configurations.Add(new SpeechGroupConfiguration());
            modelBuilder.Configurations.Add(new SpeechPhraseConfiguration());

        }

    }
}