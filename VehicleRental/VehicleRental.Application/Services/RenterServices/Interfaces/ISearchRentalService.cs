using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleRental.Core.Schema.RenterSchemas.SearchRenterSchema.Response;
using VehicleRental.Core.Schema;
using VehicleRental.Core.Schema.RenterSchemas.SearchRenterSchema.Request;

namespace VehicleRental.Application.Services.RenterServices.Interfaces
{
    public interface ISearchRentalService
    {
        Task<Result<SearchRentalResponse>> SearchRentalById(SearchRentalByIdRequest request);
        Task<Result<SearchRentalResponse>> SearchRentalByCnh(SearchRentalByCnhRequest request);
        Task<Result<SearchRentalResponse>> SearchRentalByDocument(SearchRentalByDocumentRequest request);
    }
}
