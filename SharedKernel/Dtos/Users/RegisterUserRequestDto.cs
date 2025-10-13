namespace SharedKernel.Dtos.User
{
    public sealed record RegisterUserRequestDto(
        string Email,
        string FullName,
        string Password,
        int Phone,
        string Gender,
        string RoleName = null,
        int? PackageId = null
    );
}
