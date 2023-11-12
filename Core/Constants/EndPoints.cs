namespace DiabeticsSystem.BlazorUI.Core.Constants
{
    public class EndPoints
    {
        #region Product
        public const string GetAllProducts = "Product/GetAllProducts";
        public const string GetProduct = "Product/GetProduct?id=";
        public const string CreateProduct = "Product/CreateProduct";
        public const string UpdateProduct = "Product/UpdateProduct";
        public const string DeleteProduct = "Product/DeleteProduct?id=";
        #endregion

        #region Customer
        public const string GetAllCustomers = "Customer/GetAllCustomers";
        #endregion
    }
}
