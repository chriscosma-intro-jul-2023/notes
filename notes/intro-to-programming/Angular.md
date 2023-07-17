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

### Components
```ts
@Component({
	standalone: true,             // ?
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

### Routing
- Pages are things you route to, components are things you use by selector
- You could kind of route with anchor `href` but that's actually reloading the page which is not what we want. Instead, we use `routerLink`.
- We can use `[routerLinkActive]` to set classes based on the active link