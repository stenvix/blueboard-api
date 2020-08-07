using BlueBoard.API.Contracts.Auth;
using BlueBoard.API.Contracts.Profile;
using BlueBoard.API.Contracts.Profile.Base;
using BlueBoard.API.Contracts.Trip;
using BlueBoard.API.Contracts.Trip.Base;
using BlueBoard.API.Contracts.Users;
using BlueBoard.Contract.Identity.Models;
using BlueBoard.Contract.Trip.Models;

namespace BlueBoard.API.Contracts
{
    public class ServiceProfile : AutoMapper.Profile
    {
        public ServiceProfile()
        {
            // Requests
            this.CreateMap<UpdateProfileRequest, UserModel>();
            this.CreateMap<CreateTripRequest, SlimTripModel>();
            this.CreateMap<UpdateTripRequest, TripModel>();

            // Responses
            this.CreateMap<AccessTokenModel, VerifyAccessResponse>();
            this.CreateMap<UserModel, ProfileResponse>();

            this.CreateMap<UserModel, GetProfileResponse>()
                .IncludeBase<UserModel, ProfileResponse>();

            this.CreateMap<UserModel, UpdateProfileResponse>()
                .IncludeBase<UserModel, ProfileResponse>();

            this.CreateMap<TripModel, CreateTripResponse>();
            this.CreateMap<TripModel, UpdateTripResponse>();
            this.CreateMap<TripModel, GetTripResponse>();

            // Items
            this.CreateMap<SlimUserModel, SlimUserApiItem>();
            this.CreateMap<TripModel, TripApiItem>();

        }
    }
}
