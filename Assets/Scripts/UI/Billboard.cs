using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.General
{
    class Billboard : MonoBehaviour
    {

        private void Start()
        {
            Camera camera = FindObjectOfType<Camera>(true);
        }
        private void LateUpdate()
        {
            transform.LookAt(transform.position + Camera.main.transform.forward);
        }
    }
}
