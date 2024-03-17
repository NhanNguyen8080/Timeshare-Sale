namespace BackendTimeshareSale.Service.IServices
{
    public interface IContractService
    {
        int GetContractsAreCompleted();
        decimal GetRevenueByMonth(int month);

    }
}
