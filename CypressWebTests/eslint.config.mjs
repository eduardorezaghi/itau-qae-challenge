// @ts-check

import eslint from '@eslint/js';
import tseslint from 'typescript-eslint';
import pluginCypress from 'eslint-plugin-cypress/flat';

export default tseslint.config(
  eslint.configs.recommended,
  ...tseslint.configs.recommended,
  pluginCypress.configs.recommended,
  {
    rules: {
      'cypress/no-unnecessary-waiting': 'error',
      'cypress/no-assigning-return-values': 'error',
      'cypress/assertion-before-screenshot': 'warn',
      'cypress/no-assertion-after-screenshot': 'warn',
    },
  }
);