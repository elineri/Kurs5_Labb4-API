# LABB 4
***Version 1.0.0***

## INDTRODUCTION
This is a school assignment for my school work. 

## API CALLS
Get all people in the system
- https://localhost:44363/api/person

Get all interests connected to a specific person 
- https://localhost:44363/api/interest/person2
- To change person write another id ".../person[id]

Get all links connected to a specific person
- https://localhost:44363/api/website/person2
- To change person write another id ".../person[id]

Connect a person to a new interest
- https://localhost:44363/api/interest/person2
- To change person write another id ".../person[id]
- In the body select raw and JSON. And add new interest with the code below:
  {
        "interestName": "Test5",
        "description": "Test description5"
  }

Add new links for a specific person and a specific interest
- To be added
