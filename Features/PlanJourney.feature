Feature: Plan a journey

The widget is accessible from the TFL Homepage or by clicking the “Plan a journey” tab from the homepage.  

@tag1
Scenario: A valid journey will consist of a valid locations entered into the widget page 
	Given Navigate The widget TFL Homepage 
	And click the "Plan a journey” tab from the homepage 
	When I enter the valid From address and valid TO address
	Then it is shown a valid journey can be planne on widget page
	
@tag2
Scenario: Invaid journey will consist of a invalid locations 
	Given Navigate The widget TFL Homepage 
	And click the "Plan a journey” tab from the homepage 
	When I enter the invalid From address and valid TO address
	Then it is shown a invalid journey can be planned on widget page with a message "Sorry, we can't find a journey matching your criteria"

@tag3
Scenario: unable to plan a journey if no locations are entered into the widget 
	Given Navigate The widget TFL Homepage 
	And click the "Plan a journey” tab from the homepage 
	When I not enter  From and To address click the journey
	Then user should see from field validation message "The From field is required."
	And user should see To filed validation message "The To field is required."
@tag4
Scenario: A valid journey and valid locations and edit journey 
	Given Navigate The widget TFL Homepage 
	And click the "Plan a journey” tab from the homepage 
	When I enter the valid From address and valid TO address
	And journey can be amended by using the “Edit Journey” button
	And entert the valid differnt values and update journey	
	Then it is shown a valid journey can be updateon Edit page and shown results "Discover quieter times to travel."
@tag5
Scenario:Verify “Recents” tab on the widget displays and list of recently planned journeys
	Given Navigate The widget TFL Homepage 
	And click the "Plan a journey” tab from the homepage 
	When I click the Recent button it will show the recent journeys
    Then I will find the recent journey details.
