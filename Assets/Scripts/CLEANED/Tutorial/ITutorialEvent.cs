using System;

namespace BounceFactory
{
   public interface ITutorialEvent
   {
      public event Action Performed;
   }
}