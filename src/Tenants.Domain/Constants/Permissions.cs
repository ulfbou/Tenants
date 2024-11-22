namespace Tenants.Domain.Constants;

public static class Permissions
{
    public static class Users
    {
        public const string View = "permissions.users.view";
        public const string Create = "permissions.users.create";
        public const string Edit = "permissions.users.edit";
        public const string Delete = "permissions.users.delete";
    }

    public static class Roles
    {
        public const string View = "permissions.roles.view";
        public const string Create = "permissions.roles.create";
        public const string Edit = "permissions.roles.edit";
        public const string Delete = "permissions.roles.delete";
    }

    public static class PermissionsManagement
    {
        public const string View = "permissions.permissions.view";
        public const string Create = "permissions.permissions.create";
        public const string Edit = "permissions.permissions.edit";
        public const string Delete = "permissions.permissions.delete";
    }

    public static class Tenants
    {
        public const string View = "permissions.tenants.view";
        public const string Create = "permissions.tenants.create";
        public const string Edit = "permissions.tenants.edit";
        public const string Delete = "permissions.tenants.delete";

        public static class Users
        {
            public const string View = "permissions.tenants.users.view";
            public const string Create = "permissions.tenants.users.create";
            public const string Edit = "permissions.tenants.users.edit";
            public const string Delete = "permissions.tenants.users.delete";
        }

        public static class Roles
        {
            public const string View = "permissions.tenants.roles.view";
            public const string Create = "permissions.tenants.roles.create";
            public const string Edit = "permissions.tenants.roles.edit";
            public const string Delete = "permissions.tenants.roles.delete";
        }

        public static class Permissions
        {
            public const string View = "permissions.tenants.permissions.view";
            public const string Create = "permissions.tenants.permissions.create";
            public const string Edit = "permissions.tenants.permissions.edit";
            public const string Delete = "permissions.tenants.permissions.delete";
        }
    }
}