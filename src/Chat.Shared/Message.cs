/// <summary>
/// record для хранения сообщений
/// </summary>
public record Message
(
    /// <summary>
    /// Message content
    /// <summary>
    string? Content
)
{
    /// <summary>
    /// Time to send the message
    /// </summary>
    public DateTime TimeStamp { get; } = DateTime.Now;
    /// <summary>
    /// Converts a message to a string
    /// </summary>
    /// <returns>Returns the message as a string</returns>
    public override string ToString()
    {
        return $"[{TimeStamp:HH:mm:ss}] {Content}";
    }
}