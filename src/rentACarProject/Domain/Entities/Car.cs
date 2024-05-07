using Base.Domain;

using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Car:Entity<Guid>
{

    
    public Guid ModelId { get; set; }
    public int Kilometer { get; set; }
    public short ModelYear { get; set; }
    public string Plate { get; set; }
    public short MinFindeksCreditRate { get; set; }

    
    public virtual Model Model { get; set; }
}
