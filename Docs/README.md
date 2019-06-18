# Common

## AttributesExts

 Collection of extension methods for class property attributes. 

#### .GetSymbolAttribute``1(``0)

 Gets the value of [[|Attributes.SymbolAttribute]] for the specified property. 

|Name | Description |
|-----|------|
|source: |Property|
Returns:Value of symbol.

#### .DescriptionAttr``1(``0)

 Gets the description text of [[|System.ComponentModel.DescriptionAttribute]] for the specified property. 

|Name | Description |
|-----|------|
|source: |Property|
Returns:Value of Description

## Attributes.SymbolAttribute

 Specifies a symbol for a property/field or event. 

#### .SymbolAttribute.#ctor(System.String)

 Instanciates attributes with a symbol value. 

|Name | Description |
|-----|------|
|symbolValue: ||

### Attributes.SymbolAttribute.Symbol

 Value of symbol. 

## CollectionExts

 Represents extension methods for elements that are considered as collections and mostly inherit from [[|System.Collections.Generic.IEnumerable`1]]

#### .Contains``1(System.Collections.Generic.IEnumerable{``0},System.Func{``0,System.Boolean})

 Checks if the current collection has an item that matches the specified predicate. 

|Name | Description |
|-----|------|
|enumerable: |Collection|

|Name | Description |
|-----|------|
|predicate: |Predicate function for evaluation.|
Returns:true or false.

#### .ForEach``1(System.Collections.Generic.IEnumerable{``0},System.Action{``0})

 Steps through the collection subjecting each item to the [[|System.Action]] specified. 

|Name | Description |
|-----|------|
|enumerable: ||

|Name | Description |
|-----|------|
|action: |Function/method to execute on each item in the collection.|

#### .RemoveWhere``1(System.Collections.Generic.IEnumerable{``0},System.Func{``0,System.Boolean})

 Remove all items in a collection that matches a specified predicate. 

|Name | Description |
|-----|------|
|enumerable: |Collection to filter|

|Name | Description |
|-----|------|
|predicate: |Predicate of items to remove.|
Returns:Filtered collection

## Constants

 Collection of variables and resources available to any project and supplied immediately the application starts. 

### Constants.StringComparison

 String Comparison Ordinal. 

### Constants.StringComparisonIgnoreCase

 String Comparison IgnoreCase. 

### Constants.Culture

 Current UI Thread [[|System.Globalization.CultureInfo]]

### Constants.Encoding

 Base UTF8 Encoding to re-use. 

### Constants.EmailRegex

 Regex expression to verify valid email addresses. 

## Encryptor

 Contains encyption and decryption methods. 

#### .GetMD5(System.String)

 Gets the MD5 Hash of a specified text. 

|Name | Description |
|-----|------|
|plaintext: ||
Returns:MD5 Hash

#### .Encrypt(System.String)

 Encrypts plaintext to ciphertext 

|Name | Description |
|-----|------|
|plainText: |Human readable text.|
Returns:Ciphertext

#### .Decrypt(System.String)

 Decrypts ciphertext to plaintext 

|Name | Description |
|-----|------|
|cipherText: |Ciphertext.|
Returns:Plaintext

#### .Encrypt(System.String,System.String)

 Encrypt plaintext to ciphertext using an X509 certificate 

|Name | Description |
|-----|------|
|plainText: |Human readable text|

|Name | Description |
|-----|------|
|certificatePath: |Absolute path to certificate file.|
Returns:Ciphertext

#### .Decrypt(System.String,System.String)

 Decrypts ciphertext to plaintext using an X509 certificate 

|Name | Description |
|-----|------|
|cipherText: |Ciphertext|

|Name | Description |
|-----|------|
|certificatePath: |Absolute path to certificate file.|
Returns:Plaintext

## Enums.CurrencyType

 Represents supported current types 

### Enums.CurrencyType.KES

 Kenyan Shilling. 

### Enums.CurrencyType.USD

 United States Dollar. 

### Enums.CurrencyType.EUR

 Euro. 

### Enums.CurrencyType.JPY

 Japanese Yen. 

## Enums.HttpVerb

 Represents HTTP verbs. 

### Enums.HttpVerb.GET

 GET request. 

### Enums.HttpVerb.POST

 POST request. 

### Enums.HttpVerb.PUT

 PUT request. 

### Enums.HttpVerb.DELETE

 DELETE Request. 

## GeneralUtils

 Contains general extension methods and utilities. 

### GeneralUtils.md5

 Instance of MD5 Hash Algorithm. 

#### .IsNotNull(System.Object)

 Checks if an object is not null 

|Name | Description |
|-----|------|
|value: |Object to check|
Returns:true or false

#### .IsNull(System.Object)

 Checks if an object is null 

|Name | Description |
|-----|------|
|value: |[[|System.Object]] to check|
Returns:

#### .ToJson``1(``0)

 Serializes an object of generic type to JSON [[|System.String]]

|Name | Description |
|-----|------|
|value: |Object/Model/Item to serialize|
Returns:JSON text

#### .DeserializeTo``1(System.String)

 Deserializes JSON formatted [[|System.String]] of text to a strongly typed generic of 

|Name | Description |
|-----|------|
|json: |JSON text|
Returns:

#### .ToInt(System.Object)

 Converts a decimal number to an integer 

|Name | Description |
|-----|------|
|value: |Value to convert|
Returns:Integral equivalent

#### .ToDictionary``1(``0)

 Reflects all the properties in a model of generic [[|System.Type]] that must be a class and returns a [[|System.Collections.Generic.IDictionary`2]] pairs collection mapped in the following way: Key: PropertyName, Value: PropertyValue 

|Name | Description |
|-----|------|
|model: |Model to reflect|
Returns:
[[System.ArgumentNullException|System.ArgumentNullException]]: 

#### .IsOfType``1(System.Object)

 Checks if an object is of the specified [[|System.Type]]

|Name | Description |
|-----|------|
|obj: ||
Returns:

#### .BytesToString(System.Int64)

 Converts a series of bytes to human readable notation. e.g 45KB, 3.5GB 

|Name | Description |
|-----|------|
|byteCount: ||
Returns:

## HttpHandler

 Represents a custom Http Handler. 

#### .#ctor

 Parameter-less constructor that instanciates internal [[|System.Net.Http.HttpClient]]

#### .#ctor(System.Net.Http.HttpClientHandler)

 Constructor that instaciates the internal [[|System.Net.Http.HttpClient]] with a custom [[|System.Net.Http.HttpClientHandler]]

|Name | Description |
|-----|------|
|httpClientHandler: ||
[[System.ArgumentNullException|System.ArgumentNullException]]: 

### HttpHandler.BaseAddress

 Base/Root Address 

#### .AddHeader(System.String,System.String)

 Adds a header item to the default request headers. 

|Name | Description |
|-----|------|
|key: |Header name|

|Name | Description |
|-----|------|
|value: |Header value|

#### .GetAsync(System.Uri)

 Runs a Http GET request. 

|Name | Description |
|-----|------|
|uri: |Uri resource/route|
Returns:

#### .PostAsync(System.Uri,System.Net.Http.HttpContent)

 Runs a Http POST request 

|Name | Description |
|-----|------|
|uri: |Uri resource/route|

|Name | Description |
|-----|------|
|content: |Body content to post.|
Returns:

#### .Dispose(System.Boolean)

 Dispose the current instance. 

|Name | Description |
|-----|------|
|isDisposing: ||

## IBaseInterface

 Represents the base interface that classes that have a disposable object should inherit from since it executes safe disposition and suppression. 

#### .Finalize

 Deconstructor. 

#### .Dispose

 Dispose method. 

#### .Dispose(System.Boolean)

 Dispose method that can be overriden by the inheriting class. 

|Name | Description |
|-----|------|
|isDisposing: ||

#### .DisposeItem``1(``0@)

 Calls the default dispose method on a object 

|Name | Description |
|-----|------|
|item: |Item to dispose.|

## IEncryptor

 Represents an interface with a list of encryption and decryption methods. 

#### .GetMD5(System.String)

 Generates the MD5 hash of the specified [[|System.String]] text. 

|Name | Description |
|-----|------|
|plaintext: |Text to convert.|
Returns:MD5 hash

#### .Encrypt(System.String)

 Encrypts a [[|System.String]] of plaintext using RSA algorithm into ciphertext 

|Name | Description |
|-----|------|
|plainText: |Block of text to encrypt|
Returns: Base64 encoded ciphertext 

#### .Decrypt(System.String)

 Decrypts a [[|System.String]] of ciphertext using RSA algorithm into plaintext 

|Name | Description |
|-----|------|
|cipherText: |Block of text to decrypt|
Returns: Plaintext 

#### .Encrypt(System.String,System.String)

 Encrypts a block of text using RSA algorithm from the public key in the certificate file provided. 

|Name | Description |
|-----|------|
|plainText: |Block of text to encrypt|

|Name | Description |
|-----|------|
|certificatePath: |File path to the Public Key Certificate on the current machine. |
Returns: Base64 encoded ciphertext 

#### .Decrypt(System.String,System.String)

 Decrypts a block of ciphertext using RSA algorithm from the public key in the certificate file provided. 

|Name | Description |
|-----|------|
|cipherText: |Block of ciphertext to decrypt|

|Name | Description |
|-----|------|
|certicatePath: |File path to the Public Key Certificate on the current machine. |
Returns: Plaintext 

## IHttpHandler

 Represents an interface for a custom Http Handler. 

### IHttpHandler.BaseAddress

 Base/Root Address 

#### .AddHeader(System.String,System.String)

 Adds a header item to the default request headers. 

|Name | Description |
|-----|------|
|key: |Header name|

|Name | Description |
|-----|------|
|value: |Header value|

#### .GetAsync(System.Uri)

 Runs a Http GET request. 

|Name | Description |
|-----|------|
|uri: |Uri resource/route|
Returns:

#### .PostAsync(System.Uri,System.Net.Http.HttpContent)

 Runs a Http POST request 

|Name | Description |
|-----|------|
|uri: |Uri resource/route|

|Name | Description |
|-----|------|
|content: |Body content to post.|
Returns:

## IO.FileExts

 Extension methods for file related jobs. 

#### .FileExts.ToSafeFileName(System.String)

 Re-formats a filename to one that is valid and considered safe and won't fail when trying to save. 

|Name | Description |
|-----|------|
|filepath: |File path|
Returns:Safe file path.

## IO.StreamExts

 Extension methods for all Streams. 

#### .StreamExts.ToArray(System.IO.Stream)

 Converts any object that inherits from [[|System.IO.Stream]] to a byte[] 

|Name | Description |
|-----|------|
|input: |Input stream.|
Returns:Byte Array

## Language.Resources

 A strongly-typed resource class, for looking up localized strings, etc. 

### Language.Resources.ResourceManager

 Returns the cached ResourceManager instance used by this class. 

### Language.Resources.Culture

 Overrides the current thread's CurrentUICulture property for all resource lookups using this strongly typed resource class. 

### Language.Resources.Days

 Looks up a localized string similar to days. 

### Language.Resources.DaysAgo

 Looks up a localized string similar to days ago. 

### Language.Resources.Hours

 Looks up a localized string similar to hrs. 

### Language.Resources.HoursAgo

 Looks up a localized string similar to hours ago. 

### Language.Resources.In

 Looks up a localized string similar to in. 

### Language.Resources.InOneHr

 Looks up a localized string similar to in 1 hour. 

### Language.Resources.InOneMin

 Looks up a localized string similar to in 1 min. 

### Language.Resources.InOneSec

 Looks up a localized string similar to in 1 sec. 

### Language.Resources.JustNow

 Looks up a localized string similar to just now. 

### Language.Resources.Mins

 Looks up a localized string similar to mins. 

### Language.Resources.MinsAgo

 Looks up a localized string similar to mins ago. 

### Language.Resources.Months

 Looks up a localized string similar to months. 

### Language.Resources.MonthsAgo

 Looks up a localized string similar to months ago. 

### Language.Resources.Ms

 Looks up a localized string similar to ms. 

### Language.Resources.OneHrAgo

 Looks up a localized string similar to 1 hour ago. 

### Language.Resources.OneMinAgo

 Looks up a localized string similar to 1 min ago. 

### Language.Resources.OneSecAgo

 Looks up a localized string similar to 1 sec ago. 

### Language.Resources.Secs

 Looks up a localized string similar to secs. 

### Language.Resources.SecsAgo

 Looks up a localized string similar to secs ago. 

### Language.Resources.Tomorrow

 Looks up a localized string similar to tomorrow. 

### Language.Resources.Years

 Looks up a localized string similar to yrs. 

### Language.Resources.YearsAgo

 Looks up a localized string similar to yrs ago. 

### Language.Resources.Yesterday

 Looks up a localized string similar to yesterday. 

## Models.Result`1

 Represents a boxed object to safely return the end result of a function execution and carries a generic type. 

#### .Result`1.#ctor

 Parameterless constructor. 

### Models.Result`1.IsSuccess

 Checks if the result was returned with any errors or not. 

### Models.Result`1.Message

 Additional message to pass back in case execution succeeded. This can also hold an error message. 

### Models.Result`1.Model

 Data object 

### Models.Result`1.Errors

 List of exceptions caught during execution. 

## Primitives.CurrencyExts

 Represents extension methods for currency formatting. 

#### .CurrencyExts.ToMoney(System.Decimal,Enums.CurrencyType,System.Boolean)

 Formats a [[|System.Decimal]] number to Kenyan currency with precision set by default to 2 decimal places. 

|Name | Description |
|-----|------|
|d: |Decimal amount to format.|

|Name | Description |
|-----|------|
|currency: |Currency Type to format the result to. Defaults to USD if not set.|

|Name | Description |
|-----|------|
|useFormat: |Specify whether to use decimal place checker that formats the results independently. Default is True to perform formatting. Choosing False will retain all the decimals places in a [[|System.Decimal]] if it has any. |
Returns:Formatted Kenyan money.

#### .CurrencyExts.ToMoney(System.Double,Enums.CurrencyType,System.Boolean)

 Formats a [[|System.Double]] number to Kenyan currency with precision set by default to 2 decimal places. 

|Name | Description |
|-----|------|
|d: |Decimal amount to format.|

|Name | Description |
|-----|------|
|currency: |Currency Type to format the result to. Defaults to USD if not set.|

|Name | Description |
|-----|------|
|useFormat: |Specify whether to use decimal place checker that formats the results independently. Default is True to perform formatting. Choosing False will retain all the decimals places in a [[|System.Double]] if it has any. |
Returns:Formatted Kenyan money.

#### .CurrencyExts.ToMoney(System.Int32,Enums.CurrencyType)

 Formats a [[|System.Decimal]] number to Kenyan currency. 

|Name | Description |
|-----|------|
|n: |Integer amount to format.|

|Name | Description |
|-----|------|
|currency: |Currency Type to format the result to. Defaults to USD if not set.|
Returns:Formatted Kenyan money.

## Primitives.MathExts

 Represents extension methods that are mathematically related. 

#### .MathExts.IsPositive(System.Int32)

 Validates if an [[|System.Int32]] has a value greater than 0. 

|Name | Description |
|-----|------|
|i: |Value to check.|
Returns:true or false

#### .MathExts.IsPositive(System.Decimal)

 Validates if a [[|System.Decimal]] has a value greater than 0. 

|Name | Description |
|-----|------|
|i: |Value to check.|
Returns:true or false

#### .MathExts.IsPositive(System.Double)

 Validates if an [[|System.Double]] has a value greater than 0. 

|Name | Description |
|-----|------|
|i: |Value to check.|
Returns:true or false

#### .MathExts.Negate(System.Int32)

 Negates an [[|System.Int32]] number by multiplying it by -1. 

|Name | Description |
|-----|------|
|i: |Number to negate|
Returns: Equivalent value on the other side of 0 in a cartesian plane. 

#### .MathExts.Negate(System.Decimal)

 Negates a [[|System.Decimal]] number by multiplying it by -1. 

|Name | Description |
|-----|------|
|d: |Number to negate|
Returns: Equivalent value on the other side of 0 in a cartesian plane. 

#### .MathExts.Negate(System.Double)

 Negates a [[|System.Double]] number by multiplying it by -1. 

|Name | Description |
|-----|------|
|d: |Number to negate|
Returns: Equivalent value on the other side of 0 in a cartesian plane. 

## ReflectionExts

 Collection of extension methods that require Reflection to access class properties dynamically at runtime. 

#### .GetPropertyDescriptors``1(``0)

 Gets all [[|System.ComponentModel.PropertyDescriptor]] of a certain model class for all its properties. 

|Name | Description |
|-----|------|
|class: |Model class|
Returns:Array

#### .GetPropertyValue``2(``0,System.String)

 Returns the value of a specific class property using a delegate to access class properties by Reflection. 

|Name | Description |
|-----|------|
|class: |Object value of type TClass|

|Name | Description |
|-----|------|
|propertyName: |Property name to return value of.|
Returns:

#### .SetPropertyValue``2(``0,System.String,``1)

 Sets the value of a specific class property using an [[|System.Action]] to access and assign class properties by Reflection. 

|Name | Description |
|-----|------|
|class: ||

|Name | Description |
|-----|------|
|propertyName: |Property name to assign value to.|

|Name | Description |
|-----|------|
|newValue: |Value to assign the specified property.|

#### .SetPropertyValue``1(``0,System.String,System.Type,System.Object)

 Sets the value of a specific class property using an [[|System.Action]] to access and assign class properties by Reflection. 

|Name | Description |
|-----|------|
|class: ||

|Name | Description |
|-----|------|
|propertyName: |Property name to assign value to.|

|Name | Description |
|-----|------|
|propType: |[[|System.Type]] of target property|

|Name | Description |
|-----|------|
|newValue: |Value to assign the specified property.|
[[System.InvalidCastException|System.InvalidCastException]]: 
[[System.Exception|System.Exception]]: 

#### .GetDescriptor``1(``0,System.String)

 Gets the [[|System.ComponentModel.PropertyDescriptor]] of a specified property in a class. 

|Name | Description |
|-----|------|
|class: |Model class|

|Name | Description |
|-----|------|
|prop: |Property Name|
Returns:[[|System.ComponentModel.PropertyDescriptor]]

#### .GetAttributes``2(``0,System.String)

 Gets all attributes of a certain class property. 

|Name | Description |
|-----|------|
|class: ||

|Name | Description |
|-----|------|
|prop: ||
Returns:

## StringExts

 Contains extensions methods on [[|System.Type]][[|System.String]]

#### .IsValid(System.String)

 Checks if a [[|System.String]] is valid by whether it's empty, null or whitespace. 

|Name | Description |
|-----|------|
|s: |Text to evaluate.|
Returns: True or False 

#### .Has(System.String,System.String)

 Checks if a [[|System.String]] contains the specified query text as a substring. 

|Name | Description |
|-----|------|
|s: |String text to check|

|Name | Description |
|-----|------|
|q: |Substring to check.|
Returns: True if it contains or False if it doesn't. 

#### .ToInt(System.String)

 Converts a text [[|System.String]] to an [[|System.Int32]]

|Name | Description |
|-----|------|
|intAsString: |Text to convert|
Returns: An [[|System.Int32]] number 
[[System.ArgumentNullException|System.ArgumentNullException]]: 

#### .ToDouble(System.String)

 Converts a text [[|System.String]] to a [[|System.Double]]

|Name | Description |
|-----|------|
|doubleAsString: |Text to convert|
Returns: A [[|System.Double]] number 
[[System.ArgumentNullException|System.ArgumentNullException]]: 

#### .ToDecimal(System.String)

 Converts a text [[|System.String]] to a [[|System.Decimal]]

|Name | Description |
|-----|------|
|doubleAsString: |Text to convert|
Returns: A [[|System.Decimal]] number 
[[System.ArgumentNullException|System.ArgumentNullException]]: 

#### .Matches(System.String,System.String)

 Compares and evaluates if a specific query [[|System.String]] matches another one using Regular Expressions. 

|Name | Description |
|-----|------|
|s: |The [[|System.String]] to check|

|Name | Description |
|-----|------|
|q: |The query [[|System.String]]|
Returns:true or false.

#### .HasDigit(System.String)

 Checks if a string of text contains a digit or number. 

|Name | Description |
|-----|------|
|s: |Text to check|
Returns:True or False

#### .Is(System.String,System.String,System.Boolean)

 Checks if two strings match. 

|Name | Description |
|-----|------|
|s: |Original/base/string1 to match against.|

|Name | Description |
|-----|------|
|query: |Text to match.|

|Name | Description |
|-----|------|
|ignoreCase: |Whether to ignore case or not.|
Returns:True or False

#### .Shorten(System.String,System.Int32)

 Shortens a [[|System.String]] of text to a certain number of characters and appends trailing dots(...) at the end to show continuation. 

|Name | Description |
|-----|------|
|s: |Text to shorten|

|Name | Description |
|-----|------|
|count: |Number of characters to take from the first index/start/zero|
Returns: Shortened version of the supplied [[|System.String]]

#### .IsValidJson(System.String)

 Checks if a [[|System.String]] or text is valid json in terms of formatting. 

|Name | Description |
|-----|------|
|json: |Text [[|System.String]] to validate.|
Returns:True if valid and False if invalid.
[[Newtonsoft.Json.JsonReaderException|Newtonsoft.Json.JsonReaderException]]: 
[[System.Exception|System.Exception]]: 

#### .ToByteArray(System.String)

 Converts a [[|System.String]] of text to a byte[] 

|Name | Description |
|-----|------|
|s: |Text to convert|
Returns: Byte Array. 

#### .ToBase64String(System.String)

 Converts a [[|System.String]] to a byte[] and returns the result as a Base64 encoded [[|System.String]] of text. 

|Name | Description |
|-----|------|
|s: |Text to convert|
Returns:Base64 encoded [[|System.String]]

#### .FromBase64ToArray(System.String)

 Converts a Base64 encoded string to an equivalent byte[] 

|Name | Description |
|-----|------|
|s: |base64 encoded string|
Returns:byte array

#### .GetStringAfter(System.String,System.String)

 Trims a piece of [[|System.String]] text from the location/index of where start is and returns all text after that. 

|Name | Description |
|-----|------|
|text: |[[|System.String]] to truncate |

|Name | Description |
|-----|------|
|start: | Text to find in this block and begin from. |
Returns: Truncated block [[|System.String]] having removed all text that behind the start location. 
[[System.ArgumentNullException|System.ArgumentNullException]]: 
[[System.ArgumentOutOfRangeException|System.ArgumentOutOfRangeException]]: 

#### .GetStringBefore(System.String,System.String)

 Trims a piece of [[|System.String]] text from the location/index of where end is and returns all text before that. 

|Name | Description |
|-----|------|
|text: |[[|System.String]] to truncate. |

|Name | Description |
|-----|------|
|end: | Text to find in this block and end at. |
Returns: Truncated block [[|System.String]] having removed all text after end location 
[[System.ArgumentNullException|System.ArgumentNullException]]: 
[[System.ArgumentOutOfRangeException|System.ArgumentOutOfRangeException]]: 

#### .ToStream(System.String)

 Converts a [[|System.String]] of text to a [[|System.IO.Stream]]

|Name | Description |
|-----|------|
|s: |Text to convert|
Returns: A [[|System.IO.Stream]] or [[|System.IO.MemoryStream]]

#### .IsEmailValid(System.String)

 Verify that Strings Are in Valid Email Format. 

|Name | Description |
|-----|------|
|email: |Email string|
Returns: Returns True if the [[|System.String]] contains a valid email address and False if it does not 
[[System.ArgumentException|System.ArgumentException]]: 
[[System.Text.RegularExpressions.RegexMatchTimeoutException|System.Text.RegularExpressions.RegexMatchTimeoutException]]: 

## Structs.BytesExts

 Represents extension methods on byte arrays. 

#### .BytesExts.ConvertToString(System.Byte[])

 Converts a byte[] to its equivalent [[|System.String]] of text using UTF encoding. 

|Name | Description |
|-----|------|
|bytes: |byte array|
Returns:[[|System.String]] of text 

#### .BytesExts.ToBase64String(System.Byte[])

 Converts a stream of byte[] to a Base64 encoded [[|System.String]] of text. 

|Name | Description |
|-----|------|
|bytes: |Byte array|
Returns:Base64 encoded [[|System.String]]

#### .BytesExts.ToStream(System.Byte[])

 Converts a byte[] to a [[|System.IO.Stream]]

|Name | Description |
|-----|------|
|bytes: |Array of bytes to convert|
Returns:A stream

## Structs.DateTimeExts

 Represents extension methods on [[|System.DateTime]] instances. 

#### .DateTimeExts.ToMoment(System.DateTime,System.Nullable{System.DateTime},System.Boolean)

 Returns a human readable and comprehensible time format to know the exact relative time in the past. 

|Name | Description |
|-----|------|
|pastDate: |This DateTime instance that should represent a time in the past 
|Name | Description |
|-----|------|
|currentTime: |Current datetime instance to compare to. If not specified [[|System.DateTime.Now]] will be used by default. |

|Name | Description |
|-----|------|
|includeTime: |Should the timestamp be included for differences of more than two days. If unset, timestamp is included by default. |
 or the future. |
Returns:Human readable time
[[System.ArgumentNullException|System.ArgumentNullException]]: 

#### .DateTimeExts.ToMoment(System.TimeSpan)

 Converts a [[|System.TimeSpan]] to human-readable format. 

|Name | Description |
|-----|------|
|span: |Timespan instance.|
Returns:Moment time.
[[System.ArgumentNullException|System.ArgumentNullException]]: 

