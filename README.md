# fib — File Bundler CLI
A .NET CLI tool that bundles source code files from a directory into a single output file. Supports language filtering, flexible sorting, source annotation, and interactive response file generation.

## Commands

### `bundle`
Scans the current directory and merges all matching source files into a single output file.

| Option | Alias | Description | Required |
|---|---|---|---|
| `--language` | `-l` | Programming language(s) to include, or `all` | ✅ |
| `--output` | `-o` | Output file path and name | ✅ |
| `--note` | `-n` | Include source file path as a comment above each file | ❌ |
| `--sort` | `-s` | Sort order: `name` (alphabetical) or `type` (by extension). Default: `name` | ❌ |
| `--remove-empty-lines` | `-r` | Strip empty lines from bundled code | ❌ |
| `--author` | `-a` | Add an author comment at the top of the bundle | ❌ |

**Example:**
```
fib bundle -l csharp python -o output.txt -n -a "Jane Doe" -s type
```

---

### `create-rsp`
An interactive wizard that asks questions and generates a `.rsp` response file. The response file can then be reused to run the same bundle command without retyping all options.

**Example:**
```
fib create-rsp
fib @myconfig.rsp
```

---

## Features

* **Language Filtering** — Include files by language (`csharp`, `python`, `javascript`, `typescript`, `java`, `cpp`, `c`, `ruby`, `go`, `php`, `swift`, `kotlin`) or use `all` to include everything
* **Smart File Scanning** — Automatically excludes `bin`, `obj`, `debug`, `release`, `node_modules`, `.git`, and `.vs` directories
* **Flexible Sorting** — Sort bundled files alphabetically by name or grouped by file extension
* **Source Annotation** — Optionally prepend each file's relative path as a comment
* **Empty Line Removal** — Optionally strip all blank lines from the output
* **Author Header** — Optionally add an author comment at the top of the bundle
* **Response File Support** — Save your configuration to a `.rsp` file and reuse it with `fib @filename.rsp`
* **Clean Architecture** — Logic split into focused services: `LanguageDetector`, `FileScanner`, `FileSorter`, `BundleWriter`

---

## Tech Stack

* C# / .NET 8
* System.CommandLine
* System.CommandLine.NamingConventionBinder

---

## Getting Started

### Prerequisites
* .NET 8 SDK

### Installation

```
git clone https://github.com/YOUR_USERNAME/FilesBundle.git
cd FilesBundle/fib
dotnet build
```

### Run

```
dotnet run -- bundle -l csharp -o output.txt
```

Or after publishing:
```
fib bundle -l csharp -o output.txt
```
