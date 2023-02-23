using CodeBase.Infrastructure.States;

namespace CodeBase.Infrastructure
{
    public interface IUpdateListener : IState
    {
        void Update(float deltaTime);
    }
}