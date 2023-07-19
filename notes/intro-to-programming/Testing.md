- TDD forces us to only push code to production that can be tested
- Testing is important to be done from the point of view of the person who will use it
	- Applications programmers - are business requirements met? We don't worry about performance preemptively, we write intention-revealing code instead
	- Systems programmers - is the code reliable?

## Four Rules of Simple Design
In order of importance:
1. Passes the tests
	- It works right
	- Always write the simplest thing to make the test pass first
2. Reveals intention
	- If it's not obvious what something should be called, don't give it a name too early
	- Can you understand what the code is created for?
3. No duplication
	- A little duplication is okay but make a good effort not to repeat code
	- Duplication creates code that has to be maintained in more than one spot which won't happen
4. Fewest elements
	- Variables, loops, conditionals, etc.
	- This is where bugs hide
		- Bugs scale linearly with the number of lines of code
Note: nothing here about performance, but that doesn't mean performance isn't important at all.
	- If there's a performance requirements, you write a performance-related test

## xTest
- Looks for methods with `public void SomeTest`  marked with `[Fact]` decorator or `[Test]` decorator
	- `[Test]` is used for doing the same test with different data
- Can run `dotnet watch test` or `dotnet test` in project directory or in Visual Studio

## Test First Development
- RED: Start with a meaningfully-failing test (fails on the assert)
- GREEN: Write the simplest code possible to make the test pass. If it takes longer than a few minutes, delete the test and make a smaller step by writing another test. Don't worry about writing "good" code yet, that's the next step
- REFACTOR: Making changes without changing the outcome. Make the existing code better.
	- Renaming things
	- Removing duplication
	- "Code Smells"
- (optional) COMMIT: Commit the feature
- Repeat