# SkinnedMeshCombiner
Combine a mass of skinned mesh to speed up rendering.

## 342 skinned meshes on Mi 4

Normal skinned meshes, **342 draw calls**, ≈40ms  
<img src="https://raw.githubusercontent.com/HRGame/SkinnedMeshCombiner/master/Profile/Profiling342SeperateSkinnedMeshes.png" width="640" />

Combined skinned meshes with our [PlanarShaodws](https://github.com/HRGame/PlanarShadows) integrated, **18 draw calls** (combined skinned meshes) + 18 draw calls (planar shadows), ≈22ms, **2X faster** with realtime shaodws!  
<img src="https://raw.githubusercontent.com/HRGame/SkinnedMeshCombiner/master/Profile/Profiling342CombinedSkinnedMeshesWithPlanarShadows.png" width="640" />

## 432 skinned meshes on Mi 4

Our previous baked aniation cache, **432 draw calls**, no skin animation updates, >40ms  
<img src="https://raw.githubusercontent.com/HRGame/SkinnedMeshCombiner/master/Profile/Profiling432MeshAnimationCache.png" width="640" />

Combined skinned meshes, **18 draw calls**, ≈21ms, **2X faster**!  
<img src="https://raw.githubusercontent.com/HRGame/SkinnedMeshCombiner/master/Profile/Profiling432CombinedSkinnedMeshes.png" width="640" />
