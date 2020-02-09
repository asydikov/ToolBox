using System;

namespace ToolBox.Services.Identity.Entities
{
    public abstract class EntityBase
    {
        public Guid Id { get; protected set; }
    }
}