using System.Collections.Generic;
using BlueBoard.Contract.Trip.Models;
using MediatR;

namespace BlueBoard.Contract.Trip.Queries
{
    public class GetTripsQuery : IRequest<IEnumerable<TripModel>>
    {
    }
}
