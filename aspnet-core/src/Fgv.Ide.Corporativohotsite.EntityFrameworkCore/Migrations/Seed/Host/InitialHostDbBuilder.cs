﻿using Fgv.Ide.Corporativohotsite.EntityFrameworkCore;

namespace Fgv.Ide.Corporativohotsite.Migrations.Seed.Host
{
    public class InitialHostDbBuilder
    {
        private readonly CorporativohotsiteDbContext _context;

        public InitialHostDbBuilder(CorporativohotsiteDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            new DefaultEditionCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();

            _context.SaveChanges();
        }
    }
}
