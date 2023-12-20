﻿using Core.Entities;

namespace Entities.Concretes;

public class Company : Entity<int>
{
    public string Name { get; set; }

   public virtual ICollection <Experience > Experiences { get; set; }
}