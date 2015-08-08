﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDS.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        DataContext dbContext;

        public DataContext Init()
        {
            return dbContext ?? (dbContext = new DataContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
