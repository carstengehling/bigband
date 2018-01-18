using Conductor.Entities;
using Conductor.Repositories.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Conductor.Repositories.Adapters
{
    public class DbCompositionRepository : ICompositionRepository
    {
        private ApplicationContext _context;

        public DbCompositionRepository(ApplicationContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<CompositionDTO> GetUnplayedCompositions(string artistKey)
        {
            var artist = GetArtist(artistKey);
            if (artist == null)
                return new CompositionDTO[0];

            return artist.Compositions.Where(c => c.ProcessedAt == null).OrderBy(c => c.CreatedAt)
                .Select(a => new CompositionDTO(a.Key, a.Script, a.CreatedAt));
        }

        public void MarkAsPerformed(string artistKey, PerformanceDTO performance)
        {
            var artist = GetArtist(artistKey);
            if (artist == null)
                return;

            var composition = artist.Compositions.SingleOrDefault(c => c.Key == performance.CompositionKey && c.ProcessedAt == null);
            if (composition == null)
                return;

            composition.ProcessedAt = DateTime.Now;
            composition.Success = performance.Success;
            composition.Output = performance.Output;

            _context.Entry(composition).State = EntityState.Modified;
            _context.SaveChanges();
        }

        private Artist GetArtist(string key)
        {
            return _context.Artists
                .Include(a => a.Compositions)
                .SingleOrDefault(a => a.Key == key);
        }

    }
}
