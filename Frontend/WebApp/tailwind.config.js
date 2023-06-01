/** @type {import('tailwindcss').Config} */
export default {
  content: [
    "./index.html",
    "./src/**/*.{js,ts,jsx,tsx}",
  ],
  theme: {
    extend: {
      height: {
        "screen-90": "90vh"
      },
      colors: {
        primary: "var(--primary)",
        secondary: "var(--secondary)"
      }
    },
  },
  plugins: [],
}

