using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Utils {
    public class PaginatedList<T> : List<T> {
        // pageIndex indicates the current page number, starting at 1
        public int PageIndex { get; private set; }
        // totalPages indicates the total number of pages available based on the count and pageSize values
        public int TotalPages { get; private set; }

        // items is a list of generic T that represents the page of items returned
        // count is the total number of items in the collection
        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize){
            PageIndex = pageIndex;
            // TotalPages is the number of total pages when dividing the number of items with the page size
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            // this.AddRange adds the items to the PaginatedList
            // items is the page of items returned by the query and will be a List<T> object, which is then added to PaginatedList
            AddRange(items);
        }

        // HasPreviousPage is true if the current pageIndex is greater than 1
        public bool HasPreviousPage => PageIndex > 1;

        // HasNextPage is true if the current pageIndex is less than the totalPages
        public bool HasNextPage => PageIndex < TotalPages;

        // CreateAsync creates a new PaginatedList that's paginated according to the pageIndex and pageSize values
        // source is the collection of objects that need to be paginated
        // pageIndex is the current index of Page being requested, starting with 1
        // pageSize is the number of items on the page. Must be greater than zero.
        public static async Task<PaginatedList<T>> CreateAsync(
            IQueryable<T> source, int pageIndex, int pageSize)
        {
            // count is the total number of items in the collection
            var count = await source.CountAsync();
            // items is the paged list of items to be returned
            var items = await source.Skip(
                (pageIndex - 1) * pageSize)
                .Take(pageSize).ToListAsync();
            // Returns a new PaginatedList with the newly acquired pages, the count of items, and the current pageIndex and pageSize for the current page
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }
    }
}
