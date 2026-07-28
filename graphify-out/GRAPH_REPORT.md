# Graph Report - .  (2026-07-28)

## Corpus Check
- cluster-only mode — file stats not available

## Summary
- 1678 nodes · 3483 edges · 104 communities (86 shown, 18 thin omitted)
- Extraction: 95% EXTRACTED · 5% INFERRED · 0% AMBIGUOUS · INFERRED: 189 edges (avg confidence: 0.8)
- Token cost: 0 input · 0 output

## Graph Freshness
- Built from commit: `425036bf`
- Run `git rev-parse HEAD` and compare to check if the graph is stale.
- Run `graphify update .` after code changes (no API cost).

## Community Hubs (Navigation)
- ContainerInjectContextTests
- CollectionPool
- ContainerResolveTestFixture
- ContainerPoolTests
- ContainerEntryPointsTests
- Uniject.Tests
- .Bind
- ContainerResolveFromSubcontainerTests
- ContainerFactoryTestFixture
- TickableManagerTests
- OrderedSet
- Uniject.Bindings
- InstanceGetter
- .Configure
- Uniject.Lifecycle
- BindingToTypeNonLazyBuilder
- BindingToPoolWithInitialSizeBuilder
- BindingToSubcontainerWithGameObjectNameBuilder
- BindingToPoolAsBuilder
- BindingToPoolWithMaxSizeBuilder
- ContainerTryResolveTests
- BindingToFactoryAsBuilder
- BindingToPoolExpandTypeBuilder
- Class
- ContainerNonLazyTests
- BindingToTypeFromBuilder
- BindingToTypeWithGameObjectNameBuilder
- BindingToPoolWithoutGameObjectActivationBuilder
- Container
- BindingToPoolToBuilder
- Pool
- BindingToSubcontainerAsBuilder
- ReflectionCacheTestFixture
- Uniject.Reflection
- Product
- Inject
- InstanceGetterWithParameter
- SceneLoaderTests
- BindingToFactoryWithParameterAsBuilder
- ContainerResolveFromNewContextPrefabSubcontainerTests
- Uniject.Bindings.Factories
- .Instantiate
- SubcontainerGetter
- IInstaller
- MonoInstaller
- ContainerResolveFromNewContextSubcontainerTests
- ContainerCircularDependencyTests
- BindingToTypeAsBuilder
- BindingToTypeAsEntryPointBuilder
- BindingToFactoryToBuilder
- TickableManager
- IInterface
- ContextLifecycleTests.cs
- BindingToFactoryWithParameterToBuilder
- Context
- ContainerParameterizedFactoryFromCustomFactoryTests
- ContainerParameterizedFactoryFromNewComponentOnNewPrefabTests
- ContainerResolveFromContextOnNewPrefabTests
- BindingToFactoryWithParameter
- .BindInstance
- .GetMethodInjectionData
- package.json
- ILateTickable
- ITickable
- ContainerFactoryTests
- ContainerParameterizedFactoryFromComponentInNewPrefabTests
- .Resolve
- .ResolveWithContext
- IObjectBuilder
- .GetConstructorInjectionData
- MonoBehaviour
- Pool
- BindingToType
- ContainerFactoryFromMethodTests
- GameObjectContext
- ContainerFactoryFromCustomFactoryTests
- ContainerParameterizedFactoryFromMethodTests
- .LoadSceneAdditiveAsync
- .GetInstance
- InstanceGetterFromInstance
- Binding
- BindingToPool
- Type
- InstanceGetterFromMethod
- InstanceGetterFromNewComponentOn.cs
- ContainerParameterizedFactoryTests
- MethodInjectionData
- InjectAttribute.cs
- .GetInstance
- SubcontainerGetterByNewContextFromMethodOnNewPrefab
- ContainerFactoryFromNewComponentOnNewGameObjectTests
- ConstructorInjectionData
- .FromMethod
- IPool
- SubcontainerGetterByNewContextFromMethodOnNewGameObject
- ContainerFactoryFromComponentInNewPrefabTests
- ContainerFactoryFromNewComponentOnNewPrefabTests
- AbstractClass.cs
- ContextTestUtility
- ReflectionCache
- ContainerFactoryFromResolveTests
- ScriptWithEntryPoint
- .TearDown
- .FromMethod

## God Nodes (most connected - your core abstractions)
1. `BindingToPoolAsBuilder` - 53 edges
2. `Uniject.Tests` - 52 edges
3. `Uniject.Tests.Fixtures` - 50 edges
4. `ContainerInjectContextTests` - 47 edges
5. `Container` - 44 edges
6. `ContainerFactoryTestFixture` - 40 edges
7. `ContainerPoolTests` - 39 edges
8. `Uniject.Bindings` - 36 edges
9. `Uniject.InstanceGetters` - 36 edges
10. `Uniject` - 34 edges

## Surprising Connections (you probably didn't know these)
- `CountingPrefabInstaller` --implements--> `IInstaller`  [EXTRACTED]
  Tests/Editor/ContainerResolveFromNewContextPrefabSubcontainerTests.cs → Runtime/Installers/IInstaller.cs
- `GenericCountingPrefabInstaller` --implements--> `IInstaller`  [EXTRACTED]
  Tests/Editor/ContainerResolveFromNewContextPrefabSubcontainerTests.cs → Runtime/Installers/IInstaller.cs
- `CountingInstaller` --implements--> `IInstaller`  [EXTRACTED]
  Tests/Editor/ContainerResolveFromSubcontainerTests.cs → Runtime/Installers/IInstaller.cs
- `ParentDependencyInstaller` --implements--> `IInstaller`  [EXTRACTED]
  Tests/Editor/ContainerResolveFromSubcontainerTests.cs → Runtime/Installers/IInstaller.cs
- `ScriptInstaller` --implements--> `IInstaller`  [EXTRACTED]
  Tests/Editor/ContainerResolveFromSubcontainerTests.cs → Runtime/Installers/IInstaller.cs

## Import Cycles
- None detected.

## Communities (104 total, 18 thin omitted)

### Community 0 - "ContainerInjectContextTests"
Cohesion: 0.06
Nodes (30): BaseMethodConsumer, InnerConsumer, IService, IEnumerable, Service, Action, Container, Func (+22 more)

### Community 1 - "CollectionPool"
Cohesion: 0.06
Nodes (22): BucketKey, CollectionKind, CollectionPool, IEqualityComparer, IEquatable, Queue, bool, Dictionary (+14 more)

### Community 2 - "ContainerResolveTestFixture"
Cohesion: 0.05
Nodes (19): Test, ContainerResolveFromComponentInNewPrefabTests, Test, ContainerResolveFromConstructorTests, Test, ContainerResolveFromMethodTests, Test, ContainerResolveFromNewComponentOnNewGameObjectTests (+11 more)

### Community 3 - "ContainerPoolTests"
Cohesion: 0.07
Nodes (12): EquatableProduct, ProductPool, Test, ContainerPoolFromNewComponentOnTests, ContainerPoolTestFixture, EquatableProduct, EquatableProductPool, Product (+4 more)

### Community 4 - "ContainerEntryPointsTests"
Cohesion: 0.07
Nodes (21): IDisposable, IEntryPoint, Container, Test, ContainerBuildTests, EntryPointClass, NonLazyClass, Container (+13 more)

### Community 5 - "Uniject.Tests"
Cohesion: 0.10
Nodes (5): Uniject.Tests.Fixtures, Uniject.Tests, Uniject.Attributes, Uniject, ClassWithPrivateConstructor

### Community 6 - ".Bind"
Cohesion: 0.09
Nodes (6): Test, ContainerBindingTests, Test, ContainerResolveFromInstanceTests, Test, ContainerResolveFromNewComponentOnTests

### Community 7 - "ContainerResolveFromSubcontainerTests"
Cohesion: 0.10
Nodes (10): Container, Test, ClassWithParentDependency, ContainerResolveFromSubcontainerTests, CountingInstaller, ParentDependencyInstaller, ScriptInstaller, StaticCountingInstaller (+2 more)

### Community 8 - "ContainerFactoryTestFixture"
Cohesion: 0.14
Nodes (27): Factory, IProduct, GameObject, Transform, ClassIProductFactory, ContainerFactoryTestFixture, CustomInjectableScriptWithParameterFactory, CustomScriptWithParameterFactory (+19 more)

### Community 9 - "TickableManagerTests"
Cohesion: 0.23
Nodes (4): List, Test, NotTickable, TickableManagerTests

### Community 10 - "OrderedSet"
Cohesion: 0.11
Nodes (11): Uniject.Collections, IReadOnlyCollection, HashSet, IEnumerator, List, OrderedSet, FixedTickable, LateTickable (+3 more)

### Community 11 - "Uniject.Bindings"
Cohesion: 0.11
Nodes (6): Uniject.Bindings.Pools, Uniject.Bindings, Uniject.InstanceGetters, Uniject.InstanceGetters.Factories, Uniject.SubcontainerGetters, InstanceGetterFromResolve

### Community 12 - "InstanceGetter"
Cohesion: 0.08
Nodes (20): string, Transform, CreateOptions, Component, InjectContext, Type, InstanceGetter, Component (+12 more)

### Community 13 - ".Configure"
Cohesion: 0.14
Nodes (5): Test, ContainerResolveGameObjectConfigurationTests, IEnumerable, MonoBehaviour, Transform

### Community 14 - "Uniject.Lifecycle"
Cohesion: 0.16
Nodes (8): Uniject.Exceptions, Uniject.Components, Uniject.Contexts, Uniject.Installers, Uniject.Lifecycle, Exception, NoBindingFoundException, ContextOnNewPrefabService

### Community 15 - "BindingToTypeNonLazyBuilder"
Cohesion: 0.18
Nodes (6): Container, BindingToTypeBuilder, BindingToTypeNonLazyBuilder, Type, BindingToBuilder, BindingToTypeToBuilder

### Community 16 - "BindingToPoolWithInitialSizeBuilder"
Cohesion: 0.16
Nodes (3): Component, GameObject, BindingToPoolWithInitialSizeBuilder

### Community 17 - "BindingToSubcontainerWithGameObjectNameBuilder"
Cohesion: 0.19
Nodes (7): Action, Container, GameObject, BindingToTypeByBuilder, Container, Transform, BindingToSubcontainerWithGameObjectNameBuilder

### Community 18 - "BindingToPoolAsBuilder"
Cohesion: 0.18
Nodes (7): BindingToPoolAsBuilder, Component, Container, Func, GameObject, InjectContext, BindingToPoolFromBuilder

### Community 19 - "BindingToPoolWithMaxSizeBuilder"
Cohesion: 0.14
Nodes (6): Component, Container, Func, GameObject, InjectContext, BindingToPoolWithMaxSizeBuilder

### Community 20 - "ContainerTryResolveTests"
Cohesion: 0.16
Nodes (7): resolved, Test, CircularA, CircularB, ClassWithMissingDependency, ContainerTryResolveTests, MissingDependency

### Community 21 - "BindingToFactoryAsBuilder"
Cohesion: 0.21
Nodes (7): BindingToFactoryAsBuilder, Component, Container, Func, GameObject, InjectContext, BindingToFactoryFromBuilder

### Community 22 - "BindingToPoolExpandTypeBuilder"
Cohesion: 0.14
Nodes (6): Component, Container, Func, GameObject, InjectContext, BindingToPoolExpandTypeBuilder

### Community 23 - "Class"
Cohesion: 0.14
Nodes (12): Inject, InjectableClass, Inject, int, List, ClassWithMultipleInjectMethods, InjectableClass, MultiDependencyInjectableClass (+4 more)

### Community 24 - "ContainerNonLazyTests"
Cohesion: 0.17
Nodes (11): List, Test, ContainerNonLazyTests, FailsOnFirstCreationClass, FirstNonLazyClass, LazyClass, NonLazyCachedClass, NonLazyOrder (+3 more)

### Community 25 - "BindingToTypeFromBuilder"
Cohesion: 0.15
Nodes (6): Component, Container, Func, GameObject, InjectContext, BindingToTypeFromBuilder

### Community 26 - "BindingToTypeWithGameObjectNameBuilder"
Cohesion: 0.20
Nodes (4): Component, GameObject, Transform, BindingToTypeWithGameObjectNameBuilder

### Community 27 - "BindingToPoolWithoutGameObjectActivationBuilder"
Cohesion: 0.13
Nodes (8): Container, BindingToPoolBuilder, Component, Container, Func, GameObject, InjectContext, BindingToPoolWithoutGameObjectActivationBuilder

### Community 28 - "Container"
Cohesion: 0.14
Nodes (9): context, parentTransform, Dictionary, List, Stack, Transform, Container, CustomFactory (+1 more)

### Community 29 - "BindingToPoolToBuilder"
Cohesion: 0.14
Nodes (6): Component, Container, Func, GameObject, InjectContext, BindingToPoolToBuilder

### Community 30 - "Pool"
Cohesion: 0.22
Nodes (7): ExpandType, Type, Factory, HashSet, List, Type, Pool

### Community 31 - "BindingToSubcontainerAsBuilder"
Cohesion: 0.16
Nodes (8): Scope, Container, BindingToSubcontainerAsBuilder, Container, Transform, BindingToSubcontainerUnderTransformBuilder, Container, InstanceGetterFromSubContainerResolve

### Community 32 - "ReflectionCacheTestFixture"
Cohesion: 0.13
Nodes (16): BaseTypeWithInjectMethod, MiddleTypeWithoutInjectMethod, DependencyA, DependencyB, DerivedFromMiddleTypeWithoutInjectMethod, DerivedTypeWithoutOwnInjectMethod, DerivedTypeWithOwnInjectMethod, MiddleTypeWithoutInjectMethod (+8 more)

### Community 33 - "Uniject.Reflection"
Cohesion: 0.15
Nodes (9): Uniject.Reflection, InjectContext, Type, InstanceGetterWithParameterFromComponentInNewPrefab, InjectContext, Type, InstanceGetterWithParameterFromNewComponentInNewPrefab, Type (+1 more)

### Community 34 - "Product"
Cohesion: 0.19
Nodes (10): CustomFactory, Product, ClassProductFactory, CustomProductFactory, CustomProductWithClassParameterFactory, InitializableCustomProductFactory, ProductFactory, DuplicateProductFactory (+2 more)

### Community 35 - "Inject"
Cohesion: 0.16
Nodes (9): DependencyA, DependencyB, Inject, BaseTypeWithInjectMethod, TypeWithInjectMethod, TypeWithMultipleInjectMethods, TypeWithoutInjectMethod, TypeWithPrivateInjectMethod (+1 more)

### Community 36 - "InstanceGetterWithParameter"
Cohesion: 0.12
Nodes (11): InstanceGetterBase, InjectContext, Type, InstanceGetterWithParameter, InjectContext, Type, InstanceGetterWithParameterFromFactory, Func (+3 more)

### Community 37 - "SceneLoaderTests"
Cohesion: 0.18
Nodes (9): IPostBuildCleanup, IPrebuildSetup, ParentDependency, Task, Container, string, Test, ParentDependency (+1 more)

### Community 38 - "BindingToFactoryWithParameterAsBuilder"
Cohesion: 0.21
Nodes (5): BindingToFactoryWithParameterAsBuilder, Container, Func, InjectContext, BindingToFactoryWithParameterFromBuilder

### Community 39 - "ContainerResolveFromNewContextPrefabSubcontainerTests"
Cohesion: 0.28
Nodes (4): IReadOnlyList, Test, ContainerResolveFromNewContextPrefabSubcontainerTests, TransientService

### Community 40 - "Uniject.Bindings.Factories"
Cohesion: 0.15
Nodes (6): Uniject.Bindings.Factories, InjectContext, Type, BindingToFactory, Container, BindingToFactoryBuilder

### Community 41 - ".Instantiate"
Cohesion: 0.24
Nodes (5): Component, GameObject, Test, ClassWithConstructorDependency, ContainerInstantiateTests

### Community 42 - "SubcontainerGetter"
Cohesion: 0.15
Nodes (11): Container, Transform, SubcontainerGetter, Container, GameObject, SubcontainerGetterByContextOnNewPrefab, Container, SubcontainerGetterByInstance (+3 more)

### Community 43 - "IInstaller"
Cohesion: 0.18
Nodes (9): Container, IInstaller, Container, SubcontainerGetterByInstaller, Container, SubcontainerGetterByNewContextFromInstallerOnNewGameObject, Container, GameObject (+1 more)

### Community 44 - "MonoInstaller"
Cohesion: 0.15
Nodes (9): Container, MonoInstaller, Container, SceneLoaderInstaller, Container, TickableManagerInstaller, Container, List (+1 more)

### Community 45 - "ContainerResolveFromNewContextSubcontainerTests"
Cohesion: 0.34
Nodes (4): IReadOnlyList, Test, ContainerResolveFromNewContextSubcontainerTests, TransientService

### Community 46 - "ContainerCircularDependencyTests"
Cohesion: 0.23
Nodes (8): IFromResolveCircularDependency, TestDelegate, Test, ConstructorCircularA, ConstructorCircularB, ContainerCircularDependencyTests, FromResolveCircularDependency, IFromResolveCircularDependency

### Community 47 - "BindingToTypeAsBuilder"
Cohesion: 0.24
Nodes (4): BindingToTypeAsBuilder, Container, Func, InjectContext

### Community 48 - "BindingToTypeAsEntryPointBuilder"
Cohesion: 0.21
Nodes (4): Container, BindingToTypeAsEntryPointBuilder, Transform, BindingToTypeUnderTransformBuilder

### Community 49 - "BindingToFactoryToBuilder"
Cohesion: 0.22
Nodes (3): Component, GameObject, BindingToFactoryToBuilder

### Community 50 - "TickableManager"
Cohesion: 0.19
Nodes (3): IFixedTickable, TickableManager, TestFixedTickable

### Community 51 - "IInterface"
Cohesion: 0.18
Nodes (9): Test, ContainerFactoryFromNewComponentOnTests, InterfaceResultFactory, CustomScriptWithInterfaceParameterFactory, InterfaceInterfaceFactory, InterfaceScriptFactory, ClassWithMultipleConstructorDependencies, ClassImplementedIInterface (+1 more)

### Community 52 - "ContextLifecycleTests.cs"
Cohesion: 0.19
Nodes (10): Action, Container, Inject, List, ChildContextNonLazyProbe, ContextInjectTarget, ContextLifecycleTestEvents, ContextLifecycleTestInstaller (+2 more)

### Community 53 - "BindingToFactoryWithParameterToBuilder"
Cohesion: 0.20
Nodes (4): Container, Func, InjectContext, BindingToFactoryWithParameterToBuilder

### Community 54 - "Context"
Cohesion: 0.24
Nodes (5): Container, List, Transform, Context, SceneContext

### Community 55 - "ContainerParameterizedFactoryFromCustomFactoryTests"
Cohesion: 0.24
Nodes (3): SetUp, Test, ContainerParameterizedFactoryFromCustomFactoryTests

### Community 57 - "ContainerResolveFromContextOnNewPrefabTests"
Cohesion: 0.38
Nodes (3): GameObject, Test, ContainerResolveFromContextOnNewPrefabTests

### Community 58 - "BindingToFactoryWithParameter"
Cohesion: 0.20
Nodes (6): Binding, InjectContext, Type, BindingToFactoryWithParameter, Container, BindingToFactoryWithParameterBuilder

### Community 59 - ".BindInstance"
Cohesion: 0.27
Nodes (4): SetUp, TearDown, Test, ContextLifecycleTests

### Community 61 - "package.json"
Cohesion: 0.20
Nodes (9): author, category, changelogUrl, description, displayName, documentationUrl, name, unity (+1 more)

### Community 62 - "ILateTickable"
Cohesion: 0.20
Nodes (3): ILateTickable, TestLateTickable, TestMultiTickable

### Community 63 - "ITickable"
Cohesion: 0.20
Nodes (4): ITickable, Action, TestTickable, ClassWithEntryPoint

### Community 66 - ".Resolve"
Cohesion: 0.39
Nodes (3): ParameterInfo, Type, InjectContext

### Community 67 - ".ResolveWithContext"
Cohesion: 0.22
Nodes (6): Container, InjectContext, Type, InstanceGetterBase, InjectContext, Type

### Community 68 - "IObjectBuilder"
Cohesion: 0.31
Nodes (5): Component, GameObject, IEnumerable, Type, IObjectBuilder

### Community 69 - ".GetConstructorInjectionData"
Cohesion: 0.44
Nodes (3): Type, Test, ReflectionCacheConstructorTests

### Community 70 - "MonoBehaviour"
Cohesion: 0.29
Nodes (5): MonoBehaviour, InjectTargets, CustomInterfaceScriptWithParameterFactory, AbstractScript, ScriptImplementedIInterface

### Community 71 - "Pool"
Cohesion: 0.25
Nodes (7): Pool, InterfacePool, PooledScriptPool, IEnumerator, ContainerPoolRuntimeTests, ScriptPool, UnityTest

### Community 72 - "BindingToType"
Cohesion: 0.36
Nodes (3): InjectContext, Transform, BindingToType

### Community 74 - "GameObjectContext"
Cohesion: 0.38
Nodes (5): GameObjectContext, Container, List, CountingPrefabInstaller, GenericCountingPrefabInstaller

### Community 75 - "ContainerFactoryFromCustomFactoryTests"
Cohesion: 0.33
Nodes (3): SetUp, Test, ContainerFactoryFromCustomFactoryTests

### Community 77 - ".LoadSceneAdditiveAsync"
Cohesion: 0.33
Nodes (4): Awaitable, LocalPhysicsMode, Action, SceneLoader

### Community 78 - ".GetInstance"
Cohesion: 0.33
Nodes (4): InstanceGetter, InjectContext, Type, InstanceGetterFromFactory

### Community 79 - "InstanceGetterFromInstance"
Cohesion: 0.33
Nodes (4): object, InjectContext, Type, InstanceGetterFromInstance

### Community 80 - "Binding"
Cohesion: 0.33
Nodes (4): Container, InjectContext, Type, Binding

### Community 81 - "BindingToPool"
Cohesion: 0.40
Nodes (3): InjectContext, Type, BindingToPool

### Community 83 - "InstanceGetterFromMethod"
Cohesion: 0.33
Nodes (4): Func, InjectContext, Type, InstanceGetterFromMethod

### Community 84 - "InstanceGetterFromNewComponentOn.cs"
Cohesion: 0.33
Nodes (4): GameObject, InjectContext, Type, InstanceGetterFromNewComponentOn

### Community 86 - "MethodInjectionData"
Cohesion: 0.40
Nodes (4): MethodInfo, bool, ParameterInfo, MethodInjectionData

### Community 87 - "InjectAttribute.cs"
Cohesion: 0.30
Nodes (3): PreserveAttribute, InjectAttribute, IProvider

### Community 88 - ".GetInstance"
Cohesion: 0.40
Nodes (3): InjectContext, Type, InstanceGetterFromConstructor

### Community 89 - "SubcontainerGetterByNewContextFromMethodOnNewPrefab"
Cohesion: 0.40
Nodes (4): Action, Container, GameObject, SubcontainerGetterByNewContextFromMethodOnNewPrefab

### Community 91 - "ConstructorInjectionData"
Cohesion: 0.50
Nodes (3): ConstructorInfo, ParameterInfo, ConstructorInjectionData

### Community 92 - ".FromMethod"
Cohesion: 0.50
Nodes (3): Container, Func, InjectContext

### Community 94 - "SubcontainerGetterByNewContextFromMethodOnNewGameObject"
Cohesion: 0.50
Nodes (3): Action, Container, SubcontainerGetterByNewContextFromMethodOnNewGameObject

### Community 103 - ".FromMethod"
Cohesion: 0.50
Nodes (3): Container, Func, InjectContext

## Knowledge Gaps
- **47 isolated node(s):** `CollectionKind`, `IProvider`, `NonLazyClass`, `ConstructorCircularA`, `ConstructorCircularB` (+42 more)
  These have ≤1 connection - possible missing edges or undocumented components.
- **18 thin communities (<3 nodes) omitted from report** — run `graphify query` to explore isolated nodes.

## Suggested Questions
_Questions this graph is uniquely positioned to answer:_

- **Why does `Container` connect `Container` to `ContainerInjectContextTests`, `ContainerEntryPointsTests`, `.Bind`, `OrderedSet`, `Uniject.Lifecycle`, `BindingToPoolWithInitialSizeBuilder`, `ContainerTryResolveTests`, `ContainerNonLazyTests`, `Uniject.Bindings.Factories`, `.Instantiate`, `ContainerCircularDependencyTests`, `BindingToFactoryWithParameterToBuilder`, `Context`, `BindingToFactoryWithParameter`, `.BindInstance`, `.Resolve`, `IObjectBuilder`, `BindingToType`, `.LoadSceneAdditiveAsync`, `Binding`, `Type`?**
  _High betweenness centrality (0.222) - this node is a cross-community bridge._
- **Why does `Uniject.Tests` connect `Uniject.Tests` to `CollectionPool`, `ContainerEntryPointsTests`, `SceneLoaderTests`, `ContainerFactoryFromMethodTests`, `Uniject.Bindings`, `Uniject.Lifecycle`, `ContextLifecycleTests.cs`?**
  _High betweenness centrality (0.178) - this node is a cross-community bridge._
- **Why does `Uniject.Bindings` connect `Uniject.Bindings` to `BindingToFactoryWithParameter`, `BindingToFactoryWithParameterAsBuilder`, `Uniject.Bindings.Factories`, `InstanceGetter`, `Uniject.Lifecycle`, `BindingToTypeNonLazyBuilder`, `BindingToTypeAsEntryPointBuilder`, `BindingToTypeAsBuilder`, `.GetInstance`, `InstanceGetterFromInstance`, `InstanceGetterFromMethod`, `InstanceGetterFromNewComponentOn.cs`, `.GetInstance`, `BindingToTypeWithGameObjectNameBuilder`, `BindingToPoolWithoutGameObjectActivationBuilder`, `BindingToSubcontainerAsBuilder`?**
  _High betweenness centrality (0.091) - this node is a cross-community bridge._
- **What connects `CollectionKind`, `IProvider`, `NonLazyClass` to the rest of the system?**
  _47 weakly-connected nodes found - possible documentation gaps or missing edges._
- **Should `ContainerInjectContextTests` be split into smaller, more focused modules?**
  _Cohesion score 0.056429463171036205 - nodes in this community are weakly interconnected._
- **Should `CollectionPool` be split into smaller, more focused modules?**
  _Cohesion score 0.06416275430359937 - nodes in this community are weakly interconnected._
- **Should `ContainerResolveTestFixture` be split into smaller, more focused modules?**
  _Cohesion score 0.05081967213114754 - nodes in this community are weakly interconnected._