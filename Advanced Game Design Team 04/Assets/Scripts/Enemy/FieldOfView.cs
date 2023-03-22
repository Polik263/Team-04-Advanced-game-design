using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

namespace Enemy
{
    public class FieldOfView : MonoBehaviour
    {
        [SerializeField] private float _viewRadius;
        [SerializeField, Range(0,360)] private float _viewAngle;
        
        [SerializeField] private LayerMask _targetMask;
        [SerializeField] private LayerMask _obstacleMask;
        
        private List<Transform> _targetsInViewRadius;

        [FormerlySerializedAs("displayCone")]
        [Header("Debug")] 
        [SerializeField] private bool _displayCone;
        [SerializeField] private bool markTargets;


        private void Awake()
        {
            _targetsInViewRadius = new List<Transform>();
        }

        public void Init(float viewRadius, float viewAngle)
        {
            _viewRadius = viewRadius;
            _viewAngle = viewAngle;
        }
        
        public List<Transform> GetTargetsInView()
        {
            UpdateTargetsInView();
            return _targetsInViewRadius;
        }
        
        public bool IsTargetInView(Transform target)
        {
            UpdateTargetsInView();
            return _targetsInViewRadius.Contains(target);
        }

        private void UpdateTargetsInView()
        {
            _targetsInViewRadius.Clear();
            var targets = GetCollidersInRange();

            foreach (var targetCol in targets)
            {
                if(targetCol.gameObject == gameObject) continue;
                var target = targetCol.transform;
                var dirToTarget = (target.position - transform.position).normalized;
                if (!(Vector3.Angle(transform.forward, dirToTarget) < _viewAngle / 2)) continue;
                
                var distToTarget = Vector3.Distance(transform.position, target.position);
                if (!Physics.Raycast(transform.position, dirToTarget, distToTarget, _obstacleMask))
                {
                    _targetsInViewRadius.Add(target);
                }
            }
        }

        private Collider[] GetCollidersInRange()
        {
            return Physics.OverlapSphere(transform.position, _viewRadius, _targetMask);
        }
        
        //Lague
        private Vector3 DirectionFromAngle(float angleInDegrees) 
        {
            angleInDegrees += transform.eulerAngles.y;
            return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
        }
        
        
        
        //Gizmos
        private void OnDrawGizmosSelected()
        {
            if(_displayCone)
                DisplayVisionConeGizmo();
            
            if(markTargets)
                MarkTargetsGizmo();

        }

        private void MarkTargetsGizmo()
        {
            if(_targetsInViewRadius == null || _targetsInViewRadius.Count == 0) return;
            Gizmos.color = Color.blue;
            var closestTarget = _targetsInViewRadius[0];
            var closestDistance = Vector3.Distance(transform.position, closestTarget.transform.position);
            foreach (var target in _targetsInViewRadius)
            {
                var distanceToTarget = Vector3.Distance(transform.position, target.transform.position);
                if(distanceToTarget < closestDistance)
                {
                    closestTarget = target;
                    closestDistance = distanceToTarget;
                }                
                Gizmos.DrawWireSphere(target.transform.position, 1f);
            }
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(closestTarget.transform.position, 1f);
        }

        private void DisplayVisionConeGizmo()
        {
            var position = transform.position;
            Gizmos.color = Color.red;
            var viewAngleA = DirectionFromAngle(-_viewAngle / 2);
            var viewAngleB = DirectionFromAngle(_viewAngle / 2);
            
            Handles.DrawWireArc(position, Vector3.up, viewAngleA, _viewAngle, _viewRadius);
            
            Gizmos.DrawLine(position, position + viewAngleA * _viewRadius);
            Gizmos.DrawLine(position, position + viewAngleB * _viewRadius);
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(position, position + transform.forward * _viewRadius);
        }
    }
}