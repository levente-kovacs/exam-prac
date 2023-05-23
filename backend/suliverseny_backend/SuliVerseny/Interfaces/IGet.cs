using Microsoft.AspNetCore.Mvc;

namespace SuliVerseny.Interfaces
{
    public interface IGet
    {
        IActionResult Get(string uId);
    }
}
