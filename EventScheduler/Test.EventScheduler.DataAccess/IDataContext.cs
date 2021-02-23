using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Test.EventScheduler.DataAccess.Models;

namespace Test.EventScheduler.DataAccess
{
    public interface IDataContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Event> Events { get; set; }

        void BeginTransaction();
        void Commit();
        void Rollback();
        void Save();
    }
}
