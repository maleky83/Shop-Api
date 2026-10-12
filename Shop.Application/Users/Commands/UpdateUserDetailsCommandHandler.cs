using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Shop.Domain.Entities;
using Shop.Domain.Exceptions;

namespace Shop.Application.Users.Commands;

public class UpdateUserDetailsCommandHandler(
    ILogger<UpdateUserDetailsCommandHandler> logger,
    IUserStore<User> userStore,
    IUserContext userContext
    ) : IRequestHandler<UpdateUserDetailsCommand>
{
    public async Task Handle(UpdateUserDetailsCommand request, CancellationToken cancellationToken)
    {
        CurrentUser? user = userContext.GetCurrentUser();

        logger.LogInformation("Updating user {UserId} with {@Request}", user!.Id, request);

        User dbUser = await userStore.FindByIdAsync(user.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(User), user.Id);

        dbUser.DateOfBirth = request.DateOfBirth;
        dbUser.Nationality = request.Nationality;

        await userStore.UpdateAsync(dbUser, cancellationToken);
    }
}
