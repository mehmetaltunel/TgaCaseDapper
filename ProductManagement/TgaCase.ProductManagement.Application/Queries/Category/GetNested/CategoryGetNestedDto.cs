using System.Collections.Generic;

namespace TgaCase.ProductManagement.Application.Queries.Category.GetNested
{
    public class CategoryGetNestedDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<CategoryGetNestedDto> Children { get; set; }
    }
}