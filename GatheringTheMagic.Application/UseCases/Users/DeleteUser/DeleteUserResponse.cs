namespace GatheringTheMagic.Application.UseCases.Users.DeleteUser;

public sealed class DeleteUserResponse
{
    public Guid Id { get; set; }
    public string? Email { get; set; }
    public string? UserName { get; set; }
}
