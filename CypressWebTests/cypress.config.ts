/* eslint-disable @typescript-eslint/no-unused-vars */
import { defineConfig } from "cypress";
import viteProcessor from "cypress-vite";

export default defineConfig({
  e2e: {
    baseUrl: "https://ultimateqa.com/automation",
    pageLoadTimeout: 10000,
    testIsolation: true,
    video: false,
    screenshotOnRunFailure: false,
    setupNodeEvents(on, config) {
      on('file:preprocessor', viteProcessor())
    },
  },
});
