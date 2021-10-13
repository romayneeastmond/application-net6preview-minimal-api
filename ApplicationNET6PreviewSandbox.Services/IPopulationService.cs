using ApplicationNET6PreviewSandbox.Models;

namespace ApplicationNET6PreviewSandbox.Services
{
    public interface IPopulationService
    {
        Task<Country> Maximum();

        Task<Country> Minimum();
    }
}
