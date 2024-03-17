namespace BackendTimeshareSale.Service.IServices
{
    public interface IPropertyService
    {
        int GetAllOfProperties();
        double PercentOfAvailableProperty(int month);
        double PercentOfBookingProperty(int bookingDate);
        int NumberOfPropertiesAreBooking(int month);
        int NumberOfPropertiesAreAvailable(int month);

    }
}
