using Microsoft.AspNet.Identity.EntityFramework;

namespace TrashCollectorProject
{
    internal class RoleCustomer<T>
    {
        private RoleStore<IdentityRole> roleStore;

        public RoleCustomer(RoleStore<IdentityRole> roleStore)
        {
            this.roleStore = roleStore;
        }
    }
}