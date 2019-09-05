using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("user")]
    public class User
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Column("username",TypeName ="nvarchar")]
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }
        [Column("password")]
        public string Password { get; set; }
    }
}
