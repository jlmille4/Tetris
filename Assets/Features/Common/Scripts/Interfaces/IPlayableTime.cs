
namespace gov.nasa.ksc.it.itacl.common
{
    public interface IPlayableTime : ITime
    {
        bool IsPlaying { get; }
        void Play();
        void Pause();
    }
}