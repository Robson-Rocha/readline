[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)
[![NuGet version](https://badge.fury.io/nu/ReadLine22.svg)](https://www.nuget.org/packages/ReadLine2)

# ReadLine2

> This is a Fork from [https://github.com/tonerdo/readline](https://github.com/tonerdo/readline), with some improvements for default value handling, as proposed in the pull request [#38](https://github.com/tonerdo/readline/pull/38) by [Hesam Faridmehr](https://github.com/faridmehrhesam) in the original repo

ReadLine2 is a [GNU Readline](https://en.wikipedia.org/wiki/GNU_Readline) like library built in pure C#. It can serve as a drop in replacement for the inbuilt `Console.ReadLine()` and brings along
with it some of the terminal goodness you get from unix shells, like command history navigation and tab auto completion.

It is cross platform and runs anywhere .NET is supported, targeting `netstandard1.3` means that it can be used with .NET Core as well as the full .NET Framework.

## Shortcut Guide

| Shortcut                       | Comment                           |
| ------------------------------ | --------------------------------- |
| `Ctrl`+`A` / `HOME`            | Beginning of line                 |
| `Ctrl`+`B` / `←`               | Backward one character            |
| `Ctrl`+`C`                     | Send EOF                          |
| `Ctrl`+`E` / `END`             | End of line                       |
| `Ctrl`+`F` / `→`               | Forward one character             |
| `Ctrl`+`H` / `Backspace`       | Delete previous character         |
| `Tab`                          | Command line completion           |
| `Shift`+`Tab`                  | Backwards command line completion |
| `Ctrl`+`J` / `Enter`           | Line feed                         |
| `Ctrl`+`K`                     | Cut text to the end of line       |
| `Ctrl`+`L` / `Esc`             | Clear line                        |
| `Ctrl`+`M`                     | Same as Enter key                 |
| `Ctrl`+`N` / `↓`               | Forward in history                |
| `Ctrl`+`P` / `↑`               | Backward in history               |
| `Ctrl`+`U`                     | Cut text to the start of line     |
| `Ctrl`+`W`                     | Cut previous word                 |
| `Backspace`                    | Delete previous character         |
| `Ctrl` + `D` / `Delete`        | Delete succeeding character       |


## Installation

Available on [NuGet](https://www.nuget.org/packages/ReadLine2/)

Visual Studio:

```powershell
PM> Install-Package ReadLine2
```

.NET Core CLI:

```bash
dotnet add package ReadLine2
```


## Usage

### Read input from the console

```csharp
string input = ReadLine2.Read("(prompt)> ");
```

### Read input from the console, with a default value

```csharp
string password = ReadLine2.ReadPassword("(prompt)> ", "default value");
```

### Read password from the console

```csharp
string password = ReadLine2.ReadPassword("(prompt)> ");
```

_Note: The `(prompt>)` is  optional_

### History management

```csharp
// Get command history
ReadLine2.GetHistory();

// Add command to history
ReadLine2.AddHistory("dotnet run");

// Clear history
ReadLine2.ClearHistory();

// Disable history
ReadLine2.HistoryEnabled = false;
```

_Note: History information is persisted for an entire application session. Also, calls to `ReadLine2.Read()` automatically adds the console input to history_

### Auto-Completion

```csharp
class AutoCompletionHandler : IAutoCompleteHandler
{
    // characters to start completion from
    public char[] Separators { get; set; } = new char[] { ' ', '.', '/' };

    // text - The current text entered in the console
    // index - The index of the terminal cursor within {text}
    public string[] GetSuggestions(string text, int index)
    {
        if (text.StartsWith("git "))
            return new string[] { "init", "clone", "pull", "push" };
        else
            return null;
    }
}

ReadLine2.AutoCompletionHandler = new AutoCompletionHandler();
```

_Note: If no "AutoCompletionHandler" is set, tab autocompletion will be disabled_

## Contributing

Contributions are highly welcome. If you have found a bug or if you have a feature request, please report them at this repository issues section.

Things you can help with:
* Achieve better command parity with [GNU Readline](https://en.wikipedia.org/wiki/GNU_Readline).
* Add more test cases.

## License

This project is licensed under the MIT license. See the [LICENSE](LICENSE) file for more info.
