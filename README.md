# SunamoRegex

## Short description

Pomocné funkce pro regulární výrazy a zástupné znaky, včetně předkompilovaných výrazů. Obsahuje Runner a testy.


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

## Target Frameworks

`net10.0;net9.0;net8.0`

## Dependencies

- **Microsoft.Extensions.Logging.Abstractions**
- **xunit**

## License

MIT

<!-- sunamo:test-coverage:start -->
## Test coverage

| Metric | Value |
|---|---|
| Method | static |
| Test projects | 1 |
| Public types referenced by tests | 3/4 (75.0 %) |
| Public methods referenced by tests | 4/14 (28.6 %) |
| Line coverage | n/a |
| Branch coverage | n/a |
| Generated (UTC) | 2026-11-22 21:24 |

<!-- sunamo:test-coverage:data {"package":"SunamoRegex","container":"pinp","testProjects":1,"publicTypes":4,"typesReferencedByTests":3,"publicMethods":14,"methodsReferencedByTests":4,"lineRate":null,"branchRate":null,"method":"static","generatedUtc":"2026-11-22 21:24"} -->
<!-- sunamo:test-coverage:end -->
