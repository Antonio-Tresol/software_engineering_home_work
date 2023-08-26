using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using laboratorio4.Data;
using laboratorio4.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace laboratorio4.Pages.Songs {
    public class IndexModel : PageModel {
        private readonly laboratorio4Context _context;

        public IndexModel(laboratorio4Context context) {
            _context = context;
        }

        public IList<Song> Song { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Singers { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? songSinger { get; set; }

        public async Task OnGetAsync() {
            // Use LINQ to get list of genres.
            IQueryable<string> singerQuery = from m in _context.Song
                                            orderby m.Singer
                                            select m.Singer;

            var songs = from m in _context.Song
                         select m;

            if (!string.IsNullOrEmpty(SearchString)) {
                songs = songs.Where(s => s.Name.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(songSinger)) {
                songs = songs.Where(x => x.Singer == songSinger);
            }
            Singers = new SelectList(await singerQuery.Distinct().ToListAsync());
            Song = await songs.ToListAsync();
        }
    }
}
