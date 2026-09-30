using ManualDictionary.Data.Context;
using ManualDictionary.Data.Contracts.DAO;
using ManualDictionary.Data.Contracts.Interfactes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ManualDictionary.Data.Implementation
{
    public class ManualDictionaryRepository : IManualDictionaryRepository
    {
        private readonly ManualDictionaryContext _context;
        protected DbSet<AttemptDao> AttemptDaoSet
        {
            get { return _context.AttemptDaoSet; }
        }
        protected DbSet<AttemptStatisticDao> AttemptStatisticDaoSet
        {
            get => _context.AttemptStatisticDaoSet;
        }
        protected DbSet<DictionaryDao> DictionaryDaoSet
        {
            get => _context.DictionaryDaoSet;
        }
        protected DbSet<DictionaryHistoryDao> DictionaryHistoryDaoSet
        {
            get => _context.DictionaryHistoryDaoSet;
        }
        protected DbSet<DictionaryWordDao> DictionaryWordDaoSet
        {
            get => _context.DictionaryWordDaoSet;
        }
        protected DbSet<SeansDao> SeansDaoSet
        {
            get => _context.SeansDaoSet;
        }
        protected DbSet<UsersHistoryDao> UsersHistoryDaoSet
        {
            get => _context.UsersHistoryDaoSet;
        }
        protected DbSet<WordStatisticDao> WordStatisticDaoSet
        {
            get => _context.WordStatisticDaoSet; 
        }
 
        protected ManualDictionaryContext Context
        {
            get { return this._context; }
        }


        public ManualDictionaryRepository(ManualDictionaryContext manualDictionaryContext)
        {
            if (null == manualDictionaryContext)
            {
                throw new ArgumentNullException("context");
            }

            this._context = manualDictionaryContext;
            this._context.Database.Log = Logger.Log;
        }

        public async Task<string> UpdateDictionariesAndHistories(List<DictionaryDao> dictionaries, List<UsersHistoryDao> usersHistories)
        {
            foreach (var dictionary in dictionaries)
            {
                Context.Entry<DictionaryDao>(dictionary).State = EntityState.Added;
                foreach (var word in dictionary.DictionaryWords)
                {
                    Context.Entry<DictionaryWordDao>(word).State = EntityState.Added;
                }
            }

            foreach (var usersHistory in usersHistories)
            {
                Context.Entry<UsersHistoryDao>(usersHistory).State = EntityState.Added;
                foreach (var history in usersHistory.DictionaryHistories)
                {
                    Context.Entry<DictionaryHistoryDao>(history).State = EntityState.Added;
                    foreach (var statistic in history.WordStatistics)
                    {
                        Context.Entry<WordStatisticDao>(statistic).State = EntityState.Added;
                        foreach (var attempt in statistic.AttemptStatistics)
                        {
                            Context.Entry<AttemptStatisticDao>(attempt).State = EntityState.Added;
                        }
                    }
                    foreach (var seans in history.Seanses)
                    {
                        Context.Entry<SeansDao>(seans).State = EntityState.Added;
                        foreach (var attempt in seans.Attempts)
                        {
                            Context.Entry<AttemptDao>(attempt).State = EntityState.Added;
                        }
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
