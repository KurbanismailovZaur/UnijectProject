---
type: "query"
date: "2026-07-30T16:38:30.310693+00:00"
question: "Теперь я хочу сделать метод FromComponentInChildren, который рекурсивно ищет компонент на том игровом объекте в который происходит внедрение и на его детях."
contributor: "graphify"
outcome: "useful"
source_nodes: ["Binding", "Context", "ContainerResolveFromComponentOnConsumerTests", "ContainerResolveFromComponentInHierarchyTests"]
---

# Q: Теперь я хочу сделать метод FromComponentInChildren, который рекурсивно ищет компонент на том игровом объекте в который происходит внедрение и на его детях.

## Answer

Expanded via graph vocabulary: [child, children, component, consumer, transform, inject, method, binding, getter, mono, context, hierarchy]. FromComponentInChildren should mirror FromComponentInParents for ordinary bindings, live MonoBehaviour consumer, validation, scopes, errors, and no reinjection. Recommended traversal is physical preorder DFS from consumer through descendants, including inactive objects. The material unresolved choice is whether nested GameObjectContext subtrees remain visible; physical consumer-centric semantics recommends crossing them, unlike context-centric FromComponentInHierarchy.

## Outcome

- Signal: useful

## Source Nodes

- Binding
- Context
- ContainerResolveFromComponentOnConsumerTests
- ContainerResolveFromComponentInHierarchyTests