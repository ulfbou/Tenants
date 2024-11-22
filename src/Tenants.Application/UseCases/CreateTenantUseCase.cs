using Tenants.Domain.Entities;
using Tenants.Domain.Interfaces;

namespace Tenants.Application.UseCases;

//public class CreateTenantUseCase : ICreateTenantUseCase
//{
//    private readonly ITenantRepository _tenantRepository;
//    private readonly IPermissionRepository _permissionRepository;
//    private readonly IRoleRepository _roleRepository;

//    public CreateTenantUseCase(ITenantRepository tenantRepository, IPermissionRepository permissionRepository, IRoleRepository roleRepository)
//    {
//        _tenantRepository = tenantRepository;
//        _permissionRepository = permissionRepository;
//        _roleRepository = roleRepository;
//    }

//    public async Task<Tenant> HandleAsync(CreateTenantCommand command)
//    {
//        var tenant = new Tenant(command.Name, command.Description);
//        _tenantRepository.Add(tenant);
//        await _tenantRepository.UnitOfWork.SaveChangesAsync();

//        // Set up default permissions and roles
//        var defaultPermissions = ... // Define default permissions
//        var defaultRoles = ... // Define default roles with assigned permissions

//        await _permissionRepository.AddRangeAsync(defaultPermissions);
//        await _roleRepository.AddRangeAsync(defaultRoles);
//        await _tenantRepository.UnitOfWork.SaveChangesAsync();

//        return tenant;
//    }
//}