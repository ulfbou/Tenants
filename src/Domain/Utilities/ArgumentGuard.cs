namespace Tenants.Domain.Utilities
{
    public static class ArgumentGuard
    {
        public static void NotNull<T>(T argument, string argumentName)
        {
            if (argument == null)
            {
                throw new ArgumentNullException($"The argument {argumentName} cannot be null.");
            }
        }

        public static void NotNullOrEmpty(string argument, string argumentName)
        {
            if (string.IsNullOrEmpty(argument))
            {
                throw new ArgumentNullException($"The argument {argumentName} cannot be null or empty.");
            }
        }

        public static void NotNullOrWhiteSpace(string argument, string argumentName)
        {
            if (string.IsNullOrWhiteSpace(argument))
            {
                throw new ArgumentNullException($"The argument {argumentName} cannot be null or whitespace.");
            }
        }

        public static void NotNegative<T>(T argument, string argumentName) where T : IComparable
        {
            if (argument.CompareTo(default(T)) < 0)
            {
                throw new ArgumentOutOfRangeException(argumentName, $"The argument {argumentName} cannot be negative.");
            }
        }

        public static void NotPositive<T>(T argument, string argumentName) where T : IComparable
        {
            if (argument.CompareTo(default(T)) > 0)
            {
                throw new ArgumentOutOfRangeException(argumentName, $"The argument {argumentName} cannot be positive.");
            }
        }

        public static void IsLessThan<T>(T argument, T value, string argumentName) where T : IComparable
        {
            if (argument.CompareTo(value) >= 0)
            {
                throw new ArgumentOutOfRangeException(argumentName, $"The argument {argumentName} must be less than {value}.");
            }
        }

        public static void IsGreaterThan<T>(T argument, T value, string argumentName) where T : IComparable
        {
            if (argument.CompareTo(value) <= 0)
            {
                throw new ArgumentOutOfRangeException(argumentName, $"The argument {argumentName} must be greater than {value}.");
            }
        }

        public static void InRange<T>(T argument, T min, T max, string argumentName) where T : IComparable
        {
            if (argument.CompareTo(min) < 0 || argument.CompareTo(max) > 0)
            {
                throw new ArgumentOutOfRangeException(argumentName, $"The argument {argumentName} must be between {min} and {max}.");
            }
        }

        public static void NotNullOrEmpty<T>(this IEnumerable<T> collection, string argumentName)
        {
            if (collection == null || !collection.Any())
            {
                throw new ArgumentException($"The argument {argumentName} cannot be null or empty.");
            }
        }
    }
}