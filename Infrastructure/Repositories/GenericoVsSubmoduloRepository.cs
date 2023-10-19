using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class GenericoVsSubModuloRepository : GenericRepository<GenericoVsSubmodulo>, IGenericoVsSubmodulo
    {
        private readonly NotiContext _context;

        public GenericoVsSubModuloRepository(NotiContext context) : base(context)
        {
            _context = context;
        }
    }
}