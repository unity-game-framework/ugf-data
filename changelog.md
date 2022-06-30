# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

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


