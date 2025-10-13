using Ardalis.SmartEnum;

namespace Domain.Entities.Users
{
    

    public sealed class Gender : SmartEnum<Gender, string>
    {
        public static readonly Gender Male = new(nameof(Male), "male");
        public static readonly Gender Female = new(nameof(Female), "female");

        private Gender(string name, string value) : base(name, value) { }
    }
}
