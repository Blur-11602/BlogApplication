 

// This file was automatically generated by the PetaPoco T4 Template
// Do not make changes directly to this file - edit the template instead
// 
// The following connection settings were used to generate this file
// 
//     Connection String Name: `BlogApplication`
//     Provider:               `System.Data.SqlClient`
//     Connection String:      `Data Source=Rupert;Initial Catalog=BlogApplication;User Id=blog;password=**zapped**;`
//     Schema:                 `dbo`
//     Include Views:          `False`

//     Factory Name:          `SqlClientFactory`
// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments
#pragma warning disable 1591

using System;

using ServiceStack.DataAnnotations;
using ServiceStack.Model;
using ServiceStack;

namespace BlogApplication.Models
{
[Alias("BlogPost")]
    public partial class BlogPost : IHasId<int> 
    {
        [Alias("Id")]
        [AutoIncrement]
        public int Id { get; set;}
        [References(typeof(User))]          
        [Required]
        public int UserId { get; set;}
        [Required]
        public string Title { get; set;}
        [Required]
        public string Body { get; set;}
        [Required]
        public DateTime PublishDate { get; set;}
    }

[Alias("Comment")]
    public partial class Comment : IHasId<int> 
    {
        [Alias("Id")]
        [AutoIncrement]
        public int Id { get; set;}
        [References(typeof(User))]          
        public int? UserId { get; set;}
        [References(typeof(BlogPost))]          
        public int? BlogPostId { get; set;}
        [Required]
        public string Title { get; set;}
        [Required]
        public string Body { get; set;}
        [Required]
        public DateTime PostedDate { get; set;}
    }

[Alias("User")]
    public partial class User : IHasId<int> 
    {
        [Alias("Id")]
        [AutoIncrement]
        public int Id { get; set;}
        [Required]
        public string Username { get; set;}
        [Required]
        public string EmailAddress { get; set;}
        [Required]
        public string Password { get; set;}
        public string FirstName { get; set;}
        public string LastName { get; set;}
        public DateTime? DateOfBirth { get; set;}
        [Required]
        public DateTime CreatedDate { get; set;}
        public DateTime? DateInactive { get; set;}
    }

[Alias("VersionInfo")]
    public partial class VersionInfo 
    {
        [Required]
        public long Version { get; set;}
        public DateTime? AppliedOn { get; set;}
        public string Description { get; set;}
    }

}
#pragma warning restore 1591
