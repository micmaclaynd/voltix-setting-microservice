using StackExchange.Redis;
using Voltix.SettingMicroservice.Utilities;


namespace Voltix.SettingMicroservice.Services;

public interface ISettingsService {
    public Task<int> GetDefaultRoleIdAsync();
    public Task SetDefaultRoleIdAsync(int roleId);
}

public class SettingService(IConnectionMultiplexer multiplexer) : ISettingsService {
    private readonly IDatabase _database = multiplexer.GetDatabase();

    public async Task<int> GetDefaultRoleIdAsync() => Convert.ToInt32(await GetSettingAsync(DefaultSetting.DefaultRoleId.Id));
    public async Task SetDefaultRoleIdAsync(int roleId) => await SetSettingAsync(DefaultSetting.DefaultRoleId.Id, roleId.ToString());

    private async Task<string> GetSettingAsync(int key) {
        string settingKey = key.ToString();
        var settingValue = await _database.StringGetAsync(settingKey);
        return settingValue.HasValue ? settingValue.ToString() : DefaultSetting.DefaultRoleId.Value;
    }

    private async Task SetSettingAsync(int key, string value) {
        var settingKey = key.ToString();
        await _database.StringSetAsync(settingKey, value);
    }
}
