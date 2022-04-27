# LABB 4

## INDTRODUCTION
This is a school assignment for my school work. The assignment was to create a simple web-API with REST.  

## API CALLS
Get all people in the system [GET]
- https://localhost:44363/api/person

Get all interests connected to a specific person [GET]
- https://localhost:44363/api/interest/person2
- To change person write another id ".../person[id]

Get all links connected to a specific person [GET]
- https://localhost:44363/api/website/person2
- To change person write another id ".../person[id]

Connect a person to a new interest [POST]
- https://localhost:44363/api/interest/person2
- To change person write another id ".../person[id]
- In the body select raw and JSON. And add new interest with the code:
  {
        "interestName": "Interest name",
        "description": "Interest description5"
  }

Add new links for a specific person and a specific interest [POST]
- https://localhost:44363/api/website/person3interest16
- To change person or interest write another id ".../person[id]interest[id]
- In the body select raw and JSON. And add new interest with the code:
  {
        "linkDescription": "Link description",
        "link": "link to website"
  }
