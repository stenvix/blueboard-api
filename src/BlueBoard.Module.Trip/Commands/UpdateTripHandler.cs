using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BlueBoard.Contract.Common;
using BlueBoard.Contract.Trip.Commands;
using BlueBoard.Contract.Trip.Models;
using BlueBoard.Module.Common;
using BlueBoard.Module.Common.Exceptions;
using BlueBoard.Module.Trip.Repositories;
using BlueBoard.Persistence.Abstractions;
using MediatR;

namespace BlueBoard.Module.Trip.Commands
{
    internal class UpdateTripHandler : IRequestHandler<UpdateTrip, TripInfo>
    {
        public UpdateTripHandler(
            IMapper mapper,
            IMediator mediator,
            IUnitOfWorkFactory unitOfWorkFactory,
            ITripRepository tripRepository,
            ICurrentUserProvider currentUserProvider)
        {
            this.Mapper = mapper;
            this.UnitOfWorkFactory = unitOfWorkFactory;
            this.TripRepository = tripRepository;
            this.CurrentUserProvider = currentUserProvider;
        }

        private IMapper Mapper { get; }
        private IUnitOfWorkFactory UnitOfWorkFactory { get; }
        private ITripRepository TripRepository { get; }
        private ICurrentUserProvider CurrentUserProvider { get; }

        public async Task<TripInfo> Handle(UpdateTrip request, CancellationToken cancellationToken)
        {
            using (var unitOfWork = this.UnitOfWorkFactory.Create())
            {
                var trip = await this.TripRepository.GetAsync(unitOfWork.Connection, request.Trip.Id);
                if (trip == null)
                {
                    throw new BlueBoardValidationException(ErrorCodes.InvalidId);
                }

                this.Mapper.Map(request.Trip, trip);
                trip.UpdatedBy = this.CurrentUserProvider.UserId;
                trip = await this.TripRepository.UpdateTripAsync(unitOfWork.Connection, trip);
                unitOfWork.Commit();

                return this.Mapper.Map<TripInfo>(trip);
            }
        }
    }
}
