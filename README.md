# HMSA-ProviderSearch-Test
This project serves as an example of simple test automation for a browser-based UI. We use the following toolsets:
* C# (the solution was created in Visual Studio 2015)
* Selenium
* SpecFlow
* NUnit

We use the [Page Object Pattern](https://martinfowler.com/bliki/PageObject.html) to encapsulate complexity around HTML element access. So far, we've created these page objects:
* [HomePage](https://github.com/jasonandersen/HMSA-ProviderSearch-Test/blob/master/DotCom/Pages/HomePage.cs)
* [ProviderSearchPage](https://github.com/jasonandersen/HMSA-ProviderSearch-Test/blob/master/DotCom/Pages/ProviderSearch/ProviderSearchPage.cs)
* [ProviderSearchResultsPage](https://github.com/jasonandersen/HMSA-ProviderSearch-Test/blob/master/DotCom/Pages/ProviderSearch/ProviderSearchResultsPage.cs)
* [HealthPlanSelectorPage](https://github.com/jasonandersen/HMSA-ProviderSearch-Test/blob/master/DotCom/Pages/ProviderSearch/HealthPlanSelectorPage.cs)
* [ProviderSearchResult](https://github.com/jasonandersen/HMSA-ProviderSearch-Test/blob/master/DotCom/Pages/ProviderSearch/ProviderSearchResult.cs) Note: this doesn't necessarily represent a page but a component on a page. The Page Object pattern still applies.
