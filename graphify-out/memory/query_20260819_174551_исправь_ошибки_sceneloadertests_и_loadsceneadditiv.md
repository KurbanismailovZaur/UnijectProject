---
type: "query"
date: "2026-08-19T17:45:51.215405+00:00"
question: "Исправь ошибки SceneLoaderTests и LoadSceneAdditiveAsync по build index"
contributor: "graphify"
outcome: "useful"
source_nodes: ["SceneLoader", "SceneLoaderTests", "SceneLoaderInstaller", "Container"]
---

# Q: Исправь ошибки SceneLoaderTests и LoadSceneAdditiveAsync по build index

## Answer

Expanded from original query via graph vocab: [scene, loader, load, additive, async, build, index, initialize, context, binding, container, resolve]. Added Bind<SceneLoader>().AsCached() to both SceneLoader runtime test setups. Updated the build-index overload to convert SceneUtility.GetScenePathByBuildIndex output with Path.GetFileNameWithoutExtension before delegating to the name overload.

## Outcome

- Signal: useful

## Source Nodes

- SceneLoader
- SceneLoaderTests
- SceneLoaderInstaller
- Container