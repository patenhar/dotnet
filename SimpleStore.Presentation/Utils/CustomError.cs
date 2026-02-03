namespace SimpleStore.Presentation.Utils;
class CustomError(int status, string? message, string? details)
{
    private int Status {get; set;} = status;
    private string? Message {get; set;} = message;
    private string? Details {get; set;} = details;
}