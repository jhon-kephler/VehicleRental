﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleRental.Core.Schema.RenterSchemas.SearchRenterSchema.Response;

namespace VehicleRental.Core.Schema.RenterSchemas.SearchRenterSchema.Request
{
    public class SearchRentalByDocumentRequest : IRequest<Result<SearchRentalResponse>>
    {
        public string Document { get; set; }
    }
}
