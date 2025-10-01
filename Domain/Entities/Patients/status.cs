using Ardalis.SmartEnum;

namespace Domain.Entities.Patients
{
    public sealed class Status : SmartEnum<Status, string>
    {
        public static readonly Status Scheduled = new(nameof(Scheduled), "scheduled");
        public static readonly Status Done = new(nameof(Done), "done");

        private Status(string name, string value) : base(name, value) { }
    }
}
