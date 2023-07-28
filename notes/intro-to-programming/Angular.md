## Installation and Setup
- Installation:
	`npm i -g @angular/cli@latest`
	- @latest is the default if no version is specified
- New standalone app:
	`ng new app --standalone --skip-git --skip-tests`
- Best to open just the root app folder in VS code

## Overview
- Angular HTML is more like React jsx/tsx
- Angular is for building web apps (SPAs), not web sites
	- Sends bundle to browser with:
		- runtime.js - angular bundle
		- polyfills.js - compatibility with older browsers
		- vendor.js - third party code
- Used for user interfaces
- [[Tailwind]] and [[DaisyUI]] are useful for creating interfaces

## Components
```ts
// "Metadata Decorators - Typescript"
@Component({
	standalone: true,             // doesn't need to belong to a module
	selector: 'my-app-component', // one way to include a component in HTML
	imports: [OtherComponent]     // how to specify we can use OtherComponent's selector
})
```

- A unit of user interface in Angular is a Component
	- A TS class
		- A template
		- Both are compiled and sent to the browser
		- Jobs:
			- Accurately project application state
			- Provide affordances through which the user can interact with the application
- State - the value of all meaningful data at a point in time
- Components have children
- Selector has the prefix specified in `angular.json`
- Generate a new component:
	`ng g c <component name> [--inline-template] [--inline-style] [--flat] [--dry-run]`
- Make components as dumb as possible, don't put business logic in them
- Often in Angular, we have a lot of features that don't change very often, and then there's the "hot" features that are currently being worked on

## Routing
- Pages are things you route to, components are things you use by selector
- You could kind of route with anchor `href` but that's actually reloading the page which is not what we want. Instead, we use `routerLink`.
- We can use `[routerLinkActive]` to set classes based on the active link
- Lazy loading lets you split compilation into different source files allowing frequently updated features to be downloaded separately

## Template Variables, Outputs
Here, `#thing` is a template variable and `(click)` is an output:
```tsx
<input #thing type="text">
<button (click)="addFriend(thing.value)">Add Friend</button>
```

- There is no way for sibling components to directly communicate, but, they can pass through their parent by using Outputs
- Output example:
	```ts
	@Output() itemAdded = EventEmitter<string>(); // Parent will read this child event
	...
	this.itemAdded.emit("some item was added");   // child component sends event
	...
	<app-component (itemAdded)="doSomething($event)" /> // parent
	```
- Input example:
```ts
	@Input({required: true}) shoppingList: TodoListItemModel[]; // list component
	...
	<app-list [shoppingList]="myList" /> // parent
```

## Cypress
- How can we make sure our component we are writing is working if we can't see it and don't want to commit temporary changes to another file where we could see it? We can use Cypress.
- The style of testing is Behavior Driven Development. When we write tests, we want to describe the component in various different modes.
- Start with utopian state

### Installation and Launch
`npm i -D cypress`
`cypress open`
