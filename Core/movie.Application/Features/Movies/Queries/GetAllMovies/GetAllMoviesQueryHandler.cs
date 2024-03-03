using MediatR;
using movie.Application.Interfaces.UnitOfWorks;
using movie.Domain;

namespace movie.Application;

public class GetAllMoviesQueryHandler : IRequestHandler<GetAllMoviesQueryRequest, IList<GetAllMoviesQueryResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetAllMoviesQueryHandler(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }
    public async Task<IList<GetAllMoviesQueryResponse>> Handle(GetAllMoviesQueryRequest request, CancellationToken cancellationToken)
    {
        List<GetAllMoviesQueryResponse> response = new();
        var movies = await _unitOfWork.GetReadRepository<Movie>().GetAllAsync();

        foreach (var movie in movies)
        {
            response.Add(new GetAllMoviesQueryResponse
            {
                Title = movie.Title,
                Description = movie.Description,
                Year = movie.Year,
                Genre = movie.Genre
            });
        }
        return response;

    }
}