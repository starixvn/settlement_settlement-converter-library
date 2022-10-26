namespace Fanex.Settlement.Converter.Helpers;

public static class StringExtensions
{
    public static bool IgnoreCaseEquals(this string @string, string value)
    {
        if (string.IsNullOrEmpty(@string) && string.IsNullOrEmpty(value))
        {
            return true;
        }

        return !string.IsNullOrEmpty(@string)
            && @string.Equals(value, StringComparison.OrdinalIgnoreCase);
    }

    public static bool IgnoreCaseContains(this string @string, string value)
    {
        return !string.IsNullOrWhiteSpace(@string)
            && @string.IndexOf(value, StringComparison.OrdinalIgnoreCase) > -1;
    }

    public static int IgnoreCaseIndexOf(this string @string, string value)
    {
        return @string.IndexOf(value, StringComparison.OrdinalIgnoreCase);
    }

    public static bool IgnoreCaseStartsWith(this string @string, string value)
    {
        return @string.StartsWith(value, StringComparison.OrdinalIgnoreCase);
    }

    public static bool IgnoreCaseEndsWith(this string @string, string value)
    {
        return @string.EndsWith(value, StringComparison.OrdinalIgnoreCase);
    }

    public static string Reverse(this string @string)
    {
        return new string(@string.ToCharArray().Reverse().ToArray());
    }
}