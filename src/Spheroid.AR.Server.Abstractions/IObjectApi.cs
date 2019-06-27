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

namespace Spheroid.AR.Server
{
    public interface IObjectApi
    {
        void DeleteAllObjects(User? user);
        void DeleteObject(Guid objectId, User? user);
        void PlayObjectAnimation(Guid objectId, string animationId, string stateId, User? user);
        void PlayObjectAnimationAndDelete(Guid objectId, string animationId, User? user);
        void RenderObject(Guid objectId, User? user);
        void SetObjectOnClickPlayAnimation(Guid objectId, string animationId, string stateId, User? user);
        void SetObjectGeoPosition(Guid objectId, LatLng location, Height height, User? user);
        void SetObjectModel(Guid objectId, Model model, User? user);
        void SetObjectRotation(Guid objectId, ObjectRotationOptions options, Vector3 rotation, User? user);
        void SetObjectScale(Guid objectId, float scale, User? user);
        void SetObjectScenePosition(Guid objectId, Vector3 position, HeightOptions heightOptions, User? user);
        void SetObjectSize(Guid objectId, float size, User? user);
        void SetObjectState(Guid objectId, string stateId, User? user);
        void SetObjectViewDistance(Guid objectId, float viewDistance, User? user);
    }
}
