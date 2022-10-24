using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Library.Data.Models
{
    public class User : IdentityUser
    {
        public virtual ICollection<UserBook> UsersBooks { get; set; } =
            new HashSet<UserBook>();
    }
}
