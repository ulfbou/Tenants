using Tenants.Application.Interfaces;
using Tenants.Application.DTOs;
using Tenants.Domain.Entities;
using Tenants.Domain.Interfaces;
using Tenants.Application.Mappings;

namespace Tenants.Application.Services;

public class TenantService : ITenantService
{
    private readonly ITenantRepository _tenantRepository;
    private readonly IPermissionService _permissionService;

    public TenantService(ITenantRepository tenantRepository, IPermissionService permissionService)
    {
        _tenantRepository = tenantRepository;
        _permissionService = permissionService;
    }

    public async Task<TenantResponseDto> CreateTenantAsync(TenantCreateDto tenantCreateDto, CancellationToken cancellationToken = default)
    {
        var tenant = new Tenant(tenantCreateDto.Name, tenantCreateDto.Description, tenantCreateDto.CreatedBy);

        await _tenantRepository.AddAsync(tenant, cancellationToken);
        await _permissionService.SetupDefaultPermissionsAsync(tenant.TenantId, cancellationToken);

        return tenant.AsResponse();
    }

    public async Task<TenantResponseDto> GetTenantByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var tenant = await _tenantRepository.GetByIdAsync(id, cancellationToken);

        return tenant.AsResponse();
    }
}