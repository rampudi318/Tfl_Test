Feature: Plan a journey

The widget is accessible from the TFL Homepage or by clicking the “Plan a journey” tab from the homepage.  

@tag1
Scenario: A valid journey will consist of a valid locations entered into the widget page 
	Given Navigate The widget TFL Homepage 
	And click the "Plan a journey” tab from the homepage 
	When I enter the valid From address and valid TO address
	Then it is shown a valid journey can be planne on widget page
	
@tag2
Scenario: A valid journey will consist of a invalid locations entered into the widget page 
	Given Navigate The widget TFL Homepage 
	And click the "Plan a journey” tab from the homepage 
	When I enter the invalid From address and valid TO address
	Then it is shown a invalid journey can be planne on widget page
