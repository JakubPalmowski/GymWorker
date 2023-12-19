namespace Training_and_diet_backend.Models
{
    public class PageResult<T>
    {
        public List<T> Items { get; set; }
        public int TotalPages { get; set; }
        public int ItemsFrom { get; set; }   
        public int ItemsTo { get; set; }
        public int TotalItemsCount { get; set; }

        public PageResult(List<T> items, int totalCount, int pageNumber)
        {
            Items = items;
            TotalItemsCount = totalCount;
            ItemsFrom = 4 * (pageNumber - 1) + 1;
            ItemsTo = ItemsFrom + 4 - 1;
            TotalPages = (int) Math.Ceiling(totalCount / (double) 4);
        }


    }
}
