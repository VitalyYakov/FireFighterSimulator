
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace UnityStandardAssets.Effects
{
    
    public class Hose : MonoBehaviour
    {
        public float maxPower = 20;
        public float minPower = 5;
        public float changeSpeed = 5;
        public ParticleSystem[] hoseWaterSystems;
        public Renderer systemRenderer;
        public CheckBar chb;
        
        private float m_Power;
        private bool n_Power = true;



        // Update is called once per frame
        private void Update()
        {
            if(Input.GetMouseButton(0) && CheckBar.current >=0){
            m_Power = Mathf.Lerp(m_Power, n_Power ? maxPower : minPower, Time.deltaTime*changeSpeed);
            chb.AdjustCurrentValue(-10);
            }else{
                m_Power = Mathf.Lerp(m_Power, false ? maxPower : minPower, Time.deltaTime*changeSpeed);
            }
            
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                
                systemRenderer.enabled = !systemRenderer.enabled;
            }

            foreach (var system in hoseWaterSystems)
            {
				ParticleSystem.MainModule mainModule = system.main;
                mainModule.startSpeed = m_Power;
                var emission = system.emission;
                emission.enabled = (m_Power > minPower*1.1f);
            }
        }
        public void UseProtec()
        {
            m_Power = Mathf.Lerp(m_Power, Input.GetMouseButton(0) ? maxPower : minPower, Time.deltaTime*changeSpeed);
        }

       private void OnParticleCollision(GameObject other) {
        gameObject.SetActive(false);
        if (other.TryGetComponent(out FireNode fNode))
        {
            
        }
       }
    }
}
