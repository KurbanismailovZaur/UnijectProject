---
type: "query"
date: "2026-07-30T20:36:40.635633+00:00"
question: "Реализовать factory editor tests для FromNewComponentOnRoot"
contributor: "graphify"
outcome: "useful"
source_nodes: ["ContainerFactoryFromNewComponentOnTests", "ContainerFactoryTestFixture", "Factory", "Context", "Container"]
---

# Q: Реализовать factory editor tests для FromNewComponentOnRoot

## Answer

Expanded from original query via graph vocab: [factory, component, new, root, context, binding, create, inject, container, parent, owner, cached, transient, result]. Added five isolated factory tests covering concrete component creation and injection, interface-to-concrete mapping, cached factory identity with a new result on every Create, inherited binding ownership selecting the parent Context GameObject, and the missing-Context error. Used ContainerFactoryTestFixture, ContextTestUtility, Factory, Context, and Container behavior as verified sources.

## Outcome

- Signal: useful

## Source Nodes

- ContainerFactoryFromNewComponentOnTests
- ContainerFactoryTestFixture
- Factory
- Context
- Container