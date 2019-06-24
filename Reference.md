#### _Related Links_
* [Platform Overview](https://github.com/SpheroidUniverse/Spheroid.AR.Server)
* [Quickstart](https://github.com/SpheroidUniverse/Spheroid.AR.Server.DemoCoinQuest)
* [NuGet Packages](https://www.nuget.org/profiles/SpheroidUniverse)<br><br>

# API Reference
<br>

## ARServer – _abstract class_

* __OnException__ (Exception __exception__) – _virtual method_

_AR-object events:_
* __OnObjectClick__ ([User](#user--struct) __user__, Guid __objectId__) – _virtual method_

* __OnObjectModel__ ([User](#user--struct) __user__, Guid __objectId__, [AssetSource](#AssetSource--enum) __modelSource__, Guid __modelId__) – _virtual method_
* __OnRenderObjects__ ([User](#user--struct) __user__, [Bounds](#bounds--struct) __bounds__) – _virtual method_

_AR-object methods:_
* __DeleteAllObjects__ ()

* __DeleteAllObjectsToUser__ ([User](#user--struct) __user__)
* __DeleteObject__ (Guid __objectId__)
* __DeleteObjectToUser__ ([User](#user--struct) __user__, Guid __objectId__)
* __PlayObjectAnimation__ (Guid __objectId__, string __animationId__ \[, string stateId \] )
* __PlayObjectAnimationToUser__ ([User](#user--struct) __user__, Guid __objectId__, string __animationId__ \[, string stateId \] )
* __PlayObjectAnimationAndDelete__ (Guid __objectId__, string __animationId__)
* __PlayObjectAnimationAndDeleteToUser__ ([User](#user--struct) __user__, Guid __objectId__, string __animationId__)
* __RenderObject__ (Guid __objectId__, [Model](#model--struct) __model__ \[, [LatLng](#latlng--struct) geoLocation, float geoHeightValue, [Vector3](#vector3--struct) scenePosition, [HeightRelativity](#heightrelativity--enum) heightRelativity, [HeightAlignment](#heightalignment--enum) heightAlignment, [Vector3](#vector3--struct) rotation, float rotationY, bool isMirrored, bool yAlwaysFollowUser, float size, float scale, string stateId, float viewDistance \] )
* __RenderObjectToUser__ ([User](#user--struct) __user__, Guid __objectId__, [Model](#model--struct) __model__ \[, [LatLng](#latlng--struct) geoLocation, float geoHeightValue, [Vector3](#vector3--struct) scenePosition, [HeightRelativity](#heightrelativity--enum) heightRelativity, [HeightAlignment](#heightalignment--enum) heightAlignment, [Vector3](#vector3--struct) rotation, float rotationY, bool isMirrored, bool yAlwaysFollowUser, float size, float scale, string stateId, float viewDistance \] )
* __SetObjectGeoPosition__ (Guid __objectId__, [LatLng](#latlng--struct) __location__ \[, float heightValue, [HeightRelativity](#heightrelativity--enum) heightRelativity, [HeightAlignment](#heightalignment--enum) heightAlignment \] )
* __SetObjectGeoPositionToUser__ ([User](#user--struct) __user__, Guid __objectId__, [LatLng](#latlng--struct) __location__ \[, float heightValue, [HeightRelativity](#heightrelativity--enum) heightRelativity, [HeightAlignment](#heightalignment--enum) heightAlignment \] )
* __SetObjectModel__ (Guid __objectId__, [Model](#model--struct) __model__)
* __SetObjectModelToUser__ ([User](#user--struct) __user__, Guid __objectId__, [Model](#model--struct) __model__)
* __SetObjectOnClickPlayAnimation__ (Guid __objectId__, string __animationId__ \[, string stateId \] )
* __SetObjectOnClickPlayAnimationToUser__ ([User](#user--struct) __user__, Guid __objectId__, string __animationId__ \[, string stateId \] )
* __SetObjectRotation__ (Guid __objectId__, [Vector3](#vector3--struct) __rotation__ \[, bool isMirrored, bool yAlwaysFollowUser \] )
* __SetObjectRotation__ (Guid __objectId__, float __rotationY__ \[, bool isMirrored, bool yAlwaysFollowUser \] )
* __SetObjectRotationToUser__ ([User](#user--struct) __user__, Guid __objectId__, [Vector3](#vector3--struct) __rotation__ \[, bool isMirrored, bool yAlwaysFollowUser \] )
* __SetObjectRotationToUser__ ([User](#user--struct) __user__, Guid __objectId__, float __rotationY__ \[, bool isMirrored, bool yAlwaysFollowUser \] )
* __SetObjectScale__ (Guid __objectId__, float __scale__)
* __SetObjectScaleToUser__ ([User](#user--struct) __user__, Guid __objectId__, float __scale__)
* __SetObjectScenePosition__ (Guid __objectId__, [Vector3](#vector3--struct) __position__ \[, [HeightRelativity](#heightrelativity--enum) heightRelativity, [HeightAlignment](#heightalignment--enum) heightAlignment \] )
* __SetObjectScenePositionToUser__ ([User](#user--struct) __user__, Guid __objectId__, [Vector3](#vector3--struct) __position__ \[, [HeightRelativity](#heightrelativity--enum) heightRelativity, [HeightAlignment](#heightalignment--enum) heightAlignment \] )
* __SetObjectSize__ (Guid __objectId__, float __size__)
* __SetObjectSizeToUser__ ([User](#user--struct) __user__, Guid __objectId__, float __size__)
* __SetObjectState__ (Guid __objectId__, string __stateId__)
* __SetObjectStateToUser__ ([User](#user--struct) __user__, Guid __objectId__, string __stateId__)
* __SetObjectViewDistance__ (Guid __objectId__, float __viewDistance__)
* __SetObjectViewDistanceToUser__ ([User](#user--struct) __user__, Guid __objectId__, float __viewDistance__)

_User events:_
* __OnUserCameraPosition__ ([User](#user--struct) __user__, [Vector3](#vector3--struct) __position__, [Vector3](#vector3--struct) __rotation__) – _virtual method_

* __OnUserLayer__ ([User](#user--struct) __user__, Guid __layerId__) – _virtual method_
* __OnUserLocation__ ([User](#user--struct) __user__, [LatLng](#latlng--struct) __location__) – _virtual method_
* __OnUserOffline__ ([User](#user--struct) __user__) – _virtual method_
* __OnUserOnline__ ([User](#user--struct) __user__) – _virtual method_
        
_User methods:_
* __GetUsers__ () – _returns IEnumerable\<[IUserData](#iuserdata--interface)\>_

* __SetStatusToUser__ ([User](#user--struct) __user__, string __text__ \[, [Image](#image--struct) icon \] )
* __TryGetUserData__ ([User](#user--struct) __user__, out [IUserData](#iuserdata--interface) __userData__) – _returns bool_
<br>

## AssetSource – _enum_
* Library
* Server
<br>

## Bounds – _struct_
* __Southwest__ – _[LatLng](#latlng--struct) property_
* __Northeast__ – _[LatLng](#latlng--struct) property_
* __Intersects__ ([LatLng](#latlng--struct) __location__) – _bool extension method_
<br>

## Height – _struct_
* __Value__ – _float property_
* __Options__ – _[HeightOptions](#heightoptions--struct) property_
* __Relativity__ – _[HeightRelativity](#heightrelativity--enum) property_
* __Alignment__ – _[HeightAlignment](#heightalignment--enum) property_
* __IsDefaultHeightValue__ – _bool property_
<br>

## HeightAlignment – _enum_
* Center
* Top
* Bottom
<br>

## HeightRelativity – _enum_
* Scene
* Floor
<br>

## HeightOptions – _struct_
* __Relativity__ – _[HeightRelativity](#heightrelativity--enum) property_
* __Alignment__ – _[HeightAlignment](#heightalignment--enum) property_
* __IsDefaultHeightValue__ – _bool property_
<br>

## Image – _struct_
* __Source__ – _[AssetSource](#assetsource--enum) property_
* __ImageId__ – _Guid property_
<br>

## IUserData – _interface_
* __SessionId__ – _Guid property_
* __UserId__ – _Guid? property_
* __IsOnline__ – _bool property_
* __Location__ – _[LatLng](#latlng--struct)? property_
* __LayerId__ — _Guid? property_
* __UserIdOrSessionId__ () – _Guid extension method_
* __IsAnonymous__ () – _bool extension method_
<br>

## LatLng – _struct_
* __Lat__ – _double property_
* __Lng__ – _double property_
<br>

## Model – _struct_
* __Source__ – _[AssetSource](#assetsource--enum) property_
* __ModelId__ – _Guid property_
<br>

## ObjectRotationOptions – _enum_
* IsMirrored
* YAlwaysFollowUser
<br>

## User – _struct_
* __SessionId__ – _Guid property_
* __UserId__ – _Guid? property_
* __UserIdOrSessionId__ () – _Guid extension method_
* __IsAnonymous__ () – _bool extension method_
<br>

## Vector3 – _struct_
* __X__ – _float property_
* __Y__ – _float property_
* __Z__ – _float property_
