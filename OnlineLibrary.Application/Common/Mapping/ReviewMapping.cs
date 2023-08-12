using AutoMapper;
using OnlineLibrary.Application.UseCases.Reviews.Commands.CreateReview;
using OnlineLibrary.Application.UseCases.Reviews.Commands.DeleteReview;
using OnlineLibrary.Application.UseCases.Reviews.Commands.UpdateReview;
using OnlineLibrary.Application.UseCases.Reviews.Response;
using OnlineLibrary.Domain.Entites;

namespace OnlineLibrary.Application.Common.Mapping;

public class ReviewMapping : Profile
{
    public ReviewMapping()
    {
        CreateMap<CreateReviewCommand, Review>();
        CreateMap<DeleteReviewCommand, Review>();
        CreateMap<UpdateReviewCommand, Review>();
        CreateMap<Review, ReviewResponse>();
    }
}
