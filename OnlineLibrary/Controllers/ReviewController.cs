using Microsoft.AspNetCore.Mvc;
using OnlineLibrary.Application.UseCases.Reviews.Commands.CreateReview;
using OnlineLibrary.Application.UseCases.Reviews.Commands.DeleteReview;
using OnlineLibrary.Application.UseCases.Reviews.Commands.UpdateReview;
using OnlineLibrary.Application.UseCases.Reviews.Queries.GetAllReviews;
using OnlineLibrary.Application.UseCases.Reviews.Queries.GetByIdReview;
using OnlineLibrary.Application.UseCases.Reviews.Response;
using X.PagedList;

namespace OnlineLibrary.Controllers;


[Route("api/[controller]")]
[ApiController]
public class ReviewController : BaseApiController
{
    [HttpPost("[action]")]
    public async ValueTask<int> CreateReview(CreateReviewCommand command)
    {
        return await _mediator.Send(command);
    }

    [HttpGet("[action]")]
    public async ValueTask<ReviewResponse> GetReviewById(int Id)
    {
        return await _mediator.Send(new GetByIdReviewQuery(Id));
    }

    [HttpGet("[action]")]
    public async ValueTask<IEnumerable<ReviewResponse>> GetAllReviews(int page = 1)
    {
        IPagedList<ReviewResponse> query = (await _mediator
           .Send(new GetAllReviewesQuery()))
           .ToPagedList(page, 10);
        return query;
    }

    [HttpPut("[action]")]
    public async ValueTask<IActionResult> UpdateReview(UpdateReviewCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("[action]")]
    public async ValueTask<IActionResult> DeleteReview(DeleteReviewCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }
}
