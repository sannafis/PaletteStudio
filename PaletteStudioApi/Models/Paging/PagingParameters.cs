namespace PaletteStudioApi.Models.Paging
{
    public class PagingParameters
    {
        private int pageSize = 20;
        public int PageNumber { get; set; } = 1;
        public int PageSize
        {
            get
            {
                return pageSize;
            }
            set
            {
                pageSize = value;
            }
        }
    }
}
