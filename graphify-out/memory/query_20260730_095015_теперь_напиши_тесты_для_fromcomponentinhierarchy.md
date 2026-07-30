---
type: "query"
date: "2026-07-30T09:50:15.806334+00:00"
question: "Теперь напиши тесты для FromComponentInHierarchy"
contributor: "graphify"
outcome: "useful"
source_nodes: ["ContextTestUtility", "Container", "Context", "Factory"]
---

# Q: Теперь напиши тесты для FromComponentInHierarchy

## Answer

Expanded via graph vocabulary: [test, tests, editor, context, component, container, factory, cached, hierarchy, destroy, utility]. Added separate Editor test suites for regular bindings and ordinary factories. Coverage includes generic/non-generic/interface/abstract contracts, local/parent/grandparent lookup, logical descendant exclusion, GameObjectContext and SceneContext roots, external ParentTransform, inactive/preorder behavior, missing/destroyed/unsupported/cyclic contexts, transient/cached/NonLazy/entry-point semantics, no reinjection, contextless intermediate containers, and factory re-search. Added Unity meta files. Static diff checks passed; tests and builds were intentionally not run.

## Outcome

- Signal: useful

## Source Nodes

- ContextTestUtility
- Container
- Context
- Factory