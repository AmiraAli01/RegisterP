using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using ScientificJournals.Models;

[assembly: OwinStartupAttribute(typeof(ScientificJournals.Startup))]
namespace ScientificJournals
{
    public partial class Startup
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRoles();
            CreateUsers();
        }

        public void CreateRoles()
        {
            var rolemanager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            IdentityRole role;
            if (!rolemanager.RoleExists("Administrators"))
            {
                role = new IdentityRole();
                role.Name = "Administrators";
                rolemanager.Create(role);
            }
            if (!rolemanager.RoleExists("Editors"))
            {
                role = new IdentityRole();
                role.Name = "Editors";
                rolemanager.Create(role);
            }
            if (!rolemanager.RoleExists("Publishers"))
            {
                role = new IdentityRole();
                role.Name = "Publishers";
                rolemanager.Create(role);
            }
            if (!rolemanager.RoleExists("Viewer"))
            {
                role = new IdentityRole();
                role.Name = "Viewer";
                rolemanager.Create(role);
            }

        }

        public void CreateUsers()
        {
            var usermanager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            ApplicationUser BasicAdmin = new ApplicationUser();
            BasicAdmin.Email = "BasicAdmin@gmail.com";
            BasicAdmin.UserName = "BasicAdmin";
            if (usermanager.Create(BasicAdmin, "Aa_123456789").Succeeded)
            {
                usermanager.AddToRole(BasicAdmin.Id, "Administrators");
            }

            ApplicationUser DefaultViewer = new ApplicationUser();
            DefaultViewer.Email = "DefaultViewer@hotmail.com";
            DefaultViewer.UserName = "DefaultViewer";
            if (usermanager.Create(DefaultViewer, "Aa_123456789").Succeeded)
            {
                usermanager.AddToRole(DefaultViewer.Id, "Viewer");
            }

            ApplicationUser DefaultEditor = new ApplicationUser();
            DefaultEditor.Email = "DefaultEditor@Dk.gov.eg";
            DefaultEditor.UserName = "DefaultEditor";
            if (usermanager.Create(DefaultEditor, "Aa_123456789").Succeeded)
            {
                usermanager.AddToRole(DefaultEditor.Id, "Editors");
            }

            ApplicationUser DefaultPublisher = new ApplicationUser();
            DefaultPublisher.Email = "DefaultPublisher@Dk.gov.eg";
            DefaultPublisher.UserName = "DefaultPublisher";
            if (usermanager.Create(DefaultPublisher, "Aa_123456789").Succeeded)
            {
                usermanager.AddToRole(DefaultPublisher.Id, "Publishers");
            }

        }
    }
}
