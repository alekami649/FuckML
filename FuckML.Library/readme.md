# F*ckML - a library to searching for obsense in messages.
## Installation

Open _PowerShell For Developers_ and write this code:

`dotnet add package FuckML`

You successfully installed F*ckML nuget package.

## Getting Started

Add `using FuckML.Searchers`

Create an instance of `FuckML.Searchers.QuickSearcher`

Get the result by calling `quickSearcher.ContainsObsense(textToCheckForObsense.ToLower())`