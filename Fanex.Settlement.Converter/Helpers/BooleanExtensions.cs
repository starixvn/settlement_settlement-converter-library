namespace Fanex.Settlement.Converter.Helpers;

public static class BooleanExtensions
{
    public static string ToIntString(this bool input)
    {
        return input ? "1" : "0";
    }
}