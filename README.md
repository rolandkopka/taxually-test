# Taxually technical test

This solution contains an [API endpoint](https://github.com/Taxually/developer-test/blob/main/Taxually.TechnicalTest/Taxually.TechnicalTest/Controllers/VatRegistrationController.cs) to register a company for a VAT number. Different approaches are required based on the country where the company is based:

- UK companies can register via an API
- French companies must upload a CSV file
- German companies must upload an XML document

We'd like you to refactor the existing solution with the following in mind:

- Readability
- Testability
- Adherance to SOLID principles

We'd also like you to add some tests to show us how you'd test your solution, although we aren't expecting exhaustive test coverage.

We don't expect you to implement the classes for making HTTP calls and putting messages on queues.

We'd like you to spend not more than a few hours on the exercise.

To develop and submit your solution please follow these steps:

1. Create a public repo in your own GitHub account and push the technical test there
2. Develop your solution and push your changes to your own public GitHub repo
3. Once you're happy with your solution send us a link to your repo

---

## Solution

- .Wait() is blocking thread, so I replaced it with async/await
- Created IVatRegistrationService and separate services for each country. This has a few benefits:
  - Each service is responsible for a single country (Single Responsibility Principle)
  - If we need to add a new country, we can do it without modifying existing code (Open/Closed Principle)
  - We can easily test each service in isolation
  - Readability is improved
- Upgrade to .NET 8
  - Latest LTS version
  - Simple to upgrade
  - More features
  - Better performance
- Primary constructor for less code