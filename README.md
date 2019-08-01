<p align="center">
  <img height="100" src="https://raw.githubusercontent.com/tmacharia/Shared.Common/master/Docs/logo.png" 
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

#### Long

+ `.ConvertData(this long value, DataFormat format = DataFormat.MB, int precision = 2)` `// e.g 1024 bytes --> 1.00 for KB`
+ `.HumanizeData(this long value, DataFormat? format, int precision = 2)` `// `// e.g 5400000 bytes --> 5.4 MB`

### Non-Primitive Structs

#### Bytes

+ `.ConvertToString()`
+ `.ToBase64String()`
+ `.ToStream()`

#### DateTime

+ `.ToMoment(DateTime? currentTime=null)` `// converts to human readable time`
+ `.ToMoment(this TimeSpan span)`

#### Strings

+ `.IsValid()`
+ `.Has(string q)`
+ `.ContainsAnyOf(this string s, params string[] args)`
+ `.ContainsAll(this string s, params string[] args)`
+ `.ToInt()`
+ `.ToDouble()`
+ `.ToDecimal()`
+ `.Matches(string q)` `// regex matching`
+ `.Is(string q, bool ignoreCase=true)`
+ `.Shorten(int count, string trailingText="...")` `// shorten then append trailing dots(...)`
+ `.Truncate(this string s, int count, string trailingText = "...")`
+ `.IsValidJson()`
+ `.ToByteArray()`
+ `.ToBase64String()`
+ `.FromBase64ToArray()`
+ `.GetStringAfter(string start)`
+ `.GetStringBefore(string end)`
+ `.ToStream()`
+ `.IsEmailValid()`
+ `.DeserializeTo<T>()`

#### Enums

+ `.GetName<TEnum>(this TEnum @enum)` `// Returns the name of current/selected enum`
+ `Dictionary<string, int> GetEnumPairs<TEnum>(this TEnum @enum)`
+ `Dictionary<string, int> GetEnumPairs<TEnum>()`
+ `Dictionary<string,int> GetEnumPairs(Type enumType)`

#### Objects/General

+ `.IsOfType<T>(this object obj)`
+ `.ToDictionary<T>(this T model)` `// returns IDictionary<string, string>`
+ `.ToJson<T>(this T value)`
+ `.IsNull(this object value)`
+ `.IsNotNull(this object value)`

### Collections

#### IEnumerable

+ `bool Contains<T>(Func<T,bool> predicate)`
+ `void ForEach<T>(Action<T> action)`
+ `IEnumerable<T> RemoveWhere<T>(Func<T,bool> predicate)`

### Reflection

Reflection in c# is said to be slow, the following methods use delegates, TypeDescriptors & PropertyDescriptors to improved on perfomance.

+ `.GetPropertyType<TClass>(this TClass @class, string propertyName)`
+ `.GetPropertyValue<TClass>(this TClass @class, string propertyName)`
+ `.GetPropertyValue<TClass, TProperty>(string propertyName)`
+ `.SetPropertyValue<TClass, TValue>(string propertyName, TValue newValue)`
+ `.SetPropertyValue<TClass>(string propertyName, Type propType, object newValue)`
+ `.SetPropertyValue<TClass>(this TClass @class, string propertyName, object newValue)`

<br/>

+ `PropertyDescriptor[] GetPropertyDescriptors<TClass>(this TClass @class)`
+ `PropertyDescriptor GetDescriptor<TClass>(this TClass @class, string prop)`
+ `IEnumerable<TAttribute> GetAttributes<TClass, TAttribute>(this TClass @class, string prop)`

<br/>

Use when you are processing updates or patches on a model. This method allows you to specify which properties to update 
only without affecting the other properties.

+ `TModel UpdateWith<TModel>(this TModel baseModel, TModel updatedModel, params Expression<Func<TModel,object>>[] propertySelectors)`
+ `UpdateResult<TModel> GetPropertyUpdates<TModel>(this TModel baseModel, TModel updatedModel, params Expression<Func<TModel, object>>[] propertySelectors)`

### IO

#### Streams

+ `.ToArray()`
  
#### Files

+ `bool IsFileNameValid(string fileName)`
+ `string ToSafeFileName(string filename)`
  
