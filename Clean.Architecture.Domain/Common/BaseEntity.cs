﻿namespace Clean.Architecture.Domain.Common
{
    public abstract class BaseEntity
    {
        public virtual int Id { get; protected set; }
    }
}
