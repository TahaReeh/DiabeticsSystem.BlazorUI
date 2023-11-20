namespace DiabeticsSystem.BlazorUI.Core.Constants
{
    public class EndPoints
    {
        #region Product
        public const string GetAllProducts = "Product/GetAllProducts";
        public const string GetProduct = "Product/GetProduct?id=";
        public const string AddProduct = "Product/CreateProduct";
        public const string UpdateProduct = "Product/UpdateProduct";
        public const string RemoveProduct = "Product/DeleteProduct?id=";
        #endregion

        #region Customer
        public const string GetAllCustomers = "Customer/GetAllCustomers";
        public const string GetCustomer = "Customer/GetCustomer?id=";
        public const string AddCustomer = "Customer/CreateCustomer";
        public const string UpdateCustomer = "Customer/UpdateCustomer";
        public const string RemoveCustomer = "Customer/DeleteCustomer?id=";
        #endregion

        #region PatientMovement
        public const string GetAllPatientMovement = "PatientMovment/GetAllPatientsMovments";
        public const string GetPatientMovement = "PatientMovment/GetPatientMovmentByCustomer?customerId=";
        public const string AddPatientMovement = "PatientMovment/CreatePatientMovment";
        public const string RemovePatientMovement = "PatientMovment/DeletePatientMovment?id=";
        public const string ExportPatientMovmentsToCSV = "PatientMovment/ExportPatientMovmentsToCSV";
        public const string ExportPatientMovmentsToPDF = "PatientMovment/ExportAllPatientMovmentsToPDF";
        #endregion

        #region SystemSettings
        public const string GetUserSystemSettings = "SystemSettings/GetUserSystemSettings?userId=";
        public const string UpdateUserSystemSettings = "SystemSettings/UpdateUserSystemSettings";
        #endregion
    }
}
