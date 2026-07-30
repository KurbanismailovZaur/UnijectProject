---
type: "query"
date: "2026-07-30T16:51:58.356548+00:00"
question: "Теперь я хочу сделать метод FromComponentInChildren, который рекурсивно ищет компонент на том игровом объекте в который происходит внедрение и на его детях."
contributor: "graphify"
outcome: "useful"
source_nodes: ["Binding", "Context", "Uniject.InstanceGetters", "ContainerResolveFromComponentOnConsumerTests"]
---

# Q: Теперь я хочу сделать метод FromComponentInChildren, который рекурсивно ищет компонент на том игровом объекте в который происходит внедрение и на его детях.

## Answer

Expanded from original query via graph vocab: [binding, child, children, component, consumer, context, getter, hierarchy, inject, method, transform]. Реализован FromComponentInChildren на generic, non-generic и To type-builders. Getter валидирует interface или Component, требует живой MonoBehaviour consumer и выполняет детерминированный preorder DFS от consumer по физическому subtree с inactive-объектами и без границ GameObjectContext. Он возвращает первый существующий компонент, не создает и не внедряет его повторно. Добавлены 27 editor-тестов для API, типов, порядка поиска, inactive, пересечения контекста, ошибок, scopes, inherited binding и отсутствия повторного Inject. Статические проверки и независимый review прошли; Unity tests и build намеренно не запускались.

## Outcome

- Signal: useful

## Source Nodes

- Binding
- Context
- Uniject.InstanceGetters
- ContainerResolveFromComponentOnConsumerTests