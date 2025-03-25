using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Voltix.SettingMicroservice.Protos;
using Voltix.SettingMicroservice.Services;


namespace Voltix.SettingMicroservice.GrpcServices;

public class SettingGrpcService(ISettingsService settingsService) : SettingProto.SettingProtoBase {
    private readonly ISettingsService _settingsService = settingsService;

    public override async Task<GetDefaultRoleIdResponse> GetDefaultRoleId(Empty request, ServerCallContext context) {
        return new GetDefaultRoleIdResponse {
            DefaultRoleId = await _settingsService.GetDefaultRoleIdAsync()
        };
    }
}

