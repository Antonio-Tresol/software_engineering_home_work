using Microsoft.AspNetCore.Mvc.Rendering;

namespace ForestWebApp.RenderUtils;

/// <summary>
///     Responsible for creating a list of SelectListItem objects representing countries.
/// </summary>
public class CountrySelectItemCreator : ICountrySelectItemCreator
{
    private List<SelectListItem>? _countries = new();

    /// <inheritdoc />
    public List<SelectListItem>? GetCountries()
    {
        if (_countries is { Count: 0 })
            _countries = ReadCountries().Select(c => new SelectListItem(c, c)).ToList();

        return _countries;
    }

    /// <summary>
    ///     Reads country names from a CSV file and returns them as a sorted enumerable.
    /// </summary>
    /// <returns>An IEnumerable of country names.</returns>
    private static IEnumerable<string> ReadCountries()
    {
        var countryList = new List<string>();
        var isFirstLine = true;
        using var reader = new StreamReader("StaticData/countries.csv");

        while (reader.ReadLine() is { } line)
        {
            if (isFirstLine)
            {
                isFirstLine = false;
                continue;
            }

            var parts = line.Split(',');

            if (parts.Length < 3) continue;

            var spanishName = GetSpanishNameClean(parts);

            countryList.Add(spanishName);
        }

        return countryList.OrderBy(country => country).ToList();
    }

    /// <summary>
    ///     Extracts and cleans the Spanish name of the country from a CSV line.
    /// </summary>
    /// <param name="parts">The split line from the CSV file.</param>
    /// <returns>A cleaned Spanish name of the country.</returns>
    private static string GetSpanishNameClean(IReadOnlyList<string> parts)
    {
        var spanishName = parts[1].Trim();
        spanishName = spanishName[1..^1];
        return spanishName;
    }
}