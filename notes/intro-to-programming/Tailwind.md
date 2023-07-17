## Installation
`npm i -D tailwindcss autoprefixer postcss @tailwindcss/forms @tailwindcss/typography daisyui`
`npx tailwind css init`

## Config
```js
/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./src/**/*.{html,ts}"
  ],
  theme: {
    extend: {},
  },
  plugins: [
    require('@tailwindcss/forms'),
    require('@tailwindcss/typography'),
    require('daisyui')
  ],
  daisyui: {
    themes: ["cyberpunk", "aqua", "cupcake"]
  }
}
```