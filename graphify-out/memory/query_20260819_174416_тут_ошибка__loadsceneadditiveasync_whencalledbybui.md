---
type: "query"
date: "2026-08-19T17:44:16.247451+00:00"
question: "Тут ошибка: LoadSceneAdditiveAsync_WhenCalledByBuildIndex_InitializesExpectedSceneContext — No binding found for SceneLoader"
contributor: "graphify"
outcome: "useful"
source_nodes: ["SceneLoader", "SceneLoaderTests", "SceneLoaderInstaller", "Container"]
---

# Q: Тут ошибка: LoadSceneAdditiveAsync_WhenCalledByBuildIndex_InitializesExpectedSceneContext — No binding found for SceneLoader

## Answer

Expanded from original query via graph vocab: [scene, loader, load, additive, async, build, index, initialize, context, binding, container, resolve]. The test creates a bare Container and resolves SceneLoader without binding it. Commit 4faeca7 moved that binding from Container to SceneLoaderInstaller but did not update both runtime tests. Add Bind<SceneLoader>().AsCached() in both test setups. A second build-index bug remains: GetScenePathByBuildIndex returns a path while the callback compares it with scene.name; restore Path.GetFileNameWithoutExtension(path).

## Outcome

- Signal: useful

## Source Nodes

- SceneLoader
- SceneLoaderTests
- SceneLoaderInstaller
- Container