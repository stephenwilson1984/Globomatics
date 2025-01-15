using System.Text.RegularExpressions;

namespace Globomatics.Web.Transformers;

public class SlugParameterTransformer : IOutboundParameterTransformer
{
    public string? TransformOutbound(object? value)
    {
        if (value is not string)
        {
            return null;
        }

        // Replaces any non-alphanumeric characters with a hyphen and converts to lowercase before trimming any leading or trailing hyphens.
        // This is a simple way to create a slug from a string. The timeout is set to 200 milliseconds to prevent any potential catastrophic backtracking.
        return Regex.Replace(value.ToString()!, @"[^a-zA-Z0-9]+", "-", RegexOptions.CultureInvariant, TimeSpan.FromMilliseconds(200))
            .ToLowerInvariant()
            .Trim('-');
    }
}