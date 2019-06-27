/*
 *  Copyright (c) 2019 Spheroid Universe
 *
 *  Licensed under the Apache License, Version 2.0 (the "License");
 *  you may not use this file except in compliance with the License.
 *  You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 *  Unless required by applicable law or agreed to in writing, software
 *  distributed under the License is distributed on an "AS IS" BASIS,
 *  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *  See the License for the specific language governing permissions and
 *  limitations under the License.
 */

using Spheroid.Geo;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Spheroid.AR.Server
{
    public abstract class ARServer : IARServer, IUserEvents, IObjectEvents
    {
        protected ARServer() { }

        #region IARServer

        object IARServer.Api
        {
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));

                _objectApi = value as IObjectApi;
                _userApi = value as IUserApi;
            }
        }

        object IARServer.Events => this;

        #endregion

        #region Diagnostics

        protected virtual void OnException(Exception exception) { }

        #endregion

        #region IARObjectApi

        private IObjectApi _objectApi;

        private IObjectApi RequiredObjectApi
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _objectApi ?? throw new NotSupportedException();
        }

        #region Delete all objects

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void DeleteAllObjects() =>
            RequiredObjectApi.DeleteAllObjects(user: null);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void DeleteAllObjectsToUser(User user) =>
            RequiredObjectApi.DeleteAllObjects(user: user);

        #endregion

        #region Delete object

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void DeleteObject(Guid objectId) =>
            RequiredObjectApi.DeleteObject(user: null, objectId: objectId);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void DeleteObjectToUser(User user, Guid objectId) =>
            RequiredObjectApi.DeleteObject(user: user, objectId: objectId);

        #endregion

        #region Play object animation

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void PlayObjectAnimation(Guid objectId, string animationId, string stateId = default) =>
            RequiredObjectApi.PlayObjectAnimation(
                user: null, objectId: objectId, animationId: animationId, stateId: stateId);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void PlayObjectAnimationToUser(User user, Guid objectId, string animationId, string stateId = default) =>
            RequiredObjectApi.PlayObjectAnimation(
                user: user, objectId: objectId, animationId: animationId, stateId: stateId);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void PlayObjectAnimationAndDelete(Guid objectId, string animationId) =>
            RequiredObjectApi.PlayObjectAnimationAndDelete(
                user: null, objectId: objectId, animationId: animationId);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void PlayObjectAnimationAndDeleteToUser(User user, Guid objectId, string animationId) =>
            RequiredObjectApi.PlayObjectAnimationAndDelete(
                user: user, objectId: objectId, animationId: animationId);

        #endregion

        #region Render object

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void RenderObject(
            Guid objectId,
            Model model, // model
            LatLng? geoLocation = null, float? geoHeightValue = null, Vector3? scenePosition = null,
            HeightRelativity heightRelativity = HeightRelativity.Scene, HeightAlignment heightAlignment = HeightAlignment.Center, // position
            Vector3? rotation = null, float? rotationY = null, bool isMirrored = false, bool yAlwaysFollowUser = false, // rotation
            float? size = null, float? scale = null, // size/scale
            string stateId = null, // state
            float? viewDistance = null) // view distance
        {
            SetObjectModel(objectId, model);

            if (geoLocation.HasValue)
                SetObjectGeoPosition(objectId, geoLocation.Value, geoHeightValue, heightRelativity, heightAlignment);
            else if (scenePosition.HasValue)
                SetObjectScenePosition(objectId, scenePosition.Value, heightRelativity, heightAlignment);

            if (rotation.HasValue)
                SetObjectRotation(objectId, rotation.Value, isMirrored, yAlwaysFollowUser);
            else if (rotationY.HasValue)
                SetObjectRotation(objectId, rotationY.Value, isMirrored, yAlwaysFollowUser);

            if (size.HasValue)
                SetObjectSize(objectId, size.Value);
            else if (scale.HasValue)
                SetObjectScale(objectId, scale.Value);

            if (stateId != null)
                SetObjectState(objectId, stateId);

            if (viewDistance.HasValue)
                SetObjectViewDistance(objectId, viewDistance.Value);

            RequiredObjectApi.RenderObject(user: null, objectId: objectId);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void RenderObjectToUser(
            User user, Guid objectId,
            Model model, // model
            LatLng? geoLocation = null, float? geoHeightValue = null, Vector3? scenePosition = null,
            HeightRelativity heightRelativity = HeightRelativity.Scene, HeightAlignment heightAlignment = HeightAlignment.Center, // position
            Vector3? rotation = null, float? rotationY = null, bool isMirrored = false, bool yAlwaysFollowUser = false, // rotation
            float? size = null, float? scale = null, // size/scale
            string stateId = null, // state
            float? viewDistance = null) // view distance
        {
            SetObjectModelToUser(user, objectId, model);

            if (geoLocation.HasValue)
                SetObjectPositionToUser(user, objectId, geoLocation.Value, geoHeightValue, heightRelativity, heightAlignment);
            else if (scenePosition.HasValue)
                SetObjectScenePositionToUser(user, objectId, scenePosition.Value, heightRelativity, heightAlignment);

            if (rotation.HasValue)
                SetObjectRotationToUser(user, objectId, rotation.Value, isMirrored, yAlwaysFollowUser);
            else if (rotationY.HasValue)
                SetObjectRotationToUser(user, objectId, rotationY.Value, isMirrored, yAlwaysFollowUser);

            if (size.HasValue)
                SetObjectSizeToUser(user, objectId, size.Value);
            else if (scale.HasValue)
                SetObjectScaleToUser(user, objectId, scale.Value);

            if (stateId != null)
                SetObjectStateToUser(user, objectId, stateId);

            if (viewDistance.HasValue)
                SetObjectViewDistanceToUser(user, objectId, viewDistance.Value);

            RequiredObjectApi.RenderObject(user: user, objectId: objectId);
        }

        #endregion

        #region Set geo position

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetObjectGeoPosition(
            Guid objectId, LatLng location, float? heightValue = null,
            HeightRelativity heightRelativity = HeightRelativity.Scene, HeightAlignment heightAlignment = HeightAlignment.Center) =>
            RequiredObjectApi.SetObjectGeoPosition(
                user: null,
                objectId: objectId,
                location: location,
                height: new Height(
                     value: heightValue.GetValueOrDefault(),
                     options: new HeightOptions(heightRelativity, heightAlignment, isDefaultValue: !heightValue.HasValue)));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetObjectPositionToUser(
            User user, Guid objectId, LatLng location, float? heightValue = null,
            HeightRelativity heightRelativity = HeightRelativity.Scene, HeightAlignment heightAlignment = HeightAlignment.Center) =>
            RequiredObjectApi.SetObjectGeoPosition(
                user: user,
                objectId: objectId,
                location: location,
                height: new Height(
                    value: heightValue.GetValueOrDefault(),
                    options: new HeightOptions(heightRelativity, heightAlignment, isDefaultValue: !heightValue.HasValue)));

        #endregion

        #region Set model

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetObjectModel(Guid objectId, Model model) =>
            RequiredObjectApi.SetObjectModel(
                user: null,
                objectId: objectId,
                model: model);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetObjectModelToUser(User user, Guid objectId, Model model) =>
            RequiredObjectApi.SetObjectModel(
                user: user,
                objectId: objectId,
                model: model);

        #endregion

        #region Set on click play animation

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetObjectOnClickPlayAnimation(Guid objectId, string animationId, string stateId = default) =>
            RequiredObjectApi.SetObjectOnClickPlayAnimation(
                user: null,
                objectId: objectId,
                animationId: animationId,
                stateId: stateId);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetObjectOnClickPlayAnimationToUser(User user, Guid objectId, string animationId, string stateId = default) =>
            RequiredObjectApi.SetObjectOnClickPlayAnimation(
                user: user,
                objectId: objectId,
                animationId: animationId,
                stateId: stateId);

        #endregion

        #region Set rotation

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetObjectRotation(
            Guid objectId, Vector3 rotation, bool isMirrored = false, bool yAlwaysFollowUser = false) =>
            RequiredObjectApi.SetObjectRotation(
                user: null,
                objectId: objectId,
                options: GetObjectRotationOptions(isMirrored, yAlwaysFollowUser),
                rotation: rotation);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetObjectRotation(
            Guid objectId, float rotationY, bool isMirrored = false, bool yAlwaysFollowUser = false) =>
            RequiredObjectApi.SetObjectRotation(
                user: null,
                objectId: objectId,
                options: GetObjectRotationOptions(isMirrored, yAlwaysFollowUser),
                rotation: new Vector3(x: 0, y: rotationY, z: 0));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetObjectRotationToUser(
            User user, Guid objectId, Vector3 rotation, bool isMirrored = false, bool yAlwaysFollowUser = false) =>
            RequiredObjectApi.SetObjectRotation(
                user: user,
                objectId: objectId,
                options: GetObjectRotationOptions(isMirrored, yAlwaysFollowUser),
                rotation: rotation);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetObjectRotationToUser(
            User user, Guid objectId, float rotationY, bool isMirrored = false, bool yAlwaysFollowUser = false) =>
            RequiredObjectApi.SetObjectRotation(
                user: user,
                objectId: objectId,
                options: GetObjectRotationOptions(isMirrored, yAlwaysFollowUser),
                rotation: new Vector3(x: 0, y: rotationY, z: 0));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private ObjectRotationOptions GetObjectRotationOptions(bool isMirrored, bool yAlwaysFollowUser)
        {
            var options = isMirrored ? ObjectRotationOptions.IsMirrored : ObjectRotationOptions.None;

            if (yAlwaysFollowUser)
                options |= ObjectRotationOptions.YAlwaysFollowUser;

            return options;
        }

        #endregion

        #region Set scale

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetObjectScale(Guid objectId, float scale) =>
            RequiredObjectApi.SetObjectScale(user: null, objectId: objectId, scale: scale);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetObjectScaleToUser(User user, Guid objectId, float scale) =>
            RequiredObjectApi.SetObjectScale(user: user, objectId: objectId, scale: scale);

        #endregion

        #region Set scene position

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetObjectScenePosition(
            Guid objectId, Vector3 position,
            HeightRelativity heightRelativity = HeightRelativity.Scene, HeightAlignment heightAlignment = HeightAlignment.Center) =>
            RequiredObjectApi.SetObjectScenePosition(
                user: null,
                objectId: objectId,
                position: position,
                heightOptions: new HeightOptions(heightRelativity, heightAlignment, isDefaultValue: false));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetObjectScenePositionToUser(
            User user, Guid objectId, Vector3 position,
            HeightRelativity heightRelativity = HeightRelativity.Scene, HeightAlignment heightAlignment = HeightAlignment.Center) =>
            RequiredObjectApi.SetObjectScenePosition(
                user: user,
                objectId: objectId,
                position: position,
                heightOptions: new HeightOptions(heightRelativity, heightAlignment, isDefaultValue: false));

        #endregion

        #region Set size

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetObjectSize(Guid objectId, float size) =>
            RequiredObjectApi.SetObjectSize(user: null, objectId: objectId, size: size);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetObjectSizeToUser(User user, Guid objectId, float size) =>
            RequiredObjectApi.SetObjectSize(user: user, objectId: objectId, size: size);

        #endregion

        #region Set state

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetObjectState(Guid objectId, string stateId) =>
            RequiredObjectApi.SetObjectState(user: null, objectId: objectId, stateId: stateId);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetObjectStateToUser(User user, Guid objectId, string stateId) =>
            RequiredObjectApi.SetObjectState(user: user, objectId: objectId, stateId: stateId);

        #endregion

        #region Set view distance

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetObjectViewDistance(Guid objectId, float viewDistance) =>
            RequiredObjectApi.SetObjectViewDistance(user: null, objectId: objectId, viewDistance: viewDistance);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetObjectViewDistanceToUser(User user, Guid objectId, float viewDistance) =>
            RequiredObjectApi.SetObjectViewDistance(user: user, objectId: objectId, viewDistance: viewDistance);

        #endregion

        #endregion

        #region IARObjectEvents

        public virtual void OnObjectModel(User user, Guid objectId, AssetSource modelSource, Guid modelId) { }
        public virtual void OnObjectClick(User user, Guid objectId) { }
        public virtual void OnRenderObjects(User user, Bounds bounds) { }

        void IObjectEvents.ObjectModel(User user, Guid objectId, AssetSource modelSource, Guid modelId)
        {
            try
            {
                OnObjectModel(user: user, objectId: objectId, modelSource: modelSource, modelId: modelId);
            }
            catch (Exception exception)
            {
                Debug.Fail(exception.ToString());
                OnException(exception);
                throw;
            }
        }

        void IObjectEvents.ObjectClick(User user, Guid objectId)
        {
            try
            {
                OnObjectClick(user: user, objectId: objectId);
            }
            catch (Exception exception)
            {
                Debug.Fail(exception.ToString());
                OnException(exception);
                throw;
            }
        }

        void IObjectEvents.RenderObjects(User user, Bounds bounds)
        {
            try
            {
                OnRenderObjects(user: user, bounds: bounds);
            }
            catch (Exception exception)
            {
                Debug.Fail(exception.ToString());
                OnException(exception);
                throw;
            }
        }

        #endregion

        #region IARUserApi

        private IUserApi _userApi;

        private IUserApi RequiredUserApi
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _userApi ?? throw new NotSupportedException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IEnumerable<IUserData> GetUsers() => RequiredUserApi.GetUsers();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool TryGetUserData(User user, out IUserData userData) =>
            RequiredUserApi.TryGetUserData(user, out userData);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetStatusToUser(User user, string text, Image? icon = null) =>
            RequiredUserApi.SetUserStatus(user: user, icon: icon, text: text);

        #endregion

        #region IARUserEvents

        public virtual void OnUserCameraPosition(User user, Vector3 position, Vector3 rotation) { }
        public virtual void OnUserLayer(User user, Guid layerId) { }
        public virtual void OnUserLocation(User user, LatLng location) { }
        public virtual void OnUserOffline(User user) { }
        public virtual void OnUserOnline(User user) { }

        void IUserEvents.UserCameraPosition(User user, Vector3 position, Vector3 rotation)
        {
            try
            {
                OnUserCameraPosition(user: user, position: position, rotation: rotation);
            }
            catch (Exception exception)
            {
                Debug.Fail(exception.ToString());
                OnException(exception);
                throw;
            }
        }

        void IUserEvents.UserLayer(User user, Guid layerId)
        {
            try
            {
                OnUserLayer(user, layerId);
            }
            catch (Exception exception)
            {
                Debug.Fail(exception.ToString());
                OnException(exception);
                throw;
            }
        }

        void IUserEvents.UserLocation(User user, LatLng location)
        {
            try
            {
                OnUserLocation(user: user, location: location);
            }
            catch (Exception exception)
            {
                Debug.Fail(exception.ToString());
                OnException(exception);
                throw;
            }
        }

        void IUserEvents.UserOffline(User user)
        {
            try
            {
                OnUserOffline(user: user);
            }
            catch (Exception exception)
            {
                Debug.Fail(exception.ToString());
                OnException(exception);
                throw;
            }
        }

        void IUserEvents.UserOnline(User user)
        {
            try
            {
                OnUserOnline(user: user);
            }
            catch (Exception exception)
            {
                Debug.Fail(exception.ToString());
                OnException(exception);
                throw;
            }
        }

        #endregion
    }
}
