namespace ProductManager.Core.Products
{
    internal interface IProduct
    {
        decimal GetTotalCost();
        decimal GetUnitCost();
    }
}
