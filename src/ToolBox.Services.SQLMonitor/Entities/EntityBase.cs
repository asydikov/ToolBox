using System;
using System.ComponentModel.DataAnnotations;

namespace ToolBox.Services.SQLMonitor.Entities
{
    public abstract class EntityBase
    {
        [Required]
        public Guid Id { get; protected set; }
        [Required]
        public DateTime CreatedDate { get; protected set; }
        [Required]
        public DateTime UpdatedDate { get; protected set; }
        [Required]
        public bool IsActive { get; protected set; }

        public EntityBase(Guid? id = null)
        {
            Id = id ?? Guid.NewGuid();
            CreatedDate = DateTime.UtcNow;
            IsActive = true;
            SetUpdatedDate();
        }

        public void Initialize()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.UtcNow;
            IsActive = true;
            SetUpdatedDate();
        }

        public virtual void SetUpdatedDate()
            => UpdatedDate = DateTime.UtcNow;

        public void Disable()
           => IsActive = false;

        public void Enable()
           => IsActive = true;
    }
}
