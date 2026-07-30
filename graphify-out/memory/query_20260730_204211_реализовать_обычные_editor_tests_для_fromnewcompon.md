---
type: "query"
date: "2026-07-30T20:42:11.296832+00:00"
question: "Реализовать обычные editor tests для FromNewComponentOnRoot"
contributor: "graphify"
outcome: "useful"
source_nodes: ["Binding", "Context", "Container", "InstanceGetterFromNewComponentOnRoot"]
---

# Q: Реализовать обычные editor tests для FromNewComponentOnRoot

## Answer

Expanded from original query via vocab: [binding, component, context, container, create, entry, factory, game, inject, instance, lazy, new, non, object, options, resolve, root, scene, test, transient, cached]. Добавлен отдельный editor test suite для обычных bindings: fluent surfaces, validation, GameObjectContext и SceneContext roots, CreateOptions ignored, owner context traversal, errors, scopes, NonLazy prewarm и entry point.

## Outcome

- Signal: useful

## Source Nodes

- Binding
- Context
- Container
- InstanceGetterFromNewComponentOnRoot