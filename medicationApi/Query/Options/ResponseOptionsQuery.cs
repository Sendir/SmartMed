using System.ComponentModel;

namespace medicationApi.QueryOptions
{
    public class ResponseOptionsQuery
    {
        public string? SortBy { get; set; } = null;

        [DefaultValue(false)]
        public bool IsDescending { get; set; } = false;

        [DefaultValue(1)]
        public int PageNumber { get; set; } = 1;
        [DefaultValue(2)]
        public int PageSize { get; set; } = 2;
    }
}