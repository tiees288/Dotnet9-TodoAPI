using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApi.Entity
{
     public class TodoDetail
     {
          [Key]
          [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
          public long Id { get; set; }
          public string Comment { get; set; }
          public DateTime CreatedDate { get; set; }
          public DateTime UpdatedDate { get; set; }

          [ForeignKey("TodoId")]
          [Column("TodoId")]
          public long TodoId { get; set; }
          public TodoDetail(string comment = "", DateTime createdDate = default)
          {
               Comment = comment;
               CreatedDate = createdDate == default ? DateTime.UtcNow : createdDate;
               UpdatedDate = DateTime.UtcNow;
          }
     }
}