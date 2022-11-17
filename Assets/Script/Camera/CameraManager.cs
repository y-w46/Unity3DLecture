using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CameraSpace
{
    //[ExecuteInEditMode]
    public class CameraManager : MonoBehaviour
    {
        [Serializable]
        public class Parameter
        {
            public Transform trackTarget;

            //CameraParent
            public Vector3 position;
            public Vector3 angles = new Vector3(5f, 0f, 0f);

            //CameraChild
            public float distance = 7f;

            //MainCamera
            public float fieldOfView = 45f;
            public Vector3 offsetPosition = new Vector3(0f, 1f, 0f);
            public Vector3 offsetAngles;
        }

        [SerializeField] private Transform _parent;
        [SerializeField] private Transform _child;
        [SerializeField] private Camera _camera;

        //ParameterクラスをInspectorから設定するために定義
        [SerializeField] private Parameter _parameter;

        private void LateUpdate()
        {
            if (_parent == null || _child == null || _camera == null)
            {
                return;
            }

            if (_parameter.trackTarget != null)
            {
                _parameter.position = _parameter.trackTarget.position;
            }

            //パラメータを各種オブジェクトに反映
            _parent.position = _parameter.position;
            _parent.eulerAngles = _parameter.angles;

            var childPos = _child.localPosition;
            childPos.z = -_parameter.distance;
            _child.localPosition = childPos;

            _camera.fieldOfView = _parameter.fieldOfView;
            _camera.transform.localPosition = _parameter.offsetPosition;
            _camera.transform.localEulerAngles = _parameter.offsetAngles;
        }
    }
}

