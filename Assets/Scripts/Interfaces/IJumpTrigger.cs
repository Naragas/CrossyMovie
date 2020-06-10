using UnityEngine;
namespace DefaultNamespace
{
    public interface IJumpTrigger
    {
         void SetPath();

         void OnTriggerEnter(Collider other);

         void OnTriggerExit(Collider other);

    }
}