using Ardalis.SmartEnum;

namespace SharedKernel
{
    public sealed class ErrorType : SmartEnum<ErrorType, string>
    {
        public static readonly ErrorType Failure = new(nameof(Failure), "failure");
        public static readonly ErrorType Validation = new(nameof(Validation), "validation");
        public static readonly ErrorType Problem = new(nameof(Problem), "problem");
        public static readonly ErrorType NotFound = new(nameof(NotFound), "not_found");
        public static readonly ErrorType Conflict = new(nameof(Conflict), "conflict");

        private ErrorType(string name, string value) : base(name, value) { }
    }
}
