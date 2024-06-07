using MediatR;
using VehicleRental.Core.Schema.VehicleSchema.Response;

namespace VehicleRental.Core.Schema.VehicleSchema.Request
{
    public class VehicleRequest : IRequest<Result>
    {
        public int Year_Vehicle { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Plate { get; set; }
    }
}
