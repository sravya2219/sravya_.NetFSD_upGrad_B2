----Create Database
CREATE DATABASE EventDb;


USE EventDb;


-- Table: UserInfo
CREATE TABLE UserInfo
(
    EmailId VARCHAR(100) PRIMARY KEY,
    UserName VARCHAR(50) NOT NULL CHECK(LEN(UserName) BETWEEN 1 AND 50),
    Role VARCHAR(20) NOT NULL CHECK (Role IN ('Admin', 'Participant')),
    Password VARCHAR(20) NOT NULL CHECK (LEN(Password) BETWEEN 6 AND 20)
);

--- Table: EventDetails
CREATE TABLE EventDetails
(
    EventId INT PRIMARY KEY IDENTITY(1,1),
    EventName VARCHAR(50) NOT NULL CHECK(LEN(EventName) BETWEEN 1 AND 50),
    EventCategory VARCHAR(50) NOT NULL CHECK(LEN(EventCategory) BETWEEN 1 AND 50),
    EventDate DATETIME NOT NULL,
    Description VARCHAR(500) NULL,
    Status VARCHAR(20) NOT NULL CHECK(Status IN ('Active', 'In-Active'))
);

-- Table: SpeakersDetails
CREATE TABLE SpeakersDetails
(
    SpeakerId INT PRIMARY KEY IDENTITY(1,1),
    SpeakerName VARCHAR(50) NOT NULL CHECK(LEN(SpeakerName) BETWEEN 1 AND 50)
);

--  Table: SessionInfo
CREATE TABLE SessionInfo
(
    SessionId INT PRIMARY KEY IDENTITY(1,1),
    EventId INT NOT NULL,
    SessionTitle VARCHAR(50) NOT NULL CHECK(LEN(SessionTitle) BETWEEN 1 AND 50),
    SpeakerId INT NOT NULL,
    Description VARCHAR(500) NULL,
    SessionStart DATETIME NOT NULL,
    SessionEnd DATETIME NOT NULL,
    SessionUrl VARCHAR(500) NULL,
    CONSTRAINT FK_Session_Event FOREIGN KEY (EventId) REFERENCES EventDetails(EventId),
    CONSTRAINT FK_Session_Speaker FOREIGN KEY (SpeakerId) REFERENCES SpeakersDetails(SpeakerId),
    CONSTRAINT CK_Session_Time CHECK (SessionEnd > SessionStart)
);


--  Table: ParticipantEventDetails
CREATE TABLE ParticipantEventDetails
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    ParticipantEmailId VARCHAR(100) NOT NULL,
    EventId INT NOT NULL,
    SessionId INT NOT NULL,
    IsAttended BIT NOT NULL,
    CONSTRAINT FK_Participant_User FOREIGN KEY (ParticipantEmailId) REFERENCES UserInfo(EmailId),
    CONSTRAINT FK_Participant_Event FOREIGN KEY (EventId) REFERENCES EventDetails(EventId),
    CONSTRAINT FK_Participant_Session FOREIGN KEY (SessionId) REFERENCES SessionInfo(SessionId),
    CONSTRAINT CK_IsAttended CHECK (IsAttended IN (0,1))
);