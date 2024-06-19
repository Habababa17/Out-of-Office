-- Create the database
--CREATE DATABASE SimpleOfficeDB;
GO

-- Use the newly created database
USE SimpleOfficeDB;
GO

-- Create the Subdivision table with INT identity column
CREATE TABLE Subdivision (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(255) NOT NULL
);

-- Insert data into the Subdivision table
INSERT INTO Subdivision (Name) VALUES 
('Subdivision 1'),
('Subdivision 2');

-- Create the Position table
CREATE TABLE Position (
    ID INT PRIMARY KEY IDENTITY,
    PositionName VARCHAR(255) NOT NULL
);

-- Insert data into the Position table
INSERT INTO Position (PositionName) VALUES 
('HR Manager'),
('Project Manager'),
('Employee');

-- Create the Status table with identity column
CREATE TABLE Status (
    ID INT PRIMARY KEY IDENTITY,
    StatusName VARCHAR(255) NOT NULL
);

-- Insert data into the Status table
INSERT INTO Status (StatusName) VALUES 
('Active'),
('Inactive');


-- Create the Employee table
CREATE TABLE Employee (
    ID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    FullName VARCHAR(255) NOT NULL,
    Subdivision INT NOT NULL,
    Position INT NOT NULL,
    Status INT NOT NULL,
    PeoplePartner UNIQUEIDENTIFIER, -- doesn't have NOT NULL to allow creation of HR managers with null value,
								    -- other cases are sovled by trigger
    OutOfOfficeBalance INT NOT NULL,
    Photo VARBINARY(MAX),
    CONSTRAINT FK_Subdivision FOREIGN KEY (Subdivision) REFERENCES Subdivision(ID),
    CONSTRAINT FK_Position FOREIGN KEY (Position) REFERENCES Position(ID),
    CONSTRAINT FK_PeoplePartner FOREIGN KEY (PeoplePartner) REFERENCES Employee(ID),
	CONSTRAINT FK_EmployeeStatus FOREIGN KEY (Status) REFERENCES Status(ID),
	CONSTRAINT CHK_PeoplePartner CHECK (
    (Position = 1) OR 
    (Position != 1 AND PeoplePartner IS NOT NULL)
)
);
GO
-- trigger for employees
CREATE OR ALTER TRIGGER trg_EnforcePeoplePartner
ON Employee
INSTEAD OF INSERT, UPDATE
AS
BEGIN
    --Ensure People Partner has the correct position
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN Employee e ON i.PeoplePartner = e.ID
        WHERE e.Position != 1 AND i.Position != 1 
    )
    BEGIN
        RAISERROR('People Partner must have Position HR manager.', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END;

	--Ensure Balance is not < 1
    IF EXISTS (
        SELECT 1
        FROM inserted i
        WHERE i.OutOfOfficeBalance < 1 
    )
    BEGIN
        RAISERROR('Not enough Balance.', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END;

    --insert or update
    IF EXISTS (SELECT 1 FROM inserted)
    BEGIN
        -- Update existing rows
        UPDATE Employee
        SET FullName = i.FullName,
            OutOfOfficeBalance = i.OutOfOfficeBalance,
            PeoplePartner = i.PeoplePartner,
            Photo = i.Photo,
            Position = i.Position,
            Status = i.Status,
            Subdivision = i.Subdivision
        FROM inserted i
        WHERE Employee.ID = i.ID;
        
        -- Insert new rows
        INSERT INTO Employee (ID, FullName, OutOfOfficeBalance, PeoplePartner, Photo, Position, Status, Subdivision)
        SELECT i.ID, i.FullName, i.OutOfOfficeBalance, i.PeoplePartner, i.Photo, i.Position, i.Status, i.Subdivision
        FROM inserted i
        WHERE NOT EXISTS (
            SELECT 1
            FROM Employee e
            WHERE e.ID = i.ID
        );
    END;
END;
GO

-- Create the AbsenceReason table
CREATE TABLE AbsenceReason (
    ID INT PRIMARY KEY IDENTITY,
    Reason VARCHAR(255) NOT NULL
);

-- Insert sample data into the AbsenceReason table
INSERT INTO AbsenceReason (Reason) VALUES 
('Vacation'),
('Sick Leave');

CREATE TABLE SubmitState (
    ID INT PRIMARY KEY IDENTITY,
    StateName VARCHAR(50) NOT NULL
);

-- Insert data into the SubmitState table
INSERT INTO SubmitState (StateName) VALUES 
('New'),
('Submitted'),
('Canceled'),
('Accepted'),
('Denied');


-- Create the LeaveRequest table
CREATE TABLE LeaveRequest (
    ID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Employee UNIQUEIDENTIFIER,
    AbsenceReason INT NOT NULL,
    StartDate DATE NOT NULL,
    EndDate DATE NOT NULL,
    Comment TEXT,
    Status INT NOT NULL,
    CONSTRAINT FK_Employee FOREIGN KEY (Employee) REFERENCES Employee(ID),
    CONSTRAINT FK_AbsenceReason FOREIGN KEY (AbsenceReason) REFERENCES AbsenceReason(ID),
	CONSTRAINT FK_Status FOREIGN KEY (Status) REFERENCES SubmitState(ID)
);

-- Create the ApprovalRequest table
CREATE TABLE ApprovalRequest (
    ID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Approver UNIQUEIDENTIFIER NOT NULL,
    LeaveRequest UNIQUEIDENTIFIER NOT NULL,
    Status INT NOT NULL,
    Comment TEXT,
	CONSTRAINT FK_StatusAR FOREIGN KEY (Status) REFERENCES SubmitState(ID),
    CONSTRAINT FK_Approver FOREIGN KEY (Approver) REFERENCES Employee(ID),
    CONSTRAINT FK_LeaveRequest FOREIGN KEY (LeaveRequest) REFERENCES LeaveRequest(ID)
);

-- Create the ProjectType table with adjusted columns
CREATE TABLE ProjectType (
    ID INT PRIMARY KEY IDENTITY,
    TypeName VARCHAR(255) NOT NULL
);

-- Insert sample data into the ProjectType table
INSERT INTO ProjectType (TypeName) VALUES 
('Internal'),
('External');

-- Create the Project table
CREATE TABLE Project (
    ID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
	ProjectName VARCHAR(250),
    ProjectType INT NOT NULL,
    StartDate DATE NOT NULL,
    EndDate DATE,
    ProjectManager UNIQUEIDENTIFIER NOT NULL,
    Comment VARCHAR(250),
    Status INT NOT NULL,
	CONSTRAINT FK_ProjectStatus FOREIGN KEY (Status) REFERENCES Status(ID),
    CONSTRAINT FK_ProjectType FOREIGN KEY (ProjectType) REFERENCES ProjectType(ID),
    CONSTRAINT FK_ProjectManager FOREIGN KEY (ProjectManager) REFERENCES Employee(ID)
);

CREATE TABLE EmployeeProjectAssignment (
    EmployeeID UNIQUEIDENTIFIER NOT NULL,
    ProjectID UNIQUEIDENTIFIER NOT NULL,
    PRIMARY KEY (EmployeeID, ProjectID),
    CONSTRAINT FK_EmployeeProjectAssignment_Employee FOREIGN KEY (EmployeeID) 
        REFERENCES Employee(ID) ON DELETE CASCADE,
    CONSTRAINT FK_EmployeeProjectAssignment_Project FOREIGN KEY (ProjectID) 
        REFERENCES Project(ID) ON DELETE CASCADE
);

GO

-- Create the triggers

-- Trigger for ApprovalRequest
CREATE OR ALTER TRIGGER trg_AllowedToApprove
ON ApprovalRequest
INSTEAD OF INSERT, UPDATE
AS
BEGIN
    -- Ensure no violation of approval rules
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN LeaveRequest lr ON i.LeaveRequest = lr.ID
        JOIN Employee requester ON lr.Employee = requester.ID
        JOIN Employee approver ON i.Approver = approver.ID
        JOIN EmployeeProjectAssignment epa ON requester.ID = epa.EmployeeID
        JOIN Project p ON epa.ProjectID = p.ID 
        WHERE approver.Position != 1 AND (requester.Position != 3 OR approver.ID != p.ProjectManager)
    )
    BEGIN
        RAISERROR('Only employees with higher position can approve/deny leave requests.', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END;

    -- If no issues, proceed with the insert or update into ApprovalRequest
    IF EXISTS (SELECT 1 FROM inserted)
    BEGIN
        -- Update existing rows
        UPDATE ApprovalRequest
        SET Approver = i.Approver,
            LeaveRequest = i.LeaveRequest,
            Status = i.Status,
            Comment = i.Comment
        FROM inserted i
        WHERE ApprovalRequest.ID = i.ID;
        
        -- Insert new rows
        INSERT INTO ApprovalRequest (ID, Approver, LeaveRequest, Status, Comment)
        SELECT i.ID, i.Approver, i.LeaveRequest, i.Status, i.Comment
        FROM inserted i
        WHERE NOT EXISTS (
            SELECT 1
            FROM ApprovalRequest ar
            WHERE ar.ID = i.ID
        );
    END;
END;
GO

-- Trigger for Project
CREATE OR ALTER TRIGGER trg_ProjectManagerPosition
ON Project
INSTEAD OF INSERT, UPDATE
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN Employee e ON i.ProjectManager = e.ID
        JOIN Position p ON e.Position = p.ID
        WHERE p.ID != 2
    )
    BEGIN
        RAISERROR('Only employees with Position = Project Manager can be assigned as Project Manager.', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END;

    -- If no issues, proceed with the insert/update into Project
	    IF EXISTS (SELECT 1 FROM inserted) -- Check if there are rows to process
    BEGIN
        -- Update existing rows
        UPDATE p
        SET ProjectName = i.ProjectName,
            ProjectType = i.ProjectType,
            StartDate = i.StartDate,
            EndDate = i.EndDate,
            ProjectManager = i.ProjectManager,
            Comment = i.Comment,
            Status = i.Status
        FROM Project p
        JOIN inserted i ON p.ID = i.ID;


    INSERT INTO Project (ID, ProjectName, ProjectType, StartDate, EndDate, ProjectManager, Comment, Status)
    SELECT i.ID, i.ProjectName, i.ProjectType, i.StartDate, i.EndDate, i.ProjectManager, i.Comment, i.Status
    FROM inserted i;
	END;
END;
GO
-- Populate the Data

-- Inserting example Employees
INSERT INTO Employee (ID, FullName, Subdivision, Position, Status, PeoplePartner, OutOfOfficeBalance, Photo)
VALUES
(NEWID(), 'John Doe', (SELECT ID FROM Subdivision WHERE Name = 'Subdivision 1'), 1, (SELECT ID FROM Status WHERE StatusName = 'Active'), NULL, 20, NULL),
(NEWID(), 'Jane Smith', (SELECT ID FROM Subdivision WHERE Name = 'Subdivision 2'), (SELECT ID FROM Position WHERE PositionName = 'HR Manager'), (SELECT ID FROM Status WHERE StatusName = 'Active'), NULL, 15, NULL);
INSERT INTO Employee (ID, FullName, Subdivision, Position, Status, PeoplePartner, OutOfOfficeBalance, Photo)
VALUES
(NEWID(), 'Mike Johnson', (SELECT ID FROM Subdivision WHERE Name = 'Subdivision 1'), (SELECT ID FROM Position WHERE PositionName = 'Project Manager'), (SELECT ID FROM Status WHERE StatusName = 'Active'), (SELECT TOP 1 ID FROM Employee WHERE Position = 1), 18, NULL),
(NEWID(), 'Emily Brown', (SELECT ID FROM Subdivision WHERE Name = 'Subdivision 2'), (SELECT ID FROM Position WHERE PositionName = 'Project Manager'), (SELECT ID FROM Status WHERE StatusName = 'Active'), (SELECT TOP 1 ID FROM Employee WHERE Position = 1), 16, NULL),
(NEWID(), 'Michael Williams', (SELECT ID FROM Subdivision WHERE Name = 'Subdivision 1'), (SELECT ID FROM Position WHERE PositionName = 'Employee'), (SELECT ID FROM Status WHERE StatusName = 'Active'), (SELECT TOP 1 ID FROM Employee WHERE Position = 1), 22, NULL),
(NEWID(), 'Jessica Miller', (SELECT ID FROM Subdivision WHERE Name = 'Subdivision 1'), (SELECT ID FROM Position WHERE PositionName = 'Employee'), (SELECT ID FROM Status WHERE StatusName = 'Inactive'), (SELECT TOP 1 ID FROM Employee WHERE Position = 1), 19, NULL),
(NEWID(), 'David Davis', (SELECT ID FROM Subdivision WHERE Name = 'Subdivision 2'), (SELECT ID FROM Position WHERE PositionName = 'Employee'), (SELECT ID FROM Status WHERE StatusName = 'Active'), (SELECT TOP 1 ID FROM Employee WHERE Position = 1), 17, NULL);

INSERT INTO Project (ID, ProjectName, ProjectType, StartDate, EndDate, ProjectManager, Comment, Status)
VALUES
(NEWID(), 'Project 1', (SELECT ID FROM ProjectType WHERE TypeName = 'Internal'), '2024-07-01', '2024-12-31', (SELECT ID FROM Employee WHERE FullName = 'Emily Brown'), 'Internal project for department restructuring',  (SELECT ID FROM Status WHERE StatusName = 'Active')),
(NEWID(), 'Project 2', (SELECT ID FROM ProjectType WHERE TypeName = 'External'), '2024-08-15', '2024-09-30', (SELECT ID FROM Employee WHERE FullName = 'Mike Johnson'), 'External project with client X', (SELECT ID FROM Status WHERE StatusName = 'Active')),
(NEWID(), 'Project 3', (SELECT ID FROM ProjectType WHERE TypeName = 'Internal'), '2024-07-15', '2024-10-31', (SELECT ID FROM Employee WHERE FullName = 'Mike Johnson'), 'Internal project for new product development', (SELECT ID FROM Status WHERE StatusName = 'Inactive'));

-- Inserting example Projects Assignments
INSERT INTO EmployeeProjectAssignment (EmployeeID, ProjectID)
VALUES
    ((SELECT ID FROM Employee WHERE FullName = 'Michael Williams'), 
     (SELECT ID FROM Project WHERE Comment = 'Internal project for department restructuring')),
    ((SELECT ID FROM Employee WHERE FullName = 'Jessica Miller'), 
     (SELECT ID FROM Project WHERE Comment = 'Internal project for department restructuring')),
    ((SELECT ID FROM Employee WHERE FullName = 'David Davis'), 
     (SELECT ID FROM Project WHERE Comment = 'External project with client X'));



USE SimpleOfficeDB;
GO
SELECT * FROM Employee;
Select * FROM Project;
Select * FROM EmployeeProjectAssignment;
Select * FROM LeaveRequest;
SELECT * FROM Status;

