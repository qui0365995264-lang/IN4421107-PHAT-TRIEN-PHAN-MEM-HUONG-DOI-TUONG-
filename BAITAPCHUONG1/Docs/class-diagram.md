
# Class Diagram — EduHub

```mermaid
classDiagram
    class Member {
        -Guid Id
        -string Name
        -string Email
        -string StudentCode
        -DateTime JoinedAt
        +bool IsActive()
        +Create() Member
    }

    class Club {
        -Guid Id
        -string Name
        -string Description
        -DateTime CreatedAt
        +AddMember(Member) void
        +MemberCount() int
    }

    class Event {
        -Guid Id
        -Guid ClubId
        -string Title
        -DateTime Date
        -int Capacity
        -bool IsOnline
        +HasCapacity(int) bool
    }

    class Registration {
        -Guid Id
        -Guid MemberId
        -Guid EventId
        -DateTime RegisteredAt
        -RegistrationStatus Status
        +Confirm() void
        +Cancel() void
    }

    class CheckIn {
        -Guid Id
        -Guid RegistrationId
        -DateTime CheckedInAt
        -string Method
        +Summary() string
    }

    Club "1" --> "0..*" Member : manages
    Club "1" --> "0..*" Event : organizes
    Member "1" --> "0..*" Registration : registers
    Event "1" --> "0..*" Registration : receives
    Registration "1" --> "0..1" CheckIn : records
