<p align="center">
  <img height="100" src="https://raw.githubusercontent.com/tmacharia/Shared.Common/update-patch-1/Docs/logo.png" 
			 alt="Shared.Common logo" title="Shared.Common logo">
</p>

# Introduction

[![Build status](https://ci.appveyor.com/api/projects/status/cj2wsayj5l7nea8e?svg=true)](https://ci.appveyor.com/project/tmacharia/shared-common)
[![Nuget](https://img.shields.io/nuget/vpre/Shared.Common.svg?logo=nuget&link=https://www.nuget.org/packages/Shared.Common//left)](https://www.nuget.org/packages/Shared.Common)
![SDK Downloads on Nuget](https://img.shields.io/nuget/dt/Shared.Common.svg?label=downloads&logo=nuget&link=https://www.nuget.org/packages/Shared.Common//left)

#### Tests

[![Test status](http://teststatusbadge.azurewebsites.net/api/status/tmacharia/shared-common)](https://ci.appveyor.com/project/tmacharia/shared-common/builds/25472791/tests)

A lightweight .NET library with re-usable resources/software components that can be shared among multiple application blocks or programs. It has a rich set of commonly used functions and methods with most of which are [Extension Methods](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods) to assist software developers avoid re-writing code blocks and only focus on writing new features.

## Extension Methods

Below is a list of methods that you can re-use in your code.

### Primitives

#### Integers

+ `.IsPositive()`
+ `.Negate()`
+ `.ToMoney(Country country)`  `// e.g US, GB, FR, KE, NG e.t.c`

#### Decimals

+ `.IsPositive()`
+ `.Negate()`
+ `.ToMoney(Country country)`  `// e.g US, GB, FR, KE, NG e.t.c`
  
#### Doubles

+ `.IsPositive()`
+ `.Negate()`
+ `.ToMoney(Country country)`  `// e.g US, GB, FR, KE, NG e.t.c`

### Structs

#### Bytes

+ `.ConvertToString()`
+ `.ToBase64String()`
+ `.ToStream()`

#### DateTime

+ `.ToMoment(DateTime? currentTime=null)` `// converts to human readable time`

#### Strings

+ `.IsValid()`
+ `.Has(string q)`
+ `.ToInt()`
+ `.ToDouble()`
+ `.ToDecimal()`
+ `.Matches(string q)` `// regex matching`
+ `.Is(string q, bool ignoreCase=true)`
+ `.Shorten(int count)` `// shorten then append trailing dots(...)`
+ `.IsValidJson()`
+ `.ToByteArray()`
+ `.ToBase64String()`
+ `.FromBase64ToArray()`
+ `.GetStringAfter(string start)`
+ `.GetStringBefore(string end)`
+ `.ToStream()`
+ `.IsEmailValid()`

### Collections

#### IEnumerable

+ `bool Contains<T>(Func<T,bool> predicate)`
+ `void ForEach<T>(Action<T> action)`
+ `IEnumerable<T> RemoveWhere<T>(Func<T,bool> predicate)`

### Reflection

Reflection in c# is said to be slow, the following methods use delegates, TypeDescriptors & PropertyDescriptors to improved on perfomance.

+ `.GetPropertyValue<TClass, TProperty>(string propertyName)`
+ `.SetPropertyValue<TClass, TValue>(string propertyName, TValue newValue)`
+ `SetPropertyValue<TClass>(string propertyName, Type propType, object newValue)`

<br/>

+ `PropertyDescriptor[] GetPropertyDescriptors<TClass>(this TClass @class)`
+ `PropertyDescriptor GetDescriptor<TClass>(this TClass @class, string prop)`
+ `IEnumerable<TAttribute> GetAttributes<TClass, TAttribute>(this TClass @class, string prop)`

### IO

#### Streams

+ `.ToArray()`
  
#### Files

+ `string ToSafeFileName(string filename)`
  
