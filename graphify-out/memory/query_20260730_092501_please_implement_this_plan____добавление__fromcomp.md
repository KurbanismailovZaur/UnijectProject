---
type: "query"
date: "2026-07-30T09:25:01.094000+00:00"
question: "PLEASE IMPLEMENT THIS PLAN:\n# Добавление `FromComponentInHierarchy`\n\n## Кратко\n\nДобавить source, который ищет существующий компонент начиная с контекста-владельца binding, а затем поднимается по логической цепочке родительских контейнеров. При поиске каждый контекст исключает поддеревья всех своих логических контекстов-потомков.\n\nКомпонент не создаётся и не получает повторный `Inject`.\n\n## API\n\n- Добавить `BindingToTypeAsBuilder FromComponentInHierarchy()` в generic, non-generic и `.To(...)` builders.\n- Добавить аналогичный source для обычного `Factory<TResult>`.\n- Параметризованные factory и pools не менять.\n- Разрешать interface, concrete и abstract `Component` через `TypeValidator.TypeIsInterfaceOrComponent`; обычные классы отклонять при конфигурации.\n- Для runtime-getter добавить Unity `.meta`.\n\n## Поиск и границы контекстов\n\n- Создать `InstanceGetterFromComponentInHierarchy`.\n- Начинать с ближайшего живого `Context` в цепочке `context.Container`.\n- Добавить в `Container` внутренние read-only helpers для безопасного подъёма, проверки логического потомка и обнаружения циклов.\n- Искать preorder с inactive-объектами в `GameObjectContext`, `SceneContext` и `ParentTransformForGameObjects`.\n- Исключать поддеревья логических контекстов-потомков, но не физически вложенные посторонние Context.\n- Внешний `ParentTransformForGameObjects` дочернего контекста не считать его закрытой областью.\n- Использовать `GetComponent(concreteType)` и множество посещённых Transform.\n\n## Scope и ошибки\n\n- Сохранить transient, cached, NonLazy, entry point и factory-семантику.\n- Не применять `CreateOptions` и не вызывать `Container.Inject`.\n- Бросать `InvalidOperationException` при отсутствии Context/компонента, уничтоженном/неподдерживаемом Context и цикле контейнеров.\n- Уничтоженный `ParentTransformForGameObjects` пропускать.\n\n## Проверка и ограничения\n\n- Тестовые файлы не добавлять и Unity-тесты не запускать; выполнить только статическую проверку итогового diff.\n- Документацию, версию пакета и `InjectContext` не менять."
contributor: "graphify"
outcome: "useful"
source_nodes: ["Container", "Context", "Binding", "Factory"]
---

# Q: PLEASE IMPLEMENT THIS PLAN:
# Добавление `FromComponentInHierarchy`

## Кратко

Добавить source, который ищет существующий компонент начиная с контекста-владельца binding, а затем поднимается по логической цепочке родительских контейнеров. При поиске каждый контекст исключает поддеревья всех своих логических контекстов-потомков.

Компонент не создаётся и не получает повторный `Inject`.

## API

- Добавить `BindingToTypeAsBuilder FromComponentInHierarchy()` в generic, non-generic и `.To(...)` builders.
- Добавить аналогичный source для обычного `Factory<TResult>`.
- Параметризованные factory и pools не менять.
- Разрешать interface, concrete и abstract `Component` через `TypeValidator.TypeIsInterfaceOrComponent`; обычные классы отклонять при конфигурации.
- Для runtime-getter добавить Unity `.meta`.

## Поиск и границы контекстов

- Создать `InstanceGetterFromComponentInHierarchy`.
- Начинать с ближайшего живого `Context` в цепочке `context.Container`.
- Добавить в `Container` внутренние read-only helpers для безопасного подъёма, проверки логического потомка и обнаружения циклов.
- Искать preorder с inactive-объектами в `GameObjectContext`, `SceneContext` и `ParentTransformForGameObjects`.
- Исключать поддеревья логических контекстов-потомков, но не физически вложенные посторонние Context.
- Внешний `ParentTransformForGameObjects` дочернего контекста не считать его закрытой областью.
- Использовать `GetComponent(concreteType)` и множество посещённых Transform.

## Scope и ошибки

- Сохранить transient, cached, NonLazy, entry point и factory-семантику.
- Не применять `CreateOptions` и не вызывать `Container.Inject`.
- Бросать `InvalidOperationException` при отсутствии Context/компонента, уничтоженном/неподдерживаемом Context и цикле контейнеров.
- Уничтоженный `ParentTransformForGameObjects` пропускать.

## Проверка и ограничения

- Тестовые файлы не добавлять и Unity-тесты не запускать; выполнить только статическую проверку итогового diff.
- Документацию, версию пакета и `InjectContext` не менять.

## Answer

Expanded from original query via graph vocabulary: [context, container, binding, component, hierarchy, parent, transform, scene, factory, getter, resolve]. The graph linked Binding and Resolve to Container, Context to GameObjectContext/SceneContext, and Factory to InstanceGetters. Implementation added complete parent-chain validation, strict logical-descendant checks, preorder hierarchy search with child-context pruning, ordinary type-builder and Factory<TResult> wiring, and no reinjection or object creation. Static diff review passed; tests and build were intentionally not run.

## Outcome

- Signal: useful

## Source Nodes

- Container
- Context
- Binding
- Factory