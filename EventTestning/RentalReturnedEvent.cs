using System.Collections.Generic;
using SFF_API.Repositories;
using SFF_API.Context;
using SFF_API.Models;

public class RentalReturnedEvent : EventBase
 {
 public RentalReturnedEvent()
 {
  Items = new List<Rental>();
 }

 public List<Rental> Items { get; set; }
 }
