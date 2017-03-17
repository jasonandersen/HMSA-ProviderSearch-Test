# HMSA-ProviderSearch-Test
This project serves as an example of simple test automation for a browser-based UI. For these tests, we are going to test the HMSA.com provider search feature. In order to create the tests, we use the following toolsets:
* C# (the solution was created in Visual Studio 2015)
* Selenium
* SpecFlow
* NUnit

We use the [Page Object Pattern](https://martinfowler.com/bliki/PageObject.html) to encapsulate complexity around HTML element access. So far, we've created these page objects:
* [HomePage](https://github.com/jasonandersen/HMSA-ProviderSearch-Test/blob/master/DotCom/Pages/HomePage.cs) HMSA.com.
* [ProviderSearchPage](https://github.com/jasonandersen/HMSA-ProviderSearch-Test/blob/master/DotCom/Pages/ProviderSearch/ProviderSearchPage.cs) The Find-a-Doctor page.
* [ProviderSearchResultsPage](https://github.com/jasonandersen/HMSA-ProviderSearch-Test/blob/master/DotCom/Pages/ProviderSearch/ProviderSearchResultsPage.cs) The page returned after a provider search has been executed.
* [HealthPlanSelectorPage](https://github.com/jasonandersen/HMSA-ProviderSearch-Test/blob/master/DotCom/Pages/ProviderSearch/HealthPlanSelectorPage.cs) The page that allows a user to specify an individual plan.
* [ProviderSearchResult](https://github.com/jasonandersen/HMSA-ProviderSearch-Test/blob/master/DotCom/Pages/ProviderSearch/ProviderSearchResult.cs) A single provider search result. This doesn't necessarily represent a page but a component on a page. The Page Object pattern still applies.

The tests are built using [Behavior Driven Development](https://www.agilealliance.org/glossary/bdd/). Specifically, we use the BDD tool [SpecFlow](http://specflow.org/) to bind business requirements to automated tests. The BDD tests right now are located in this file:
* [BasicProviderSearch.feature](https://github.com/jasonandersen/HMSA-ProviderSearch-Test/blob/master/DotCom/Specs/ProviderSearch/BasicProviderSearch.feature)

The glue code (C# code that automates the tests) is currently located in this C# class:
* [ProviderSearchSteps.cs](https://github.com/jasonandersen/HMSA-ProviderSearch-Test/blob/master/DotCom/Specs/ProviderSearch/ProviderSearchSteps.cs)
