using medicationApi.Models;
using medicationApi.QueryOptions;

namespace medicationApi.Query.Logic
{
    public static class MedicineQueryableLogic
    {
        public static IQueryable<Medicine> ApplyFiltering(this IQueryable<Medicine> medicines, QueryObject queryOptions)
        {
            if (!string.IsNullOrWhiteSpace(queryOptions.Name))
            {
                medicines = medicines.Where(m => m.Name.Contains(queryOptions.Name));
            }

            if (queryOptions.Quantity.HasValue)
            {
                medicines = medicines.Where(m => m.Quantity == queryOptions.Quantity.Value);
            }

            return medicines;
        }

        public static IQueryable<Medicine> ApplySorting(this IQueryable<Medicine> medicines, QueryObject queryOptions)
        {
            if (!string.IsNullOrWhiteSpace(queryOptions.SortBy))
            {
                switch (queryOptions.SortBy.ToLower())
                {
                    case "name":
                        medicines = queryOptions.IsDescending
                            ? medicines.OrderByDescending(m => m.Name)
                            : medicines.OrderBy(m => m.Name);
                        break;

                    case "quantity":
                        medicines = queryOptions.IsDescending
                            ? medicines.OrderByDescending(m => m.Quantity)
                            : medicines.OrderBy(m => m.Quantity);
                        break;
                }
            }

            return medicines;
        }

        public static IQueryable<Medicine> ApplyPaging(this IQueryable<Medicine> medicines, QueryObject queryOptions)
        {
            var skipNumber = (queryOptions.PageNumber - 1) * queryOptions.PageSize;
            return medicines.Skip(skipNumber).Take(queryOptions.PageSize);
        }
    }
}