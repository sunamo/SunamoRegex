# SunamoRegex

Regex and wildcard helpers for .NET applications.

## Overview

SunamoRegex is part of the Sunamo package ecosystem, providing modular, platform-independent utilities for .NET development. It includes precompiled regular expressions for common validation tasks and a wildcard pattern matching engine built on top of the .NET Regex class.

## Key Classes

- **RegexHelper** - Static helper with precompiled regexes for email, URI, phone number, HTML tag, color code, and GUID validation.
- **Wildcard** - Converts wildcard patterns (`*` and `?`) to regular expressions and provides matching functionality.
- **WildcardHelper** - Detects whether a string contains wildcard characters.

## Installation

```bash
dotnet add package SunamoRegex
```

## Usage

```csharp
using SunamoRegex;

// Email validation
bool isEmail = RegexHelper.IsEmail("user@example.com");
bool isValidEmail = RegexHelper.IsValidEmail("user@example.com");

// URI validation
bool isUri = RegexHelper.IsUri("https://example.com");

// Phone number validation
bool isTelephone = RegexHelper.IsTelephone("+420123456789");

// Color code validation
bool isColor = RegexHelper.IsColor("#FF00AA");

// Wildcard matching
bool isMatch = Wildcard.IsMatch("hello world", "hello*");
Regex wildcardRegex = Wildcard.CreateInstance("*.txt");
```

## Links

- [NuGet](https://www.nuget.org/profiles/sunamo)
- [GitHub](https://github.com/sunamo/PlatformIndependentNuGetPackages)
- [Developer site](https://sunamo.cz)

## Target Frameworks

`net10.0;net9.0;net8.0`

## License

MIT
