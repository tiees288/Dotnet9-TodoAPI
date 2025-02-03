using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models
{
    /// <summary>
    /// Data Transfer Object for TodoItem.
    /// </summary>
    public class TodoItemModel
    {
        /// <summary>
        /// Gets or sets the Id of the TodoItem.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the Name of the TodoItem.
        /// </summary>
        [Required(ErrorMessage = "Name is required.")]
        public required string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the TodoItem is complete.
        /// </summary>
        [Required(ErrorMessage = "IsComplete is required.")]
        public bool? IsComplete { get; set; }
    }
}