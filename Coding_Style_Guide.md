# Coding Style Guide

This guide is largely based on the Google C# and HTML Style Guide. For questions without answers on this document, please refer to the Google Style Guide, or if unclear reference the project team as a whole. Unless the project is complete, this file will remain incomplete.

## Code

- Program will be adapted from the base framework for Blazor Webapp in the JetBrains Rider IDE
- Break long lines, greater than 150 characters whenever possible
  - If impossible, consider revisiting with different syntax

### C#

- Classes, methods, interfaces, and variables should be named using Pascal Case
- Begin class names with C
- Begin interface names with I
- Begin method names with M // MAYBE NOT?
- Namespace 'using' implementation should be ordered alphabetically except for 'System' or at need
  - Exceptions should be explained with a comment

### HTML

- Implement <!DOCTYPE html> on all html documents
- Use lowercase for all html syntax
- Attempt to omit optional tags for readability
  - Some may remain on need
- Use double quotations when possible

### CSS

- Integrating *Bootstrap* CSS

## Files

- File names should be named using Pascal Case
- Class file names should match the class name

## Indentation

- Use two space // MAYBE NOT?

## Comments

- Explain on demand
- Always explain large sections of code
- Always explain small code that is complex or unclear

## Multimedia Fallback

- Provide an alternative for any images in case of load failure