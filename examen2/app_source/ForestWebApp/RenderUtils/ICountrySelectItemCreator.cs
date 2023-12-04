using Microsoft.AspNetCore.Mvc.Rendering;

namespace ForestWebApp.RenderUtils;

public interface ICountrySelectItemCreator
{
    public List<SelectListItem> GetCountries();
}