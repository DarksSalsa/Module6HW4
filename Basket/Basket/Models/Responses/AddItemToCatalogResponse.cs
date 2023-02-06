namespace Basket.Models.Responses
{
    public class AddItemToCatalogResponse<T>
    {
        public T Id { get; set; } = default(T)!;
    }
}
