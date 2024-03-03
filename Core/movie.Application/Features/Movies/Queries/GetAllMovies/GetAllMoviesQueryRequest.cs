using MediatR;

namespace movie.Application;

public class GetAllMoviesQueryRequest : IRequest<IList<GetAllMoviesQueryResponse>>
{
    
}

