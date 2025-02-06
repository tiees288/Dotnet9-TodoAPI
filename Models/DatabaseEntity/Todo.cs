using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApi.Entity
{
     /// <summary>
     /// Represents a Todo Data Transfer Object.
     /// </summary>
     public class Todo
     {
          /// <summary>
          /// Gets or sets the unique identifier for the Todo item.
          /// </summary>
          [Key]
          [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  // Auto-increment PK
          public long Id { get; set; }

          /// <summary>
          /// Gets or sets the name of the Todo item.
          /// </summary>
          public string Name { get; set; }

          /// <summary>
          /// Gets or sets a value indicating whether the Todo item is complete.
          /// </summary>
          public bool IsComplete { get; set; }

          /// <summary>
          /// Gets or sets the date and time when the Todo item was created.
          /// </summary>
          public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

          /// <summary>
          /// Gets or sets the date and time when the Todo item was last updated.
          /// </summary>
          public DateTime UpdatedDate { get; set; }
          /// <summary>
          /// Initializes a new instance of the <see cref="TodoDTO"/> class.
          /// </summary>
          /// <param name="name">The name of the Todo item.</param>
          /// <param name="isComplete">A value indicating whether the Todo item is complete.</param>
          /// <param name="createdDate">The date and time when the Todo item was created.</param>
          
          public ICollection<TodoDetail> TodoDetails { get; set; }

          public Todo(
               string name = "",
               bool isComplete = false,
               DateTime createdDate = default
          )
          {
               Name = name;
               IsComplete = isComplete;
               CreatedDate = createdDate == default ? DateTime.UtcNow : createdDate;
               UpdatedDate = DateTime.UtcNow;
          }
     }
}