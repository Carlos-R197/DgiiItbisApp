namespace Api.Dtos;

public class PostLogRequestDto
{
    public DateTime DateTime { get; set; }
    public string Msg { get; set; } = "";
    public string StackTrace { get; set; } = "";     
}