namespace VRTK.Examples
{
    using UnityEngine;

    public class GunShoot : MonoBehaviour
    {
        public SteamVR_TrackedObject trackedObjR;
        private SteamVR_Controller.Device deviceR;
        public SteamVR_TrackedObject trackedObjL;
        private SteamVR_Controller.Device deviceL;
        public gunAttachment gunAttach;

        public GameObject projectile;
        public Transform projectileSpawnPoint;
        public float projectileSpeed = 1000f;
        public float projectileLife = 5f;

        private void Update() {
            if((int)trackedObjR.index != -1) {
                deviceR = SteamVR_Controller.Input((int)trackedObjR.index);
            }
            if((int)trackedObjL.index != -1) {
                deviceL = SteamVR_Controller.Input((int)trackedObjL.index);
            }

            if(deviceR != null && deviceR.GetPressDown(SteamVR_Controller.ButtonMask.Trigger) && gunAttach.gunAttached == true) {
                FireProjectile();
            } else if(deviceL != null && deviceL.GetPressDown(SteamVR_Controller.ButtonMask.Trigger) && gunAttach.gunAttached == true) {
                FireProjectile();
            }

        }

        protected virtual void FireProjectile()
        {
            if (projectile != null && projectileSpawnPoint != null)
            {
                GameObject clonedProjectile = Instantiate(projectile, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
                Rigidbody projectileRigidbody = clonedProjectile.GetComponent<Rigidbody>();
                float destroyTime = 0f;
                if (projectileRigidbody != null)
                {
                    projectileRigidbody.AddForce(clonedProjectile.transform.forward * projectileSpeed);
                    destroyTime = projectileLife;
                }
                Destroy(clonedProjectile, destroyTime);
            }
        }
    }
}