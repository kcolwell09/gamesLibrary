using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace gamesLibrary.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the gamesLibraryUser class
    public class gamesLibraryUser : IdentityUser
    {
        [PersonalData]
        [Column(TypeName="nvarchar(50)")]
        public string Forename { get; set; }
        [PersonalData]
        [Column(TypeName = "nvarchar(50)")]
        public string Surname { get; set; }
    }
}
