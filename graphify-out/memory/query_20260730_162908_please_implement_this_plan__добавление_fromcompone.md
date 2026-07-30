---
type: "query"
date: "2026-07-30T16:29:08.446957+00:00"
question: "PLEASE IMPLEMENT THIS PLAN: Добавление FromComponentInParents"
contributor: "graphify"
outcome: "useful"
source_nodes: ["Binding", "Container", "InjectContext", "ContainerResolveFromComponentOnConsumerTests"]
---

# Q: PLEASE IMPLEMENT THIS PLAN: Добавление FromComponentInParents

## Answer

Expanded from the approved request via graph vocabulary: [component, consumer, parent, parents, transform, inject, method, binding, getter, mono, container, test]. Implemented FromComponentInParents on generic, non-generic, and To type-binding surfaces; added a consumer-based getter that walks the physical Transform parent chain including inactive objects; added Unity meta files and 27 Editor tests covering contracts, precedence, context-boundary crossing, errors, scopes, inherited bindings, and no reinjection. Container, InjectContext, factories, pools, docs, and version were unchanged. Static diff, whitespace, GUID, and independent reviews passed; Unity tests and builds were intentionally not run.

## Outcome

- Signal: useful

## Source Nodes

- Binding
- Container
- InjectContext
- ContainerResolveFromComponentOnConsumerTests