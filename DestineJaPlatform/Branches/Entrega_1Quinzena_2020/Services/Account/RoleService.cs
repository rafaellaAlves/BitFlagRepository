using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Services.Account
{
    public class RoleService
    {
        private class RoleDefinition
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public RoleDefinition(string name, string description)
            {
                this.Name = name;
                this.Description = description;
            }
        }

        private readonly AspNetIdentityDbContext.ApplicationDbContext context;
        RoleManager<AspNetIdentityDbContext.Role> roleManager;
        List<RoleDefinition> rolesDefinition;
        public RoleService(AspNetIdentityDbContext.ApplicationDbContext context, RoleManager<AspNetIdentityDbContext.Role> roleManager)
        {
            this.context = context;
            this.roleManager = roleManager;
            this.rolesDefinition = new List<RoleDefinition>()
            {
                new RoleDefinition("Administrator", "Administrador"),
                new RoleDefinition("Financial", "Financeiro"),
                new RoleDefinition("Commercial", "Comercial"),
                new RoleDefinition("Operational", "Operacional"),
                new RoleDefinition("Cliente", "Cliente"),
                new RoleDefinition("ClientAdministrator", "Administrador - Cliente")
            };
        }
        public void CreateBasicRoles()
        {
            foreach (var roleDefinition in rolesDefinition)
            {
                if (!roleManager.RoleExistsAsync(roleDefinition.Name).Result)
                {
                    var result = roleManager.CreateAsync(new AspNetIdentityDbContext.Role()
                    {
                        Name = roleDefinition.Name,
                        Description = roleDefinition.Description
                    }).Result;
                }
            }
        }
        public async Task<List<DTO.Account.RoleViewModel>> GetRoles()
        {
            return await context.Roles.Select(x => new DTO.Account.RoleViewModel()
            {
                Name = x.Name,
                Description = x.Description
            }).ToListAsync();
        }
        public string[] GetAllRoles()
        {
            return rolesDefinition.Select(x => x.Name).ToArray();
        }

        public async Task<AspNetIdentityDbContext.Role> GetRoleByName(string name) => await roleManager.FindByNameAsync(name);
    }
}