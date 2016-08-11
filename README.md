# BAChallenge .NET Web Services
***

### Usable Routes (Case Insensitive)

(X) marks that the user has to be authorized.

1. GET
..* .../api/Activity
..* .../api/Activity/{id}
..* .../api/Activity?date="insertdatehere"
..* .../api/Activity?location="insertlocationhere"
..* .../api/Activity?branch="insertbranchhere"
..* .../api/Participant
..* .../api/Participant/{id}
..* .../api/Result
..* .../api/Result/{id}
..* .../api/ActivityParticipant
..* .../api/ActivityParticipant/{id}
..* .../api/ExcelExport/{id}
2. POST
..* .../api/Activity (X)
..* .../api/Participant (X)
..* .../api/ActivityParticipant (X)
..* .../api/Result (X)
..* .../api/Admin (X)
..* .../api/Token
3. PUT
..* .../api/Activity/{id} (X)
..* .../api/Participant/{id} (X)
..* .../api/ActivityParticipant/{activityId}/{participantId} (X)
..* .../api/Result/{id} (X)
..* .../api/Admin/{id} (X)
4. DELETE
..* .../api/Activity/{id} (X)
..* .../api/Participant/{id} (X)
..* .../api/ActivityParticipant/{activityId}/{participantId} (X)
..* .../api/Result/{id} (X)
..* .../api/Admin/{id} (X)

