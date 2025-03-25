namespace Voltix.SettingMicroservice.Interfaces.Http;

public class IGetDefaultRoleIdResponse {
    public required int DefaultRoleId { get; set; }
}

public class ISetDefaultRoleIdRequest {
    public required int DefaultRoleId { get; set; }
}
