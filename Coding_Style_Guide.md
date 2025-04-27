# Coding Style Guide

This guide is largely based on the base Blazor C# and HTML Style Guide. For questions without answers on this document, please refer to the Blazor documentation, Bootstrap documentation, or if unclear reference the project team as a whole. Unless the project is complete, this file will remain subject to change.

## Code

- Program will be adapted from the base framework for Blazor Webapp in the JetBrains Rider IDE
- Break long lines, greater than 150 characters whenever possible
  - If impossible, consider revisiting with different syntax
### Spaces
- Use hyphen (-) for space between names when appropriate
### C#

- Variables should be named using Pascal Case
- Namespace 'using' implementation should be ordered alphabetically except for 'System' or at need
  - Exceptions should be explained with a comment

### HTML
- Attempt to omit optional tags for readability
  - Some may remain on need
- Use double quotations when possible

### CSS

- Integrating *Bootstrap* CSS
- Default naming conventions to match Bootstrap
- Incorporate as much html styling through bootstrap.css 

## Files

- Component file names should be named using Pascal Case
- C# Class file names should match the class name

## Indentation

- Use Tab indentation

## Comments

- Explain on demand
- Always explain large sections of code
- Always explain small code that is complex or unclear

## Multimedia Fallback

- Provide an alternative for any images in case of load failure
