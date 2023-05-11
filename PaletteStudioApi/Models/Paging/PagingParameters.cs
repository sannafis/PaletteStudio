namespace PaletteStudioApi.Models.Paging
{
    public class PagingParameters
    {
        private int _pageSize = 20;

        public int StartIndex { get; set; }

        public int PageNumber { get; set; }

        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = value;
            }
        }
    }
}
