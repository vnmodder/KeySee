using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Squirrel.Application.Common.CQRS;
using Squirrel.Application.Common.Interfaces;
using Squirrel.Domain.Exceptions;
using Squirrel.Domain.Messages;
using Squirrel.Infrastructure.Databases.SquirrelDB;

namespace Squirrel.Application.CategoryManagerment.Queries.GetCategories
{
    public class GetCategoriesHandler : BaseQueryHandler<GetCategoriesRequest, GetCategoriesResponse>
    {
        public GetCategoriesHandler(
            SquirrelDbContext dbContext,
            IMapper mapper,
            ILogService log) : base(dbContext, mapper, log)
        {

        }
        public override async Task<GetCategoriesResponse> Handle(GetCategoriesRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var categories = await _dbContext.Categories.Where(x =>
                                                request.Id == null || x.Id == request.Id)
                                                .ToListAsync(cancellationToken);
                return new GetCategoriesResponse()
                {
                    Categories = _mapper.Map<List<CategoryModel>>(categories)
                };

            }
            catch (Exception ex)
            {
                _log.Error("Couldn't get data from database", ex, request);
                throw ExceptionHelper.GenerateBusinessException(nameof(ErrorMessages.EM0035), ex);
            }
        }
    }
}
