namespace CarWash.BL
{
    public enum Permissions
    {
        None = 0,
        ViewCustomers = 1 << 0,
        ManageEmployees = 1 << 1,
        CashOperations = 1 << 2,
        ViewInvoices = 1 << 3,
        ViewReports = 1 << 4,
        ManageServices = 1 << 5,
        Settings = 1 << 6,
        All = -1
    }
}
