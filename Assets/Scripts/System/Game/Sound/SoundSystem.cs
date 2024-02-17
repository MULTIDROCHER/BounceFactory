namespace BounceFactory.System.Game.Sound
{
    public class SoundSystem
    {
        public VolumeChanger VolumeChanger { get; private set; }
        public SourcePool Pool { get; private set; }

        public SoundSystem(SourcePool pool)
        {
            Pool = pool;
            VolumeChanger = new (pool);
        }
    }
}