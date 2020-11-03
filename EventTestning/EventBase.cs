using System;

public class EventBase
 {
 protected DateTime OccuredOn {get;set;}
 public EventBase()
 {
  OccuredOn = DateTime.Now;
 }
 
 }