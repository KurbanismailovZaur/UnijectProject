---
type: "query"
date: "2026-07-30T20:44:41.976807+00:00"
question: "Теперь я хочу добавить FromNewComponentOnRoot, который создает новый компонент на игровом объекте текущего контекста."
contributor: "graphify"
outcome: "useful"
source_nodes: ["Binding", "Container", "Context", "Factory", "GameObjectContext", "Uniject.InstanceGetters"]
---

# Q: Теперь я хочу добавить FromNewComponentOnRoot, который создает новый компонент на игровом объекте текущего контекста.

## Answer

Expanded from original query via graph vocab: [binding, component, container, context, factory, game, getter, hierarchy, new, object, root, scene]. Реализован FromNewComponentOnRoot в generic, non-generic, To type-builders и обычном Factory<TResult>. Getter выбирает ближайший живой GameObjectContext или SceneContext в цепочке контейнера-владельца binding, отклоняет destroyed и unsupported Context, добавляет новый component на Context.gameObject и внедряет его через owner container. Parameterized factories, pools, Container и InjectContext не менялись. Добавлены 25 regular и 5 factory NUnit cases; статические проверки и независимые reviews прошли, Unity tests и build намеренно не запускались.

## Outcome

- Signal: useful

## Source Nodes

- Binding
- Container
- Context
- Factory
- GameObjectContext
- Uniject.InstanceGetters