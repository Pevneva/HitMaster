using CodeBase.Infrastructure.Services.Factory;
using UnityEngine;

namespace CodeBase.WayPoints
{
    public class SpawnWayPoint : MonoBehaviour
    {
        private IGameFactory _factory;

        public void Construct(IGameFactory factory) => 
            _factory = factory;
    }
}