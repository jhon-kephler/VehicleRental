using MediatR;

namespace VehicleRental.Core.Schema.OrderSchemas.Request
{
    public class NewOrderRequest : IRequest<Result>
    {
        public int Renter_Id { get; set; }
        public int Vehicle_Id { get; set; }
        public int Rental_Days { get; set; }
    }
}