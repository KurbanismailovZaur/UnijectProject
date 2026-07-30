---
type: "query"
date: "2026-07-30T16:51:14.972880+00:00"
question: "Read-only финальный review текущего package diff для FromComponentInChildren: runtime getter, три builder API, scope/error semantics и compile risks"
contributor: "graphify"
outcome: "useful"
source_nodes: ["InstanceGetterFromComponentOnConsumer", "Binding", "InjectContext", "Scope"]
---

# Q: Read-only финальный review текущего package diff для FromComponentInChildren: runtime getter, три builder API, scope/error semantics и compile risks

## Answer

Expanded from original query via graph vocab: [children, component, consumer, getter, binding, builder, context, instance, inject, mono, scope, type]. Getter performs deterministic preorder DFS from the live MonoBehaviour consumer, includes inactive descendants, crosses context boundaries, validates interface-or-Component contracts, does not create or inject components, and reports missing/invalid-consumer errors consistently. Generic, non-generic, and To(...) builders expose the source and preserve normal transient/cached/non-lazy semantics. No concrete runtime or compile-risk findings.

## Outcome

- Signal: useful

## Source Nodes

- InstanceGetterFromComponentOnConsumer
- Binding
- InjectContext
- Scope