using Microsoft.AspNetCore.Mvc.Rendering;

namespace ForestWebApp.RenderUtils;

public class CountrySelectItemCreator : ICountrySelectItemCreator
{
    private List<SelectListItem> _countries = new();
    
    public List<SelectListItem> GetCountries()
    {
        if (_countries.Count == 0)
        {
            _countries = ReadCountries().Select(c => new SelectListItem(c, c)).ToList();
        }

        return _countries;
    }

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
            
            var spanishName = parts[1].Trim();
            
            spanishName = spanishName[1..^1];

            countryList.Add(spanishName);
        }

        return countryList.OrderBy(country => country).ToList();
    }
}