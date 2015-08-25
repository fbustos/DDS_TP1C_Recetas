using System.Linq;
using System.Security.Principal;
using DDS.Model.Models;

namespace DDS.Models.Security
{
    public class CustomPrincipal : IPrincipal
    {
        public IIdentity Identity { get; private set; }

        public bool IsInRole(string role)
        {
            return true;
        }

        public CustomPrincipal(string username)
        {
            this.Identity = new GenericIdentity(username);
        }

        public Usuario User { get; set; }
    }
}