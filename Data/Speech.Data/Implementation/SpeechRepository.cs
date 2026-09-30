using Speech.Data.Context;
using Speech.Data.Contracts.DAO;
using Speech.Data.Contracts.Interfactes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Speech.Data.Implementation
{
    public class SpeechRepository : ISpeechRepository
    {
        private readonly SpeechContext _context;
        protected DbSet<SpeechGroupDao> DataSet
        {
            get { return _context.SpeechGroupSet; }
        }
        protected SpeechContext Context
        {
            get { return this._context; }
        }

        /// <summary>
        /// Expression for including child entities in the base queries.
        /// </summary>
        protected Func<IQueryable<SpeechGroupDao>, IQueryable<SpeechGroupDao>> IncludeExpression { get; set; }

        protected DbSet<SpeechPhraseDao> SpeechPhraseSet
        {
            get => _context.SpeechPhraseSet;
        }

        public SpeechRepository(SpeechContext speechContext)
        {
            if (null == speechContext)
            {
                throw new ArgumentNullException("context");
            }

            this._context = speechContext;
            this._context.Database.Log = Logger.Log;
        }

        public async Task<IEnumerable<SpeechGroupDao>> GetSpeechList()
        {
            var query = this.DataSet.Include(b => b.SpeechPhrases).AsQueryable().Where(v => !v.IsDeleted);

            return await query.ToListAsync();
        }

        public async Task<(string Error, IEnumerable<SpeechGroupDao> SpeechGroups)> UpdateSpeechGroups(IEnumerable<SpeechGroupDao> speechGroups, List<long> dirtyGroup, List<long> dirtyPhrase)
        {
            foreach (var group in speechGroups)
            {
                if (group.SpeechGroupId == 0)
                {
                    Context.Entry<SpeechGroupDao>(group).State = EntityState.Added;
                }
                else if (dirtyGroup.Any(g => g == group.SpeechGroupId))
                {
                    Context.Entry<SpeechGroupDao>(group).State = EntityState.Modified;
                }
                foreach (var phrase in group.SpeechPhrases)
                {
                    if (phrase.SpeechPhraseId == 0)
                    {
                        Context.Entry<SpeechPhraseDao>(phrase).State = EntityState.Added;
                    }
                    else if (dirtyPhrase.Any(g => g == phrase.SpeechPhraseId))
                    {
                        Context.Entry<SpeechPhraseDao>(phrase).State = EntityState.Modified;
                    }
                }
            }


            try
            {
                await this.SaveChangesAsync(new CancellationTokenSource().Token)
                          .ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return (e.Message, null);
            }
            return (string.Empty, speechGroups);
        }

        public async Task<string> DeleteSpeechGroup(SpeechGroupDao speechGroup)
        {
  
            var phrases = speechGroup.SpeechPhrases.ToList();
            foreach (var phrase in phrases)
            {
                speechGroup.SpeechPhrases.Remove(phrase);
                Context.Entry<SpeechPhraseDao>(phrase).State = EntityState.Deleted;
            }
            Context.Entry<SpeechGroupDao>(speechGroup).State = EntityState.Deleted;

            try
            {
                await this.SaveChangesAsync(new CancellationTokenSource().Token)
                          .ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return e.Message;
            }
            return string.Empty;
        }

        public async Task<string> DeleteSpeechPhrase(SpeechPhraseDao speechPhrase)
        {

            Context.Entry<SpeechPhraseDao>(speechPhrase).State = EntityState.Deleted;

            try
            {
                await this.SaveChangesAsync(new CancellationTokenSource().Token)
                          .ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return e.Message;
            }
            return string.Empty;
        }



        public virtual async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await this._context.SaveChangesAsync(cancellationToken)
                      .ConfigureAwait(false);
        }

     }

    public class Logger
    {
        public static void Log(string message)
        {
            Console.WriteLine("EF Message: {0} ", message);
            using (StreamWriter w = File.AppendText("Speech.log"))
            {
                w.WriteLine($"EF Message: {message} ");

                // Close the writer and underlying file.
                w.Close();
            }
        }
    }
}
