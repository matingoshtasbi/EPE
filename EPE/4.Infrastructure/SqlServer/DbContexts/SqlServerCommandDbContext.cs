using EPE.Infrastructure.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE.Infrastructure.SqlServer.DbContexts
{
    public class SqlServerCommandDbContext : CommandDbContext
    {
        #region constractor
        public SqlServerCommandDbContext(DbContextOptions<SqlServerCommandDbContext> options) : base(options)
        {
        }
        #endregion
    }
}

