@ProviderSearch
@HappyPath
Feature: Basic Provider Search
	As a current or prospective HMSA member
	I want basic search results for providers
	So that I don't have to browse the entire provider directory to choose a new provider
	
 Background: 
	Given I have this provider:
	    | Name			| Degree	| Specialty		|
		| Aaron K Nada	| MD		| Nephrology	|
	And the provider 'Aaron K Nada' accepts 'HMSA Akamai Advantage'
	And the provider 'Aaron K Nada' has the following locations:
		| Line 1				| Line 2		| City		| State | Zip	| Phone				|
		| 1520 Liliha St		| Suite 601		| Honolulu	| HI	| 96817	| (808) 523-0445	|
		| 98-211 Pali Momi St	| Suite 320		| Aiea		| HI	| 96701	| (808) 523-0445	|
		| 3-3295 Kuhio Hwy		|				| Lihue		| HI	| 96766	| (808) 245-8874	|


@HomePage
@Medicare
Scenario: Perform a provider search by navigating from the home page and validate first result
	Given I navigate to the home page
	And I select Find a Doctor
	When I search for 'nephrology' with this health plan: 'HMSA Akamai Advantage'
	Then I see my search query is 'nephrology' 
	And I see my plan is 'HMSA Akamai Advantage'
	And I see these provider search results:
		| Name            | Specialty  | Line 1								| City		| State | Zip		| Phone			 |
		| Aaron K Nada MD | Nephrology | 98-1247 Kaahumanu St , Suite 315	| Aiea		| HI	| 96701		| (808) 523-0445 |
		| Aaron K Nada MD | Nephrology | 4643B Waimea Canyon Dr				| Waimea	| HI	| 96796		| (808) 338-8311 |

@MultipleSpecialties
@Medicare
Scenario: Multiple specialties
	When I search for 'oncology' with this health plan: 'HMSA Akamai Advantage'
	Then the first result is:
		| Name				| Specialty				| Line 1						| City		| State | Zip		| Phone			 |
		| Jonathan K Cho MD	| Oncology/Hematology	| 1329 Lusitana St , Suite 307 	| Honolulu	| HI	| 96813		| (808) 524-6115 |
	
@Medicare
@GoogleMaps
Scenario: Link to a map of the providers address  
	Given I search for 'nephrology' with this health plan: 'HMSA Akamai Advantage'
	And the first result is:
		| Name            | Specialty  | Line 1						| City		| State | Zip		| Phone			 |
		| Aaron K Nada MD | Nephrology | 1520 Liliha St , Suite 601	| Honolulu	| HI	| 96817		| (808) 523-0445 |
	When I select Map on the first result
	Then I see a Google Maps page in a separate window for this address:
		| Address										|
		| 1520 Liliha St Suite 601, Honolulu HI, 98617	|
