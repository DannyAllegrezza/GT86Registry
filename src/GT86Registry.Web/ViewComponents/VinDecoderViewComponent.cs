using GT86Registry.Web.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GT86Registry.Web.ViewComponents
{
    public class VinDecoderViewComponent : ViewComponent
    {
        private readonly IVinDecoderService _vinDecoderService;

        public VinDecoderViewComponent(IVinDecoderService vinDecoderService)
        {
            _vinDecoderService = vinDecoderService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string vin)
        {
            var vinResult = await _vinDecoderService.GetDecodedVin(vin);
            return View(vinResult);
        }
    }
}
