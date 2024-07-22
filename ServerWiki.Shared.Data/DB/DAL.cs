using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerWiki_Console;

namespace ServerWiki.Shared.Data.DB
{
    public class DAL<T> where T : class
    {
        private readonly ServerWikiContext context;

        public DAL(ServerWikiContext context)
        {
            this.context = context;
        }

        public IEnumerable<T> Read()
        {
            return context.Set<T>().ToList();
        }

        public void create(T entity)
        {
            context.Set<T>().Add(entity);
            context.SaveChanges();
        }

        public void update(T entity)
        {
            context.Set<T>().Update(entity);
            context.SaveChanges();
        }

        public void delete(T entity)
        {
            context.Set<T>().Remove(entity);
            context.SaveChanges();
        }

        public T? ReadBy(Func<T, bool> predicate)
        {
            return context.Set<T>().FirstOrDefault(predicate);
        }
    }
}
