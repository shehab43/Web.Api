namespace Domain.Entities
{
    public class KeyValue
    {
        public string Key { get; set; } = string.Empty; // "phone", "email", etc.
        public string Value { get; set; } = string.Empty; // The actual value
    }
}
