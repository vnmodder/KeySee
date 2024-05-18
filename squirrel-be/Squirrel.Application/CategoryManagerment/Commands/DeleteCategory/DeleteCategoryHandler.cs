using AutoMapper;
using Squirrel.Application.Common.CQRS;
using Squirrel.Application.Common.Interfaces;
using Squirrel.Infrastructure.Databases.SquirrelDB;
using Squirrel.Domain.Exceptions;
using Squirrel.Domain.Messages;
using Microsoft.EntityFrameworkCore;

namespace Squirrel.Application.CategoryManagerment.Commands.DeleteCategory
{
    public class DeleteCategoryHandler : BaseCommandHandler<DeleteCategoryCommand, DeleteCategoryResponse>
    {

        public DeleteCategoryHandler(
            SquirrelDbContext dbContext,
            IMapper mapper,
            IUserService userService,
            ILogService log) : base(dbContext, mapper, userService, log)
        {

        }
        public override async Task<DeleteCategoryResponse> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var catrgory = await _dbContext.Categories.FirstOrDefaultAsync(x=>x.Id == request.Id);
            if (catrgory != null)
            {
                using (var trans = _dbContext.Database.BeginTransaction())
                {
                    try
                    {
                        _dbContext.Categories.Remove(catrgory);
                        _dbContext.SaveChanges();
                        await trans.CommitAsync(cancellationToken);

                        return new DeleteCategoryResponse();
                    }
                    catch (Exception ex)
                    {
                        await trans.RollbackAsync();
                        _log.Error("Delete category FAILED", ex, request);
                        throw ExceptionHelper.GenerateBusinessException(nameof(ErrorMessages.EM0035));
                    }
                }
            }
            return new DeleteCategoryResponse()
            {
                Message = "Không tìm thấy danh mục này"
            };
        }
    }
}
