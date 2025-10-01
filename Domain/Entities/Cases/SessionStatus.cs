using Ardalis.SmartEnum;

namespace Domain.Entities.Accounts
{
    public sealed class SessionStatus : SmartEnum<SessionStatus, string>
    {
        public static readonly SessionStatus InProgress = new(nameof(InProgress), "in_progress");
        public static readonly SessionStatus Closed = new(nameof(Closed), "closed");

        private SessionStatus(string name, string value) : base(name, value) { }
    }
}
