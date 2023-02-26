using CodeBase.Infrastructure.States;

namespace CodeBase.Infrastructure
{
    public interface IUpdateListener : IExitableState
    {
        void Update(float deltaTime);
    }
}