namespace TrainingAndDietApp.BLL.Utils
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
            ItemsFrom = 9 * (pageNumber - 1) + 1;
            ItemsTo = ItemsFrom + 9 - 1;
            TotalPages = (int) Math.Ceiling(totalCount / (double) 9);
        }


    }
}
