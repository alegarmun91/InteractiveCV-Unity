using UnityEngine;

namespace MonoBehaviours.PlayspaceSystem.PlayspaceAgents
{
    [RequireComponent(typeof(Rigidbody))]
    public class GlobeSpinner : PlayspaceAgent
    {
        public float lerpSpeed = 1.5f;
        public float rotationSpeed = 10.0f;
        
        private Vector3 _avgSpeed;
        private bool _dragging;
        private Rigidbody _myRigidbody;
        private Vector3 _speed;
        private Vector3 _targetSpeedX = new Vector3();

        protected override void Start()
        {
            base.Start();

            _myRigidbody = transform.GetComponent<Rigidbody>();
            _myRigidbody.maxAngularVelocity = 15f;
        }

        private void Update()
        {
            HandleInput(isActive);

            transform.Rotate(Vector3.up, _speed.x * rotationSpeed, Space.Self);
        }

        private void HandleInput(bool state)
        {
            if (Input.GetMouseButton(0) && _dragging && state)
            {
                _speed = new Vector3(-Input.GetAxis("Mouse X"), 0, 0);
                _avgSpeed = Vector3.Lerp(_avgSpeed, _speed, Time.deltaTime * 5);
            }
            else
            {
                if (_dragging)
                {
                    _speed = _avgSpeed;
                    _dragging = false;
                }

                var i = Time.deltaTime * lerpSpeed;
                _speed = Vector3.Lerp(_speed, Vector3.zero, i);
            }
        }

        private void OnMouseDrag()
        {
            _myRigidbody.isKinematic = true;
            _dragging = true;
        }

        private void OnMouseUp()
        {
            _myRigidbody.isKinematic = false;
        }
    }
}