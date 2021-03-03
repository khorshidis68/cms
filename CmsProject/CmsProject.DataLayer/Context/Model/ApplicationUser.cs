//using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Linq;

namespace CmsProject.DataLayer.Context.Model
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name ="نام")]
        [MaxLength(200,ErrorMessage ="حداکثر تعداد {0} برابر با 200 کاراکتر می باشد")]
        public string FirstName { get; set; }

        [Display(Name = "نام خانوادگی")]
        [MaxLength(200, ErrorMessage = "حداکثر تعداد {0} برابر با 200 کاراکتر می باشد")]
        public string LastName { get; set; }

        [Display(Name = "تاریخ تولد")]
        public string BirthDate { get; set; }



        //public async Task<ClaimsIdentity> GenerateUserIdentityAsync(Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> manager)
        //{
        //    // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
        //    var userIdentity = await manager.CreateIdentityAsync(this, Microsoft.AspNet.Identity.DefaultAuthenticationTypes.ApplicationCookie);
        //    // Add custom user claims here
        //    userIdentity.AddClaim(new Claim("FullName", this.FirstName + ' ' + LastName));
        //    return userIdentity;
        //}


        //public static string GetFullName(this System.Security.Principal.IPrincipal usr)
        //{
        //    var fullNameClaim = ((ClaimsIdentity)usr.Identity).FindFirst("FullName");
        //    if (fullNameClaim != null)
        //        return fullNameClaim.Value;

        //    return "";
        //}

    }
}