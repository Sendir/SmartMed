namespace medicationApi.QueryOptions
{
    public class QueryObject : ResponseOptionsQuery
    {
        public string? Name { get; set; } = null;
        public int? Quantity { get; set; } = null;

    }
}