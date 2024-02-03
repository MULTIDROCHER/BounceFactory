using System;

namespace BounceFactory.Tutorial
{
   public interface ITutorialEvent
   {
      public event Action Performed;
   }
}