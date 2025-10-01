using Ardalis.SmartEnum;

namespace Domain.Entities.Users
{
    public sealed class Role : SmartEnum<Role, string>
    {
        public static readonly Role Doctor = new(nameof(Doctor), "doctor");
        public static readonly Role Nurse = new(nameof(Nurse), "nurse");
        public static readonly Role Admin = new(nameof(Admin), "admin");

        private Role(string name, string value) : base(name, value) { }
    }
}
