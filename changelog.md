# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [3.0.0-preview.3](https://github.com/unity-game-framework/ugf-data/releases/tag/3.0.0-preview.3) - 2022-12-13  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-data/milestone/10?closed=1)  
    

### Fixed

- Fix data loader controller ([#26](https://github.com/unity-game-framework/ugf-data/issues/26))  
    - Add `DataLoaderProviderControllerAsset` inspector replacement support for collection.
    - Fix `DataLoaderController` class to access to the specified loader.

## [3.0.0-preview.2](https://github.com/unity-game-framework/ugf-data/releases/tag/3.0.0-preview.2) - 2022-12-12  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-data/milestone/9?closed=1)  
    

### Added

- Add data loader file controller extension option ([#23](https://github.com/unity-game-framework/ugf-data/issues/23))  
    - Add `DataLoaderFileController.OnGetPath` method to be protected and overridable used to change path building behavior.
    - Change `DataLoaderFileController` class to support extension name append for specified data path.
- Add data loader memory controller ([#22](https://github.com/unity-game-framework/ugf-data/issues/22))  
    - Update dependencies: `com.ugf.module.controllers` to `4.0.0-preview.6` version.
    - Update package _Unity_ version to `2022.2`.
    - Add `DataLoaderMemory` class as loader implementation with data storage in memory.
    - Add `DataLoaderSerializeController` class as loader controller with serialization.
    - Add `DataLoaderController<TDescription, TLoader>` abstract class to implement controller with specific type of the loader.
    - Change `DataLoaderController` class to be the default loader controller implementation with direct loader usage.

## [3.0.0-preview.1](https://github.com/unity-game-framework/ugf-data/releases/tag/3.0.0-preview.1) - 2022-08-07  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-data/milestone/8?closed=1)  
    

### Added

- Add DataLoaderPrefs save immediately option ([#20](https://github.com/unity-game-framework/ugf-data/issues/20))  
    - Update dependencies: `com.ugf.module.controllers` to `4.0.0-preview.3` and `com.ugf.runtimetools` to `2.14.0` versions.
    - Add `DataLoaderPrefs.SaveOnWrite` property used to determine whether to save preferences after each write.

## [3.0.0-preview](https://github.com/unity-game-framework/ugf-data/releases/tag/3.0.0-preview) - 2022-07-14  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-data/milestone/7?closed=1)  
    

### Changed

- Change string ids to global id ([#18](https://github.com/unity-game-framework/ugf-data/issues/18))  
    - Update dependencies: `com.ugf.module.controllers` to `4.0.0-preview`, `com.ugf.module.serialize` to `5.0.0-preview` and `com.ugf.runtimetools` to `2.9.2` versions.
    - Update package _Unity_ version to `2022.1`.
    - Change usage of ids as `GlobalId` structure instead of `string`.

## [2.0.0-preview.4](https://github.com/unity-game-framework/ugf-data/releases/tag/2.0.0-preview.4) - 2022-06-30  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-data/milestone/6?closed=1)  
    

### Fixed

- Fix data loader prefs can't write ([#16](https://github.com/unity-game-framework/ugf-data/issues/16))  
    - Add `DataLoaderInstanceController.GetOrCreate<T>()` extension method used to get or create and set the specified type of data.
    - Fix `DataLoaderPrefs` class can't write data when no specified key was set.

## [2.0.0-preview.3](https://github.com/unity-game-framework/ugf-data/releases/tag/2.0.0-preview.3) - 2022-06-30  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-data/milestone/5?closed=1)  
    

### Fixed

- Fix DataLoaderController using bytes serializer ([#14](https://github.com/unity-game-framework/ugf-data/issues/14))  
    - Fix `DataLoaderController` class to use general serializer, instead of serializer with data as byte array only.

## [2.0.0-preview.2](https://github.com/unity-game-framework/ugf-data/releases/tag/2.0.0-preview.2) - 2022-06-29  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-data/milestone/4?closed=1)  
    

### Fixed

- Fix DataLoaderController accessing dependencies (#12 )
  - Fix `DataLoaderController` class to properly define dependencies to loader and serializer.

## [2.0.0-preview.1](https://github.com/unity-game-framework/ugf-data/releases/tag/2.0.0-preview.1) - 2022-06-28  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-data/milestone/3?closed=1)  
    

### Added

- Add DataLoaderInstanceController ([#8](https://github.com/unity-game-framework/ugf-data/issues/8))  
    - Add `DataLoaderInstanceController` class as controller which works with loading of single instance of the data.
- Add data loader prefs ([#6](https://github.com/unity-game-framework/ugf-data/issues/6))  
    - Add `DataLoaderPrefs` class as implementation of `IDataLoader` interface which works with _Unity_ `PlayerPrefs`.

### Changed

- Add check for exist data ([#7](https://github.com/unity-game-framework/ugf-data/issues/7))  
    - Update dependencies: `com.ugf.module.controllers` to `2.1.1`, `com.ugf.module.serialize` to `4.0.0` and `com.ugf.runtimetools` to `2.8.0`.
    - Change `IDataLoader` interface and implementations to work using _Try_ pattern methods.
    - Change `IDataLoaderController` interface and implementations to work using _Try_ pattern methods.

## [2.0.0-preview](https://github.com/unity-game-framework/ugf-data/releases/tag/2.0.0-preview) - 2021-11-26  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-data/milestone/2?closed=1)  
    

### Changed

- Add data loading controllers ([#5](https://github.com/unity-game-framework/ugf-data/pull/5))  
    - Update package Unity version to `2021.2`.
    - Update dependencies: add `com.ugf.module.controllers` of `2.0.0` and `com.ugf.module.serialize` of `4.0.0-preview.1` version.
    - Update package publish registry.
    - Add `DataLoader` and related classes to implement abstract loaders for specific data storage or type.
    - Add `DataLoaderController` and related classes to implement abstract loader controllers that converts raw data to specific objects.
    - Remove all old data structure classes.

## [1.0.0-preview](https://github.com/unity-game-framework/ugf-data/releases/tag/1.0.0-preview) - 2019-06-30  

- [Commits](https://github.com/unity-game-framework/ugf-data/compare/ddfe50a...1.0.0-preview)
- [Milestone](https://github.com/unity-game-framework/ugf-data/milestone/1?closed=1)

### Added
- This is a initial release.


