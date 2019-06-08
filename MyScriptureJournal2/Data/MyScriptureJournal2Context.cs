using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyScriptureJournal2.Models
{
    public class MyScriptureJournal2Context : DbContext
    {
        public MyScriptureJournal2Context (DbContextOptions<MyScriptureJournal2Context> options)
            : base(options)
        {
        }

        public DbSet<MyScriptureJournal2.Models.Scripture> Scripture { get; set; }
    }
}
