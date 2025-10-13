using SharedKernel;

namespace Domain.Entities.Users
{
    public static class UserErrors
    {
        public static Error NotFound(int Id) => Error.NotFound(
            "Users.NotFound",
            $"The User with Id = {Id} was Not Found"
            );

        public static readonly Error FaildToUpdateEmailVerification = Error.Failure(
            "Users.FaildToUpdate",
            "Faild Email Verification "
            );

        public static Error Unauthorized() => Error.NotFound(
            "Users.Unauthorized",
            "You are not authorized to perform this action."
            );

        public static readonly Error NotFoundByEmail = Error.NotFound(
          "Users.NotFoundByEmail",
          "The user with the specified email was not found");

        public static readonly Error EmailNotUnique = Error.Confilct(
            "Users.EmailNotUnique",
            "The provided email is not unique");

        public static Error InvalidRole(string roleName) => Error.Failure(
            "Users.InvalidRole",
            $"The role '{roleName}' is not valid");

        public static readonly Error RoleAssignmentFailed = Error.Failure(
            "Users.RoleAssignmentFailed",
            "Failed to assign role to user");
    }
}
