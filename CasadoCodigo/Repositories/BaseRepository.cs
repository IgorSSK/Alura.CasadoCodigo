using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasadoCodigo.Repositories
{
    public class BaseRepository<T> where T : BaseModel
    {
        public readonly ApplicationContext context;
        public readonly DbSet<T> dbSet;

        public BaseRepository(ApplicationContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();

        }
    }
}
