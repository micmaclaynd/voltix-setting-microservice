using Microsoft.AspNetCore.Mvc;
using Voltix.SettingMicroservice.Interfaces.Http;
using Voltix.SettingMicroservice.Services;


namespace Voltix.SettingMicroservice.Controllers;

[Route("settings")]
[ApiController]
public class Se7ttingController(ISettingsService settingsService) : ControllerBase {
    private readonly ISettingsService _settingsService = settingsService;

    [HttpGet("default-role-id")]
    public async Task<ActionResult> GetDefaultRoleIdAsync() {
        return Ok(new IGetDefaultRoleIdResponse {
            DefaultRoleId = await _settingsService.GetDefaultRoleIdAsync()
        });
    }

    [HttpPut("default-role-id")]
    public async Task<ActionResult> SetDefaultRoleIdAsync([FromBody] ISetDefaultRoleIdRequest request) {
        await _settingsService.SetDefaultRoleIdAsync(request.DefaultRoleId);
        return Ok();
    }
}

