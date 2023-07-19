- A solution is a container for one or more projects
- Java JAR <=> .NET Assembly
- LTS and STS .NET versions
	- STS - 1.5 years, odd numbered versions
	- LTS - 3 years, even numbered versions
- If you have a file called `Program.cs` all the code will go into a `static void Main` if not using top-level statements
- CLR <=> JVM
	- The JVM runs Java bytecode
	- The CLR runs Common Intermediate Language (CIL)
	- C# and F# get compiled to CIL
- FCL - all the .NET types that come in the "box", e.g. `System.Console`

## Web SDK
- `launchSettings.json` - change ports, environment variables, launch browser toggle
- You can run routes by right clicking project -> add new item -> file ending in `.http`
- The Web SDK will convert response objects to JSON automatically