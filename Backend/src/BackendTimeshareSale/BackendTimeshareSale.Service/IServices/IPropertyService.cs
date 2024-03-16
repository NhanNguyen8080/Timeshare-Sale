namespace BackendTimeshareSale.Service.IServices
{
    public interface IPropertyService
    {
        int GetNumberOfProperties();
        double PercentOfAvailableProperty(int month);
        double PercentOfBookingProperty(int bookingDate);
    }
}
